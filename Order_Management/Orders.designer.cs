﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Order_Management
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="OrderManagement")]
	public partial class OrdersDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public OrdersDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["OrderManagementConnectionString1"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public OrdersDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public OrdersDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public OrdersDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public OrdersDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.spDelete_Order")]
		public int spDelete_Order([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> intOrderID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), intOrderID);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.spDisplay_AllOrders")]
		public ISingleResult<spDisplay_AllOrdersResult> spDisplay_AllOrders()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<spDisplay_AllOrdersResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.spDisplay_Order")]
		public ISingleResult<spDisplay_OrderResult> spDisplay_Order([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> intOrderID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), intOrderID);
			return ((ISingleResult<spDisplay_OrderResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.spUpsert_Order")]
		public ISingleResult<spUpsert_OrderResult> spUpsert_Order([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(100)")] string vcBuyerName, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(50)")] string vcBuyerPhone, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(50)")] string vcBuyerEmail, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(MAX)")] string vcShippingAddress, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> intOrderStatus, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> intOrderItem, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> intQuantity, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> existOrderID, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] ref System.Nullable<int> intOrderID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), vcBuyerName, vcBuyerPhone, vcBuyerEmail, vcShippingAddress, intOrderStatus, intOrderItem, intQuantity, existOrderID, intOrderID);
			intOrderID = ((System.Nullable<int>)(result.GetParameterValue(8)));
			return ((ISingleResult<spUpsert_OrderResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.spUpsert_OrderItem")]
		public ISingleResult<spUpsert_OrderItemResult> spUpsert_OrderItem([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(100)")] string vcItemName, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> intWeight, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> intHeight, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(MAX)")] string vcImage, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> intStockItems, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(MAX)")] string vcBarCode, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> intAvailableQuantity, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> existOrderItemID, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] ref System.Nullable<int> intOrderItemID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), vcItemName, intWeight, intHeight, vcImage, intStockItems, vcBarCode, intAvailableQuantity, existOrderItemID, intOrderItemID);
			intOrderItemID = ((System.Nullable<int>)(result.GetParameterValue(8)));
			return ((ISingleResult<spUpsert_OrderItemResult>)(result.ReturnValue));
		}
	}
	
	public partial class spDisplay_AllOrdersResult
	{
		
		private int _intOrderID;
		
		private string _vcBuyerName;
		
		private string _vcBuyerPhone;
		
		private string _vcBuyerEmail;
		
		private string _vcShippingAddress;
		
		private System.Nullable<int> _intOrderStatus;
		
		private System.Nullable<int> _intOrderItem;
		
		private System.Nullable<int> _intQuantity;
		
		public spDisplay_AllOrdersResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_intOrderID", DbType="Int NOT NULL")]
		public int intOrderID
		{
			get
			{
				return this._intOrderID;
			}
			set
			{
				if ((this._intOrderID != value))
				{
					this._intOrderID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_vcBuyerName", DbType="NVarChar(100)")]
		public string vcBuyerName
		{
			get
			{
				return this._vcBuyerName;
			}
			set
			{
				if ((this._vcBuyerName != value))
				{
					this._vcBuyerName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_vcBuyerPhone", DbType="NVarChar(50)")]
		public string vcBuyerPhone
		{
			get
			{
				return this._vcBuyerPhone;
			}
			set
			{
				if ((this._vcBuyerPhone != value))
				{
					this._vcBuyerPhone = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_vcBuyerEmail", DbType="NVarChar(50)")]
		public string vcBuyerEmail
		{
			get
			{
				return this._vcBuyerEmail;
			}
			set
			{
				if ((this._vcBuyerEmail != value))
				{
					this._vcBuyerEmail = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_vcShippingAddress", DbType="NVarChar(MAX)")]
		public string vcShippingAddress
		{
			get
			{
				return this._vcShippingAddress;
			}
			set
			{
				if ((this._vcShippingAddress != value))
				{
					this._vcShippingAddress = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_intOrderStatus", DbType="Int")]
		public System.Nullable<int> intOrderStatus
		{
			get
			{
				return this._intOrderStatus;
			}
			set
			{
				if ((this._intOrderStatus != value))
				{
					this._intOrderStatus = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_intOrderItem", DbType="Int")]
		public System.Nullable<int> intOrderItem
		{
			get
			{
				return this._intOrderItem;
			}
			set
			{
				if ((this._intOrderItem != value))
				{
					this._intOrderItem = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_intQuantity", DbType="Int")]
		public System.Nullable<int> intQuantity
		{
			get
			{
				return this._intQuantity;
			}
			set
			{
				if ((this._intQuantity != value))
				{
					this._intQuantity = value;
				}
			}
		}
	}
	
	public partial class spDisplay_OrderResult
	{
		
		private int _intOrderID;
		
		private string _vcBuyerName;
		
		private string _vcBuyerPhone;
		
		private string _vcBuyerEmail;
		
		private string _vcShippingAddress;
		
		private System.Nullable<int> _intOrderStatus;
		
		private System.Nullable<int> _intOrderItem;
		
		private System.Nullable<int> _intQuantity;
		
		public spDisplay_OrderResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_intOrderID", DbType="Int NOT NULL")]
		public int intOrderID
		{
			get
			{
				return this._intOrderID;
			}
			set
			{
				if ((this._intOrderID != value))
				{
					this._intOrderID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_vcBuyerName", DbType="NVarChar(100)")]
		public string vcBuyerName
		{
			get
			{
				return this._vcBuyerName;
			}
			set
			{
				if ((this._vcBuyerName != value))
				{
					this._vcBuyerName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_vcBuyerPhone", DbType="NVarChar(50)")]
		public string vcBuyerPhone
		{
			get
			{
				return this._vcBuyerPhone;
			}
			set
			{
				if ((this._vcBuyerPhone != value))
				{
					this._vcBuyerPhone = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_vcBuyerEmail", DbType="NVarChar(50)")]
		public string vcBuyerEmail
		{
			get
			{
				return this._vcBuyerEmail;
			}
			set
			{
				if ((this._vcBuyerEmail != value))
				{
					this._vcBuyerEmail = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_vcShippingAddress", DbType="NVarChar(MAX)")]
		public string vcShippingAddress
		{
			get
			{
				return this._vcShippingAddress;
			}
			set
			{
				if ((this._vcShippingAddress != value))
				{
					this._vcShippingAddress = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_intOrderStatus", DbType="Int")]
		public System.Nullable<int> intOrderStatus
		{
			get
			{
				return this._intOrderStatus;
			}
			set
			{
				if ((this._intOrderStatus != value))
				{
					this._intOrderStatus = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_intOrderItem", DbType="Int")]
		public System.Nullable<int> intOrderItem
		{
			get
			{
				return this._intOrderItem;
			}
			set
			{
				if ((this._intOrderItem != value))
				{
					this._intOrderItem = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_intQuantity", DbType="Int")]
		public System.Nullable<int> intQuantity
		{
			get
			{
				return this._intQuantity;
			}
			set
			{
				if ((this._intQuantity != value))
				{
					this._intQuantity = value;
				}
			}
		}
	}
	
	public partial class spUpsert_OrderResult
	{
		
		private System.Nullable<int> _Column1;
		
		public spUpsert_OrderResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="", Storage="_Column1", DbType="Int")]
		public System.Nullable<int> Column1
		{
			get
			{
				return this._Column1;
			}
			set
			{
				if ((this._Column1 != value))
				{
					this._Column1 = value;
				}
			}
		}
	}
	
	public partial class spUpsert_OrderItemResult
	{
		
		private System.Nullable<int> _Column1;
		
		public spUpsert_OrderItemResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="", Storage="_Column1", DbType="Int")]
		public System.Nullable<int> Column1
		{
			get
			{
				return this._Column1;
			}
			set
			{
				if ((this._Column1 != value))
				{
					this._Column1 = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
