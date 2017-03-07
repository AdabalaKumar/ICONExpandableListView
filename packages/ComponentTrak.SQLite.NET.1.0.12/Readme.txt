A set of helper classes for using SQLite. TrakPropertyChanged implements the INotifyPropertyChanged interface to save 
coding. TrakViewModel inherits TrakPropertyChanged and has 2 properties, VMList and EditRecord.

Before you using the ComponentTrak classes or method, you need to register the routines. In the MainPage or App, add a call to 
the ComponentTrak.Init.Register static method passing in the developer code given to you when you registered ComponentTrak. Example is

            ComponentTrak.Init.Register("abcd");


TrakDbContext
   The Database context implements some basic properties and methods for helping add SQLite to a Xamarin Forms app using SQLite.NET.

   Inherits from  IDisposable.

   Method:      
	  Open(string dbFilename) - Opens a SQLite connection to the DB file using the filename passed in.
	  Close() - Closes the SQLite connection to the DB file.
	  Dispose - Cleans up the SQLite connection.
	  Boolean TableExits(string tableName) - Checks the SQLite database to see if the table exists, returns true if the table exists.
	  CreateTable<T>() - Creates the table in the SQLite database based on the object type if the table does not already exist.
	  int Insert(object rec) - Adds a row to a table.
	  int Delete(object rec) - Deletes a row from a table.
	  int Update(object rec) - Updates a row in a table.

   Properties:
      DbConnection - The SQLiteConnection object that is create in the native platform.
	  DbFilename - The filename that SQLite should use on the file system.
	  IsOpen - Is true when the DB connection is open, otherwise is false.

   Example:
      Always add the using statement at the top of your cs file.

         using ComponentTrak.TrakSQLite;

         class MyViewModel
         {
		    private TrakDbContext<Customer> _CustomerDb = new TrakDbContext<Customer>();
			public TrakDbContext<Customer> CustomerDb { get { return _CustomerDb; } }

			public void DeleteRecord(Customer cust)
			{
			   CustomerDb.Delete(cust);
			}
         }

		 public class Customer
		 {
		    [Key]
			public string Id { get; set; }

			public string Name { get; set; }
		 }




TrakSQLiteViewModel
   Inherits from TrakViewModel which also inherits TrakEditViewModel.

   Method:
      RaisePropertyChanged(); - Add this method to all properties when you set the value for the property.
      public virtual Task LoadListAsync() - This is a default method to load the VMList.
	  public virtual Task DeleteAsync() - This is a default method that the UI can call for deleting a row from the SQLite table.
	  public virtual async void Save() - This is a default method that the UI can call for updating and/or adding the EditMethod row to the SQLite table based on the ID.
	  public virtual async void AddRecord(T rec) - This is a method that the UI can call for adding a row to VMList and SQLite.
	  public virtual Task AddToDbAsync(T rec) - This is a method that adds a row to the SQLite table and does not update VMList.
	  public virtual Task UpdateDbAsync(T rec) - Updates the SQLite database.

   Properties:
      VMList - Declares an observable collection using T.
	  EditRecord - Declares an edit record.
	  DbContext - The DB context that contains the SQLite Connection and other C# objects for the database.
	  IdPropertyName - Name of the property that holds the ID for the model. This field is typically defined with the [Key] attribute.


   Example:
      Always add the using statement at the top of your cs file.

         using ComponentTrak.TrakSQLite;

	  This class also implements the TrakPRopertyChanged class so you can use the RaisePropertyChanged 
	  on any of your custom properties. Also in the constructor, we call open with the db filename. Set the
	  IdPropertyName to the property name that will be the Key column for the SQLite table. At the end of the 
	  constructor in your ViewModel that inherits TrakSQLiteViewModel, we need to call LoadListAsync.

         class MyViewModel : TrakSQLiteViewModel
         {
	        private string _Name = "";
		    public string Name { get { return _Name; } set { _Name = value; RaisePropertyChanged(); } }

			public MyViewModel()
			{
				DbContext.Open("TestSQLiteNet.db");
				this.IdPropertyName = "CustomerId";

				this.ValidateRequired("Name", "Name is Required");
				this.ValidateStringLength("Name", 5, 100, "Name must be 5 to 100 characters");
				LoadData();
			}

			private async void LoadData()
			{
				await LoadListAsync();
			}
         }

      In your MyContentPage.xaml to use the built-in list of models, you could bind it to your ListView
	     
		 <ListView ItemsSource="{Binding VMList}"/>
	     
      In your MyContentPage.xaml to edit a record using the built-in model, you could bind your grid or any 
	  control to the EditVMRecord that has a model with multiple properties. This example shows if the model 
	  was a customer model with a couple of properties, Name and Address



















