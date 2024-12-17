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


        PatientServices PatientServices = new PatientServices();
        ExamServices examServices = new ExamServices();

        AppointmentServicescs appointmentServicescs = new AppointmentServicescs();


        public PatientDetails(int id)
        {
            InitializeComponent();
            patientId = id;
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
            userAppointments.DataSource = appointmentServicescs.GetAppointmentsByUserId(patientId);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddAppointment addAppointment = new AddAppointment(patient);
            addAppointment.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditPersonalnfo editPersonalnfo = new EditPersonalnfo(patient);
            editPersonalnfo.Show();
        }
    }
}
