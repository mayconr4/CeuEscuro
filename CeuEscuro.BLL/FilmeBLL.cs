using CeuEscuro.DAL;
using CeuEscuro.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeuEscuro.BLL
{
    public class FilmeBLL
    {
        //objeto para acessar os recursos da camada DAL
        FilmeDal objBLL = new FilmeDal();

        //CRUD
        //Create
        public void CreateFilm(FilmeDTO filme)
        {
            objBLL.Create(filme);
        }

        //Read
        public List<FilmeDTO> GetFilm_Film()
        {
            return objBLL.Get_Film();
        }

        //Update
        public void UpdateFilm(FilmeDTO filme)
        {
            objBLL.Update(filme);
        }

        //Delete
        public void DeleteFilm(int filmeId)
        {
            objBLL.Delete(filmeId);
        }

        //Search by Id
        public FilmeDTO SearchByIdFilm(int filmId)
        {
            return objBLL.SearchById(filmId);
        }


        //Load DropDownListClassif
        public List<ClassificacaoDTO> LoadDDLClassif_Classif()
        {
            return objBLL.LoadDDLClassif();
        }

        //Load DropDownListGenero
        public List<GeneroDTO> LoadDDLGenero_Genero()
        {
            return objBLL.LoadDDLGenero();
        }

        //Search by Name
        public FilmeDTO SearchByNameFilm(string titulo)
        {
            return objBLL.SearchByName(titulo);

        } 

        //Filtrar
        public List<FilmeDTO> FiltrarFilmeBLL(string objFilter)
        {
            return objBLL.FiltrarFilme(objFilter);
        }






    }
}
