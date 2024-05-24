using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CeuEscuro.DAL;
using CeuEscuro.DTO;




namespace CeuEscuro.BLL
{
    public class UsuarioBLL
    {
        //objeto para acessar os recursos da camada DAL
        UsuarioDAL objBLL = new UsuarioDAL();

        UsuarioDTO usuarioDTO = new UsuarioDTO();


        public UsuarioDTO AutenticaUser(string objNome, string objSenha)

        {
            return usuarioDTO = objBLL.Autenticar(objNome, objSenha);


             



        }

        //CRUD
        //Create
        public void CreateUser(UsuarioDTO usuario)
        {
            objBLL.Create(usuario);


        }

        //Read 
        public List<UsuarioDTO> GetUsers_User()
        {
            return objBLL.GetUsers();
        }

        //Update
        public void UpdateUser(UsuarioDTO usuario)
        {
            objBLL.Update(usuario);
        }

        //Delete
        public void DeleteUser(int usuarioId)
        {
            objBLL.Delete(usuarioId);
        }

        //Search by Id
        public UsuarioDTO SearchByIdUser(int usuarioId)
        {
            return objBLL.SearchById(usuarioId);
        }

        //Load DropDownList
        public List<TipoUsuarioDTO> LoadDDl_TpUser()
        {
            return objBLL.LoadDDL();

        }

        //Search by Name
        public UsuarioDTO SearchBynameUser(string nome)
        {
            return objBLL.SearchByName(nome);
        }




    }
}
