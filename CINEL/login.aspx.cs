﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CINEL
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_entrar_Click(object sender, EventArgs e)
        {
            if (tb_utilizador.Text == "user"  && tb_ppasse.Text == "123456")
            {
                Session["utilizador"] = tb_utilizador.Text;
                Session["entrou"] = "sim";
                Response.Redirect("app.aspx");
            }
            else
            {
                lbl_mensagem.Visible = true;
            }
          

        }
    }
}


