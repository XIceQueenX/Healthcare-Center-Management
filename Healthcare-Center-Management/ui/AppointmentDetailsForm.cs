﻿using Gestao_Centro_Saude.models;
using Gestao_Centro_Saude.repository;
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
    public partial class AppointmentDetailsForm : Form
    {
        private Appointment _appointment;

        private HashSet<int> scheduledExamIds;
        public AppointmentDetailsForm(Appointment appointment)
        {
            InitializeComponent();
            _appointment = appointment;

            labelDate.Text = $"Date: {DateTimeOffset.FromUnixTimeSeconds(_appointment.DateAndTime).DateTime}";
            labelPatientName.Text = $"Patient Name: {_appointment.Patient.Name}";
            labelPatientMobile.Text = $"Patient Mobile: {_appointment.Patient.Mobile_Phone}";
            labelPatientGender.Text = $"Patient Gender: {_appointment.Patient.Gender}";
            labelStaffName.Text = $"Staff Name: {_appointment.Staff.Name}";
            labelStaffSpecialty.Text = $"Specialty: {_appointment.Staff.Specialty}";

            PatientRepository repo = new PatientRepository();

            var allExams = repo.GetAllExams();

            var scheduledExams = repo.GetPatientExamsById(appointment.Patient.Id);

            scheduledExamIds = new HashSet<int>(scheduledExams.Select(exam => exam.Id));

            if (!dataGridAddExam.Columns.Contains("Id"))
            {
                dataGridAddExam.Columns.Add("Id", "Exam ID");
            }
            if (!dataGridAddExam.Columns.Contains("ExamName"))
            {
                dataGridAddExam.Columns.Add("ExamName", "Exam Name");
            }
            if (!dataGridAddExam.Columns.Contains("isSelected"))
            {
                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
                {
                    Name = "isSelected",
                    HeaderText = "Select Exam"
                };
                dataGridAddExam.Columns.Add(checkBoxColumn);
            }

            dataGridAddExam.Rows.Clear();

            foreach (var exam in allExams)
            {
                int examId = exam.Id;
                bool isScheduled = scheduledExamIds.Contains(examId);

                int rowIndex = dataGridAddExam.Rows.Add();

                dataGridAddExam.Rows[rowIndex].Cells["Id"].Value = examId;
                dataGridAddExam.Rows[rowIndex].Cells["ExamName"].Value = exam.Name; 
                dataGridAddExam.Rows[rowIndex].Cells["isSelected"].Value = isScheduled;

                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)dataGridAddExam.Rows[rowIndex].Cells["isSelected"];

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




        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AppointmentDetailsForm_Load(object sender, EventArgs e)
        {

        }

        private void SaveSelectedExams()
        {
            List<int> selectedExamIds = new List<int>();
            foreach (DataGridViewRow row in dataGridAddExam.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["isSelected"].Value);
                if (isSelected)
                {
                    int examId = (int)row.Cells["Id"].Value;
                    selectedExamIds.Add(examId);
                }
            }

            if (selectedExamIds.Count == 0)
            {
                MessageBox.Show("No exams selected to schedule.");
                return;
            }

            PatientRepository repo = new PatientRepository();
            var scheduledExams = repo.GetPatientExamsById(_appointment.Patient.Id);
            var scheduledExamIds = new HashSet<int>(scheduledExams.Select(exam => exam.Id));

            var examsToSchedule = selectedExamIds.Where(examId => !scheduledExamIds.Contains(examId)).ToList();

            if (examsToSchedule.Count == 0)
            {
                MessageBox.Show("All selected exams are already scheduled.");
                return;
            }

            DateTime startDate = new DateTime(2024, 1, 1);
            DateTime endDate = new DateTime(2024, 12, 31);

            foreach (var examId in examsToSchedule)
            {
                try
                {
                    DateTime examDate = GetRandomDate(startDate, endDate);

                    bool success = repo.SaveExamForPatient(_appointment.Patient.Id, examId, 1, _appointment.Id, examDate); //TODO

                    if (success)
                    {
                        MessageBox.Show("Exam scheduled successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to schedule the exam.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        public DateTime GetRandomDate(DateTime startDate, DateTime endDate)
        {
            Random random = new Random();

            int range = (endDate - startDate).Days;

            int randomDays = random.Next(range);

            return startDate.AddDays(randomDays);
        }



        private long GetSelectedExamDate()
        {
            return DateTime.Now.Ticks;
        }


        private void dataGridViewExams_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridAddExam.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                int examId = (int)dataGridAddExam.Rows[e.RowIndex].Cells["Id"].Value;

                bool isScheduled = scheduledExamIds.Contains(examId);

                if (isScheduled)
                {
                    return;
                }

                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)dataGridAddExam.Rows[e.RowIndex].Cells[e.ColumnIndex];

                bool currentValue = Convert.ToBoolean(checkBoxCell.Value);

                checkBoxCell.Value = !currentValue;

                dataGridAddExam.CommitEdit(DataGridViewDataErrorContexts.Commit);

                if ((bool)checkBoxCell.Value)
                {
                    dataGridAddExam.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen; 
                }
                else
                {
                    dataGridAddExam.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White; 
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveSelectedExams();
        }
    }
}