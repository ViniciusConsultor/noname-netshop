using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Product.BLL;

namespace NoName.NetShop.BackFlat.Category
{
    public partial class List : System.Web.UI.Page
    {
        private CategoryModelBll bll = new CategoryModelBll();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList1Data();
            }
        }

        private void BindList1Data()
        {
            ListBox1.DataSource = bll.GetList("parentid=0 order by showorder");
            ListBox1.DataTextField = "catename";
            ListBox1.DataValueField = "cateid";
            ListBox1.DataBind();
            if (ListBox1.Items.Count > 0)
            {
                ListBox1.Items[0].Selected = true;
            }

            if (Convert.ToInt32(ListBox1.SelectedValue) != 0)
            {
                BindList2Data(Convert.ToInt32(ListBox1.SelectedValue));
            }
        }
        private void BindList2Data(int ParentID)
        {
            ListBox2.DataSource = bll.GetList("parentid=" + ParentID + " order by showorder");
            ListBox2.DataTextField = "catename";
            ListBox2.DataValueField = "cateid";
            ListBox2.DataBind();
            if (ListBox2.Items.Count > 0)
            {
                ListBox2.Items[0].Selected = true;
                ListBox2.Visible = true;
            }

            if (Convert.ToInt32(ListBox2.SelectedValue) != 0)
            {
                BindList3Data(Convert.ToInt32(ListBox2.SelectedValue));
            }

        }
        private void BindList3Data(int ParentID)
        {
            ListBox3.DataSource = bll.GetList("parentid=" + ParentID + " order by showorder");
            ListBox3.DataTextField = "catename";
            ListBox3.DataValueField = "cateid";
            ListBox3.DataBind();
            if (ListBox3.Items.Count > 0)
            {
                ListBox3.Items[0].Selected = true;
                ListBox3.Visible = true;
            }

        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ListBox1.SelectedValue) != 0)
            {
                BindList2Data(Convert.ToInt32(ListBox1.SelectedValue)); 
            }
        }

        protected void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ListBox2.SelectedValue) != 0)
            {
                BindList3Data(Convert.ToInt32(ListBox2.SelectedValue));
            }
        }

        protected void Button1MoveUp_Click(object sender, EventArgs e)
        {
            int OriginCateID = Convert.ToInt32(ListBox1.SelectedItem.Value);
            int SwitchCateID = Convert.ToInt32(ListBox1.Items[ListBox1.Items.IndexOf(ListBox1.SelectedItem) - 1].Value);
            bll.SwitchOrder(OriginCateID,SwitchCateID);
            BindList1Data();
        }

        protected void Button1MoveDown_Click(object sender, EventArgs e)
        {
            int OriginCateID = Convert.ToInt32(ListBox1.SelectedItem.Value);
            int SwitchCateID = Convert.ToInt32(ListBox1.Items[ListBox1.Items.IndexOf(ListBox1.SelectedItem) + 1].Value);
            bll.SwitchOrder(OriginCateID, SwitchCateID);
            BindList1Data();
        }

        protected void Button2MoveUp_Click(object sender, EventArgs e)
        {
            int OriginCateID = Convert.ToInt32(ListBox2.SelectedItem.Value);
            int SwitchCateID = Convert.ToInt32(ListBox2.Items[ListBox2.Items.IndexOf(ListBox2.SelectedItem) - 1].Value);
            bll.SwitchOrder(OriginCateID, SwitchCateID);
            BindList2Data(Convert.ToInt32(ListBox1.SelectedValue));
        }

        protected void Button2MoveDown_Click(object sender, EventArgs e)
        {
            int OriginCateID = Convert.ToInt32(ListBox2.SelectedItem.Value);
            int SwitchCateID = Convert.ToInt32(ListBox2.Items[ListBox2.Items.IndexOf(ListBox2.SelectedItem) + 1].Value);
            bll.SwitchOrder(OriginCateID, SwitchCateID);
            BindList2Data(Convert.ToInt32(ListBox1.SelectedValue));
        }

        protected void Button3MoveUp_Click(object sender, EventArgs e)
        {
            int OriginCateID = Convert.ToInt32(ListBox3.SelectedItem.Value);
            int SwitchCateID = Convert.ToInt32(ListBox3.Items[ListBox3.Items.IndexOf(ListBox3.SelectedItem) - 1].Value);
            bll.SwitchOrder(OriginCateID, SwitchCateID);
            BindList3Data(Convert.ToInt32(ListBox2.SelectedValue));
        }

        protected void Button3MoveDown_Click(object sender, EventArgs e)
        {
            int OriginCateID = Convert.ToInt32(ListBox3.SelectedItem.Value);
            int SwitchCateID = Convert.ToInt32(ListBox3.Items[ListBox3.Items.IndexOf(ListBox3.SelectedItem) + 1].Value);
            bll.SwitchOrder(OriginCateID, SwitchCateID);
            BindList3Data(Convert.ToInt32(ListBox2.SelectedValue));
        }
    }
}
