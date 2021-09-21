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

namespace ServiceWebHook
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="ReadMeter")]
	public partial class ModelDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertZl_User_Follow(Zl_User_Follow instance);
    partial void UpdateZl_User_Follow(Zl_User_Follow instance);
    partial void DeleteZl_User_Follow(Zl_User_Follow instance);
    #endregion
		
		public ModelDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["ReadMeterConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ModelDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ModelDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ModelDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ModelDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Zl_User_Follow> Zl_User_Follows
		{
			get
			{
				return this.GetTable<Zl_User_Follow>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Zl_User_Follow")]
	public partial class Zl_User_Follow : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _IdFollower;
		
		private System.Nullable<bool> _IsFollower;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdFollowerChanging(string value);
    partial void OnIdFollowerChanged();
    partial void OnIsFollowerChanging(System.Nullable<bool> value);
    partial void OnIsFollowerChanged();
    #endregion
		
		public Zl_User_Follow()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdFollower", DbType="NVarChar(100) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string IdFollower
		{
			get
			{
				return this._IdFollower;
			}
			set
			{
				if ((this._IdFollower != value))
				{
					this.OnIdFollowerChanging(value);
					this.SendPropertyChanging();
					this._IdFollower = value;
					this.SendPropertyChanged("IdFollower");
					this.OnIdFollowerChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsFollower", DbType="Bit")]
		public System.Nullable<bool> IsFollower
		{
			get
			{
				return this._IsFollower;
			}
			set
			{
				if ((this._IsFollower != value))
				{
					this.OnIsFollowerChanging(value);
					this.SendPropertyChanging();
					this._IsFollower = value;
					this.SendPropertyChanged("IsFollower");
					this.OnIsFollowerChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591