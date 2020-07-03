using System;
using System.Windows.Forms;
using Examen.Classes;

namespace Examen.UserControls
{
    public partial class HistoryUC : UserControl
    {
        public delegate void ButtonClick(UserControl uc);
        public ButtonClick BackButton;

        public HistoryUC(User user)
        {
            InitializeComponent();

            SearchRegistry(user.Id);

            var dt = DBConnect.ExecuteQuery($"SELECT entrada, fechaRegistro, horaRegistro, temperatura FROM " +
                $"Registros WHERE idUsuario = '{user.Id}'");

            dataGridView1.DataSource = dt;
        }

        private void SearchRegistry(string id)
        {
            var dt = DBConnect.ExecuteQuery($"SELECT idUsuario FROM Registros WHERE idUsuario = '{id}'");

            if (dt.ExtendedProperties.Values.Count.Equals(0) && dt.Rows.Count == 0)
            {
                throw new Exception("Usuario no existe");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BackButton?.Invoke(this);
        }
    }
}
