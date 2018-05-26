using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mvb.Services.Favorites
{
	public interface IFavoriteService
	{
		Task<List<FavoriteRoute>> GetFavoriteRoutesAsync();
		Task SaveFavoriteRoutesAsync(List<FavoriteRoute> routes);

		Task<List<FavoriteStop>> GetFavoriteStopsAsync();
		Task SaveFavoriteStopsAsync(List<FavoriteStop> stops);
	}
}
