using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace ICONExpandableListView
{
	public class DeviceListViewModel:INotifyPropertyChanged
	{
		public DeviceListViewModel()
		{
			WifiInfoList = new ObservableCollection<Grouping<SelectWifiInfoViewModel, DeviceInfo>>();
			var selectWifiInfo =
				DataFactory.DataItems.Select(x => new SelectWifiInfoViewModel { WifiInfo = x.WifiInfo, Selected = false })
				           .GroupBy(sc => new { sc.WifiInfo.WifiId })
					.Select(g => g.First())
					.ToList();
			foreach (var item in selectWifiInfo)
			{
				WifiInfoList.Add(new Grouping<SelectWifiInfoViewModel, DeviceInfo>(item, new List<DeviceInfo>()));
			}
			//selectWifiInfo.ForEach(sc => WifiInfoList.Add(new Grouping<SelectWifiInfoViewModel, DeviceInfo>(sc, new List<DeviceInfo>())));

			SelectedCommand = new Command<Grouping<SelectWifiInfoViewModel, DeviceInfo>>(g =>
				{
						if (g == null) return;
							g.Key.Selected = !g.Key.Selected;

							if (g.Key.Selected)
							{

								foreach (var item in DataFactory.DataItems.Where(i => (i.WifiInfo.WifiId == g.Key.WifiInfo.WifiId)))
								{
							      
						          g.Add(item);
								}

							}
							else
							{
								g.Clear();
							}
							if (g.Key.WifiInfo.Rotation == 270)
								g.Key.WifiInfo.Rotation = 0;
							else
								g.Key.WifiInfo.Rotation = 270;

							WifiInfoList.Where(u => u.Key.WifiInfo.WifiId == g.Key.WifiInfo.WifiId).Select(w => w.Key.WifiInfo.Rotation = g.Key.WifiInfo.Rotation).ToList();

				});


		}

	




		private ObservableCollection<Grouping<SelectWifiInfoViewModel, DeviceInfo>> _wifiinfoList;

		public event PropertyChangedEventHandler PropertyChanged;

		public ObservableCollection<Grouping<SelectWifiInfoViewModel, DeviceInfo>> WifiInfoList
		{
			get
			{
				return _wifiinfoList;
			}
			set
			{
				_wifiinfoList = value;

			}
		}
		public ICommand SelectedCommand
		{
			get;
			set;
		}
		public Command<Grouping<SelectWifiInfoViewModel, DeviceInfo>> HeaderSelectedCommand
		{
			get
			{
				return new Command<Grouping<SelectWifiInfoViewModel, DeviceInfo>>(g =>
				{
					if (g == null) return;
					g.Key.Selected = !g.Key.Selected;

					if (g.Key.Selected)
					{

						foreach (var item in DataFactory.DataItems.Where(i => (i.WifiInfo.WifiId == g.Key.WifiInfo.WifiId)))
						{
							g.Add(item);
						}

						//DataFactory.DataItems.Where(i => (i.WifiInfo.WifiId == g.Key.WifiInfo.WifiId))
						//	.ForEach(g.Add);


					}
					else
					{
						g.Clear();
					}
					if (g.Key.WifiInfo.Rotation == 270)
						g.Key.WifiInfo.Rotation = 0;
					else
						g.Key.WifiInfo.Rotation = 270;

					WifiInfoList.Where(u => u.Key.WifiInfo.WifiId == g.Key.WifiInfo.WifiId).Select(w => w.Key.WifiInfo.Rotation = g.Key.WifiInfo.Rotation).ToList();

				});
			}
		}

	}
	public class SelectWifiInfoViewModel
	{
		public WifiInfo _wifiinfo;
		public WifiInfo WifiInfo
		{
			get
			{
				return _wifiinfo;
			}
			set
			{
				_wifiinfo = value;

			}
		}
		public bool Selected { get; set; }
	}
}
