using System;
namespace NoName.NetShop.Model
{
	/// <summary>
	/// 实体类AnswerModel 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class AnswerModel
	{
		public AnswerModel()
		{}
		#region Model
		private int? _questionid;
		private int _answerid;
		private string _title;
		private string _brief;
		private string _content;
		private DateTime? _answertime;
		/// <summary>
		/// 
		/// </summary>
		public int? QuestionId
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
		public string Brief
		{
			set{ _brief=value;}
			get{return _brief;}
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
		public DateTime? AnswerTime
		{
			set{ _answertime=value;}
			get{return _answertime;}
		}
		#endregion Model

	}
}

