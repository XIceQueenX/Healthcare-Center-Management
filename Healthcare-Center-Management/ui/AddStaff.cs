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
    public partial class AddStaff : Form
    {
        public AddStaff()
        {
            InitializeComponent();
            var repo = new StaffServices();
           // comboBoxSpeciality.DataSource = repo.GetAllSpecializations();
        }
    }
}
