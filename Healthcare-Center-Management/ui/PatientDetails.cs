using Gestao_Centro_Saude.models;
using Gestao_Centro_Saude.repository;
using Gestao_Centro_Saude.services;
using Gestao_Centro_Saude.ui;
using System;
using System.Windows.Forms;

namespace Gestao_Centro_Saude
{
    public partial class PatientDetails : Form
    {
        private int patientId;
        private Patient patient;
        private static PatientDetails instance;
        PatientServices PatientServices = new PatientServices();
        ExamServices examServices = new ExamServices();

        private PatientDetails(int id)
        {
            InitializeComponent();
            patientId = id;
        }

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
            var pat = PatientServices.GetPatientById(patientId);
            if (pat != null)
            {
                label1.Text = $"Name: {pat.Name}\n" +
                              $"Mobile Phone: {pat.Mobile_Phone}\n" +
                              $"Gender: {pat.Gender}\n";

                patient = pat;
            }

            userExams.DataSource = examServices.GetPatientExamsById(patientId);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddAppointment addAppointment = new AddAppointment(patient);
            addAppointment.Show();
        }
    }
}
