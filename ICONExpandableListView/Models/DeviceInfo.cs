using System;
using System.ComponentModel;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using Xamarin.Forms;

namespace ICONExpandableListView
{
	public class DeviceInfo:INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		[PrimaryKey, AutoIncrement]
		public int DeviceId { get; set; }
		[ForeignKey(typeof(WifiInfo))]    // Specify the foreign keyy
		public int WifiID { get; set; }
		private string wifiName { get; set; }
		private string deviceName { get; set; }
		private string panelAddress { get; set; }
		private string portNumber { get; set; }
		public Color devicestatus
		{
			get;
			set;
		}
		public WifiInfo WifiInfo
		{
			get;
			set;
		}


		public DeviceInfo()
		{
			//this.PanelAddress = "http://192.168.0.150";
			//this.PortNumber = "80";
		}

		public string WifiName
		{
			get { return wifiName; }
			set
			{
				wifiName = value;
				OnPropertyChanged("WifiName");
			}
		}
		public string DeviceName
		{
			get { return deviceName; }
			set
			{
				deviceName = value;
				OnPropertyChanged("DeviceName");
			}
		}
		public string PanelAddress
		{
			get { return panelAddress; }
			set
			{
				panelAddress = value;
				OnPropertyChanged("PanelAddress");
			}
		}
		public string PortNumber
		{
			get { return portNumber; }
			set
			{
				portNumber = value;
				OnPropertyChanged("PortNumber");
			}
		}


		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged == null)
				return;
			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
