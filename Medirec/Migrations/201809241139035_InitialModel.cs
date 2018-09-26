namespace Medirec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Allergies",
                c => new
                    {
                        AllergiesId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AllergiesId);
            
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        AreaId = c.Int(nullable: false, identity: true),
                        AreaCode = c.String(maxLength: 4),
                        NameAr = c.String(nullable: false, maxLength: 50),
                        NameEn = c.String(nullable: false, maxLength: 50),
                        CityId = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 225),
                        CreadtedDateTime = c.DateTime(nullable: false),
                        ModifiedBy = c.String(maxLength: 225),
                        ModifiedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AreaId)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        CountryCode = c.String(maxLength: 4),
                        NameAr = c.String(nullable: false, maxLength: 50),
                        NameEn = c.String(nullable: false, maxLength: 50),
                        CountryId = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 225),
                        CreadtedDateTime = c.DateTime(nullable: false),
                        ModifiedBy = c.String(maxLength: 225),
                        ModifiedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CityId)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        CountryCode = c.String(nullable: false, maxLength: 4),
                        NameAr = c.String(nullable: false, maxLength: 50),
                        NameEn = c.String(nullable: false, maxLength: 50),
                        CreatedBy = c.String(maxLength: 225),
                        CreadtedDateTime = c.DateTime(nullable: false),
                        ModifiedBy = c.String(maxLength: 225),
                        ModifiedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.BloodPressures",
                c => new
                    {
                        BloodPressureId = c.Int(nullable: false, identity: true),
                        Systolic = c.Double(nullable: false),
                        Diastolic = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BloodPressureId);
            
            CreateTable(
                "dbo.BookingTypes",
                c => new
                    {
                        BookingTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.BookingTypeId);
            
            CreateTable(
                "dbo.Calenders",
                c => new
                    {
                        CalendersId = c.Int(nullable: false, identity: true),
                        TimeFrom = c.Time(precision: 7),
                        TimeTo = c.Time(precision: 7),
                        DayName = c.String(nullable: false, maxLength: 10),
                        GenerateEveryXMin = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        EntityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CalendersId)
                .ForeignKey("dbo.Doctors", t => t.DoctorId)
                .ForeignKey("dbo.Entities", t => t.EntityId)
                .Index(t => new { t.TimeFrom, t.TimeTo, t.DayName, t.GenerateEveryXMin, t.DoctorId, t.EntityId }, unique: true, name: "IX_Calenders");
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorId = c.Int(nullable: false, identity: true),
                        DoctorCode = c.String(nullable: false, maxLength: 5),
                        NameAr = c.String(nullable: false, maxLength: 100),
                        NameEn = c.String(nullable: false, maxLength: 100),
                        SpecialtyId = c.Int(nullable: false),
                        Gender = c.String(nullable: false, maxLength: 1),
                        AboutDoctorShortDescriptionEn = c.String(maxLength: 100),
                        AboutDoctorLongDescriptionEn = c.String(maxLength: 1000),
                        AboutDoctorShortDescriptionAr = c.String(maxLength: 100),
                        AboutDoctorLongDescriptionAr = c.String(maxLength: 1000),
                        BirthDate = c.DateTime(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                        SearchName = c.String(nullable: false, maxLength: 225),
                        PhoneNumber = c.String(nullable: false, maxLength: 11),
                        IsActive = c.Boolean(nullable: false),
                        ImageURL = c.String(maxLength: 1500),
                        CreatedBy = c.String(maxLength: 225),
                        CreadtedDateTime = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 225),
                        ModifiedDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.DoctorId)
                .ForeignKey("dbo.Specialties", t => t.SpecialtyId)
                .Index(t => t.SpecialtyId);
            
            CreateTable(
                "dbo.DoctorsDoctorsTitles",
                c => new
                    {
                        DoctorId = c.Int(nullable: false),
                        DoctorsTitlesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DoctorId, t.DoctorsTitlesId })
                .ForeignKey("dbo.Doctors", t => t.DoctorId)
                .ForeignKey("dbo.DoctorsTitles", t => t.DoctorsTitlesId)
                .Index(t => t.DoctorId)
                .Index(t => t.DoctorsTitlesId);
            
            CreateTable(
                "dbo.DoctorsTitles",
                c => new
                    {
                        DoctorsTitlesId = c.Int(nullable: false, identity: true),
                        DoctorsTitlesCode = c.String(),
                        NameAr = c.String(nullable: false, maxLength: 50),
                        NameEn = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.DoctorsTitlesId);
            
            CreateTable(
                "dbo.DoctorsEntities",
                c => new
                    {
                        DoctorId = c.Int(nullable: false),
                        EntityId = c.Int(nullable: false),
                        PaymentTypesId = c.Int(nullable: false),
                        CalenderTypeId = c.Int(nullable: false),
                        WaitingTime = c.Int(nullable: false),
                        TicketPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DoctorId, t.EntityId, t.PaymentTypesId })
                .ForeignKey("dbo.Doctors", t => t.DoctorId)
                .ForeignKey("dbo.Entities", t => t.EntityId)
                .ForeignKey("dbo.PaymentTypes", t => t.PaymentTypesId)
                .Index(t => t.DoctorId)
                .Index(t => t.EntityId)
                .Index(t => t.PaymentTypesId);
            
            CreateTable(
                "dbo.Entities",
                c => new
                    {
                        EntityId = c.Int(nullable: false, identity: true),
                        EntityCode = c.String(nullable: false, maxLength: 4),
                        NameAr = c.String(nullable: false),
                        NameEn = c.String(nullable: false),
                        CountryId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        AreaId = c.Int(nullable: false),
                        AddressEn = c.String(nullable: false, maxLength: 1000),
                        AddressAr = c.String(nullable: false, maxLength: 1000),
                        EntitiesTypesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EntityId)
                .ForeignKey("dbo.Areas", t => t.AreaId)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .ForeignKey("dbo.EntitiesTypes", t => t.EntitiesTypesId)
                .Index(t => t.CountryId)
                .Index(t => t.CityId)
                .Index(t => t.AreaId)
                .Index(t => t.EntitiesTypesId);
            
            CreateTable(
                "dbo.EntitiesTypes",
                c => new
                    {
                        EntitiesTypesId = c.Int(nullable: false, identity: true),
                        EntitiesTypesCode = c.String(nullable: false, maxLength: 4),
                        NameAr = c.String(nullable: false),
                        NameEn = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EntitiesTypesId);
            
            CreateTable(
                "dbo.PaymentTypes",
                c => new
                    {
                        PaymentTypesId = c.Int(nullable: false, identity: true),
                        PaymentTypesCode = c.String(nullable: false, maxLength: 5),
                        NameAr = c.String(nullable: false, maxLength: 50),
                        NameEn = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.PaymentTypesId);
            
            CreateTable(
                "dbo.DoctorsSubSpecialities",
                c => new
                    {
                        DoctorId = c.Int(nullable: false),
                        SubSpecialitiesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DoctorId, t.SubSpecialitiesId })
                .ForeignKey("dbo.Doctors", t => t.DoctorId)
                .ForeignKey("dbo.SubSpecialities", t => t.SubSpecialitiesId)
                .Index(t => t.DoctorId)
                .Index(t => t.SubSpecialitiesId);
            
            CreateTable(
                "dbo.SubSpecialities",
                c => new
                    {
                        SubSpecialitiesId = c.Int(nullable: false, identity: true),
                        SubSpecialitiesCode = c.String(maxLength: 5),
                        NameAr = c.String(nullable: false, maxLength: 50),
                        NameEn = c.String(nullable: false, maxLength: 50),
                        SpecialtyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubSpecialitiesId)
                .ForeignKey("dbo.Specialties", t => t.SpecialtyId)
                .Index(t => t.SpecialtyId);
            
            CreateTable(
                "dbo.Specialties",
                c => new
                    {
                        SpecialtyId = c.Int(nullable: false, identity: true),
                        SpecialtyCode = c.String(maxLength: 4),
                        NameAr = c.String(nullable: false, maxLength: 100),
                        NameEn = c.String(nullable: false, maxLength: 100),
                        CreatedBy = c.String(maxLength: 225),
                        CreadtedDateTime = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 225),
                        ModifiedDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.SpecialtyId);
            
            CreateTable(
                "dbo.CalendersDetails",
                c => new
                    {
                        CalendersDetailsId = c.Int(nullable: false, identity: true),
                        CalendersId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        EntityId = c.Int(nullable: false),
                        TimeFrom = c.Time(precision: 7),
                        TimeTo = c.Time(precision: 7),
                        DayName = c.String(),
                        Date = c.DateTime(),
                        IsReserved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CalendersDetailsId)
                .ForeignKey("dbo.Calenders", t => t.CalendersId)
                .ForeignKey("dbo.Doctors", t => t.DoctorId)
                .ForeignKey("dbo.Entities", t => t.EntityId)
                .Index(t => t.CalendersId)
                .Index(t => t.DoctorId)
                .Index(t => t.EntityId);
            
            CreateTable(
                "dbo.Condations",
                c => new
                    {
                        CondationsId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CondationsId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 100),
                        TypeOfRelation = c.String(maxLength: 10),
                        PhoneNumber01 = c.String(nullable: false, maxLength: 11),
                        PhoneNumber02 = c.String(maxLength: 11),
                        Email = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.HumanBodies",
                c => new
                    {
                        HumanBodyId = c.Int(nullable: false, identity: true),
                        Height = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HumanBodyId);
            
            CreateTable(
                "dbo.Immunizations",
                c => new
                    {
                        ImmunizationId = c.Int(nullable: false, identity: true),
                        VaccineId = c.Int(nullable: false),
                        DateGiven = c.DateTime(nullable: false),
                        AdministratedBy = c.String(maxLength: 25),
                        NextDoesDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImmunizationId)
                .ForeignKey("dbo.Vaccines", t => t.VaccineId)
                .Index(t => t.VaccineId);
            
            CreateTable(
                "dbo.Vaccines",
                c => new
                    {
                        VaccineId = c.Int(nullable: false, identity: true),
                        VaccineCode = c.Int(nullable: false),
                        Name = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.VaccineId);
            
            CreateTable(
                "dbo.MedicalDevices",
                c => new
                    {
                        MedicalDevicesId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedicalDevicesId);
            
            CreateTable(
                "dbo.Medications",
                c => new
                    {
                        MedicationsId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedicationsId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PatientCode = c.String(maxLength: 4),
                        FullName = c.String(nullable: false, maxLength: 100),
                        CountryId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        AreaId = c.Int(nullable: false),
                        InsuranceId = c.Int(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 11),
                        Gender = c.String(nullable: false, maxLength: 1),
                        Address = c.String(nullable: false, maxLength: 100),
                        ImageURL = c.String(maxLength: 1500),
                        BirthDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 225),
                        CreadtedDateTime = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 225),
                        ModifiedDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.PatientId);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        ResourcesId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        ImageUrl = c.String(maxLength: 1500),
                        CreadtedDateTime = c.DateTime(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResourcesId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Immunizations", "VaccineId", "dbo.Vaccines");
            DropForeignKey("dbo.CalendersDetails", "EntityId", "dbo.Entities");
            DropForeignKey("dbo.CalendersDetails", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.CalendersDetails", "CalendersId", "dbo.Calenders");
            DropForeignKey("dbo.Calenders", "EntityId", "dbo.Entities");
            DropForeignKey("dbo.Calenders", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Doctors", "SpecialtyId", "dbo.Specialties");
            DropForeignKey("dbo.SubSpecialities", "SpecialtyId", "dbo.Specialties");
            DropForeignKey("dbo.DoctorsSubSpecialities", "SubSpecialitiesId", "dbo.SubSpecialities");
            DropForeignKey("dbo.DoctorsSubSpecialities", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.DoctorsEntities", "PaymentTypesId", "dbo.PaymentTypes");
            DropForeignKey("dbo.DoctorsEntities", "EntityId", "dbo.Entities");
            DropForeignKey("dbo.Entities", "EntitiesTypesId", "dbo.EntitiesTypes");
            DropForeignKey("dbo.Entities", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Entities", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Entities", "AreaId", "dbo.Areas");
            DropForeignKey("dbo.DoctorsEntities", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.DoctorsDoctorsTitles", "DoctorsTitlesId", "dbo.DoctorsTitles");
            DropForeignKey("dbo.DoctorsDoctorsTitles", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Areas", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Immunizations", new[] { "VaccineId" });
            DropIndex("dbo.CalendersDetails", new[] { "EntityId" });
            DropIndex("dbo.CalendersDetails", new[] { "DoctorId" });
            DropIndex("dbo.CalendersDetails", new[] { "CalendersId" });
            DropIndex("dbo.SubSpecialities", new[] { "SpecialtyId" });
            DropIndex("dbo.DoctorsSubSpecialities", new[] { "SubSpecialitiesId" });
            DropIndex("dbo.DoctorsSubSpecialities", new[] { "DoctorId" });
            DropIndex("dbo.Entities", new[] { "EntitiesTypesId" });
            DropIndex("dbo.Entities", new[] { "AreaId" });
            DropIndex("dbo.Entities", new[] { "CityId" });
            DropIndex("dbo.Entities", new[] { "CountryId" });
            DropIndex("dbo.DoctorsEntities", new[] { "PaymentTypesId" });
            DropIndex("dbo.DoctorsEntities", new[] { "EntityId" });
            DropIndex("dbo.DoctorsEntities", new[] { "DoctorId" });
            DropIndex("dbo.DoctorsDoctorsTitles", new[] { "DoctorsTitlesId" });
            DropIndex("dbo.DoctorsDoctorsTitles", new[] { "DoctorId" });
            DropIndex("dbo.Doctors", new[] { "SpecialtyId" });
            DropIndex("dbo.Calenders", "IX_Calenders");
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropIndex("dbo.Areas", new[] { "CityId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Resources");
            DropTable("dbo.Patients");
            DropTable("dbo.Medications");
            DropTable("dbo.MedicalDevices");
            DropTable("dbo.Vaccines");
            DropTable("dbo.Immunizations");
            DropTable("dbo.HumanBodies");
            DropTable("dbo.Contacts");
            DropTable("dbo.Condations");
            DropTable("dbo.CalendersDetails");
            DropTable("dbo.Specialties");
            DropTable("dbo.SubSpecialities");
            DropTable("dbo.DoctorsSubSpecialities");
            DropTable("dbo.PaymentTypes");
            DropTable("dbo.EntitiesTypes");
            DropTable("dbo.Entities");
            DropTable("dbo.DoctorsEntities");
            DropTable("dbo.DoctorsTitles");
            DropTable("dbo.DoctorsDoctorsTitles");
            DropTable("dbo.Doctors");
            DropTable("dbo.Calenders");
            DropTable("dbo.BookingTypes");
            DropTable("dbo.BloodPressures");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Areas");
            DropTable("dbo.Allergies");
        }
    }
}
