﻿using Microsoft.EntityFrameworkCore;

using WebApi.Models;

namespace WebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        DbSet<Product> Products { get; set; }
    }
}
