using Geospatial_Insights_Dashboard_Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geospatial_Insights_Dashboard_Server.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cities> Cities { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Regions> Regions { get; set; }
        public DbSet<Insights> Insights { get; set; }
        public DbSet<Pestle> Pestle { get; set; }
        public DbSet<Swot> Swot { get; set; }
        public DbSet<Sectors> Sectors { get; set; }
        public DbSet<Topics> Topics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Insights>(entity =>
            {
                entity.ToTable("insights");

                entity.HasKey(e => e.InsightId);
                entity.Property(e => e.InsightId).HasColumnName("insight_id");
                entity.Property(e => e.Title).HasColumnName("title");
                entity.Property(e => e.Url).HasColumnName("url");
                entity.Property(e => e.Impact).HasColumnName("impact");
                entity.Property(e => e.Likelihood).HasColumnName("likelihood");
                entity.Property(e => e.Intensity).HasColumnName("intensity");
                entity.Property(e => e.Added).HasColumnName("added");
                entity.Property(e => e.Published).HasColumnName("published");
                entity.Property(e => e.StartYear).HasColumnName("start_year");
                entity.Property(e => e.EndYear).HasColumnName("end_year");
                entity.Property(e => e.Relevance).HasColumnName("relevance");
                entity.Property(e => e.SectorId).HasColumnName("sector_id");
                entity.Property(e => e.TopicId).HasColumnName("topic_id");
                entity.Property(e => e.SwotId).HasColumnName("swot_id");
                entity.Property(e => e.PestleId).HasColumnName("pestle_id");
                entity.Property(e => e.RegionId).HasColumnName("region_id");
                entity.Property(e => e.CountryId).HasColumnName("country_id");
                entity.Property(e => e.CityId).HasColumnName("city_id");

            });

            modelBuilder.Entity<Cities>(entity =>
            {
                entity.ToTable("cities");

                entity.HasKey(e => e.CityId);
                entity.Property(e => e.CityId).HasColumnName("city_id");
                entity.Property(e => e.CityName).HasColumnName("city_name");
                entity.Property(e => e.CountryId).HasColumnName("country_id");
                entity.Property(e => e.Citylng).HasColumnName("citylng");
                entity.Property(e => e.Citylat).HasColumnName("citylat");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.ToTable("countries");
                entity.HasKey(e => e.CountryId);
                entity.Property(e => e.CountryId).HasColumnName("country_id");
                entity.Property(e => e.CountryName).HasColumnName("country_name");
                entity.Property(e => e.RegionId).HasColumnName("region_id");
            });

            modelBuilder.Entity<Regions>(entity =>
            {
                entity.ToTable("regions");
                entity.HasKey(e => e.RegionId);
                entity.Property(e => e.RegionId).HasColumnName("region_id");
                entity.Property(e => e.RegionName).HasColumnName("region_name");
            });

            modelBuilder.Entity<Pestle>(entity =>
            {
                entity.ToTable("pestle");
                entity.HasKey(e => e.PestleId);
                entity.Property(e => e.PestleId).HasColumnName("pestle_id");
                entity.Property(e => e.PestleDescription).HasColumnName("pestle_description");
            });

            modelBuilder.Entity<Swot>(entity =>
            {
                entity.ToTable("swot");
                entity.HasKey(e => e.SwotId);
                entity.Property(e => e.SwotId).HasColumnName("swot_id");
                entity.Property(e => e.SwotDescription).HasColumnName("swot_description");
            });

            modelBuilder.Entity<Sectors>(entity =>
            {
                entity.ToTable("sectors");
                entity.HasKey(e => e.SectorId);
                entity.Property(e => e.SectorId).HasColumnName("sector_id");
                entity.Property(e => e.SectorName).HasColumnName("sector_name");
            });

            modelBuilder.Entity<Topics>(entity =>
            {
                entity.ToTable("topics");
                entity.HasKey(e => e.TopicId);
                entity.Property(e => e.TopicId).HasColumnName("topic_id");
                entity.Property(e => e.TopicName).HasColumnName("topic_name");
            });
        }
    }
}
