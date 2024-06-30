using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVC_Test.Models;

public partial class MvctestDbContext : DbContext
{
    public MvctestDbContext()
    {
    }

    public MvctestDbContext(DbContextOptions<MvctestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdminUser> AdminUsers { get; set; }

    public virtual DbSet<BonusActivity> BonusActivities { get; set; }

    public virtual DbSet<BuildingInformation> BuildingInformations { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerBonusActivity> CustomerBonusActivities { get; set; }

    public virtual DbSet<CustomerFavoriteShop> CustomerFavoriteShops { get; set; }

    public virtual DbSet<CustomerTransaction> CustomerTransactions { get; set; }

    public virtual DbSet<CustomerTransactionBonusRecord> CustomerTransactionBonusRecords { get; set; }

    public virtual DbSet<CustomerTransactionDiscount> CustomerTransactionDiscounts { get; set; }

    public virtual DbSet<CustomerTransactionFlow> CustomerTransactionFlows { get; set; }

    public virtual DbSet<FirebaseDevice> FirebaseDevices { get; set; }

    public virtual DbSet<JwtRefreshToken> JwtRefreshTokens { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<NotificationDetail> NotificationDetails { get; set; }

    public virtual DbSet<NotificationFirebaseLog> NotificationFirebaseLogs { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Shop> Shops { get; set; }

    public virtual DbSet<ShopAd> ShopAds { get; set; }

    public virtual DbSet<ShopCategoryMapping> ShopCategoryMappings { get; set; }

    public virtual DbSet<ShopDiscountCoupon> ShopDiscountCoupons { get; set; }

    public virtual DbSet<ShopEmployee> ShopEmployees { get; set; }

    public virtual DbSet<ShopFlow> ShopFlows { get; set; }

    public virtual DbSet<ShopWeekDay> ShopWeekDays { get; set; }

    public virtual DbSet<ShopWeekDayTime> ShopWeekDayTimes { get; set; }

    public virtual DbSet<SystemAd> SystemAds { get; set; }

    public virtual DbSet<SystemAdMapping> SystemAdMappings { get; set; }

    public virtual DbSet<SystemAnnounce> SystemAnnounces { get; set; }

    public virtual DbSet<SystemAnnounceMapping> SystemAnnounceMappings { get; set; }

    public virtual DbSet<SystemConfig> SystemConfigs { get; set; }

    public virtual DbSet<SystemLog> SystemLogs { get; set; }

    public virtual DbSet<VerificationCode> VerificationCodes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=MVCTestDB;User Id=sa;Password=@Abcd1234;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdminUser>(entity =>
        {
            entity.ToTable("AdminUser");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Account).HasMaxLength(200);
            entity.Property(e => e.AdminUserName).HasMaxLength(100);
            entity.Property(e => e.AdminUserNumber)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.LastModifyDateTime).HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(200);
            entity.Property(e => e.PhoneCountryCode).HasMaxLength(5);
            entity.Property(e => e.PhoneNumber).HasMaxLength(10);
            entity.Property(e => e.Remark).HasMaxLength(200);
            entity.Property(e => e.StatusCode).HasMaxLength(30);

            entity.HasOne(d => d.Company).WithMany(p => p.AdminUsers)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("AdminUser_FK");

            entity.HasMany(d => d.PermissionCodes).WithMany(p => p.AdminUsers)
                .UsingEntity<Dictionary<string, object>>(
                    "AdminUserPermissionMapping",
                    r => r.HasOne<Permission>().WithMany()
                        .HasForeignKey("PermissionCode")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_AdminUserPermissionMapping_Permission"),
                    l => l.HasOne<AdminUser>().WithMany()
                        .HasForeignKey("AdminUserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_AdminUserPermissionMapping_AdminUser"),
                    j =>
                    {
                        j.HasKey("AdminUserId", "PermissionCode");
                        j.ToTable("AdminUserPermissionMapping");
                        j.IndexerProperty<string>("PermissionCode").HasMaxLength(50);
                    });
        });

        modelBuilder.Entity<BonusActivity>(entity =>
        {
            entity.ToTable("BonusActivity");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ActivityDateTime).HasColumnType("datetime");
            entity.Property(e => e.BonusType).HasMaxLength(50);
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.ExpireDateTime).HasColumnType("datetime");
            entity.Property(e => e.QrcodeNumber)
                .HasMaxLength(20)
                .HasColumnName("QRCodeNumber");
            entity.Property(e => e.Reason).HasMaxLength(200);
            entity.Property(e => e.Remark).HasMaxLength(500);
            entity.Property(e => e.StatusCode).HasMaxLength(50);
            entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<BuildingInformation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Buildinginformation");

            entity.ToTable("BuildingInformation");

            entity.Property(e => e.BuildingName).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.StatusCode).HasMaxLength(20);
            entity.Property(e => e.UrlLink).HasMaxLength(200);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryCode);

            entity.ToTable("Category");

            entity.Property(e => e.CategoryCode).HasMaxLength(50);
            entity.Property(e => e.CategoryName).HasMaxLength(50);
            entity.Property(e => e.CategoryPath).HasMaxLength(200);
            entity.Property(e => e.CouponImagePath).HasMaxLength(200);
            entity.Property(e => e.StatusCode).HasMaxLength(30);
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Company_PK");

            entity.ToTable("Company");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CompanyName).HasMaxLength(10);
            entity.Property(e => e.ImagePath).HasMaxLength(200);
            entity.Property(e => e.Slogan).HasMaxLength(15);
            entity.Property(e => e.StatusCode)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address).HasMaxLength(400);
            entity.Property(e => e.AvatarPath).HasMaxLength(400);
            entity.Property(e => e.BirthDay).HasColumnType("date");
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.CustomerName).HasMaxLength(200);
            entity.Property(e => e.CustomerNumber).HasMaxLength(20);
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.GenderCode).HasMaxLength(20);
            entity.Property(e => e.LastModifyDateTime).HasColumnType("datetime");
            entity.Property(e => e.PhoneCountryCode).HasMaxLength(5);
            entity.Property(e => e.PhoneNumber).HasMaxLength(10);
            entity.Property(e => e.StatusCode).HasMaxLength(40);

            entity.HasMany(d => d.PermissionCodes).WithMany(p => p.Customers)
                .UsingEntity<Dictionary<string, object>>(
                    "CustomerPermissionMapping",
                    r => r.HasOne<Permission>().WithMany()
                        .HasForeignKey("PermissionCode")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CustomerPermissionMapping_Permission"),
                    l => l.HasOne<Customer>().WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CustomerPermissionMapping_Customer"),
                    j =>
                    {
                        j.HasKey("CustomerId", "PermissionCode");
                        j.ToTable("CustomerPermissionMapping");
                        j.IndexerProperty<string>("PermissionCode").HasMaxLength(50);
                    });
        });

        modelBuilder.Entity<CustomerBonusActivity>(entity =>
        {
            entity.ToTable("CustomerBonusActivity");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.BonusActivity).WithMany(p => p.CustomerBonusActivities)
                .HasForeignKey(d => d.BonusActivityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerBonusActivity_BonusActivity");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerBonusActivities)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerBonusActivity_Customer");
        });

        modelBuilder.Entity<CustomerFavoriteShop>(entity =>
        {
            entity.ToTable("CustomerFavoriteShop");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerFavoriteShops)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerFavoriteShop_Customer");

            entity.HasOne(d => d.Shop).WithMany(p => p.CustomerFavoriteShops)
                .HasForeignKey(d => d.ShopId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerFavoriteShop_Shop");
        });

        modelBuilder.Entity<CustomerTransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CustomerTransactionRecord");

            entity.ToTable("CustomerTransaction");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AdminUserModifyReason).HasMaxLength(500);
            entity.Property(e => e.CancelReason).HasMaxLength(500);
            entity.Property(e => e.CustomerComment).HasMaxLength(1000);
            entity.Property(e => e.CustomerCommentDateTime).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDateTime).HasColumnType("datetime");
            entity.Property(e => e.RejectCancelReason).HasMaxLength(500);
            entity.Property(e => e.StatusCode).HasMaxLength(30);
            entity.Property(e => e.TransactionDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerTransactions)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_CustomerTransaction_Customer");

            entity.HasOne(d => d.Shop).WithMany(p => p.CustomerTransactions)
                .HasForeignKey(d => d.ShopId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerTransaction_Shop");
        });

        modelBuilder.Entity<CustomerTransactionBonusRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ShopBonusRecord");

            entity.ToTable("CustomerTransactionBonusRecord");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BonusDateTime).HasColumnType("datetime");
            entity.Property(e => e.BonusTypeCode).HasMaxLength(30);
            entity.Property(e => e.RecipientTypeCode).HasMaxLength(30);

            entity.HasOne(d => d.CustomerTransaction).WithMany(p => p.CustomerTransactionBonusRecords)
                .HasForeignKey(d => d.CustomerTransactionId)
                .HasConstraintName("FK_ShopBonusRecord_CustomerTransaction");
        });

        modelBuilder.Entity<CustomerTransactionDiscount>(entity =>
        {
            entity.ToTable("CustomerTransactionDiscount");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CouponSerialNumber).HasMaxLength(20);
            entity.Property(e => e.DiscountTypeCode).HasMaxLength(30);

            entity.HasOne(d => d.CouponSerialNumberNavigation).WithMany(p => p.CustomerTransactionDiscounts)
                .HasForeignKey(d => d.CouponSerialNumber)
                .HasConstraintName("FK_CustomerTransactionDiscount_ShopDiscountCoupon");

            entity.HasOne(d => d.CustomerTransaction).WithMany(p => p.CustomerTransactionDiscounts)
                .HasForeignKey(d => d.CustomerTransactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerTransactionDiscount_CustomerTransaction");
        });

        modelBuilder.Entity<CustomerTransactionFlow>(entity =>
        {
            entity.ToTable("CustomerTransactionFlow");

            entity.Property(e => e.LastModifyDateTime).HasColumnType("datetime");
            entity.Property(e => e.StatusCode).HasMaxLength(30);
            entity.Property(e => e.UserName).HasMaxLength(50);

            entity.HasOne(d => d.CustomerTransaction).WithMany(p => p.CustomerTransactionFlows)
                .HasForeignKey(d => d.CustomerTransactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerTransactionFlow_CustomerTransaction");
        });

        modelBuilder.Entity<FirebaseDevice>(entity =>
        {
            entity.HasKey(e => new { e.Owner, e.DeviceId });

            entity.ToTable("FirebaseDevice");

            entity.Property(e => e.Owner).HasMaxLength(100);
            entity.Property(e => e.DeviceId).HasMaxLength(200);
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<JwtRefreshToken>(entity =>
        {
            entity.HasKey(e => e.Token).HasName("PK_RefreshToken");

            entity.ToTable("JwtRefreshToken");

            entity.Property(e => e.Token)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.LastModifyDateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.ToTable("Notification");

            entity.Property(e => e.Content).HasMaxLength(500);
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.CreateUser).HasMaxLength(50);
            entity.Property(e => e.NotificationDateTime).HasColumnType("datetime");
            entity.Property(e => e.NotificationFrom).HasMaxLength(100);
            entity.Property(e => e.NotificationName).HasMaxLength(100);
            entity.Property(e => e.NotificationTo).HasMaxLength(100);
            entity.Property(e => e.NotificationType).HasMaxLength(30);
            entity.Property(e => e.StatusCode).HasMaxLength(30);
            entity.Property(e => e.TargrtUrl).HasMaxLength(300);
            entity.Property(e => e.Title).HasMaxLength(200);
            entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");
            entity.Property(e => e.UpdateUser).HasMaxLength(50);
        });

        modelBuilder.Entity<NotificationDetail>(entity =>
        {
            entity.ToTable("NotificationDetail");

            entity.Property(e => e.ClickAction).HasMaxLength(200);
            entity.Property(e => e.ErrorMessage).HasMaxLength(500);
            entity.Property(e => e.LastExecTime).HasColumnType("datetime");
            entity.Property(e => e.OpenTarget).HasMaxLength(100);
            entity.Property(e => e.ReadDateTime).HasColumnType("datetime");
            entity.Property(e => e.ReadUser).HasMaxLength(50);
            entity.Property(e => e.RecipientId).HasMaxLength(200);
            entity.Property(e => e.RecipientName).HasMaxLength(200);
            entity.Property(e => e.StatusCode).HasMaxLength(30);

            entity.HasOne(d => d.Notification).WithMany(p => p.NotificationDetails)
                .HasForeignKey(d => d.NotificationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NotificationDetail_Notification");
        });

        modelBuilder.Entity<NotificationFirebaseLog>(entity =>
        {
            entity.ToTable("NotificationFirebaseLog");

            entity.Property(e => e.FcmdeviceId)
                .HasMaxLength(255)
                .HasColumnName("FCMDeviceId");
            entity.Property(e => e.Fcmmessage)
                .HasMaxLength(500)
                .HasColumnName("FCMMessage");
            entity.Property(e => e.Fcmstatus).HasColumnName("FCMStatus");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.PermissionCode);

            entity.ToTable("Permission");

            entity.Property(e => e.PermissionCode).HasMaxLength(50);
            entity.Property(e => e.Module).HasMaxLength(30);
            entity.Property(e => e.PermissionName).HasMaxLength(50);
            entity.Property(e => e.StatusCode).HasMaxLength(30);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleCode);

            entity.ToTable("Role");

            entity.Property(e => e.RoleCode).HasMaxLength(50);
            entity.Property(e => e.RoleName).HasMaxLength(50);
            entity.Property(e => e.StatusCode).HasMaxLength(30);

            entity.HasMany(d => d.PermissionCodes).WithMany(p => p.RoleCodes)
                .UsingEntity<Dictionary<string, object>>(
                    "RolePermissionMapping",
                    r => r.HasOne<Permission>().WithMany()
                        .HasForeignKey("PermissionCode")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_RolePermissionMapping_Permission"),
                    l => l.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleCode")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_RolePermissionMapping_Role"),
                    j =>
                    {
                        j.HasKey("RoleCode", "PermissionCode");
                        j.ToTable("RolePermissionMapping");
                        j.IndexerProperty<string>("RoleCode").HasMaxLength(50);
                        j.IndexerProperty<string>("PermissionCode").HasMaxLength(50);
                    });
        });

        modelBuilder.Entity<Shop>(entity =>
        {
            entity.ToTable("Shop");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.AdminUserRemark).HasMaxLength(500);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FaceBookUrl).HasMaxLength(200);
            entity.Property(e => e.HomeImagePath).HasMaxLength(200);
            entity.Property(e => e.InstagramUrl).HasMaxLength(200);
            entity.Property(e => e.Introduction).HasMaxLength(500);
            entity.Property(e => e.LastModifyDateTime).HasColumnType("datetime");
            entity.Property(e => e.LineUrl).HasMaxLength(200);
            entity.Property(e => e.OfficialWebUrl).HasMaxLength(200);
            entity.Property(e => e.OwnerGenderCode).HasMaxLength(100);
            entity.Property(e => e.OwnerIdNumber).HasMaxLength(200);
            entity.Property(e => e.OwnerName).HasMaxLength(200);
            entity.Property(e => e.OwnerPhoneNumber).HasMaxLength(200);
            entity.Property(e => e.PhoneCountryCode).HasMaxLength(5);
            entity.Property(e => e.PhoneNumber).HasMaxLength(10);
            entity.Property(e => e.Remark).HasMaxLength(500);
            entity.Property(e => e.ShopName).HasMaxLength(100);
            entity.Property(e => e.ShopNumber).HasMaxLength(100);
            entity.Property(e => e.StatusCode).HasMaxLength(30);
            entity.Property(e => e.TaxId).HasMaxLength(50);
            entity.Property(e => e.TelAreaCode).HasMaxLength(3);
            entity.Property(e => e.TelNumber).HasMaxLength(10);

            entity.HasOne(d => d.AdminUser).WithMany(p => p.Shops)
                .HasForeignKey(d => d.AdminUserId)
                .HasConstraintName("Shop_FK");

            entity.HasMany(d => d.ShopEmployeesNavigation).WithMany(p => p.Shops)
                .UsingEntity<Dictionary<string, object>>(
                    "ShopEmployeeShopMapping",
                    r => r.HasOne<ShopEmployee>().WithMany()
                        .HasForeignKey("ShopEmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ShopEmployeeShopMapping_ShopEmployee"),
                    l => l.HasOne<Shop>().WithMany()
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ShopEmployeeShopMapping_Shop"),
                    j =>
                    {
                        j.HasKey("ShopId", "ShopEmployeeId");
                        j.ToTable("ShopEmployeeShopMapping");
                    });
        });

        modelBuilder.Entity<ShopAd>(entity =>
        {
            entity.ToTable("ShopAd");

            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Path).HasMaxLength(200);
            entity.Property(e => e.StatusCode).HasMaxLength(30);
            entity.Property(e => e.Title).HasMaxLength(1000);
            entity.Property(e => e.UrlLink).HasMaxLength(400);

            entity.HasOne(d => d.Shop).WithMany(p => p.ShopAds)
                .HasForeignKey(d => d.ShopId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShopAd_Shop");
        });

        modelBuilder.Entity<ShopCategoryMapping>(entity =>
        {
            entity.HasKey(e => new { e.ShopId, e.CategoryCode });

            entity.ToTable("ShopCategoryMapping");

            entity.Property(e => e.CategoryCode).HasMaxLength(50);

            entity.HasOne(d => d.CategoryCodeNavigation).WithMany(p => p.ShopCategoryMappings)
                .HasForeignKey(d => d.CategoryCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShopCategoryMapping_Category");

            entity.HasOne(d => d.Shop).WithMany(p => p.ShopCategoryMappings)
                .HasForeignKey(d => d.ShopId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShopCategoryMapping_Shop");
        });

        modelBuilder.Entity<ShopDiscountCoupon>(entity =>
        {
            entity.HasKey(e => e.SerialNumber);

            entity.ToTable("ShopDiscountCoupon");

            entity.Property(e => e.SerialNumber).HasMaxLength(20);
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.ExchangeDateTime)
                .HasColumnType("datetime")
                .HasColumnName("ExchangeDateTIme");
            entity.Property(e => e.ExpireDateTime).HasColumnType("datetime");
            entity.Property(e => e.UseDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.ShopDiscountCoupons)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_ShopDiscountCoupon_Customer");

            entity.HasOne(d => d.Shop).WithMany(p => p.ShopDiscountCoupons)
                .HasForeignKey(d => d.ShopId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShopDiscountCoupon_Shop");
        });

        modelBuilder.Entity<ShopEmployee>(entity =>
        {
            entity.ToTable("ShopEmployee");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address).HasMaxLength(400);
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.EmployeeName).HasMaxLength(50);
            entity.Property(e => e.IdNumber).HasMaxLength(40);
            entity.Property(e => e.LastModifyDateTime).HasColumnType("datetime");
            entity.Property(e => e.PhoneCountryCode).HasMaxLength(10);
            entity.Property(e => e.PhoneNumber).HasMaxLength(10);
            entity.Property(e => e.StatusCode).HasMaxLength(30);
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Shop).WithMany(p => p.ShopEmployees)
                .HasForeignKey(d => d.ShopId)
                .HasConstraintName("FK_ShopEmployee");

            entity.HasMany(d => d.PermissionCodes).WithMany(p => p.ShopEmployees)
                .UsingEntity<Dictionary<string, object>>(
                    "ShopEmployeePermissionMapping",
                    r => r.HasOne<Permission>().WithMany()
                        .HasForeignKey("PermissionCode")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ShopEmployeePermissionMapping_Permission"),
                    l => l.HasOne<ShopEmployee>().WithMany()
                        .HasForeignKey("ShopEmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ShopEmployeePermissionMapping_ShopEmployee"),
                    j =>
                    {
                        j.HasKey("ShopEmployeeId", "PermissionCode");
                        j.ToTable("ShopEmployeePermissionMapping");
                        j.IndexerProperty<string>("PermissionCode").HasMaxLength(50);
                    });

            entity.HasMany(d => d.RoleCodes).WithMany(p => p.ShopEmployees)
                .UsingEntity<Dictionary<string, object>>(
                    "ShopEmployeeRoleMapping",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleCode")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ShopEmployeeRoleMapping_Role"),
                    l => l.HasOne<ShopEmployee>().WithMany()
                        .HasForeignKey("ShopEmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ShopEmployeeRoleMapping_ShopEmployee"),
                    j =>
                    {
                        j.HasKey("ShopEmployeeId", "RoleCode");
                        j.ToTable("ShopEmployeeRoleMapping");
                        j.IndexerProperty<string>("RoleCode").HasMaxLength(50);
                    });
        });

        modelBuilder.Entity<ShopFlow>(entity =>
        {
            entity.ToTable("ShopFlow");

            entity.Property(e => e.LastModifyDateTime).HasColumnType("datetime");
            entity.Property(e => e.StatusCode).HasMaxLength(100);
            entity.Property(e => e.UserName).HasMaxLength(100);

            entity.HasOne(d => d.Shop).WithMany(p => p.ShopFlows)
                .HasForeignKey(d => d.ShopId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShopFlow");
        });

        modelBuilder.Entity<ShopWeekDay>(entity =>
        {
            entity.ToTable("ShopWeekDay");

            entity.Property(e => e.WeekDay).HasMaxLength(50);

            entity.HasOne(d => d.Shop).WithMany(p => p.ShopWeekDays)
                .HasForeignKey(d => d.ShopId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShopWeekDay_Shop");
        });

        modelBuilder.Entity<ShopWeekDayTime>(entity =>
        {
            entity.ToTable("ShopWeekDayTime");

            entity.Property(e => e.TimePeriodCode).HasMaxLength(30);

            entity.HasOne(d => d.ShopWeekDay).WithMany(p => p.ShopWeekDayTimes)
                .HasForeignKey(d => d.ShopWeekDayId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShopWeekDayTime_ShopWeekDay");
        });

        modelBuilder.Entity<SystemAd>(entity =>
        {
            entity.ToTable("SystemAd");

            entity.Property(e => e.AdTypeCode).HasMaxLength(30);
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.ImagePath).HasMaxLength(200);
            entity.Property(e => e.ImagePathForList).HasMaxLength(200);
            entity.Property(e => e.Remark).HasMaxLength(1000);
            entity.Property(e => e.StatusCode).HasMaxLength(30);
            entity.Property(e => e.SystemAdTypeCode).HasMaxLength(30);
            entity.Property(e => e.Title).HasMaxLength(100);
            entity.Property(e => e.UrlLink).HasMaxLength(200);
        });

        modelBuilder.Entity<SystemAdMapping>(entity =>
        {
            entity.HasKey(e => new { e.SystemAdId, e.SystemAdTypeCode }).HasName("SystemAdMapping_PK");

            entity.ToTable("SystemAdMapping");

            entity.Property(e => e.SystemAdTypeCode).HasMaxLength(100);

            entity.HasOne(d => d.SystemAd).WithMany(p => p.SystemAdMappings)
                .HasForeignKey(d => d.SystemAdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SystemAdMapping_FK");
        });

        modelBuilder.Entity<SystemAnnounce>(entity =>
        {
            entity.ToTable("SystemAnnounce");

            entity.Property(e => e.AnnounceContent).HasMaxLength(2000);
            entity.Property(e => e.AnnounceDateTime).HasColumnType("datetime");
            entity.Property(e => e.AnnounceLink).HasMaxLength(200);
            entity.Property(e => e.AnnounceTitle).HasMaxLength(1000);
            entity.Property(e => e.AnnounceTypeCode).HasMaxLength(100);
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.ExpireDateTime).HasColumnType("datetime");
            entity.Property(e => e.ImagePath).HasMaxLength(200);
            entity.Property(e => e.Remark).HasMaxLength(1000);
            entity.Property(e => e.StatusCode).HasMaxLength(20);
        });

        modelBuilder.Entity<SystemAnnounceMapping>(entity =>
        {
            entity.HasKey(e => new { e.SystemAnnounceId, e.AnnounceTypeCode });

            entity.ToTable("SystemAnnounceMapping");

            entity.Property(e => e.AnnounceTypeCode).HasMaxLength(100);

            entity.HasOne(d => d.SystemAnnounce).WithMany(p => p.SystemAnnounceMappings)
                .HasForeignKey(d => d.SystemAnnounceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SystemAnnounceMapping");
        });

        modelBuilder.Entity<SystemConfig>(entity =>
        {
            entity.HasKey(e => new { e.DataType, e.DataCode });

            entity.ToTable("SystemConfig");

            entity.Property(e => e.DataType).HasMaxLength(50);
            entity.Property(e => e.DataCode).HasMaxLength(50);
            entity.Property(e => e.DateName).HasMaxLength(50);
        });

        modelBuilder.Entity<SystemLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Log");

            entity.ToTable("SystemLog");

            entity.Property(e => e.Action).HasMaxLength(50);
            entity.Property(e => e.Application).HasMaxLength(100);
            entity.Property(e => e.Controller).HasMaxLength(50);
            entity.Property(e => e.EventDate).HasColumnType("datetime");
            entity.Property(e => e.Level).HasMaxLength(50);
            entity.Property(e => e.LogUser).HasMaxLength(100);
            entity.Property(e => e.Message).HasMaxLength(500);
            entity.Property(e => e.RequestIp).HasMaxLength(50);
            entity.Property(e => e.RequestParams).HasMaxLength(250);
        });

        modelBuilder.Entity<VerificationCode>(entity =>
        {
            entity.HasKey(e => new { e.VerifyCode, e.Recipient, e.ExpireDateTime }).HasName("PK_SMSVerification");

            entity.ToTable("VerificationCode");

            entity.Property(e => e.VerifyCode).HasMaxLength(400);
            entity.Property(e => e.Recipient).HasMaxLength(100);
            entity.Property(e => e.ExpireDateTime).HasColumnType("datetime");
            entity.Property(e => e.VerificationTypeCode).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
