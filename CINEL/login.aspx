<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="CINEL.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>

    <style>
    body {
      font-family: Arial, sans-serif;
    }
    
    .container {
      width: 300px;
      margin: 0 auto;
      margin-top: 100px;
      border: 5px solid #ccc;
      padding: 20px;
      text-align: center;
      border-color: #FF0000;
    }
    
    input[type="text"],
    input[type="password"] {
      padding: 10px;
      margin-bottom: 10px;
      box-sizing: border-box;
    }
    
    input[type="submit"] {
      width: 100%;
      padding: 10px;
      background-color: #1b14e0;
      color: #fff;
      border-style: double;
      cursor: pointer;
    }
    .auto-style1 {
      width: 200px;
      height: 80px;
     }
    h2 {
        color: #0000FF;
    }
  </style>

</head>
<body>
     <div class="container">

    <form id="form1" runat="server">

    <h2>
        <img alt="" class="auto-style1" src="logo257x45.png" /></h2>
        <br />
        <h2>Login </h2>
      <p>Utilizador:
           <asp:TextBox ID="tb_utilizador" runat="server" class="form-control"  Width="225px"></asp:TextBox>
             </p>
            
      <br>
     <p>Palavra-passe:
         <asp:TextBox ID="tb_ppasse" runat="server" Width="224px" TextMode="Password"></asp:TextBox>
             </p>
             <br />
             <br />
      <asp:Label ID="lbl_mensagem" runat="server" ForeColor="#CC3300" Text="Utilizador ou palavra-passe errados" Visible="False"></asp:Label>
             <br />
      <br>
      
         <br />
        <asp:Button ID="btn_entrar" runat="server" Text="ENTRAR" OnClick="btn_entrar_Click" />
      
         </form>
  </div>
</body>
</html>
