using gym.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym.Models
{
    public class GymContext : DbContext
    {
        public DbSet<Judge> Judges { get; set; }
    }
}
