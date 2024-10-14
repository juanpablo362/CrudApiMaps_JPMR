using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Capas
using BLL;
using DAL;
namespace CrudUbicaciones_JPMR
{
    public partial class frmlUbicaciones : System.Web.UI.Page
    {
        UbicacionesBLL oubicacionesBLL;
        UbicacionesDAL oubicacionesDAL;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListarUbicaciones();
            }
        }

        // Método recargado de listar los datos de la BD en un GRIDView
        public void ListarUbicaciones()
        {
           oubicacionesDAL = new UbicacionesDAL();
           gvUbicaciones.DataSource = oubicacionesDAL.Listar(); ;
           gvUbicaciones.DataBind();
        }
    }
}