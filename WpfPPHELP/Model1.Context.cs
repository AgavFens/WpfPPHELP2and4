﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfPPHELP
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BDPPEntities : DbContext
    {
        public BDPPEntities()
            : base("name=BDPPEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Chvet> Chvet { get; set; }
        public virtual DbSet<Karandashi> Karandashi { get; set; }
        public virtual DbSet<Razmer> Razmer { get; set; }
        public virtual DbSet<ZavodKarandashey> ZavodKarandashey { get; set; }
        public virtual DbSet<ChvetView> ChvetView { get; set; }
        public virtual DbSet<KarandashiInventory> KarandashiInventory { get; set; }
        public virtual DbSet<KarandashiView> KarandashiView { get; set; }
        public virtual DbSet<RazmerView> RazmerView { get; set; }
    }
}
