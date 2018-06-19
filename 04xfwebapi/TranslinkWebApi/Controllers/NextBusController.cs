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
	[Route("api/nextbus")]
	public class NextBusController : Controller
	{
		private IConfigurationRoot _configuration = null;
		private HttpClient _client = null;

		public NextBusController(IConfigurationRoot configuration)
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


		[HttpGet("{stopId}/{count}/{timeframe}")]
		public async Task<List<NextBus>> GetNextBusesAsync(string stopId, string count, string timeframe)
		{
			string url = this.GetBaseUrl() +
				"stops/" + this.UrlEncode(stopId) +
				"/estimates?apikey=" + this.GetTranslinkApiKey(_configuration) +
				"&count=" + this.UrlEncode(count) +
				"&timeframe=" + this.UrlEncode(timeframe);

			using (var request = this.CreateRequest(url))
			using (var response = await _client.SendAsync(request))
			{
				return await this.ReadResponseContentAsync<List<NextBus>>(response);
			}
		}
	}
}
