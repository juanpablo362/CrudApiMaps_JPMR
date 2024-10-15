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

        protected void LimpiarRegistros(object sender, EventArgs e)
        {
            oubicacionesDAL = new UbicacionesDAL();
            oubicacionesDAL.Limpiar();
            ListarUbicaciones();
        }                   


        // Método recargado de listar los datos de la BD en un GRIDView
        public void ListarUbicaciones()
        {
           oubicacionesDAL = new UbicacionesDAL();
           gvUbicaciones.DataSource = oubicacionesDAL.Listar();
           gvUbicaciones.DataBind();
        }

        // Método encardado de recoloctar los datos de nuestra interfaz
        public UbicacionesBLL datosUbicacion()
        {
            int ID = 0;
            int.TryParse(txtID.Value, out ID);
            oubicacionesBLL=new UbicacionesBLL();
            oubicacionesBLL.ID = ID;
            oubicacionesBLL.Ubicacion = txtUbicacion.Text;
            oubicacionesBLL.Latitud=txtLat.Text;
            oubicacionesBLL.Longitud = txtLong.Text;

            return oubicacionesBLL;
        }

        protected void AgregarRegistro(object sender, EventArgs e)
        {
            oubicacionesDAL=new UbicacionesDAL();
            oubicacionesDAL.Agregar(datosUbicacion());
            ListarUbicaciones(); // Para mostrarla en el GV
        }

        protected void ModificarRegistro(object sender, EventArgs e)
        {
            oubicacionesDAL= new UbicacionesDAL();
            oubicacionesDAL.Modificar(datosUbicacion());
            ListarUbicaciones();    
           
        }

        protected void EliminarRegistro(object sender, EventArgs e)
        {
            oubicacionesDAL=new UbicacionesDAL();
            oubicacionesDAL.Eliminar(datosUbicacion());
            ListarUbicaciones();
        }


        protected void SeleccionarRegistro(object sender, GridViewCommandEventArgs e)
        {
            int FilaSeleccionada = int.Parse(e.CommandArgument.ToString());

            txtID.Value = gvUbicaciones.Rows[FilaSeleccionada].Cells[1].Text;
            txtUbicacion.Text = gvUbicaciones.Rows[FilaSeleccionada].Cells[2].Text;
            txtLat.Text = gvUbicaciones.Rows[FilaSeleccionada].Cells[3].Text;
            txtLong.Text = gvUbicaciones.Rows[FilaSeleccionada].Cells[4].Text;
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
            btnAgregar.Enabled = true;  

          
        }
    }
}   