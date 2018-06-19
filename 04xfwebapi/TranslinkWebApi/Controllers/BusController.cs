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
	[Route("api/bus")]
	public class BusController : Controller
	{
		private IConfigurationRoot _configuration = null;
		private HttpClient _client = null;

		public BusController(IConfigurationRoot configuration)
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


		[HttpGet("{id}")]
		public async Task<Bus> GetAsync(string id)
		{
			string url = this.GetBaseUrl() +
				"buses/" + this.UrlEncode(id) +
				"?apikey=" + this.GetTranslinkApiKey(_configuration);

			using (var request = this.CreateRequest(url))
			using (var response = await _client.SendAsync(request))
			{
				return await this.ReadResponseContentAsync<Bus>(response);
			}
		}


		[HttpGet("buses/{route}")]
		public async Task<List<Bus>> GetBusesForRouteAsync(string route)
		{
			string url = this.GetBaseUrl() +
				"buses?apikey=" + this.GetTranslinkApiKey(_configuration) +
				"&routeNo=" + this.UrlEncode(route);

			using (var request = this.CreateRequest(url))
			using (var response = await _client.SendAsync(request))
			{
				return await this.ReadResponseContentAsync<List<Bus>>(response);
			}
		}
	}
}
