using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Translink.Models;

namespace TranslinkWebApi.Controllers
{
	[Route("api/stops")]
	public class StopsController : Controller
	{
		private IConfigurationRoot _configuration = null;
		private HttpClient _client = null;

		public StopsController(IConfigurationRoot configurationRoot)
		{
			_configuration = configurationRoot;
			_client = this.CreateHttpClient();
		}



		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (_client != null)
				{
					_client.Dispose();
					_client = null;
				}
			}

			base.Dispose(disposing);
		}



		[HttpGet("{latitude}/{longitude}/{radius}")]
		public async Task<List<Stop>> GetStopsAsync(double latitude, double longitude, double radius)
		{
			string url = this.GetBaseUrl() +
				"stops?apikey=" + this.GetTranslinkApiKey(_configuration) +
				"&lat=" + this.UrlEncodeCoords(latitude) +
				"&long=" + this.UrlEncodeCoords(longitude) +
				"&radius=" + this.UrlEncode(radius);

			try
			{
				using (var request = this.CreateRequest(url))
				using (var response = await _client.SendAsync(request))
				{
					return await this.ReadResponseContentAsync<List<Stop>>(response);
				}
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine(e.ToString());
			}

			return new List<Stop>();
		}
	}
}
