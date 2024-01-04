using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CINEL
{
    public partial class master_page2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_enviar1_Click(object sender, EventArgs e)
        {
            Response.Write(tb_nome.Text + " - " + tb_email.Text + " - " + tb_assunto.Text);
        }
    }
}