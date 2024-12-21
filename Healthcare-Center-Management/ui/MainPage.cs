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
    public partial class MainPage : Form
    {

        AppointmentServicescs appointmentServicescs = new AppointmentServicescs();
        private List<Appointment> _allAppointments;

        /// <summary>
        /// Instantieta the form
        /// </summary>
        public MainPage()
        {
            InitializeComponent();

            _allAppointments = appointmentServicescs.GetAppointmentsOfTheDay();

            var appointmentsSummary = _allAppointments.Select(appointment => new
            {
                AppointmentId = appointment.Id,
                AppointmentDate = appointment.GetDateAndTimeAsDateTime().ToString(),
                PatientName = appointment.Patient.Name,
                StaffName = appointment.Staff.Name
            }).ToList();

            grid.DataSource = appointmentsSummary;

        }

        /// <summary>
        /// Open a new form that shows all the patients
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            ListAllPatients listAllPatients = new ListAllPatients();
            listAllPatients.Show();
        }


        /// <summary>
        /// When click in some cell, go to the details of this appointment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onClickGridCell(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int selectedAppointmentId = (int)grid.Rows[e.RowIndex].Cells["AppointmentId"].Value;

                var selectedAppointment = _allAppointments.FirstOrDefault(a => a.Id == selectedAppointmentId);

                if (selectedAppointment != null)
                {
                    AppointmentDetailsForm detailsForm = new AppointmentDetailsForm(selectedAppointment);
                    detailsForm.ShowDialog();
                }
            }

        }


        /// <summary>
        /// Close the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Go to list all the patients
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
