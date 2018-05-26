using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mvb.Services.Translink
{
	public class TranslinkService : ITranslinkService
	{
		private string _apiKey = null;
		private HttpClient _client = null;


		public TranslinkService(string apiKey)
		{
			_apiKey = apiKey;
			_client = new HttpClient();
			_client.DefaultRequestHeaders.Clear();
		}


		#region helpers

		private string UrlEncode(string s)
		{
			return WebUtility.UrlEncode(s);
		}


		private string UrlEncode(int i)
		{
			return WebUtility.UrlEncode(i.ToString());
		}

		private string UrlEncodeCoords(double d)
		{
			return WebUtility.UrlEncode($"{d:0.00000}");
		}

		private string UrlEncode(double d)
		{
			return WebUtility.UrlEncode(d.ToString());
		}



		private T Deserialize<T>(string s)
		{
			return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(s);
		}


		private HttpRequestMessage CreateRequest(string url, HttpMethod method = null)
		{
			HttpRequestMessage r = new HttpRequestMessage(method ?? HttpMethod.Get, url);
			r.Headers.Clear();
			r.Content = null;
			r.Properties.Clear();
			r.Headers.Accept.Clear();
			r.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
			return r;
		}

		private async Task<T> ReadResponseContentAsync<T>(HttpResponseMessage response) where T : class
		{
			if (response.IsSuccessStatusCode)
			{
				var s = await response.Content.ReadAsStringAsync();
				var ret = Deserialize<T>(s);
				return ret;
			}

			return null;
		}

		#endregion



		public async Task<Bus> GetBusDetailsAsync(string busId)
		{
			string url = String.Format("http://api.translink.ca/rttiapi/v1/buses/{0}?apikey={1}", UrlEncode(busId), _apiKey);
			using (var request = CreateRequest(url))
			using (var response = await _client.SendAsync(request))
			{
				return await ReadResponseContentAsync<Bus>(response);
			}
		}

		public Task<List<Bus>> GetBusesForRouteAndStopAsync(string stopNo, string routeNo)
		{
			throw new NotImplementedException();
		}

		public async Task<List<Bus>> GetBusesForRouteAsync(string routeNo)
		{
			string url = String.Format("http://api.translink.ca/rttiapi/v1/buses?apikey={0}&routeNo={1}", _apiKey, UrlEncode(routeNo));
			using (var request = CreateRequest(url))
			using (var response = await _client.SendAsync(request))
			{
				return await ReadResponseContentAsync<List<Bus>>(response);
			}
		}

		public Task<List<Bus>> GetBusesForStopAsync(string stopNo)
		{
			throw new NotImplementedException();
		}


		private bool _isGetNextBusEstimatesBusy = false;

		public async Task<List<NextBus>> GetNextBusEstimatesAsync(string stopId, int count = 6, int timeFrame = 1440, string routeNo = null)
		{
			if (_isGetNextBusEstimatesBusy)
				return null;

			_isGetNextBusEstimatesBusy = true;

			List<NextBus> ret = null;

			string url = String.Format(
				"http://api.translink.ca/rttiapi/v1/stops/{0}/estimates?apikey={1}&count={2}&timeframe={3}",
				UrlEncode(stopId),
				_apiKey,
				UrlEncode(count.ToString()),
				UrlEncode(timeFrame.ToString()));

			if (!String.IsNullOrWhiteSpace(routeNo))
			{
				url += String.Format("&routeNo={0}", UrlEncode(routeNo));
			}

			try
			{
				using (var request = CreateRequest(url))
				using (var response = await _client.SendAsync(request))
				{
					ret = await ReadResponseContentAsync<List<NextBus>>(response);
					if (ret != null)
					{
						Debug.WriteLine(ret.ToString());
					}
				}
			}
			catch (Exception e)
			{
				ret = null;
				Debug.WriteLine(e.ToString());
			}


			_isGetNextBusEstimatesBusy = false;
			return ret;
		}

		public Task<Stop> GetStopAsync(string id)
		{
			throw new NotImplementedException();
		}

		private bool _isGetStopsAsyncBusy = false;

		public async Task<List<Stop>> GetStopsAsync(double latitude, double longitude, int radius = 500, string routeNo = null)
		{
			if (_isGetStopsAsyncBusy)
				return null;

			_isGetStopsAsyncBusy = true;

			string url = String.Format(
				"http://api.translink.ca/rttiapi/v1/stops?apikey={0}&lat={1}&long={2}&radius={3}",
				_apiKey,
				UrlEncode(latitude.ToString("0.000000")),
				UrlEncode(longitude.ToString("0.000000")),
				UrlEncode(radius));

			if (!String.IsNullOrWhiteSpace(routeNo))
			{
				url += String.Format("&routeNo={0}", UrlEncode(routeNo));
			}


			List<Stop> ret = null;

			try
			{
				using (var request = CreateRequest(url))
				using (var response = await _client.SendAsync(request))
				{
					_isGetStopsAsyncBusy = true;
					ret = await ReadResponseContentAsync<List<Stop>>(response);
				}
			}
			catch (Exception e)
			{
				ret = null;
				Debug.WriteLine(e.ToString());
			}

			_isGetStopsAsyncBusy = false;
			return ret;
		}



		private bool _isGetRouteInformationAsyncBusy = false;

		public async Task<Route> GetRouteInformationAsync(string routeNo)
		{
			if (_isGetRouteInformationAsyncBusy)
				return null;

			if (String.IsNullOrWhiteSpace(routeNo))
				return null;

			_isGetRouteInformationAsyncBusy = true;

			//"http://api.translink.ca/rttiapi/v1/routes/351?apikey=sqC4AYYoJMa5bVbKOhih"
			string url = String.Format(
				"http://api.translink.ca/rttiapi/v1/routes/{0}?apikey={1}",
				UrlEncode(routeNo),
				_apiKey);

			Route r = null;

			try
			{
				using (var request = CreateRequest(url))
				using (var response = await _client.SendAsync(request))
				{
					r = await ReadResponseContentAsync<Route>(response);
				}
			}
			catch (Exception e)
			{
				r = null;
				Debug.WriteLine(e.ToString());
			}


			_isGetRouteInformationAsyncBusy = false;

			return r;
		}

	}
}
