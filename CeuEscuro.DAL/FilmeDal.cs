using CeuEscuro.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeuEscuro.DAL
{
    public class FilmeDal : Conexao
    {

        //CRUD
        //Create
        public void Create(FilmeDTO filme)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("INSERT INTO Filme (Titulo,Produtora,UrlImg,Classificacao_Id) VALUES (@Titulo,@Produtora,@UrlImg,@TipoFilme_Dal);", conn);                 
                cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                cmd.Parameters.AddWithValue("@Produtora", filme.Produtora);
                cmd.Parameters.AddWithValue("@UrlImg", filme.UrlImg);
                cmd.Parameters.AddWithValue("@Classificacao_Id", filme.Classificacao_Id);
                cmd.Parameters.AddWithValue("@Genero_Id", filme.Genero_Id);
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();

            }

        }


        //Update
        public void Update(FilmeDTO filme)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("UPDATE Filme SET Id = @Id, Titulo = @Titulo, Produtora = @Produtora,UrlImg = @UrlImg,Classificacao_Id = @Classificacao_Id WHERE Genero_Id = @Genero_Id;", conn);
                cmd.Parameters.AddWithValue("@Id", filme.Id);
                cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                cmd.Parameters.AddWithValue("@Produtora", filme.Produtora);
                cmd.Parameters.AddWithValue("@UrlImg", filme.UrlImg);
                cmd.Parameters.AddWithValue("@Classificacao_Id", filme.Classificacao_Id);
                cmd.Parameters.AddWithValue("@Genero_Id", filme.Genero_Id);
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            finally
            {
                Desconectar();


            }

        }

       

        //Delete
        public void Delete(int filmeId)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("DELETE FROM Filme WHERE Filme.Id = @Filme.Id;", conn);
                cmd.Parameters.AddWithValue("@Filme.Id", filmeId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {


            }

        }

        //Read
        public List<FilmeDTO> Get_Film()
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT Filme.Id,Titulo,Produtora, UrlImg, Genero.Descricao, DescricaoClassif FROM Filme INNER JOIN Genero ON Genero_Id = Genero.Id INNER JOIN Classificacao ON Filme.Classificacao_Id = Classificacao.Id;", conn);
                dr = cmd.ExecuteReader();
                List<FilmeDTO> lista = new List<FilmeDTO>();// lista vazia
                while (dr.Read())
                {
                    FilmeDTO obj = new FilmeDTO();
                    obj.Id = Convert.ToInt32(dr["Id"]);
                    obj.Titulo = dr["Titulo"].ToString();
                    obj.Produtora = dr["Produtora"].ToString();
                    obj.UrlImg = dr["UrlImg"].ToString();
                    obj.Classificacao_Id = dr["DescricaoClassif"].ToString();
                    obj.Genero_Id = dr["Descricao"].ToString();

                    //adicionar a lista
                    lista.Add(obj);

                }

                return lista;
            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }



            finally
            {
                Desconectar();


            }



        }

        //Search by Id
        public FilmeDTO SearchById(int filmeId)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT * FROM Filme WHERE Filme.Id = @Filme.Id;", conn);
                cmd.Parameters.AddWithValue("@Filme.Id", filmeId);
                dr = cmd.ExecuteReader();
                FilmeDTO filme = new FilmeDTO();
                if (dr.Read())
                {
                    filme = new FilmeDTO();
                    filme.Id = Convert.ToInt32(dr["Id"]);
                    filme.Titulo = dr["Titulo"].ToString();
                    filme.Produtora = dr["Produtora"].ToString();
                    filme.UrlImg = dr["UrlImg"].ToString();
                    
                    filme.Classificacao_Id = dr["Classificacao_Id"].ToString();
                    filme.Genero_Id = dr["Genero_Id"].ToString();

                }
                return filme;








            }


            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();

            }

        }

        //Load DropDownListClassif
        public List<ClassificacaoDTO> LoadDDLClassif()
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT * FROM Classificacao;", conn);
                dr = cmd.ExecuteReader();
                List<ClassificacaoDTO> Lista = new List<ClassificacaoDTO>();
                while (dr.Read())
                {
                    ClassificacaoDTO classificacao = new ClassificacaoDTO();
                    classificacao.Id = Convert.ToInt32(dr["Id"]);
                    classificacao.DescricaoClassif = dr["DescricaoClassif"].ToString();
                    Lista.Add(classificacao);
                }
                return Lista;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Load DropDownListGenero
        public List<GeneroDTO> LoadDDLGenero()
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT * FROM Genero;", conn);
                dr = cmd.ExecuteReader();
                List<GeneroDTO> Lista = new List<GeneroDTO>();
                while (dr.Read())
                {
                    GeneroDTO genero = new GeneroDTO();
                    genero.Id = Convert.ToInt32(dr["Id"]);
                    genero.Descricao = dr["Descricao"].ToString();
                    Lista.Add(genero);
                }
                return Lista;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }


        //Search by Name
        public FilmeDTO SearchByName(string titulo)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT * FROM Filme WHERE Titulo = @Titulo ;", conn);
                cmd.Parameters.AddWithValue("@Titulo", titulo);
                dr = cmd.ExecuteReader();
                FilmeDTO filme = new FilmeDTO();
                if (dr.Read())
                {
                    filme = new FilmeDTO();
                    filme.Id = Convert.ToInt32(dr["Id"]);
                    filme.Titulo = dr["Titulo"].ToString();
                    filme.Produtora = dr["Produtora"].ToString();
                    filme.UrlImg = dr["UrlImg"].ToString();
                    filme.Classificacao_Id = dr["Classificacao_Id"].ToString();
                    filme.Genero_Id = dr["Genero_Id"].ToString();
                }
                return filme;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }

        }

        //Filtar por Genero
        public List<FilmeDTO> FiltrarFilme(string genero)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT  Filme.Id,Titulo,Produtora, UrlImg, Genero.Descricao, DescricaoClassif FROM Filme INNER JOIN Genero ON Genero_Id = Genero.Id INNER JOIN Classificacao ON Filme.Classificacao_Id = Classificacao.Id WHERE Descricao = @genero;", conn);
                cmd.Parameters.AddWithValue("@Genero", genero); //Genero.Descricao = DescricaoClassif // Filme WHERE Genero = @Genero  ;
                dr = cmd.ExecuteReader();
                List<FilmeDTO> Lista = new List<FilmeDTO>();
                if (dr.Read())
                {
                    FilmeDTO obj = new FilmeDTO();
                    obj.Id = Convert.ToInt32(dr["Id"]);
                    obj.Titulo = dr["Titulo"].ToString();
                    obj.Produtora = dr["Produtora"].ToString();
                    obj.UrlImg = dr["UrlImg"].ToString();
                    obj.Classificacao_Id = dr["Classificacao_Id"].ToString();
                    obj.Genero_Id = dr["Descricao"].ToString(); 

                    Lista.Add(obj);
                }
                return Lista;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }

            
        }
             


    } 
}
