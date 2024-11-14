using Gestao_Centro_Saude.models;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Gestao_Centro_Saude.repository;
using static System.Net.Mime.MediaTypeNames;
using System.IO;


namespace Gestao_Centro_Saude
{
    public partial class Clients : Form
    {
        public Clients()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNewUser addNewUser = new AddNewUser();
            addNewUser.Show();
        }

        private void Clients_Load(object sender, EventArgs e)
        {

            grid.DataSource = Patient.GetPatients();
        }

        private void onClickGridCell(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = grid.Rows[e.RowIndex];
                int patientId = (int)selectedRow.Cells["Id"].Value;

                PatientDetails.ShowPatientDetails(patientId);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
