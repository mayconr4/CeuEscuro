using CeuEscuro.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

using System.Web.UI.WebControls;

namespace CeuEscuro.UI.USER
{
    public partial class Consulta : System.Web.UI.Page
    {
        
        UsuarioBLL objBLL = new UsuarioBLL();
        

        protected void Page_Load(object sender, EventArgs e)
        {
                       

              PopularGV1(); 
        }

        //popular gv1
        public void PopularGV1()
        {
            gv1.DataSource = objBLL.GetUsers_User();
            gv1.DataBind();
        }

    }
}