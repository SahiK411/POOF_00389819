using System;
using System.Windows.Forms;
using Examen.Classes;

namespace Examen.UserControls
{
    public partial class ManageUC : UserControl
    {
        public delegate void ButtonClick(UserControl uc);
        public ButtonClick BackButton;
        public ManageUC()
        {
            InitializeComponent();
            
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Empleado");
            comboBox1.Items.Add("Vigilante");
            comboBox1.Items.Add("Administrador");

            var dt = DBConnect.ExecuteQuery($"SELECT * FROM usuarios");

            dataGridView1.DataSource = dt;

            dt = DBConnect.ExecuteQuery($"SELECT * FROM departamentos;");

            dataGridView2.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BackButton?.Invoke(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateID();
            }
            catch
            {
                return;
            }

            try
            {
                ValidateDeptID(textBox5.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            try
            {
                ValidateDUI();
            }
            catch
            {
                return;
            }

            try
            {
                ValidateDate();
            }
            catch
            {
                return;
            }

            string id = textBox1.Text;
            string name = textBox2.Text;
            string lastName = textBox3.Text;
            string password = textBox4.Text;
            int deptID = Convert.ToInt32(textBox5.Text);
            string dui = textBox6.Text;
            
            string role;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    role = "em";
                    break;
                case 1:
                    role = "gu";
                    break;
                case 2:
                    role = "ad";
                    break;
                default:
                    MessageBox.Show("Error de Rol");
                    return;
            }
            string date = textBox7.Text;

            DBConnect.ExecuteNonQuery($"INSERT INTO usuarios(idUsuario, nombre, apellido, contrasena, idDepartamento, dui, " +
                $"rolUsuario, fechaNacimiento) VALUES('{id}', '{name}', '{lastName}', '{password}', {deptID}, '{dui}', " +
                $"'{role}', '{date}');");

            MessageBox.Show("Operacion Completada Exitosamente.");
        }

        #region Validations
        private void ValidateID()
        {
            if (textBox1.Text.Length != 8)
            {
                MessageBox.Show("El carnet introducido no es valido.");
                throw new Exception();
            }
            string userID;
            try
            {
                userID = textBox1.Text;
                var idNumber = Convert.ToInt32(userID);
            }
            catch
            {
                MessageBox.Show("El carnet introducido no es valido.");
                throw new Exception();
            }
        }

        private void ValidateDUI()
        {
            if (textBox6.Text.Equals("########-#") || textBox6.Text.Length != 10)
            {
                MessageBox.Show("Por favor ingrese un DUI Valido");
                throw new Exception();
            }
            string dui = textBox6.Text;
            string substring = (dui.Substring(0, 8) + "-" + dui.Substring(9, 1));
            if (!dui.Equals(substring))
            {
                MessageBox.Show("Por favor ingrese un DUI Valido");
                throw new Exception();
            }
        }

        private void ValidateDate()
        {
            try
            {
                var dte = new DateTime(year: Convert.ToInt32($"{textBox7.Text.Substring(0, 3)}"), month: Convert.ToInt32($"{textBox7.Text.Substring(5, 2)}"), 
                    day: Convert.ToInt32($"{textBox7.Text.Substring(8, 2)}"));
            }
            catch
            {
                MessageBox.Show("Por favor ingrese la fecha en el formato YYYY/MM/DD");
            }
        }

        private void ValidateDeptID(string id)
        {
            var dt = DBConnect.ExecuteQuery($"SELECT idDepartamento FROM Departamentos WHERE idDepartamento = {Convert.ToInt32(id)}");

            if (dt.ExtendedProperties.Values.Count.Equals(0) && dt.Rows.Count == 0)
            {
                throw new Exception("Departamento Inexistente");
            }
        }

        private void ValidateUser(string id)
        {
            var dt = DBConnect.ExecuteQuery($"SELECT idUsuario FROM usuarios WHERE idUsuario = '{id}'");

            if (dt.ExtendedProperties.Values.Count.Equals(0) && dt.Rows.Count == 0)
            {
                throw new Exception("Usuario no existe");
            }
        }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateUser(textBox8.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            DBConnect.ExecuteNonQuery($"DELETE FROM usuarios WHERE idUsuario = '{textBox8.Text}'");
            MessageBox.Show("Operacion Completada Exitosamente.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var dt = DBConnect.ExecuteQuery($"SELECT * FROM usuarios");

            dataGridView1.DataSource = dt;
            MessageBox.Show("Operacion Completada Exitosamente.");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox10.Text.Length == 0 || textBox9.Text.Length == 0)
            {
                MessageBox.Show("No se pueden dejar espacios en blanco.");
                return;
            }

            if (textBox9.Text.Length > 50 || textBox10.Text.Length > 50)
            {
                MessageBox.Show("Error: Un nombre excede 50 caracteres.");
            }
            try
            {
                DBConnect.ExecuteNonQuery($"INSERT INTO departamentos(nombre, ubicacion) " +
                    $"VALUES('{textBox9.Text}', '{textBox10.Text}');");

                MessageBox.Show("Operacion Completada Exitosamente.");
            }
            catch
            {

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var dt = DBConnect.ExecuteQuery($"SELECT * FROM departamentos;");

            dataGridView2.DataSource = dt;
            MessageBox.Show("Operacion Completada Exitosamente.");
        }
    }
}
