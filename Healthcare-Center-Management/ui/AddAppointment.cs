﻿using Gestao_Centro_Saude.models;
using Gestao_Centro_Saude.repository;
using Gestao_Centro_Saude.services;
using System.Windows.Forms;

namespace Gestao_Centro_Saude.ui
{
    public partial class AddAppointment : Form
    {
        private Patient currentPatient;

        private StaffServices staffServices = new StaffServices();
        private AppointmentServicescs appointmentServicescs = new AppointmentServicescs();

        /// <summary>
        /// Initialize the view
        /// </summary>
        /// <param name="patient"></param>
        public AddAppointment(Patient patient)
        {
            InitializeComponent();
            currentPatient = patient;
            SetupView();
        }

        /// <summary>
        /// Setup the content
        /// </summary>
        private void SetupView()
        {
            LoadSpecializations();

            comboBoxSpecialization.SelectedIndexChanged += ComboBoxSpecialization_SelectedIndexChanged;

            labelName.Text = currentPatient.Name;

            dateTimePickerAppointment.MinDate = DateTime.Today;
            dateTimePickerAppointment.MaxDate = DateTime.Today.AddMonths(6);
        }

        private void LoadSpecializations()
        {
            comboBoxSpecialization.DataSource = staffServices.GetAllSpecializations(); 
            comboBoxSpecialization.DisplayMember = "Description"; 
            comboBoxSpecialization.ValueMember = "Id";         
        }

        private void ComboBoxSpecialization_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedSpecialization = comboBoxSpecialization.SelectedItem as Specialization;

            if (selectedSpecialization != null)
            {
                var staffList = staffServices.GetStaffBySpecialty(selectedSpecialization.Id);

                comboStaff.DataSource = staffList;
                comboStaff.DisplayMember = "Name"; 
                comboStaff.ValueMember = "Id";   

            }
            else
            {
                comboStaff.DataSource = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (comboBoxSpecialization.SelectedItem == null || comboStaff.SelectedItem == null)
                {
                    MessageBox.Show("Please select both a specialization and a staff member.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedStaff = comboStaff.SelectedItem as Staff;
                var appointmentDateAndTime = dateTimePickerAppointment.Value;

                var newAppointment = new Appointment(
                    id: 0,
                    dateAndTime: ((DateTimeOffset)appointmentDateAndTime).ToUnixTimeSeconds(),
                    patient: currentPatient,
                    staff: selectedStaff
                );

                if (appointmentServicescs.InsertAppointment(newAppointment))
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to create appointment. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
