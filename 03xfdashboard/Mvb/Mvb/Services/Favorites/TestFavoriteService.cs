using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mvb.Services.Favorites
{
	public class TestFavoriteService : IFavoriteService
	{
		private Random _random = new Random();
		private List<FavoriteRoute> _routes = new List<FavoriteRoute>();
		private List<FavoriteStop> _stops = new List<FavoriteStop>();


		public TestFavoriteService()
		{
			InitializeRoutes();
			InitializeStops();
		}


		private void InitializeRoutes()
		{
			int num = _random.Next(3, 5);
			for (int i = 0; i < num; i++)
			{
				_routes.Add(new FavoriteRoute(i, $"Route {i}", $"Route name {i}", "operating company"));
			}
		}


		private void InitializeStops()
		{
			int num = _random.Next(5, 8);
			for (int i = 0; i < num; i++)
			{
				_stops.Add(new FavoriteStop(i, $"Stop {i}", $"Name {i}", $"on st {i}", $"at st {i}", 0, 0));
			}
		}





		private async Task DoRandomDelayAsync()
		{
			int milliseconds = _random.Next(700, 1200);
			await Task.Delay(milliseconds);
		}

		public async Task<List<FavoriteRoute>> GetFavoriteRoutesAsync()
		{
			await DoRandomDelayAsync();
			List<FavoriteRoute> ret = new List<FavoriteRoute>(_routes);
			return ret;
		}

		public async Task<List<FavoriteStop>> GetFavoriteStopsAsync()
		{
			await DoRandomDelayAsync();
			List<FavoriteStop> ret = new List<FavoriteStop>(_stops);
			return ret;
		}

		public async Task SaveFavoriteRoutesAsync(List<FavoriteRoute> routes)
		{
			await DoRandomDelayAsync();
			_routes = new List<FavoriteRoute>(routes);
		}

		public async Task SaveFavoriteStopsAsync(List<FavoriteStop> stops)
		{
			await DoRandomDelayAsync();
			_stops = new List<FavoriteStop>(stops);
		}
	}
}
