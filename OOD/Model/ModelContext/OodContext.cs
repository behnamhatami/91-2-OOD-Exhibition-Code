﻿#region

using System;
using System.Data.Entity;
using System.Reflection;
using OOD.Model.ExhibitionPackage.ExhibitionDefinition;
using OOD.Model.ExhibitionPackage.ExhibitionProgress.ExhibitionPeripheral;
using OOD.Model.ExhibitionPackage.ExhibitionRoles;
using OOD.Model.NotificationPackage;
using OOD.Model.UserManagingPackage;

#endregion

namespace OOD.Model.ModelContext
{
    public class OodContext : DbContext
    {
        public OodContext()
            : base(ConnectionString)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Exhibition> Exhibitions { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<ExhibitionRole> ExhibitionRoles { get; set; }
        public DbSet<UserExhibitionRole> UserExhibitionRoles { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<PollChoice> PollChoices { get; set; }
        public DbSet<PollUser> PollUsers { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<PostOffice> PostOffices { get; set; }
        public DbSet<PostItem> PostItems { get; set; }
        public DbSet<WareHouse> WareHouses { get; set; }
        public DbSet<WareHouseItem> WareHouseItems { get; set; }

        public static string ConnectionString
        {
            get
            {
                return @"Data Source=" +
                       Assembly
                           .GetExecutingAssembly()
                           .Location
                           .Substring(0,
                               Assembly.GetExecutingAssembly()
                                   .Location.LastIndexOf("\\", StringComparison.Ordinal) + 1)
                       + @"ood.sdf";
            }
        }
    }
}