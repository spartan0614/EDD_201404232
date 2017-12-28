using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameClient
{
    public partial class Admin : System.Web.UI.Page
    {
        webServerNW.ProyectoEDDSoapClient servicio = new webServerNW.ProyectoEDDSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void agregarUsuario_Click(object sender, EventArgs e) {
            string nickname = txtNickname.Text;
            string password = txtPassword.Text;
            string email = txtCorreo.Text;

            if ((string.IsNullOrEmpty(nickname)) || (string.IsNullOrEmpty(password)) || (string.IsNullOrEmpty(email)))
            {
                //Mostrar un texto que indique que se necesita llenar los campos
            }
            else {
                servicio.AddNewUser(nickname, password, email, 0);
                txtNickname.Text = "";
                txtPassword.Text = "";
                txtCorreo.Text = "";
                imgBinario.ImageUrl = servicio.ViewTree();
                //imgBinario.ImageUrl = servicio.ViewTree();
            }
        } 

        protected void eliminarUsuario_Click(object sender, EventArgs e)
        {
            string nickname = txtEliminar.Text;
            if (string.IsNullOrEmpty(nickname))
            {
                //Mostrar un texto que indique que se necesita llenar el campo
            }
            else {
                servicio.DeleteUser(nickname);
            }
        }

        protected void cargarUsuarios_Click(object sender, EventArgs e)
        {
            
        }

        protected void altura_Click(object sender, EventArgs e)
        {
            lblAltura.Text = servicio.getHeigth().ToString();
        }

        protected void niveles_Click(object sender, EventArgs e)
        {
            lblNiveles.Text = servicio.getLevels().ToString();
        }

        protected void hojas_Click(object sender, EventArgs e)
        {
            lblHojas.Text = servicio.getLeaves().ToString();
        }

        protected void ramas_Click(object sender, EventArgs e)
        {
            lblRamas.Text = servicio.getBranches().ToString();
        }

    }
}