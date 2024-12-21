using Gestao_Centro_Saude.models;
using Gestao_Centro_Saude.services;
using System;
using System.Data;
using System.Windows.Forms;

namespace Gestao_Centro_Saude.ui
{
    public partial class AppointmentDetailsForm : Form
    {
        private DateTime appointmentDate = new DateTime(2024, 12, 25);

        private ExamServices examServices = new ExamServices();
        private AppointmentServicescs appointmentServicescs = new AppointmentServicescs();
        private Appointment _appointment;

        private List<int> scheduledExamIds;
        public AppointmentDetailsForm(Appointment appointment)
        {
            InitializeComponent();
            _appointment = appointment;


             scheduledExamIds = examServices
                .GetPatientExamsById(appointment.Patient.Id)
                .Select(exam => exam.Id)
                .ToList();


            setupView();
        }


        private void setupView()
        {
            labelDate.Text = _appointment.GetDateAndTimeAsDateTime().ToString();
            labelPatientName.Text = _appointment.Patient.Name;
            labelPatientMobile.Text = $"Mobile Phone: {_appointment.Patient.Mobile_Phone}";
            labelPatientGender.Text = $"Gender:{_appointment.Patient.Gender.ToString()}";
            labelStaffName.Text = $"Doctor: {_appointment.Staff.Name} - \t\t\t\t {_appointment.Staff.speciality.Description}";

            ToggleTextBoxVisibility();

            setupDataViewCells();



        }

        private void setupDataViewCells()
        {

            var allExams = examServices.GetAllExams();

            foreach (var exam in allExams)
            {
                int examId = exam.Id;
                bool isScheduled = scheduledExamIds.Contains(examId);

                int rowIndex = dataGridAddExam.Rows.Add();

                dataGridAddExam.Rows[rowIndex].Cells["Id"].Value = examId;
                dataGridAddExam.Rows[rowIndex].Cells["ExamName"].Value = exam.Name;
                dataGridAddExam.Rows[rowIndex].Cells["Selected"].Value = isScheduled;

                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)dataGridAddExam.Rows[rowIndex].Cells["Selected"];

                checkBoxCell.Value = isScheduled;

                if (isScheduled)
                {
                    checkBoxCell.ReadOnly = true;
                }
                else
                {
                    checkBoxCell.ReadOnly = false;
                }
            }
        }
        private void ToggleTextBoxVisibility()
        {
            DateTime currentDateTime = DateTime.Now;

            DateTime appointmentDateOnly = _appointment.GetDateAndTimeAsDateTime().Date;
            DateTime currentDateOnly = currentDateTime.Date;

            if (appointmentDateOnly == currentDateOnly)
            {
                textBox1.Visible = true;
                button2.Visible = true;

                textBox1.ReadOnly = false;
                textBox1.Text = _appointment.AdditionalDetails;

            }
            else if (appointmentDateOnly < currentDateOnly)
            {
                textBox1.Visible = true;
                button2.Visible = false;

                textBox1.ReadOnly = true;

                textBox1.Text = _appointment.AdditionalDetails;
            }
            else
            {
                textBox1.Visible = false;
                button2.Visible = false;
            }
        }


        private void SaveSelectedExams()
        {
            var selectedExamIds = new List<int>();
            foreach (DataGridViewRow row in dataGridAddExam.Rows)
            {
                if (row.Cells["Selected"].Value != null && Convert.ToBoolean(row.Cells["Selected"].Value))
                {
                    selectedExamIds.Add((int)row.Cells["Id"].Value);
                }
            }

            if (selectedExamIds.Count == 0)
            {
                MessageBox.Show("No exams selected to schedule.");
                return;
            }

            var scheduledExamIds = examServices.GetPatientExamsById(_appointment.Patient.Id)
                                               .Select(exam => exam.Id)
                                               .ToHashSet();

            var examsToSchedule = selectedExamIds.Where(id => !scheduledExamIds.Contains(id)).ToList();

            if (examsToSchedule.Count == 0)
            {
                MessageBox.Show("All selected exams are already scheduled.");
                return;
            }

            DateTime startDate = new DateTime(2024, 1, 1);
            DateTime endDate = new DateTime(2024, 12, 31);

            foreach (var examId in examsToSchedule)
            {
                DateTime examDate = GetRandomDate(_appointment.GetDateAndTimeAsDateTime());

                bool success = examServices.SaveExamForPatient(_appointment.Patient.Id, examId, 1, _appointment.Id, examDate);

                MessageBox.Show(success ? "Exam scheduled successfully!" : "Failed to schedule the exam.");
                this.Close();
            }
        }

        public DateTime GetRandomDate(DateTime appointmentDate)
        {
            Random random = new Random();

            DateTime randomDate = appointmentDate.AddDays(random.Next(0, 7));

            randomDate = randomDate.AddHours(random.Next(0, 24))   
                                   .AddMinutes(random.Next(0, 60)) 
                                   .AddSeconds(random.Next(0, 60))  
                                   .AddMilliseconds(random.Next(0, 1000));

            return randomDate;
        }

        private void dataGridViewExams_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridAddExam.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                int examId = (int)dataGridAddExam.Rows[e.RowIndex].Cells["Id"].Value;

                bool isScheduled = scheduledExamIds.Contains(examId);

                if (isScheduled)
                    return;

                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)dataGridAddExam.Rows[e.RowIndex].Cells[e.ColumnIndex];

                bool currentValue = Convert.ToBoolean(checkBoxCell.Value);

                checkBoxCell.Value = !currentValue;                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveSelectedExams();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            appointmentServicescs.UpdateAdditionalDetails(_appointment.Id, textBox1.Text);
        }
    }
}
