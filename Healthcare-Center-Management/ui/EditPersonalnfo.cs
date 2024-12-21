using Gestao_Centro_Saude.models;
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
    public partial class EditPersonalnfo : Form
    {
        private Patient patient;

        public EditPersonalnfo(Patient patient)
        {
            InitializeComponent();
            this.patient = patient;

            LoadPatientInfo();
        }

        /// <summary>
        /// Put the patient info into the label
        /// </summary>
        private void LoadPatientInfo()
        {
            patient_Name.Text = patient.Name;
            patient_mobilePhone.Text = patient.Mobile_Phone;
            comboBox1.Text = patient.Gender.ToString(); 
        }

        /// <summary>
        /// Edit the personla info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient(
                id: this.patient.Id,
                name: patient_Name.Text,
                mobilePhone: patient_mobilePhone.Text,
                gender: comboBox1.Text[0]
            );

            var repo = new PatientServices();

            if (repo.UpdatePatient(patient))
                this.Close();
        }
    }
}
