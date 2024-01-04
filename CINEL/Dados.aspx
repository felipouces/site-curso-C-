<%@ Page Title="" Language="C#" MasterPageFile="~/master_page3.Master" AutoEventWireup="true" CodeBehind="Dados.aspx.cs" Inherits="CINEL.Dados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <p style="color:blue;">
         Nome 
    </p>
       <asp:Label ID="lbl_nome" runat="server" Text="Label"></asp:Label><br />
    <br />
     <p style="color:blue;">
         Morada   
    </p>
       <asp:Label ID="lbl_morada" runat="server" Text="Label"></asp:Label><br />
    <br />
    <p style="color:blue;">
        Palavra passe   
    </p>
       <asp:Label ID="lbl_passe" runat="server" Text="Label"></asp:Label><br />
    <br />
    <p style="color:blue;">
        Palavra-Passe encriptada 
    </p>
        <asp:Label ID="lbl_encriptada" runat="server" Text="Label"></asp:Label><br />
    <br />
    <p style="color:blue;">
        Curso  
    </p>
        <asp:Label ID="lbl_curso" runat="server" Text="Label"></asp:Label><br />
    <br />
    <p style="color:blue;">
        Email   
    </p>
       <asp:Label ID="lbl_email" runat="server" Text="Label"></asp:Label><br />
    <br />
    <p style="color:blue;">
        Código postal  
    </p>
        <asp:Label ID="lbl_postal" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <br />

    <p>
        &nbsp;<asp:Button ID="btn_excel" runat="server" BackColor="Aqua" Font-Italic="True" ForeColor="Black" OnClick="btn_excel_Click" Text="Exportar Excel" Width="141px" />
        &nbsp;&nbsp;<asp:Button ID="btn_word" runat="server" BackColor="Aqua" ForeColor="Black" OnClick="btn_word_Click" Text="Exportar Word" Font-Italic="True" />
        <asp:Button ID="btn_pdf" runat="server" BackColor="#66FFFF" ForeColor="Black" OnClick="btn_pdf_Click" Text="Exportar PDF" Width="130px" Font-Italic="True" />
        </p>
    <p>
        &nbsp;</p>
    <h1 style="color:blue;">
        Enviar os dados por email<br />
    </h1>
    <br />
    <h3>De:<asp:TextBox ID="tb_de" runat="server" Width="350px" TextMode="Email"></asp:TextBox>
    </h3>
    <h3>Para:<asp:TextBox ID="tb_para" runat="server" Width="341px" TextMode="Email"></asp:TextBox>
    </h3>
    <h3>Assunto:<asp:TextBox ID="tb_assunto" runat="server" Width="292px"></asp:TextBox>
</h3>
<p>&nbsp;</p>
<p>
    <asp:TextBox ID="tb_mensagem" runat="server" Height="104px" TextMode="MultiLine" Width="453px"></asp:TextBox>
</p>
    <h3>
        Anexo:<asp:FileUpload ID="FileUpload1" runat="server" />
</h3>
<p>&nbsp;</p>
<p>
    <asp:Button ID="btn_enviar" runat="server" BackColor="#66FFFF" Font-Italic="True" ForeColor="Black" OnClick="btn_enviar_Click" Text="Enviar" Width="93px" />
</p>
<p>&nbsp;</p>
<p>
    <asp:Label ID="lbl_mensagem" runat="server"></asp:Label>
</p>
    

    

    

</asp:Content>

