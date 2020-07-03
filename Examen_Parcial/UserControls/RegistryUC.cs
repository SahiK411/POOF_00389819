using System;
using System.Windows.Forms;
using Examen.Classes;

namespace Examen.UserControls
{
    public partial class RegistryUC : UserControl
    {
        public delegate void ButtonClick(UserControl uc);
        public ButtonClick BackButton;
        public RegistryUC()
        {
            InitializeComponent();
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Entrada");
            comboBox1.Items.Add("Salida");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BackButton?.Invoke(this);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length != 8)
            {
                MessageBox.Show("El carnet introducido no es valido.");
                return;
            }

            string id;
            try
            {
                    id = textBox1.Text;
                    var idNumber = Convert.ToInt32(id);
            }
            catch
            {
                    MessageBox.Show("El carnet introducido no es valido.");
                    return;
            }

            double temperature;
            try
            {
                temperature = Convert.ToDouble(textBox2.Text);
            }
            catch
            {
                MessageBox.Show("La temperatura introducida no es valida.");
                return;
            }

            bool entrance;

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    entrance = true;
                    break;
                case 1:
                    entrance = false;
                    break;
                default:
                    MessageBox.Show("Error en la Situacion");
                    return;
            }

            var date = DateTime.Today.ToString();
            var hour = DateTime.Now.TimeOfDay.ToString();

            try
            {
            DBConnect.ExecuteNonQuery($"INSERT INTO registros(idUsuario, entrada, fechaRegistro, horaRegistro, temperatura) " +
                $"VALUES('{id}', {entrance}, '{date.Substring(6, 4) + "/" + date.Substring(3, 2) + "/" + date.Substring(0, 2)}', " +
                $"'{hour.Substring(0,2)}:{hour.Substring(3, 2)}:{hour.Substring(6,2)}', " +
                $"{temperature})");
                MessageBox.Show("Operacion Completada Exitosamente.");
            }
            catch
            {
                MessageBox.Show("Error de Conexion");
                return;
            }
        }
    }
}
