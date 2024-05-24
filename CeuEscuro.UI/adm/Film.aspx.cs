using CeuEscuro.BLL;
using CeuEscuro.DTO;
using CeuEscuro.UI.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CeuEscuro.UI.adm
{
    public partial class Film : System.Web.UI.Page
    {

        FilmeDTO objDTO = new FilmeDTO();
        FilmeBLL objBLL = new FilmeBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            if (!IsPostBack)
            {
                PopularGV2();
                PopularDDLClassif();
                PopularDDLGenero();
            }

        }

        //popular gv2
        public void PopularGV2()
        {
            gv2.DataSource = objBLL.GetFilm_Film();
            gv2.DataBind();
        }

        //popular ddlClassif
        public void PopularDDLClassif()
        {
            ddlClassif.DataSource = objBLL.LoadDDLClassif_Classif();
            ddlClassif.DataBind();

        }

        //popular ddlGenero
        public void PopularDDLGenero()
        {
            ddlGenero.DataSource = objBLL.LoadDDLGenero_Genero();
            ddlGenero.DataBind();

        }

        //Search by name
        public void Search(string titulo)
        {
            titulo = txtSearch.Text.Trim();
            objDTO = objBLL.SearchByNameFilm(titulo);
            if (string.IsNullOrEmpty(titulo))
            {
                lblSearch.Text = "Campo vazio !";
                txtSearch.Text = string.Empty;
                return;
            }
            else if (objDTO.Titulo == null)
            {
                lblSearch.Text = "Filme não cadastrado";
                txtSearch.Text = string.Empty;
                return;

            }
            else
            {
                lblSearch.Text = string.Empty;
                txtId.Text = objDTO.Id.ToString();
                txtTitulo.Text = objDTO.Titulo.ToString();
                txtProdutora.Text = objDTO.Produtora.ToString();
                ddlClassif.SelectedValue = objDTO.Classificacao_Id.ToString();
                ddlGenero.SelectedValue = objDTO.Genero_Id.ToString();
                txtSearch.Text = string.Empty;
                txtTitulo.Focus();
            }

        }

        //Search
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string titulo = txtSearch.Text.Trim();
            Search(titulo);
        }

        //select gv2
        protected void gv2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int filmeId = int.Parse(gv2.SelectedRow.Cells[1].Text);
            objDTO = objBLL.SearchByIdFilm(filmeId);
            txtId.Text = objDTO.Id.ToString();
            txtTitulo.Text = objDTO.Titulo.ToString();
            txtProdutora.Text = objDTO.Produtora.ToString();
            ddlClassif.SelectedValue = objDTO.Classificacao_Id.ToString();
            ddlGenero.SelectedValue = objDTO.Genero_Id.ToString();
            txtTitulo.Focus();
        }

        //Validation 
        public bool ValidaPage()
        {
            bool valid;
            if (string.IsNullOrEmpty(txtTitulo.Text))
            {
                lblTitulo.Text = "Digite o Título !!";
                txtTitulo.Focus();
                valid = false;

            }
            else if (string.IsNullOrEmpty(txtProdutora.Text))
            {
                lblProdutora.Text = "Digite a Produtora !!";
                txtProdutora.Focus();
                valid = false;

            }
            else if (!Fup.HasFile)
            {
                lblFup.Text = "Selecione uma imagem !!";
                Fup.Focus();
                valid = false;
            }
            else
            {
                valid = false;
            }
            return valid;

        }

        //record
        protected void btnRecord_Click(object sender, EventArgs e)
        {
            if (ValidaPage())
            {

                //pegando as informacoes do usuario
                objDTO.Titulo = txtTitulo.Text.Trim();
                objDTO.Produtora = txtProdutora.Text.Trim();
                objDTO.Classificacao_Id = ddlClassif.SelectedValue;
                objDTO.Genero_Id = ddlGenero.SelectedValue;
                //Imagem
                string str = Fup.FileName;
                Fup.PostedFile.SaveAs(Server.MapPath($"~/img/{str}"));
                string caminhoImg = $"~/img/{str}";
                objDTO.UrlImg = caminhoImg;

                //checando campo id
                if ((string.IsNullOrEmpty(txtProdutora.Text)))
                {
                    objBLL.CreateFilm(objDTO);
                    PopularGV2();
                    Clear.ClearControl(this);
                    txtSearch.Focus();
                    lblMessage.Text = $"O Filme {objDTO.Titulo} Foi cadastrado com sucesso !!";
                }
                else
                {
                    objDTO.Id = int.Parse(txtId.Text);
                    objBLL.UpdateFilm(objDTO);
                    PopularGV2();
                    Clear.ClearControl(this);
                    txtSearch.Focus();
                    lblMessage.Text = $"O Filme {objDTO.Titulo} Foi editado com sucesso !!";

                }
            }
            else { }







        }

        //Clear
        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear.ClearControl(this);
            txtSearch.Focus();
        }

        //delete
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            objDTO.Id = int.Parse(txtId.Text);
            objBLL.DeleteFilm(objDTO.Id);
            PopularGV2();
            Clear.ClearControl(this);
            txtSearch.Focus();
        }

        //metodo FiltrarGVFilme
        public void FiltrarGVFilme()
        {
            string objFilter = txtFiltro.Text;
            gv2.DataSource = objBLL.FiltrarFilmeBLL(objFilter);
            gv2.DataBind();
        }

        //Filter
        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            string objFilter = txtFiltro.Text;
            var result = objBLL.FiltrarFilmeBLL(objFilter);

            if (string.IsNullOrEmpty(txtFiltro.Text) || (result.Count == 0))
            {
                Clear.ClearControl(this);
                lblFiltro.ForeColor = System.Drawing.Color.Red;
                lblFiltro.Text = "Digite um gênero existente !!";
                txtFiltro.Focus();
                PopularGV2();
            }
            else
            {
                FiltrarGVFilme();
                Clear.ClearControl(this);
                txtFiltro.Focus();
                
            }
        }

        //ClearFilter
        protected void btnClearFilter_Click(object sender, EventArgs e)
        {
            PopularGV2();
            txtFiltro.Text = string.Empty;
            txtFiltro.Focus();
        }
    }



}