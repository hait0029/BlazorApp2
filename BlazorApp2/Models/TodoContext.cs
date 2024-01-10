﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Models;

public partial class TodoContext : DbContext
{
    public TodoContext()
    {
    }

    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cpr> Cprs { get; set; }

    public virtual DbSet<Todolist> Todolists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Todo;Trusted_Connection=True;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cpr>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cpr__3214EC27BF4F6969");

            entity.ToTable("Cpr");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cpr1).HasColumnName("Cpr");
        });

        modelBuilder.Entity<Todolist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Todolist__3214EC270E4A9E3A");

            entity.ToTable("Todolist");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
