using Gestao_Centro_Saude.models;
using Gestao_Centro_Saude.repository;

namespace Gestao_Centro_Saude.ui
{
    public partial class AddAppointment : Form
    {
        private Patient currentPatient;

        public AddAppointment(Patient patient)
        {
            InitializeComponent();
            currentPatient = patient;
        }

        private void AddAppointment_Load(object sender, EventArgs e)
        {
            LoadSpecializations();

            comboBoxSpecialization.SelectedIndexChanged += ComboBoxSpecialization_SelectedIndexChanged;

            textBoxPatientName.Text = currentPatient.Name;
        }

        private void LoadSpecializations()
        {
            var specializationRepository = new PatientRepository();
            var specializations = specializationRepository.GetAllSpecializations();

            comboBoxSpecialization.DataSource = specializations;
            comboBoxSpecialization.DisplayMember = "Description"; 
            comboBoxSpecialization.ValueMember = "Id";         
        }

        private void ComboBoxSpecialization_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedSpecialization = comboBoxSpecialization.SelectedItem as Specialization;

            if (selectedSpecialization != null)
            {
                var staffRepository = new PatientRepository();
                var staffList = staffRepository.GetStaffBySpecialty(selectedSpecialization.Id);

                comboStaff.DataSource = null;  
                comboStaff.DataSource = staffList;
                comboStaff.DisplayMember = "Name"; 
                comboStaff.ValueMember = "Id";   

                comboStaff.ResetBindings();
            }
            else
            {
                comboStaff.DataSource = null;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

            /*ScheduleExams addNewUser = new ScheduleExams(currentPatient);
            addNewUser.Show();*/

            /*try
            {
                if (comboBoxSpecialization.SelectedItem == null || comboStaff.SelectedItem == null)
                {
                    MessageBox.Show("Please select both a specialization and a staff member.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedStaff = comboStaff.SelectedItem as Staff;
                var appointmentDateAndTime = dateTimePickerAppointment.Value; // Get DateTime from DateTimePicker

                var newAppointment = new Appointment(
                    id: 0,
                    dateAndTime: ((DateTimeOffset)appointmentDateAndTime).ToUnixTimeSeconds(), // Convert DateTime to long
                    patient: currentPatient,
                    staff: selectedStaff,
                    exam: null//,
                              //isReturning: checkBoxReturning.Checked
                );



                var appointmentRepository = new PatientRepository();
                if (appointmentRepository.InsertAppointment(newAppointment))
                {
                    MessageBox.Show("Appointment successfully created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to create appointment. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void dataGridAddExam_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
