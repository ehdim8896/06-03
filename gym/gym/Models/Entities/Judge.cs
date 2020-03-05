using gym.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym.Models.Entities
{
    public class Judge
    {
        [Key]
        public int Id { get; set; }
        public int JsonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Country { get; set; }
        public Discipline Discipline { get; set; }
        public int Category { get; set; }
        public DateTime Birth { get; set; }
    }
}
