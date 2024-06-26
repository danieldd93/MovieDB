﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MovieDB.DOMAIN.Core.Entities;

namespace MovieDB.DOMAIN.Infrastructure.Data;

public partial class MovieDbueContext : DbContext
{
    public MovieDbueContext()
    {

    }

    public MovieDbueContext(DbContextOptions<MovieDbueContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Movie> Movie { get; set; }
    public virtual DbSet<Director> Director { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=Parcial20240120200113;Integrated Security=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
