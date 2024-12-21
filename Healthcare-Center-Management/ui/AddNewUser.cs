using Gestao_Centro_Saude.models;
using Gestao_Centro_Saude.services;

namespace Gestao_Centro_Saude
{
    public partial class AddNewUser : Form
    {
        public AddNewUser()
        {
            InitializeComponent();
        }

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
