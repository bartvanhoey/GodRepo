using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet8SpecificationPattern.Entities
{
    public class DLC
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        public string Description{ get; set; }  
        public string Email { get; set; }
    }
}