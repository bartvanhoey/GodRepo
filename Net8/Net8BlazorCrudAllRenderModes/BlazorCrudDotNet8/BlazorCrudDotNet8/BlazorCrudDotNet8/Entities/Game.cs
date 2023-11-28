using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCrudDotNet8.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}