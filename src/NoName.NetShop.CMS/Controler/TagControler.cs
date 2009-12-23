using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.CMS.Model;
using System.Data;
using NoName.NetShop.CMS.DataAccess;

namespace NoName.NetShop.CMS.Controler
{
    public class TagControler
    {
        public static TagModel GetModel(int TagID)
        {
            TagModel model = null;

            DataTable dt = TagDataAccess.Get(TagID);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                model = new TagModel();

                model.TagID = Convert.ToInt32(row["tagid"]);
                model.TagName = Convert.ToString(row["tagname"]);
                model.XsltTemplate = Convert.ToString(row["xslttemplate"]);
                model.DataProvider = Convert.ToString(row["dataprovider"]);
                model.DefaultParameter = Convert.ToString(row["defaultparameter"]);
                model.EditControl = Convert.ToString(row["editcontrol"]);
                model.ExamplePicture = Convert.ToString(row["examplepicture"]);
                model.IsPublic = Convert.ToBoolean(row["ispublic"]);
            }


            return model;
        }
    }
}
