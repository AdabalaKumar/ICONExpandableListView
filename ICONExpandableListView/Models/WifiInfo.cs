using System;
using System.Collections.Generic;
using System.ComponentModel;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace ICONExpandableListView
{
	public class WifiInfo : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		[PrimaryKey, AutoIncrement]
		public int WifiId { get; set; }


		[OneToMany(CascadeOperations = CascadeOperation.All)]      // One to many relationship with Valuation
		public List<DeviceInfo> devices { get; set; }		private string wifiName { get; set; }


		public WifiInfo()
		{
			Rotation = 270;
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


		public int _Rotation;
		public int Rotation
		{
			get { return _Rotation; }
			set
			{
				_Rotation = value;
				OnPropertyChanged("Rotation");
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
