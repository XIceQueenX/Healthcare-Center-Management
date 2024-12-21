using Gestao_Centro_Saude.models;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Gestao_Centro_Saude.repository;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using Gestao_Centro_Saude.ui;
using Gestao_Centro_Saude.services;


namespace Gestao_Centro_Saude
{
    public partial class Clients : Form
    {

        PatientServices patientServices = new PatientServices();
        public Clients()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListAllPatients listAllPatients = new ListAllPatients();
            listAllPatients.Show();
        }

        private void Clients_Load(object sender, EventArgs e)
        {
            grid.DataSource = patientServices.GetPatients();
        }

        private void onClickGridCell(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = grid.Rows[e.RowIndex];
                int patientId = (int)selectedRow.Cells["Id"].Value;

                PatientDetails addNewUser = new PatientDetails(patientId);
                addNewUser.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListAllAppointments listAllAppointments = new ListAllAppointments();
            listAllAppointments.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddStaff addStaff = new AddStaff();
            addStaff.Show();
        }
    }
}
