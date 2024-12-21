using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Centro_Saude.models
{

    public class Category
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public Category() { }

        public Category(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
