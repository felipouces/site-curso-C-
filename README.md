# Site-curso-C#
O objetivo deste projeto é o desenvolvimento de um site, em ambiente Web, utilizando as seguintes 
tecnologias:
• ASPX
• CSHARP
• HTML
• CSS
• XML
• XSLT
## Descrição
O projeto .Net criado no Visual Studio, é composto por 4 páginas

• Login.aspx 
-> Esta página permitirá ao utilizador autenticar-se com o utilizador “user” ou “USER” e a 
palavra-passe “123456”. Utilizar validadores e mensagens de erro caso o 
utilizador/palavra-passe estejam errados. Após autenticação o utilizador deverá ser 
redirecionado para a página “App.aspx”.

• App.aspx 
-> Esta página apresenta a mensagem de bem-vindo e o nome do utilizador e uma outra 
mensagem com a data e horas atuais;
-> Contém duas DropDownlists, uma com o Regime (diurno / noturno) e outra com os 
cursos. Os cursos que aparecem na DropDownlist dos cursos dependem do regime 
selecionado na DropDownlist do Regime;
-> Apresenta também um botão de redireccionamento para a página “Inscricao.aspx”;
-> Para além disso existi uma área dinâmica que apresente as últimas 10 notícias 
relacionadas com “Tecnologia”

• Inscricao.aspx 
Contém um formulário com os campos:
▪ Nome – Textbox – campo obrigatório
▪ Morada – Textbox multiline – campo obrigatório
▪ Palavra-Passe – Textbox – garantir que a palavra-passe é forte;
▪ Palavra-Passe encriptada – Textbox – apresenta a palavra-passe escolhida no 
campo anterior de forma encriptada;
▪ Curso – Label preenchida com o curso selecionado na página anterior (App.aspx);
▪ Email – Textbox – Campo obrigatório e o email tem de ser válido;
▪ Código-postal – Textbox – Campo obrigatório e no formato 1111-111;
-> Esta página terá um botão de “submeter” e outro de “limpar”. O botão “submeter” 
redireciona para a página “Dados.aspx” caso os validadores tenham sido “ultrapassados”, 
o botão “limpar” limpa os campos que estejam preenchidos.

• Dados.aspx 
Deverá apresentar todos os dados que o utilizador preencheu na página anterior e tem os 
seguintes botões:
▪ EXCEL – exporta todo o conteúdo para EXCEL
▪ WORD – exporta todo o conteúdo para WORD
▪ PDF – exporta todo o conteúdo para um PDF utilizando um template
• Mostra o PDF gerado no ecran
▪ ENVIAR POR EMAIL – envia, em anexo, o PDF gerado com base num template
para o endereço de email preenchido

