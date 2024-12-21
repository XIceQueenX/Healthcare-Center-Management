using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Centro_Saude.models
{
    /// <summary>
    /// Specialization Class
    /// </summary>
    public class Specialization
    {
        /// <summary>
        /// Properites
        /// </summary>
        public int Id { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        public Specialization(int id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}
