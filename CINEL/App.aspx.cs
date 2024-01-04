using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace CINEL
{
    public partial class App : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["entrou"] == null)
            {
                Response.Redirect("login.aspx");
            }

            lbl_hora.Text = DateTime.Now.ToString("G");

            if (!Page.IsPostBack)
            {
                lbl_utilizador.Text = Session["utilizador"].ToString();
            }

            XmlDocument url = new XmlDocument();
            url.Load("https://www.noticiasaominuto.com/rss/tech");

            Xml1.Document = url;

            //  criar xslt que vai apresentar apenas 10 urls
            Xml1.TransformSource = "lista_noticias.xslt";

        }



        protected void ddl_regime_SelectedIndexChanged(object sender, EventArgs e)
        {

            ddl_curso.Items.Clear();

            if (ddl_regime.SelectedItem.ToString() == "Diurno")
            {
                ddl_curso.Items.Add("UX / UI DESIGN");
                ddl_curso.Items.Add("Programação de Sites Web");
                ddl_curso.Items.Add("Programação PHP - Iniciação");
                ddl_curso.Items.Add("Programação Python - Iniciação");
                ddl_curso.Items.Add("Programação e Algoritmia");
            }
            else if (ddl_regime.SelectedItem.ToString() == "Noturno")
            {
                ddl_curso.Items.Add("Programação em JAVA - Iniciação");
                ddl_curso.Items.Add("Blockchain - Iniciação");
                ddl_curso.Items.Add("Cibersegurança - Iniciação");
                ddl_curso.Items.Add("Programação em C/C++");
                ddl_curso.Items.Add("Adobe Illustrator");
            }

        }

        protected void btn_inscricao_Click(object sender, EventArgs e)
        {
            Session["curso"] = ddl_curso.Text;
            Response.Redirect("inscricao.aspx");
        }
    }
}