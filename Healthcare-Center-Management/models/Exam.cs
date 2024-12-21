using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Centro_Saude.models
{
    public class Exam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Cost { get;  set; }

        public Exam() { }

        public Exam(int id, string name, string description, double cost)
        {
            Id = id;
            Name = name;
            Description = description;
            Cost = cost;
        }
    }
}
