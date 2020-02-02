﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace mls.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<mls.Models.CustomerOrder> CustomerOrders { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomerDivision> CustomerDivisions { get; set; }

        public DbSet<MlsDivision> MlsDivisions { get; set; }

        public DbSet<OrderStatus> OrderStatuses { get; set; }

        public DbSet<ShipInStatus> ShipInStatuses { get; set; }

        public DbSet<FreightType> FreightTypes { get; set; }

        public DbSet<FPaymentMethod> FPaymentMethods { get; set; }

        public DbSet<ActivePart> ActiveParts { get; set; }

        public DbSet<MasterPartList> MasterPartLists { get; set; }

        public System.Data.Entity.DbSet<mls.ViewModels.NewOrderViewModel> NewOrderViewModels { get; set; }

        public System.Data.Entity.DbSet<mls.Models.ShipIn> ShipIns { get; set; }

        public System.Data.Entity.DbSet<mls.Models.ShipOut> ShipOuts { get; set; }

        public DbSet<Disposition> Dispositions { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<Pfep> Pfeps { get; set; }

        public DbSet<TxQoh> TxQohs { get; set; }

        public DbSet<PartType> PartTypes { get; set; }

        public DbSet<WorkOrder> WorkOrders { get; set; }

        public DbSet<OrderType> OrderTypes { get; set; }

        public DbSet<WoPartType> WoPartTypes { get; set; }

        public DbSet<WoOrderStatus> WoOrderStatuses { get; set; }

        public System.Data.Entity.DbSet<mls.Models.NCR> NCRs { get; set; }

        public System.Data.Entity.DbSet<mls.ViewModels.NewWorkOrderViewModel> NewWorkOrderViewModels { get; set; }

        public System.Data.Entity.DbSet<mls.Models.DownReport> DownReports { get; set; }

        public DbSet<DownStatus> DownStatuses { get; set; }

        public DbSet<BuildHistory> BuildHistories { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Scrum> Scrums { get; set; }

        public DbSet<ScrumStatus> ScrumStatuses { get; set; }

        public DbSet<Classification> Classifications { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<ScrumCreatedBy> ScrumCreatedBies { get; set; }

        public DbSet<ScrumResponsible> ScrumResponsibles { get; set; }

        public DbSet<SupplierContact> SupplierContacts { get; set; }

        public DbSet<ChOil> ChOils { get; set; }

        public DbSet<ExpeditedFreight> ExpeditedFreights { get; set; }

        public DbSet<ExpFreightDetail> ExpFreightDetails { get; set; }

        public DbSet<File> Files { get; set; }

        public DbSet<ScrumDetail> ScrumDetails { get; set; }

        public DbSet<FilePath> FilePaths { get; set; }

        public DbSet<NcrType> NcrTypes { get; set; }

        public DbSet<NcrChina> NcrChinas { get; set; }

        public DbSet<ComplaintSeverity> ComplaintSeverities { get; set; }

        public DbSet<ComplaintType> ComplaintTypes { get; set; }

        public DbSet<CustomerComplaint> CustomerComplaints { get; set; }

        public DbSet<WoDetail> WoDetails { get; set; }

        public DbSet<Productive> Productives { get; set; }

        public DbSet<WoResponsible> WoResponsibles { get; set; }

        public DbSet<BomLevel1> BomLevel1s { get; set; }

        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }

        public DbSet<PoOrderStatus> PoOrderStatuses { get; set; }

        public DbSet<IncomingList> IncomingLists { get; set; }

        public DbSet<InspStatus> InspStatuses { get; set; }

        public System.Data.Entity.DbSet<mls.Models.IncomingTopLevel> IncomingTopLevels { get; set; }

        public System.Data.Entity.DbSet<mls.Models.IncomingDetail> IncomingDetails { get; set; }

        public DbSet<IncomingLog> IncomingLogs { get; set; }

        public DbSet<InspectionStatus> InspectionStatuses { get; set; }

        public DbSet<Practice> Practices { get; set; }

        public DbSet<Demand> Demands { get; set; }

        public DbSet<WkSchedule> WkSchedules { get; set; }

        public DbSet<CustomerQoh> CustomerQohs { get; set; }

        public DbSet<ShipCommit> ShipCommits { get; set; }

        public DbSet<ShipOut2> ShipOut2s { get; set; }

        public DbSet<ShipOut2Detail> ShipOut2Details { get; set; }

        public DbSet<DemandWk> DemandWks { get; set; }

        public DbSet<CommitWk> CommitWks { get; set; }

        public DbSet<CalendarWk> CalendarWks { get; set; }

        public DbSet<ProcessMatrix> ProcessMatrixes { get; set; }

        public DbSet<ProcessStatus> ProcessStatuses { get; set; }

        public DbSet<ProductionPlan> ProductionPlans { get; set; }

        public DbSet<Requisition> Requisitions { get; set; }

        public DbSet<CheckRequest> CheckRequests { get; set; }

        public DbSet<CheckStatus> CheckStatuses { get; set; }

        public DbSet<CalWk> CalWks { get; set; }

        public DbSet<ContainerPoTracker> ContainerPoTrackers { get; set; }

        public DbSet<Checklist> Checklists { get; set; }

        public DbSet<ChecklistType> ChecklistTypes { get; set; }

        public DbSet<Quote> Quotes { get; set; }

        public DbSet<CustomerQuote> CustomerQuotes { get; set; }

        public DbSet<COrderType> COrderTypes { get; set; }

        public DbSet<ReqStatus> ReqStatuses { get; set; }

        public DbSet<ShipPlan> ShipPlans { get; set; }

        public DbSet<ShipPlanStatus> ShipPlanStatuses { get; set; }

        public DbSet<PoPlan> PoPlans { get; set; }

        public DbSet<CQStatus> CQStatuses { get; set; }

        public DbSet<PartStockOut> PartStockOuts { get; set; }

        public DbSet<CycleCount> CycleCounts { get; set; }

        public DbSet<SafetyIncident> SafetyIncidents { get; set; }

        public DbSet<VtCycleCount> VtCycleCounts { get; set; }

        public DbSet<VtPfep> VtPfeps { get; set; }

        public DbSet<VtShipPlan> VtShipPlans { get; set; }

    }
}