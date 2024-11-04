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
            var repo = new PatientRepository();

            List<Patient> patients = repo.GetPatients();

            /*string text = "";
            foreach (Patient pat in patients)
            {
                text += $"Name: {pat.Name}\n" +
                                              $"Mobile Phone: {pat.Mobile_Phone}\n" +
                                              $"Gender: {pat.Gender}\n";
            }

            label1.Text = text;*/


            Patient pat = repo.GetPatient(2);
            if (pat != null)
            {
                label1.Text = $"Name: {pat.Name}\n" +
                              $"Mobile Phone: {pat.Mobile_Phone}\n" +
                              $"Gender: {pat.Gender}\n";
            }
            else
            {
                label1.Text = "No patient found with the specified ID.";
            }
        }
    }
}
