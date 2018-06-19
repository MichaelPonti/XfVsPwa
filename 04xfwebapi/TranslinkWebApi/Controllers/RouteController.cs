using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TranslinkWebApi.Controllers
{
	[Route("api/routes")]
	public class RouteController : Controller
	{
		private IConfigurationRoot _configuration = null;
		private HttpClient _client = null;


		public RouteController(IConfigurationRoot configuration)
		{
			_configuration = configuration;
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


		[HttpGet("{routeNo}")]
		public async Task<List<Route>> GetRoutesAsync(string routeNo)
		{
			string url = this.GetBaseUrl() +
				"routes/" + this.UrlEncode(routeNo) +
				"?apikey=" + this.GetTranslinkApiKey(_configuration);

			using (var request = this.CreateRequest(url))
			using (var response = await _client.SendAsync(request))
			{
				return await this.ReadResponseContentAsync<List<Route>>(response);
			}
		}
	}
}
