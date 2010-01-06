using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.Comment
{
        	[Serializable]
   public class AnswerModel
    {
		public AnswerModel()
		{}
		#region Model
		private int _questionid;
		private int _answerid;
		private string _title;
		private string _content;
		private DateTime _answertime;
		/// <summary>
		/// 
		/// </summary>
		public int QuestionId
		{
			set{ _questionid=value;}
			get{return _questionid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int AnswerId
		{
			set{ _answerid=value;}
			get{return _answerid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime AnswerTime
		{
			set{ _answertime=value;}
			get{return _answertime;}
		}
		#endregion Model

    }
}
