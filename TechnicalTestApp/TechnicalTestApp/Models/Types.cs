using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TechnicalTestApp.Models
{
    public class Types
    {
        [Key]
        public string Value { get; set; }
        public string Name { get; set; }
    }
    public class Information
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Remarks { get; set; } 
    }
    public class InfoDbContext : DbContext
    {
        public DbSet<Types> Types { get; set; }
        public DbSet<Information> Informations { get; set; } 
    }
}