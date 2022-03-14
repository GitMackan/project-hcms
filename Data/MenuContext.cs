using Microsoft.EntityFrameworkCore;
using project_hcms.Models;

namespace project_hcms.Data;

public class MenuContext : DbContext {
        
        // Constructor
        public MenuContext(DbContextOptions<MenuContext> options) : base(options) {

        }

        // Set DB Tables
        public DbSet<MainCourse> MainCourses { get; set; }

        public DbSet<Starter> Starters { get; set; }

        public DbSet<Dessert> Desserts { get; set; }

        public DbSet<Drink> Drinks { get; set; }

        public DbSet<Appetizer> Appetizers { get; set; }

        public DbSet<Coffee> Coffees { get; set; }

        public DbSet<MainCourseVeg> MainCoursesVeg { get; set; }

        public DbSet<VineBeer> VineBeers { get; set; }
    }