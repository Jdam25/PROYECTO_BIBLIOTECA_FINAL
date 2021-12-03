using PROYECTO_BIBLIOTECA.MODELOS.DAO;
using PROYECTO_BIBLIOTECA.MODELOS.ENTIDADES;
using PROYECTO_BIBLIOTECA.VISTAS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYECTO_BIBLIOTECA.CONTROLADORES
{
    public class Cliente_Controller
    {
        REGISTRAR vista;
        ClienteDAO clienteDAO = new ClienteDAO();
        Cliente cliente = new Cliente();
        string operacion = string.Empty;

        public Cliente_Controller(REGISTRAR view)
        {
            vista = view;
            vista.NuevoButton.Click += new EventHandler(Nuevo);
            vista.GuardarButton.Click += new EventHandler(Guardar);
            vista.Load += new EventHandler(Load);
            vista.ModificarButton.Click += new EventHandler(Modificar);
            vista.EliminarButton.Click += new EventHandler(Eliminar);
        }

        private void Eliminar(object sender, EventArgs e)
        {
            if (vista.RegistrardataGridView.SelectedRows.Count > 0)
            {
                bool elimino = clienteDAO.EliminarCliente(Convert.ToInt32(vista.RegistrardataGridView.CurrentRow.Cells[0].Value));
                if (elimino)
                {
                    MessageBox.Show("Cliente eliminado correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarClientes();
                }
                else
                {
                    MessageBox.Show("Cliente no se pudo eliminar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Modificar(object sender, EventArgs e)
        {
            if (vista.RegistrardataGridView.SelectedRows.Count > 0)
            {
                operacion = "Modificar";
                HabilitarControles();

                //vista.IdtextBox.Text = vista.RegistrardataGridView.CurrentRow.Cells["ID"].Value.ToString();
                vista.NombreTextBox.Text = vista.RegistrardataGridView.CurrentRow.Cells["NOMBRE"].Value.ToString();
                vista.NumeroTextBox.Text = vista.RegistrardataGridView.CurrentRow.Cells["NUMERO"].Value.ToString();
                vista.NombreLTextBox.Text = vista.RegistrardataGridView.CurrentRow.Cells["LIBRO"].Value.ToString();
                vista.FechaPTextBox.Text = vista.RegistrardataGridView.CurrentRow.Cells["FECHAP"].Value.ToString();
                vista.FechaETextBox.Text = vista.RegistrardataGridView.CurrentRow.Cells["FECHAE"].Value.ToString();
                vista.PreciotextBox.Text = vista.RegistrardataGridView.CurrentRow.Cells["PRECIO"].Value.ToString();

               
            }


        }

        private void Load(object sender, EventArgs e)
        {
            ListarClientes();
        }

        private void ListarClientes()
        {
            vista.RegistrardataGridView.DataSource = clienteDAO.GetClientes();
        }

       

        private void Guardar(object sender, EventArgs e)
        {
            if (vista.IdtextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.IdtextBox, "Ingrese una identidad");
                vista.IdtextBox.Focus();
                return;
            }
            if (vista.NombreTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.NombreTextBox, "Ingrese un nombre");
                vista.NombreTextBox.Focus();
                return;
            }
            if (vista.NumeroTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.NumeroTextBox, "Ingrese un numero");
                vista.NumeroTextBox.Focus();
                return;
            }
            if (vista.NombreLTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.NombreLTextBox, "Ingrese el nombre del libro");
                vista.NombreLTextBox.Focus();
                return;
            }
            if (vista.FechaPTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.FechaPTextBox, "Ingrese la fecha de prestamo");
                vista.FechaPTextBox.Focus();
                return;
            }
            if (vista.FechaETextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.FechaETextBox, "Ingrese el nombre del libro");
                vista.FechaETextBox.Focus();
                return;
            }
            if (vista.PreciotextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.PreciotextBox, "Ingrese el nombre del libro");
                vista.PreciotextBox.Focus();
                return;
            }

            //cliente.Id = vista.IdtextBox.Text;
            cliente.Nombre = vista.NombreTextBox.Text;
            cliente.Numero = vista.NumeroTextBox.Text;
            cliente.Libro = vista.NombreLTextBox.Text;
            cliente.FechaP = vista.FechaPTextBox.Text;
            cliente.FechaE = vista.FechaETextBox.Text;
            cliente.Precio = vista.PreciotextBox.Text;

            if (operacion == "Nuevo")
            {
                bool inserto = clienteDAO.InsertarNuevoCliente(cliente);
                if (inserto)
                {
                    MessageBox.Show("Cliente insertado correctamente");
                    DesabilitarControles();
                    LimpiarControles();
                    ListarClientes();
                }
                else
                {
                    MessageBox.Show("Cliente no se pudo insertar");
                }
            }
            else if (operacion == "Modificar")
            {
                cliente.Id = Convert.ToInt32(vista.IdtextBox.Text);
                bool modifico = clienteDAO.ActualizarCliente(cliente);
                if (modifico)
                {
                    MessageBox.Show("Cliente modificado correctamente", "Atanción", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DesabilitarControles();
                    LimpiarControles();
                    ListarClientes();
                }
                else
                {
                    MessageBox.Show("Cliente no se pudo modificar", "Atanción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void Nuevo(object sender, EventArgs e)
        {
            operacion = "Nuevo";
            HabilitarControles();
        }

        private void HabilitarControles()
        {
            vista.IdtextBox.Enabled = true;
            vista.NombreTextBox.Enabled = true;
            vista.NumeroTextBox.Enabled = true;
            vista.NombreLTextBox.Enabled = true;
            vista.FechaPTextBox.Enabled = true;
            vista.FechaETextBox.Enabled = true;
            vista.GuardarButton.Enabled = true;
            vista.PreciotextBox.Enabled = true;


            vista.ModificarButton.Enabled = true;
            vista.NuevoButton.Enabled = true;
        }

        private void LimpiarControles()
        {
            vista.IdtextBox.Clear();
            vista.NombreTextBox.Clear();
            vista.NumeroTextBox.Clear();
            vista.NombreLTextBox.Clear();
            vista.FechaPTextBox.Clear();
            vista.FechaETextBox.Clear();
            vista.PreciotextBox.Clear();
        }
        private void DesabilitarControles()
        {
            vista.IdtextBox.Enabled = false;
            vista.NombreTextBox.Enabled = false;
            vista.NumeroTextBox.Enabled = false;
            vista.NombreLTextBox.Enabled = false;
            vista.FechaPTextBox.Enabled = false;
            vista.FechaETextBox.Enabled = false;
            vista.GuardarButton.Enabled = false;
            

            vista.ModificarButton.Enabled = true;
            vista.NuevoButton.Enabled = true;
        }


    }
}
