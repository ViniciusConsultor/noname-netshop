using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Solution.DAL;
using NoName.NetShop.Solution.Model;
using System.Data;

namespace NoName.NetShop.Solution.Bll
{
    public class SolutionDemandBll
    {
        private SolutionDemandDal dal = new SolutionDemandDal();

        public void Add(SolutionDemandModel model)
        {
            dal.Add(model);
        }

        public void Update(SolutionDemandModel model)
        {
            dal.Update(model);
        }

        public void Delete(int DemandID)
        {
            dal.Delete(DemandID);
        }

        public SolutionDemandModel GetModel(int DemandID)
        {
            return dal.GetModel(DemandID);
        }

        public DataTable GetList(int PageIndex, int PageSize, string Condititon, out int RecordCount)
        {
            return dal.GetList(PageIndex,PageSize,Condititon,out RecordCount);
        }
    }
}
