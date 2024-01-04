<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.Master" AutoEventWireup="true" CodeBehind="App.aspx.cs" Inherits="CINEL.App" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:Label ID="lbl_hora" runat="server" Text="Label"></asp:Label>
        </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="lbl_utilizador" runat="server" Text="Label"></asp:Label>
        </p>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <p>
        Regime :
       
        <asp:DropDownList ID="ddl_regime" runat="server" BackColor="White" Font-Size="Large" ForeColor="Black" Height="28px" Width="101px" AutoPostBack="True" OnSelectedIndexChanged="ddl_regime_SelectedIndexChanged">
            <asp:ListItem>------</asp:ListItem>
            <asp:ListItem>Diurno</asp:ListItem>
            <asp:ListItem>Noturno</asp:ListItem>
            
        </asp:DropDownList>

    </p>
<p>
        &nbsp;</p>
<p>
        Curso :
        <asp:DropDownList ID="ddl_curso" runat="server" BackColor="White" Font-Size="Medium" ForeColor="Black" Height="28px" Width="214px">
        </asp:DropDownList>

    </p>
<p>
        &nbsp;</p>
<p>
        <asp:Button ID="btn_inscricao" runat="server" BackColor="White" Font-Size="Medium" ForeColor="Black" OnClick="btn_inscricao_Click" Text="Inscrição" Width="164px" />

    </p>
    <p>
        &nbsp;</p>
    <h2>
        Abaixo confira, as notícias sobre tecnologia!!!</h2>
<p>
        &nbsp;</p>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:Xml ID="Xml1" runat="server"></asp:Xml>
</asp:Content>
