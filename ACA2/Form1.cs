using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACA2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboFuncion.SelectedIndex = 0;
            rbtnNo.Checked = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            calcular();

        }
        private void calcular()
        {
            string nombre = txtNombre.Text;
            int cantidadBoletas = 0;
            string funcion = comboFuncion.SelectedItem.ToString();
            bool tieneTarjeta = rbtnSi.Checked;
            try
            {
                cantidadBoletas = int.Parse(txtCantidadBoletas.Text);
                System.Diagnostics.Debug.WriteLine($"{funcion} {cantidadBoletas.ToString()} {nombre}");
            }
            catch (FormatException formatException)
            {
                mostrarError("Debes ingresar un valor numerico en el campo cantidad boletas");
                return;
            }
            if (cantidadBoletas > 8)
            {
                mostrarError("la cantidad de boletas no debe sobrepasar de 8");
                return;
            }
            int precioUnitario = "3XD" == funcion ? 18500 : 12500;
            int subTotal = precioUnitario * cantidadBoletas;
            float total = 0;
            float descuento = 0;
            if (cantidadBoletas > 5)
            {
                descuento = (subTotal * 0.15f);
            }
            else if (cantidadBoletas >= 3 && cantidadBoletas <= 5)
            {
                descuento = (subTotal * 0.1f);
            }
            if (tieneTarjeta)
            {
                descuento += subTotal * 0.1f;
            }
            total = subTotal - descuento;
            lblCostoBoleta.Text = "$" + precioUnitario.ToString();
            lblCostoBoletas.Text = "$" + subTotal.ToString();
            lblDescuentos.Text = "$" + descuento.ToString();
            lblTotalPago.Text = "$" + total.ToString();
            
        }
        private void  limpiar(){
            lblCostoBoleta.Text = "$____________________";
            lblCostoBoletas.Text = "$____________________";
            lblDescuentos.Text = "$____________________";
            lblTotalPago.Text = "$____________________";
            txtCantidadBoletas.Text = "";
            txtNombre.Text = "";
            comboFuncion.SelectedIndex = 0;
            rbtnNo.Checked = true;
            rbtnSi.Checked = false;
            
        }   
       

        private void mostrarError(string mensaje)
        {            
            Form2 form = new Form2(mensaje);
            form.ShowDialog(this);

            lblCostoBoleta.Text = "####################";
            lblCostoBoletas.Text = "####################";
            lblDescuentos.Text = "####################";
            lblTotalPago.Text = "####################";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    
}
