using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace TranslinkWebApi.Controllers
{
	public static class ControllerExts
	{
		public static string GetTranslinkApiKey(this Controller controller, IConfigurationRoot configuration)
		{
			var section = configuration.GetSection("secrets");
			string key = section.GetValue<string>("translinkkey");
			return key;
		}


		public static string UrlEncode(this Controller controller, string s)
		{
			return WebUtility.UrlEncode(s);
		}

		public static string UrlEncodeCoords(this Controller controller, double d)
		{
			return WebUtility.UrlEncode($"{d:0.000000}");
		}

		public static string UrlEncode(this Controller controller, double d)
		{
			return WebUtility.UrlEncode(d.ToString());
		}

		public static string UrlEncode(this Controller controller, int i)
		{
			return WebUtility.UrlEncode(i.ToString());
		}

		public static T Deserialize<T>(this Controller controller, string data)
		{
			return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(data);
		}

		public static HttpClient CreateHttpClient(this Controller controller)
		{
			var client = new HttpClient();
			client.DefaultRequestHeaders.Clear();
			return client;
		}


		public static HttpRequestMessage CreateRequest(this Controller controller, string url, HttpMethod method = null)
		{
			HttpRequestMessage r = new HttpRequestMessage(method ?? HttpMethod.Get, url);
			r.Headers.Clear();
			r.Content = null;
			r.Properties.Clear();
			r.Headers.Accept.Clear();
			r.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
			return r;
		}


		public static async Task<T> ReadResponseContentAsync<T>(this Controller controller, HttpResponseMessage response) where T : class
		{
			if (response.IsSuccessStatusCode)
			{
				var s = await response.Content.ReadAsStringAsync();
				var ret = controller.Deserialize<T>(s);
				return ret;
			}

			return null;
		}


		public static string GetBaseUrl(this Controller controller)
		{
			return "http://api.translink.ca/rttiapi/v1/";
		}

	}
}
