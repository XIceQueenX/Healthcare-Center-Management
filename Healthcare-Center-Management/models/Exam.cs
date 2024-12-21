using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Centro_Saude.models
{
    /// <summary>
    /// Exam Class
    /// </summary>
    public class Exam
    {
        /// <summary>
        /// Properties
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Cost { get;  set; }

        /// <summary>
        /// Empty Constructor to initialize nil objects
        /// </summary>
        public Exam() { }

        /// <summary>
        /// Filled constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="cost"></param>
        public Exam(int id, string name, string description, double cost)
        {
            Id = id;
            Name = name;
            Description = description;
            Cost = cost;
        }
    }
}
