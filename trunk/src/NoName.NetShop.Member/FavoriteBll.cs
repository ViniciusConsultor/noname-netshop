using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Member.Model;
namespace NoName.NetShop.Member
{
    /// <summary>
    /// 业务逻辑类FavoriteModel 的摘要说明。
    /// </summary>
    public class FavoriteBll
    {
        private readonly NoName.NetShop.Member.FavoriteDal dal = new NoName.NetShop.Member.FavoriteDal();
        public FavoriteBll()
        { }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(NoName.NetShop.Member.FavoriteModel model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int FavoriteId)
        {
            dal.Delete(FavoriteId);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string userId, int msgId)
        {
            dal.Delete(userId, msgId);
        }

        /// <summary>
        /// 删除多条数据
        /// </summary>
        public void Delete(string userId, string msgIds)
        {
            dal.Delete(userId, msgIds);
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public NoName.NetShop.Member.FavoriteModel GetModel(int FavoriteId)
        {

            return dal.GetModel(FavoriteId);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<NoName.NetShop.Member.FavoriteModel> GetModelList(string userId)
        {
            return dal.GetListArray(userId);
        }
        #endregion  成员方法
    }
}

