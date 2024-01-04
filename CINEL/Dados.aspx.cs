using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.IO;
using System.Drawing.Printing;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace CINEL
{
    public partial class Dados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["entrou"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (!Page.IsPostBack)
            {
                lbl_nome.Text = Session["nome"].ToString();
                lbl_morada.Text = Session["morada"].ToString();
                lbl_passe.Text = Session["Palavra-Passe"].ToString();
                //lbl_encriptada = Session["encriptada"].ToString();
                lbl_curso.Text = Session["curso"].ToString();
                lbl_email.Text = Session["email"].ToString();
                lbl_postal.Text = Session["postal"].ToString();
            }

            lbl_encriptada.Text = EncryptString(lbl_passe.Text);
                string EncryptString(string Message)
            {
                string Passphrase = "cinel";
                byte[] Results;
                System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

                // Step 1. We hash the passphrase using MD5
                // We use the MD5 hash generator as the result is a 128 bit byte array
                // which is a valid length for the TripleDES encoder we use below

                MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
                byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

                // Step 2. Create a new TripleDESCryptoServiceProvider object
                TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

                // Step 3. Setup the encoder
                TDESAlgorithm.Key = TDESKey;
                TDESAlgorithm.Mode = CipherMode.ECB;
                TDESAlgorithm.Padding = PaddingMode.PKCS7;

                // Step 4. Convert the input string to a byte[]
                byte[] DataToEncrypt = UTF8.GetBytes(Message);

                // Step 5. Attempt to encrypt the string
                try
                {
                    ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                    Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
                }
                finally
                {
                    // Clear the TripleDes and Hashprovider services of any sensitive information
                    TDESAlgorithm.Clear();
                    HashProvider.Clear();
                }

                // Step 6. Return the encrypted string as a base64 encoded string
                return Convert.ToBase64String(Results);
            }
        }

        protected void btn_word_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=ficheiro.doc");
            Response.ContentType = "application/vnd.ms-word";
            Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());

            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            htw.Write("<table><tr><td><b>Nome:</b></td><td>" + lbl_nome.Text + "</td></tr> <tr><td><b>Morada:</b></td><td></td>" + lbl_morada.Text + "</tr> <tr><td><b>Palavra passe:</b></td><td>" + lbl_passe.Text + "</td></tr> <tr><td><b>Palavra passe encriptada:</b></td><td>" + lbl_encriptada.Text + "</td></tr> " +
            " <tr><td><b>Curso:</b></td><td>" + lbl_curso.Text + "</td></tr> <tr><td><b>Email:</b></td><td>" + lbl_email.Text + "</td></tr> <tr><td><b>Código postal:</b></td><td>" + lbl_postal.Text + "</td></tr>" +
             "</td></tr></table>");

            Response.Write(sw.ToString());

            Response.End();
        }

        protected void btn_excel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=ficheiro.xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());

            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            htw.Write("<table><tr><td><b>Nome:</b></td><td>" + lbl_nome.Text + "</td></tr> <tr><td><b>Morada:</b></td><td></td>" + lbl_morada.Text + "</tr> <tr><td><b>Palavra passe:</b></td><td>" + lbl_passe.Text + "</td></tr> <tr><td><b>Palavra passe encriptada:</b></td><td>" + lbl_encriptada.Text + "</td></tr> " +
            " <tr><td><b>Curso:</b></td><td>" + lbl_curso.Text + "</td></tr> <tr><td><b>Email:</b></td><td>" + lbl_email.Text + "</td></tr> <tr><td><b>Código postal:</b></td><td>" + lbl_postal.Text + "</td></tr>" +
             "</td></tr></table>");

            Response.Write(sw.ToString());

            Response.End();

        }

        protected void btn_pdf_Click(object sender, EventArgs e)
        {
            string caminhoCartao = "C:\\Users\\felip\\source\\repos\\CINEL\\CINEL\\template\\template_formulario_new.pdf";

            string caminhoPDFS = "C:\\Users\\felip\\source\\repos\\CINEL\\CINEL\\";

            string dadosPDF = caminhoPDFS + "\\dadosCinel.pdf";

            PdfReader pdfReader1 = new PdfReader(caminhoCartao);
            PdfReader pdfReader = pdfReader1;

            PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(dadosPDF, FileMode.Create));

            AcroFields pdfFields = pdfStamper.AcroFields;

            pdfFields.SetField("nome", lbl_nome.Text);
            pdfFields.SetField("morada", lbl_morada.Text);
            pdfFields.SetField("palavra passe", lbl_passe.Text);
            pdfFields.SetField("palavra passe encriptada", lbl_encriptada.Text);
            pdfFields.SetField("curso", lbl_curso.Text);
            pdfFields.SetField("email", lbl_email.Text);
            pdfFields.SetField("código postal", lbl_postal.Text);

            pdfStamper.Close();
            Response.Redirect("https://localhost:44399/dadosCinel.pdf");

        }

        protected void btn_enviar_Click(object sender, EventArgs e)
        {
            MailMessage mail = new MailMessage();
            SmtpClient servidor = new SmtpClient();

            mail.From = new MailAddress(tb_de.Text);
            mail.To.Add(new MailAddress(tb_para.Text));
            mail.Subject = tb_assunto.Text;

            mail.IsBodyHtml = true;
            mail.Body = tb_mensagem.Text;

            System.Net.Mail.Attachment anexo;
            anexo = new System.Net.Mail.Attachment(FileUpload1.FileContent, FileUpload1.FileName);
            mail.Attachments.Add(anexo);



            servidor.Host = "smtp.office365.com";
            servidor.Port = 587;

            string passe = ConfigurationManager.AppSettings["pw"];

            servidor.Credentials = new System.Net.NetworkCredential
                ("Felipe.Sales.22766@formandos.cinel.pt", passe);

            servidor.EnableSsl = true;
            servidor.Send(mail);

            lbl_mensagem.Text = "Email enviado com sucesso";
        }
    }
}