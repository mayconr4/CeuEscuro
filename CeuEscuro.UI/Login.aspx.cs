﻿using CeuEscuro.BLL;
using CeuEscuro.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CeuEscuro.UI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         txtNome.Focus();

        }
        //btnCancelar
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
         txtNome.Text = txtSenha.Text = string.Empty;
         txtNome.Focus();
        }
        //btnEntrar
        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            UsuarioDTO usuario = new UsuarioDTO();
          UsuarioBLL usuarioBLL = new UsuarioBLL();


            string nome = txtNome.Text;
            string senha = txtSenha.Text;

            usuario = usuarioBLL.AutenticaUser(nome,senha);

            if (usuario!= null)
            {
                switch (usuario.TipoUsuario_Id) 
                {
                    case "1":
                        Session["Usuario"]= usuario.Nome.Trim();
                        Response.Redirect("adm/User.aspx");
                        break;
                    case "2":
                        Session["Usuario"] = usuario.Nome.Trim();
                        Response.Redirect("user/Consulta.aspx");
                        break;

                }   
            }
            else
            {
                lblMensagem.Text = $"Usuario{txtNome.Text.ToUpper()} não cadastrado !!";

            }
        }   
    }
}