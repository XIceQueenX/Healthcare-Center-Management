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
    public partial class ListAllPatients : Form
    {
        PatientServices patientServices = new PatientServices();
        public ListAllPatients()
        {
            InitializeComponent();
            grid.DataSource = patientServices.GetPatients();
        }

        private void onClickGridCell(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = grid.Rows[e.RowIndex];
                int patientId = (int)selectedRow.Cells["Id"].Value;


                PatientDetails patientDetails = new PatientDetails(patientId);
                patientDetails.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNewUser addNewUser = new AddNewUser();
            addNewUser.Show();
            this.Close();
        }
    }
}
