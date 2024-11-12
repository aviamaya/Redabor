using Microsoft.EntityFrameworkCore;
using Redarbor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redarbor.Infraestructure.Data
{
    public class RedarborContext : DbContext
    {
        public RedarborContext(DbContextOptions<RedarborContext> options) : base(options)
        { }
        public virtual DbSet<Employee> Employee { get; set; }

    }
}
