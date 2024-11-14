using Gestao_Centro_Saude.models;
using Gestao_Centro_Saude.repository;
using System;
using System.Windows.Forms;

namespace Gestao_Centro_Saude
{
    public partial class PatientDetails : Form
    {
        private int patientId;
        private static PatientDetails instance;

        private PatientDetails(int id)
        {
            InitializeComponent();
            patientId = id;
        }

        //Singleton to avoid opening more than one instnace
        public static void ShowPatientDetails(int id)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new PatientDetails(id);
                instance.Show();
            }
            else
            {
                instance.UpdatePatientDetails(id);
                instance.BringToFront();
            }
        }

        private void UpdatePatientDetails(int id)
        {
            patientId = id;
            LoadPatientDetails(); 
        }

        private void PatientDetails_Load(object sender, EventArgs e)
        {
            LoadPatientDetails();
        }

        private void LoadPatientDetails()
        {
            var repo = new PatientRepository();

            Patient pat = repo.GetPatient(patientId);
            if (pat != null)
            {
                label1.Text = $"Name: {pat.Name}\n" +
                              $"Mobile Phone: {pat.Mobile_Phone}\n" +
                              $"Gender: {pat.Gender}\n";
            }
        }
    }
}
