﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MM.DataLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ManiMotorsEntities1 : DbContext
    {
        public ManiMotorsEntities1()
            : base("name=ManiMotorsEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<EmployeeLoginDetail> EmployeeLoginDetails { get; set; }
        public virtual DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<FinanceInfo> FinanceInfoes { get; set; }
        public virtual DbSet<InsuranceInfo> InsuranceInfoes { get; set; }
        public virtual DbSet<MainDealer> MainDealers { get; set; }
        public virtual DbSet<MMRole> MMRoles { get; set; }
        public virtual DbSet<OtherBookingAllotment> OtherBookingAllotments { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RTOInfo> RTOInfoes { get; set; }
        public virtual DbSet<SparePartsBookingAllotment> SparePartsBookingAllotments { get; set; }
        public virtual DbSet<SparePartsInfo> SparePartsInfoes { get; set; }
        public virtual DbSet<SparePartsInventory> SparePartsInventories { get; set; }
        public virtual DbSet<SparePartsInventoryStatu> SparePartsInventoryStatus { get; set; }
        public virtual DbSet<SparePartsInventoryStatusType> SparePartsInventoryStatusTypes { get; set; }
        public virtual DbSet<SparePartsType> SparePartsTypes { get; set; }
        public virtual DbSet<VehicleBooking> VehicleBookings { get; set; }
        public virtual DbSet<VehicleBookingAllotment> VehicleBookingAllotments { get; set; }
        public virtual DbSet<VehicleBookingFinanceAllotment> VehicleBookingFinanceAllotments { get; set; }
        public virtual DbSet<VehicleBookingFollowUp> VehicleBookingFollowUps { get; set; }
        public virtual DbSet<VehicleBookingInsuranceAllotment> VehicleBookingInsuranceAllotments { get; set; }
        public virtual DbSet<VehicleBookingRTOAllotment> VehicleBookingRTOAllotments { get; set; }
        public virtual DbSet<VehicleInfo> VehicleInfoes { get; set; }
        public virtual DbSet<VehicleInventory> VehicleInventories { get; set; }
        public virtual DbSet<VehicleInventoryStatu> VehicleInventoryStatus { get; set; }
        public virtual DbSet<VehicleInventoryStatusType> VehicleInventoryStatusTypes { get; set; }
        public virtual DbSet<VehicleSalesStatu> VehicleSalesStatus { get; set; }
        public virtual DbSet<VehicleType> VehicleTypes { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerExchangeVehicle> CustomerExchangeVehicles { get; set; }
        public virtual DbSet<CustomerEnquiry> CustomerEnquiries { get; set; }
        public virtual DbSet<CustomerEnquiryFollowUp> CustomerEnquiryFollowUps { get; set; }
    }
}
