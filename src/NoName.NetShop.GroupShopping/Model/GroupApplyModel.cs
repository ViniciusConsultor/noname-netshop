using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.GroupShopping.Model
{
    public class GroupApplyModel
    {
        public GroupApplyModel()
		{}

		#region Model
		private int _groupapplyid;
		private int _groupproductid;
		private string _userid;
		private int _applystatus;
		private string _applybrief;
		private DateTime _applytime;
		private DateTime _confirmtime;
		/// <summary>
		/// 
		/// </summary>
		public int GroupApplyID
		{
			set{ _groupapplyid=value;}
			get{return _groupapplyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int GroupProductID
		{
			set{ _groupproductid=value;}
			get{return _groupproductid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ApplyStatus
		{
			set{ _applystatus=value;}
			get{return _applystatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ApplyBrief
		{
			set{ _applybrief=value;}
			get{return _applybrief;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ApplyTime
		{
			set{ _applytime=value;}
			get{return _applytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ConfirmTime
		{
			set{ _confirmtime=value;}
			get{return _confirmtime;}
		}
		#endregion Model
    }
}
