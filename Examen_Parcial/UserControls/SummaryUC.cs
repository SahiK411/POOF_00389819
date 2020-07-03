using System;
using System.Data;
using System.Windows.Forms;
using Examen.Classes;
using Examen.DecoratorPattern;

namespace Examen.UserControls
{
    public partial class SummaryUC : UserControl
    {
        public delegate void ButtonClick(UserControl uc);
        public ButtonClick BackButton;
        public SummaryUC()
        {
            InitializeComponent();

            //Primer Tab
            var dt = DBConnect.ExecuteQuery("SELECT * FROM registros ORDER BY fechaRegistro, horaRegistro ASC");
            dataGridView1.DataSource = dt;

            //SegundoTab
            var ep = DBConnect.ExecuteQuery("SELECT idUsuario, COUNT(idUsuario) FROM registros GROUP BY idUsuario;");
            var rc = ep.Rows.Count;
            DataTable newDT = new DataTable();
            newDT.Columns.Clear();
            newDT.Columns.Add("idUsuarios");
            newDT.Columns.Add("count");
            for(int i = 0; i < rc; i++)
            {
                var dr = ep.Rows[i];
                if(Convert.ToInt32(dr[1].ToString()) % 2 != 0)
                {
                    newDT.Rows.Add(dr);
                }
            }

            newDT.Columns.RemoveAt(1);
            dataGridView2.DataSource = newDT;

            //Tercer Tab
            var pd = DBConnect.ExecuteQuery($"SELECT d.nombre, count(u.idDepartamento) as frecuencia FROM REGISTRO r, " +
                $"DEPARTAMENTO d, USUARIO u WHERE r.idUsuario = u.idUsuario AND d.idDepartamento = u.idDepartamento " +
                $"GROUP BY d.idDepartamento ORDER BY frecuencia DESC LIMIT 1;");
            dataGridView3.DataSource = pd;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BackButton?.Invoke(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dt = DBConnect.ExecuteQuery("SELECT * FROM registros ORDER BY fechaRegistro, horaRegistro DESC");
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var ep = DBConnect.ExecuteQuery("SELECT idUsuario, COUNT(idUsuario) FROM registros GROUP BY idUsuario;");
            var rc = ep.Rows.Count;
            DataTable newDT = new DataTable();
            newDT.Columns.Clear();
            newDT.Columns.Add("idUsuarios");
            newDT.Columns.Add("count");
            for (int i = 0; i < rc; i++)
            {
                var dr = ep.Rows[i];
                if (Convert.ToInt32(dr[1].ToString()) % 2 != 0)
                {
                    newDT.Rows.Add(dr);
                }
            }

            newDT.Columns.RemoveAt(1);
            dataGridView2.DataSource = newDT;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var pd = DBConnect.ExecuteQuery($"SELECT d.nombre, count(u.idDepartamento) as frecuencia FROM REGISTRO r, " +
                $"DEPARTAMENTO d, USUARIO u WHERE r.idUsuario = u.idUsuario AND d.idDepartamento = u.idDepartamento " +
                $"GROUP BY d.idDepartamento ORDER BY frecuencia DESC LIMIT 1;");
            dataGridView3.DataSource = pd;
        }
    }
}
