<%@ Page Title="" Language="C#" MasterPageFile="~/master_page2.Master" AutoEventWireup="true" CodeBehind="Inscricao.aspx.cs" Inherits="CINEL.Inscricao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p  >
    Nome   :
    <asp:TextBox ID="tb_nome" runat="server"  Width="285px"></asp:TextBox>
</p>
<p>
    Morada   :
    <asp:TextBox ID="tb_morada" runat="server" TextMode="MultiLine" Width="285px"></asp:TextBox>
</p>
<p>
    Palavra-Passe   :
    <asp:TextBox ID="tb_passe" runat="server" Width="229px" OnTextChanged="tb_passe_TextChanged" ></asp:TextBox>
    <asp:Button ID="btn_Encriptar" runat="server" Text="Encriptar" Width="115px" />
</p>
<p>
    Palavra-Passe Encriptada   :
    <asp:TextBox ID="tb_encriptada" runat="server" Width="229px"></asp:TextBox>
</p>
<p>
    Curso   :
    <asp:Label ID="lbl_curso" runat="server" Text="Label" Width="295px"></asp:Label>
</p>
<p>
    Email   :
    <asp:TextBox ID="tb_email" runat="server" TextMode="Email" Width="307px"></asp:TextBox>
</p>
<p>
    Código-postal   :
    <asp:TextBox ID="tb_postal" runat="server" Width="211px"></asp:TextBox>
    &nbsp;&nbsp;
    </p>
<p>
    &nbsp;</p>
<p>
    <asp:Label ID="lbl_mensagem" runat="server" Text="."></asp:Label>
</p>
    <p>
        &nbsp;</p>
    <p>
</p>
    <p>
        <asp:Button ID="btn_submeter" runat="server" ForeColor="#3399FF" Text="Submeter" Width="98px" OnClick="btn_submeter_Click" />
&nbsp;&nbsp;
        <asp:Button ID="btn_limpar" runat="server" BackColor="#0066FF" BorderColor="White" Font-Italic="True" ForeColor="White" OnClick="btn_limpar_Click" Text="Limpar" Width="87px" />
</p>
    <p>
</p>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
</asp:Content>
