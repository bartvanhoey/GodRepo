using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet8SpecificationPattern.Entities
{
    public class Game : BaseEntity
    {
        public required string Name { get; set; }

        public Genre? Genre { get; set; }

        public List<DLC> DLCs { get; set; } = [];
    }
}