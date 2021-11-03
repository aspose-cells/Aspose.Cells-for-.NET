using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace Aspose.Cells.GridWeb.DemosCS.DataBind
{
	/// <summary>
	/// DemoDatabase 
	/// </summary>
	public class ExampleDatabase : System.ComponentModel.Component
	{
		public System.Data.OleDb.OleDbConnection oleDbConnection1;
		public System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		public System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter2;
		/// <summary>
		/// 
		/// </summary>
		//private System.ComponentModel.Container components = null;

		public ExampleDatabase(System.ComponentModel.IContainer container)
		{
			/// <summary>
			/// Windows.Forms 
			/// </summary>
			container.Add(this);
			InitializeComponent();

			//
			// TODO: InitializeComponent
			//
		}

		public ExampleDatabase()
		{
			/// <summary>
			/// Windows.Forms 
			/// </summary>
			InitializeComponent();

			//
			// TODO:  InitializeComponent
			//
		}

		#region Component Designer generated code
		/// <summary>
		/// 
		/// 
		/// </summary>
		private void InitializeComponent()
		{
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbDataAdapter1 = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapter2 = new System.Data.OleDb.OleDbDataAdapter();
			// 
			// oleDbConnection1
			// 
			this.oleDbConnection1.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Password="""";User ID=Admin;Data Source=demos.mdb;Mode=Share Deny None;Extended Properties="""";Jet OLEDB:System database="""";Jet OLEDB:Registry Path="""";Jet OLEDB:Database Password="""";Jet OLEDB:Engine Type=5;Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Global Bulk Transactions=1;Jet OLEDB:New Database Password="""";Jet OLEDB:Create System Database=False;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:SFP=False";
			// 
			// oleDbDataAdapter1
			// 
			this.oleDbDataAdapter1.DeleteCommand = this.oleDbDeleteCommand1;
			this.oleDbDataAdapter1.InsertCommand = this.oleDbInsertCommand1;
			this.oleDbDataAdapter1.SelectCommand = this.oleDbSelectCommand1;
			this.oleDbDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										new System.Data.Common.DataTableMapping("Table", "Products", new System.Data.Common.DataColumnMapping[] {
																																																					new System.Data.Common.DataColumnMapping("CategoryID", "CategoryID"),
																																																					new System.Data.Common.DataColumnMapping("CreatedDate", "CreatedDate"),
																																																					new System.Data.Common.DataColumnMapping("Discontinued", "Discontinued"),
																																																					new System.Data.Common.DataColumnMapping("ProductID", "ProductID"),
																																																					new System.Data.Common.DataColumnMapping("ProductName", "ProductName"),
																																																					new System.Data.Common.DataColumnMapping("QuantityPerUnit", "QuantityPerUnit"),
																																																					new System.Data.Common.DataColumnMapping("ReorderLevel", "ReorderLevel"),
																																																					new System.Data.Common.DataColumnMapping("SupplierID", "SupplierID"),
																																																					new System.Data.Common.DataColumnMapping("UnitPrice", "UnitPrice"),
																																																					new System.Data.Common.DataColumnMapping("UnitsInStock", "UnitsInStock"),
																																																					new System.Data.Common.DataColumnMapping("UnitsOnOrder", "UnitsOnOrder")})});
			this.oleDbDataAdapter1.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM Products WHERE (ProductID = ?)";
			this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProductID", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(5)), ((System.Byte)(0)), "ProductID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO Products(CategoryID, CreatedDate, Discontinued, ProductID, ProductNam" +
				"e, QuantityPerUnit, ReorderLevel, SupplierID, UnitPrice, UnitsInStock, UnitsOnOr" +
				"der) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CategoryID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "CategoryID", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CreatedDate", System.Data.OleDb.OleDbType.DBDate, 0, "CreatedDate"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Discontinued", System.Data.OleDb.OleDbType.Boolean, 2, "Discontinued"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProductID", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(5)), ((System.Byte)(0)), "ProductID", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProductName", System.Data.OleDb.OleDbType.VarWChar, 40, "ProductName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("QuantityPerUnit", System.Data.OleDb.OleDbType.VarWChar, 20, "QuantityPerUnit"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ReorderLevel", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(5)), ((System.Byte)(0)), "ReorderLevel", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("SupplierID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "SupplierID", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("UnitPrice", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(19)), ((System.Byte)(0)), "UnitPrice", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("UnitsInStock", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(5)), ((System.Byte)(0)), "UnitsInStock", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("UnitsOnOrder", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(5)), ((System.Byte)(0)), "UnitsOnOrder", System.Data.DataRowVersion.Current, null));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT CategoryID, CreatedDate, Discontinued, ProductID, ProductName, QuantityPer" +
				"Unit, ReorderLevel, SupplierID, UnitPrice, UnitsInStock, UnitsOnOrder FROM Produ" +
				"cts";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = "UPDATE Products SET CategoryID = ?, CreatedDate = ?, Discontinued = ?, ProductID " +
				"= ?, ProductName = ?, QuantityPerUnit = ?, ReorderLevel = ?, SupplierID = ?, Uni" +
				"tPrice = ?, UnitsInStock = ?, UnitsOnOrder = ? WHERE (ProductID = ?)";
			this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CategoryID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "CategoryID", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CreatedDate", System.Data.OleDb.OleDbType.DBDate, 0, "CreatedDate"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Discontinued", System.Data.OleDb.OleDbType.Boolean, 2, "Discontinued"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProductID", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(5)), ((System.Byte)(0)), "ProductID", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProductName", System.Data.OleDb.OleDbType.VarWChar, 40, "ProductName"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("QuantityPerUnit", System.Data.OleDb.OleDbType.VarWChar, 20, "QuantityPerUnit"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ReorderLevel", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(5)), ((System.Byte)(0)), "ReorderLevel", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("SupplierID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "SupplierID", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("UnitPrice", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(19)), ((System.Byte)(0)), "UnitPrice", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("UnitsInStock", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(5)), ((System.Byte)(0)), "UnitsInStock", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("UnitsOnOrder", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(5)), ((System.Byte)(0)), "UnitsOnOrder", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProductID", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(5)), ((System.Byte)(0)), "ProductID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT CategoryID, CategoryName, Description, Picture FROM Categories";
			this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = "INSERT INTO Categories(CategoryName, Description, Picture) VALUES (?, ?, ?)";
			this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CategoryName", System.Data.OleDb.OleDbType.VarWChar, 15, "CategoryName"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Description", System.Data.OleDb.OleDbType.VarWChar, 0, "Description"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Picture", System.Data.OleDb.OleDbType.VarBinary, 0, "Picture"));
			// 
			// oleDbUpdateCommand2
			// 
			this.oleDbUpdateCommand2.CommandText = "UPDATE Categories SET CategoryName = ?, Description = ?, Picture = ? WHERE (Categ" +
				"oryID = ?) AND (CategoryName = ?) AND (Description = ? OR ? IS NULL AND Descript" +
				"ion IS NULL) AND (Picture = ? OR ? IS NULL AND Picture IS NULL)";
			this.oleDbUpdateCommand2.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CategoryName", System.Data.OleDb.OleDbType.VarWChar, 15, "CategoryName"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Description", System.Data.OleDb.OleDbType.VarWChar, 0, "Description"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Picture", System.Data.OleDb.OleDbType.VarBinary, 0, "Picture"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CategoryID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "CategoryID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CategoryName", System.Data.OleDb.OleDbType.VarWChar, 15, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CategoryName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Description", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Description", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Description1", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Description", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Picture", System.Data.OleDb.OleDbType.VarBinary, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Picture", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Picture1", System.Data.OleDb.OleDbType.VarBinary, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Picture", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbDeleteCommand2
			// 
			this.oleDbDeleteCommand2.CommandText = "DELETE FROM Categories WHERE (CategoryID = ?) AND (CategoryName = ?) AND (Descrip" +
				"tion = ? OR ? IS NULL AND Description IS NULL) AND (Picture = ? OR ? IS NULL AND" +
				" Picture IS NULL)";
			this.oleDbDeleteCommand2.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CategoryID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "CategoryID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CategoryName", System.Data.OleDb.OleDbType.VarWChar, 15, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CategoryName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Description", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Description", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Description1", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Description", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Picture", System.Data.OleDb.OleDbType.VarBinary, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Picture", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Picture1", System.Data.OleDb.OleDbType.VarBinary, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Picture", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbDataAdapter2
			// 
			this.oleDbDataAdapter2.DeleteCommand = this.oleDbDeleteCommand2;
			this.oleDbDataAdapter2.InsertCommand = this.oleDbInsertCommand2;
			this.oleDbDataAdapter2.SelectCommand = this.oleDbSelectCommand2;
			this.oleDbDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										new System.Data.Common.DataTableMapping("Table", "Categories", new System.Data.Common.DataColumnMapping[] {
																																																					  new System.Data.Common.DataColumnMapping("CategoryID", "CategoryID"),
																																																					  new System.Data.Common.DataColumnMapping("CategoryName", "CategoryName"),
																																																					  new System.Data.Common.DataColumnMapping("Description", "Description"),
																																																					  new System.Data.Common.DataColumnMapping("Picture", "Picture")})});
			this.oleDbDataAdapter2.UpdateCommand = this.oleDbUpdateCommand2;

		}
		#endregion
	}
}
