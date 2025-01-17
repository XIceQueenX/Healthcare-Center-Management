﻿using Gestao_Centro_Saude.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Centro_Saude.models
{
    /// <summary>
    /// Patient Exam class
    /// </summary>
    public class PatientExam
    {
        /// <summary>
        /// Properties
        /// </summary>
        public int Id { get; private set; }
        public string Name { get; set; }
        public long Date { get; private set; } 
        public string Staff { get; set; }
        public string Diagnosis { get; set; }


        /// <summary>
        /// FIlled constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="date"></param>
        /// <param name="staff"></param>
        /// <param name="diagnosis"></param>
        public PatientExam(int id, string name, long date, string staff, string diagnosis)
        {
            Id = id;
            Name = name;
            Date = date;
            Staff = staff;
            Diagnosis = diagnosis;
        }
    }
}
