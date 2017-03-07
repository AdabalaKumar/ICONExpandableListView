using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ICONExpandableListView
{
	public partial class MainPage : ContentPage
	{
		void Handle_Swiped(object sender, MR.Gestures.SwipeEventArgs e)
		{
			throw new NotImplementedException();
		}

		async void Handle_Tapped(object sender, System.EventArgs e)
		{
			
			var answer = await DisplayAlert("Delete", "Are you sure want delete?", "Yes", "No");
			if (answer)
			{
				

			}
		}

		public MainPage()
		{
			InitializeComponent();
			BindingContext = new DeviceListViewModel();
		}
	}
}
