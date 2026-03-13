using FAP_ONLINE.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FAP_ONLINE.Data
{
    public class Context: DbContext
    {
        public Context() : base("FAP_ONLINE")
        {

        }
        public DbSet<Plano> Planos { get; set; }
        public DbSet<Tarifa> Tarifa { get; set; }
    }
}