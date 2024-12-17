using Gestao_Centro_Saude.models;
using Gestao_Centro_Saude.repository;
using Gestao_Centro_Saude.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestao_Centro_Saude.ui
{
    public partial class ListAllAppointments : Form
    {
        AppointmentServicescs appointmentServicescs = new AppointmentServicescs();
        private List<Appointment> _allAppointments;

        public ListAllAppointments()
        {
            InitializeComponent();

            LoadAppointments();
        }

        private void LoadAppointments()
        {
           
            _allAppointments = appointmentServicescs.GetAllAppointments();

            var appointmentsSummary = _allAppointments.Select(appointment => new
            {
                AppointmentId = appointment.Id,
                AppointmentDate = appointment.GetDateAndTimeAsDateTime().ToString(),
                PatientName = appointment.Patient.Name,
                StaffName = appointment.Staff.Name
            }).ToList();

            grid.DataSource = appointmentsSummary;

            grid.CellDoubleClick += Grid_CellDoubleClick;
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
    }
}
