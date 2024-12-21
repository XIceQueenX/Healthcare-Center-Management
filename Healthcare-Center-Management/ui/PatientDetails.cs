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

        private List<Appointment> _allAppointments;


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

            _allAppointments = appointmentServicescs.GetAppointmentsByUserId(patientId);

            var appointmentsSummary = _allAppointments.Select(appointment => new
            {
                AppointmentId = appointment.Id,
                AppointmentDate = appointment.GetDateAndTimeAsDateTime().ToString(),
                PatientName = appointment.Patient.Name,
                StaffName = appointment.Staff.Name
            }).ToList();

            userExams.DataSource = examServices.GetPatientExamsById(patientId);
            userAppointments.DataSource = appointmentsSummary;
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

        private void userAppointments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int selectedAppointmentId = (int)userAppointments.Rows[e.RowIndex].Cells["AppointmentId"].Value;

                var selectedAppointment = _allAppointments.FirstOrDefault(a => a.Id == selectedAppointmentId);

                if (selectedAppointment != null)
                {
                    AppointmentDetailsForm detailsForm = new AppointmentDetailsForm(selectedAppointment);
                    detailsForm.ShowDialog();
                }
            }
        }
    }
}
