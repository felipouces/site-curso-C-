using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Web.Services.Description;
using System.Security.Cryptography;


namespace CINEL
{
    public partial class Inscricao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["entrou"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (!Page.IsPostBack)
            {
                lbl_curso.Text = Session["curso"].ToString();
            }

        }

        protected void btn_submeter_Click(object sender, EventArgs e)
        {
            Session["Palavra-Passe"] = tb_passe;

            Regex maiusculas = new Regex("[A-Z]");
            Regex minusculas = new Regex("[a-z]");
            Regex numeros = new Regex("[0-9]");
            Regex especial = new Regex("[^a-zA-Z0-9]");
            Regex plica = new Regex("'");
            Regex email = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
            Regex c_postal = new Regex(@"^\d{4}(-\d{3})?$");

            string situacao = "forte";

            if (string.IsNullOrEmpty(tb_nome.Text))
            {
                situacao = "fraco";
                Response.Write("O campo nome, não pode estar vazio!");
            }
            if (string.IsNullOrEmpty(tb_morada.Text))
            {
                situacao = "fraco";
                Response.Write("O campo da morada, não pode estar vazio!");
            }
            if (email.Matches(tb_email.Text).Count == 0)
            {
                situacao = "fraco";
                Response.Write("Email Inválido!");
            }
            if (tb_passe.Text.Length < 6)
            {
                situacao = "fraco";
            }
            if (maiusculas.Matches(tb_passe.Text).Count < 1)
            {
                situacao = "fraco";
            }
            if (minusculas.Matches(tb_passe.Text).Count < 1)
            {
                situacao = "fraco";
            }
            if (especial.Matches(tb_passe.Text).Count < 1)
            {
                situacao = "fraco";
            }
            if (numeros.Matches(tb_passe.Text).Count < 1)
            {
                situacao = "fraco";
            }
            if (plica.Matches(tb_passe.Text).Count != 0)
            {
                situacao = "fraco";
            }
            if (!c_postal.IsMatch(tb_postal.Text))
            {
                situacao = "fraco";
                Response.Write("Código postal inválido!");
            }

            lbl_mensagem.Text = situacao;

            if (situacao == "forte")
            {
                Session["Palavra-Passe"] = tb_passe.Text;
                Session["nome"] = tb_nome.Text;
                Session["morada"] = tb_morada.Text;
                Session["encriptada"] = tb_encriptada.Text;
                Session["curso"] = lbl_curso.Text;
                Session["email"] = tb_email.Text;
                Session["postal"] = tb_postal.Text;

                Response.Redirect("Dados.aspx");
            }

        }
        protected void btn_limpar_Click(object sender, EventArgs e)
        {
            Response.Redirect("inscricao.aspx");
        }

        protected void tb_passe_TextChanged(object sender, EventArgs e)
        {
            tb_encriptada.Text = EncryptString(tb_passe.Text);
            

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
    }
}