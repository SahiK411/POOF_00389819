using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Examen.Classes;
using Examen.DecoratorPattern;

namespace Examen.UserControls
{
    public partial class LogInView : UserControl
    {
        public LogInView()
        {
            InitializeComponent();
        }

        private void Button1_Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button2_LogIn(object sender, EventArgs e)
        {
            try
            {
                string username = textBox1.Text;
                string password = textBox2.Text;
                if (username.Equals("") || password.Equals(""))
                {
                    MessageBox.Show("No se pueden dejar espacios en blanco.");
                    return;
                }

                SearchUsers();
                IDisplay display = null;

                var dt = DBConnect.ExecuteQuery($"SELECT contrasena FROM usuarios WHERE idUsuario = '{username}'");
                var dr = dt.Rows[0];
                var dbPass = dr[0].ToString();

                if (password.Equals(dbPass))
                {
                    dt = DBConnect.ExecuteQuery($"SELECT idUsuario, nombre, apellido, rolusuario FROM usuarios " +
                        $"WHERE idUsuario = '{username}'");
                    User loggedInUser = new User(dt);
                    switch (loggedInUser.Type)
                    {
                        case User.UserTypeEnum.Employee:
                            display = new DUserView(new MainView(loggedInUser));
                            (display as DUserView).ConstructView();
                            ((display as DUserView).Display as UserControl).Dock = DockStyle.Fill;
                            ((display as DUserView).Display as UserControl).AutoSizeMode = AutoSizeMode.GrowAndShrink;
                            Parent.Controls.Add((display as DUserView).Display as UserControl);
                            Parent.Controls.Remove(this);
                            break;
                        case User.UserTypeEnum.Guard:
                            display = new DGuardView(new MainView(loggedInUser));
                            (display as DGuardView).ConstructView();
                            ((display as DGuardView).Display as UserControl).Dock = DockStyle.Fill;
                            ((display as DGuardView).Display as UserControl).AutoSizeMode = AutoSizeMode.GrowAndShrink;
                            Parent.Controls.Add((display as DGuardView).Display as UserControl);
                            Parent.Controls.Remove(this);
                            break;
                        case User.UserTypeEnum.Admin:
                            display = new DAdminView(new MainView(loggedInUser));
                            (display as DAdminView).ConstructView();
                            ((display as DAdminView).Display as UserControl).Dock = DockStyle.Fill;
                            ((display as DAdminView).Display as UserControl).AutoSizeMode = AutoSizeMode.GrowAndShrink;
                            Parent.Controls.Add((display as DAdminView).Display as UserControl);
                            Parent.Controls.Remove(this);
                            break;
                        default:
                            throw new Exception("Error de Enum");
                    }
                    this.Dispose();
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchUsers()
        {
            var dt = DBConnect.ExecuteQuery($"SELECT idUsuario FROM usuarios WHERE idUsuario = '{textBox1.Text}'");

            if (dt.ExtendedProperties.Values.Count.Equals(0) && dt.Rows.Count == 0)
            {
                throw new Exception("Usuario no existe");
            }
        }
    }
}