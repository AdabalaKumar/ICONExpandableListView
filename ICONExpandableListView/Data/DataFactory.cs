using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ICONExpandableListView
{
	public static class DataFactory
	{
		public static IList<DeviceInfo> DataItems { get; private set; }

		private static readonly WifiInfo Category1 = new WifiInfo { WifiId = 1, WifiName = "ValleyGrower 1" };
		private static readonly WifiInfo Category2 = new WifiInfo { WifiId = 2, WifiName = "ValleyGrower 2" };

		static DataFactory()
		{
			DataItems = new ObservableCollection<DeviceInfo>()
			{
				new DeviceInfo
				{
					DeviceId = 1,
					DeviceName = "Device 1",
					PanelAddress="Address: 198.168.01.101",
					devicestatus=Color.FromHex("#1E90FF"),
					WifiInfo = Category1
				},
				new DeviceInfo
				{
					DeviceId = 2,
					DeviceName = "Device 2",
					devicestatus=Color.Silver,
					PanelAddress="Address: 198.168.01.101",
					WifiInfo = Category1
				},
				new DeviceInfo
				{
					DeviceId = 3,
					DeviceName = "Device 3",
					devicestatus=Color.Silver,
					PanelAddress="Address: 198.168.01.101",
					WifiInfo = Category2
				},
				new DeviceInfo
				{
					DeviceId = 4,
					DeviceName = "Device 4",
					devicestatus=Color.Silver,
					PanelAddress="Address: 198.168.01.101",
					WifiInfo = Category2
				}
			};
		}
	}
}
