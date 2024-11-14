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





            /*Patient pat = repo.GetPatient(2);
            if (pat != null)
            {
                label1.Text = $"Name: {pat.Name}\n" +
                              $"Mobile Phone: {pat.Mobile_Phone}\n" +
                              $"Gender: {pat.Gender}\n";
            }
            else
            {
                label1.Text = "No patient found with the specified ID.";
            }*/
        }

        private void Clients_Load(object sender, EventArgs e)
        {
            var repo = new PatientRepository();

            List<Patient> patients = repo.GetPatients();

            var patientView = patients.Select(p => new
            {
                p.Id,
                p.Name,
                p.Mobile_Phone,
                p.Gender
            }).ToList();

            grid.DataSource = patientView;
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
    }
}
