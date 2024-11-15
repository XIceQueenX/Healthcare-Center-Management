﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Centro_Saude.models
{
    internal class Exam
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Cost { get; private set; }

        public Exam() { }

        public Exam(string name, string description, double cost)
        {
            Name = name;
            Description = description;
            Cost = cost;
        }

        public void UpdateCost(double value)
        {
            if(value != Cost)
            {
                Cost = value;
            }
        }
    }
}
