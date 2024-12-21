using Gestao_Centro_Saude.models;
using Gestao_Centro_Saude.services;

namespace Gestao_Centro_Saude
{
    public partial class AddNewUser : Form
    {

        /// <summary>
        /// Initialize the form
        /// </summary>
        public AddNewUser()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Add the user to db, then close the windows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient(
                name: patient_Name.Text,
                mobilePhone: patient_mobilePhone.Text,
                gender: comboBox1.Text[0]
            );

            var repo = new PatientServices();

            if (repo.InsertPatient(patient))
                this.Close();
        }
    }
}
