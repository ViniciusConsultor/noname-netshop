using System;
namespace NoName.NetShop.Model
{
	/// <summary>
	/// 实体类QuestionModel 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class QuestionModel
	{
		public QuestionModel()
		{}
		#region Model
		private int _questionid;
		private int? _userid;
		private int? _contenttype;
		private string _contentid;
		private string _title;
		private string _content;
		private string _brief;
		private DateTime? _inserttime;
		private DateTime? _lastanswertime;
		private string _lastanswerid;
		private int? _answernum;
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
		public int? UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ContentType
		{
			set{ _contenttype=value;}
			get{return _contenttype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ContentId
		{
			set{ _contentid=value;}
			get{return _contentid;}
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
		public string Brief
		{
			set{ _brief=value;}
			get{return _brief;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? InsertTime
		{
			set{ _inserttime=value;}
			get{return _inserttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LastAnswerTime
		{
			set{ _lastanswertime=value;}
			get{return _lastanswertime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LastAnswerId
		{
			set{ _lastanswerid=value;}
			get{return _lastanswerid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AnswerNum
		{
			set{ _answernum=value;}
			get{return _answernum;}
		}
		#endregion Model

	}
}

