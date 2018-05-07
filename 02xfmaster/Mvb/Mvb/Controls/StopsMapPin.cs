using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace Mvb.Controls
{
	public class StopsMapPin
	{
		public Pin Pin { get; set; }

		public StopsMapPin()
		{
		}

		public StopsMapPin(string address, string label, double latitude, double longitude)
		{
			Pin = new Pin
			{
				Address = address,
				Label = label,
				Position = new Position(latitude, longitude),
			};
		}
	}
}
