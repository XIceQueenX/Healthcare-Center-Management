using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Centro_Saude.models
{
    /// <summary>
    /// CAtegory Class
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Properties
        /// </summary>
        public int Id { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Filles Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        public Category(int id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}
