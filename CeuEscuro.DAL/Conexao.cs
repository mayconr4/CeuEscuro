using MySql.Data.MySqlClient;//
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CeuEscuro.DAL
{ }
    public class Conexao
    {
     //variaveis
     protected MySqlConnection conn;
     protected MySqlCommand cmd;
     protected MySqlDataReader dr;

        //metodos
        protected void Conectar()
        {
            try
            {
             conn = new MySqlConnection("Data Source = localhost; Initial Catalog = CeuEscuroDB; Uid = root ; Pwd = ;");  
             conn. Open();
            }
            catch (System.Exception ex)
            {

                throw new Exception($"Deu problema na conexão !!!){ex.Message}");
            }


        }

        
           protected void Desconectar()
           {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }






    }
}
