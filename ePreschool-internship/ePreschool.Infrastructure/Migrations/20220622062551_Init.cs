using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ePreschool.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleLevel = table.Column<int>(type: "integer", nullable: true),
                    SignInAllowed = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Abbreviation = table.Column<string>(type: "text", nullable: true),
                    IsFavorite = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RowId = table.Column<int>(type: "integer", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    TableName = table.Column<string>(type: "text", nullable: true),
                    ReferrerUrl = table.Column<string>(type: "text", nullable: true),
                    CurrentUrl = table.Column<string>(type: "text", nullable: true),
                    Controller = table.Column<string>(type: "text", nullable: true),
                    Action = table.Column<string>(type: "text", nullable: true),
                    Message = table.Column<string>(type: "text", nullable: true),
                    ExceptionMessage = table.Column<string>(type: "text", nullable: true),
                    ExceptionStackTrace = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Preschools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    WebPage = table.Column<string>(type: "text", nullable: true),
                    IDNumber = table.Column<string>(type: "text", nullable: true),
                    TaxNumber = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PostalCode = table.Column<string>(type: "text", nullable: true),
                    Logo = table.Column<string>(type: "text", nullable: true),
                    LogoThumbnail = table.Column<string>(type: "text", nullable: true),
                    Identifier = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    InVatSystem = table.Column<bool>(type: "boolean", nullable: false),
                    VatIncludedInPrice = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preschools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IsFavorite = table.Column<bool>(type: "boolean", nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    IDNumber = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PostalCode = table.Column<string>(type: "text", nullable: true),
                    Identifier = table.Column<string>(type: "text", nullable: true),
                    Latitude = table.Column<string>(type: "text", nullable: true),
                    Longitude = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    PreschoolId = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessUnits_Preschools_PreschoolId",
                        column: x => x.PreschoolId,
                        principalTable: "Preschools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    ProfilePhoto = table.Column<string>(type: "text", nullable: true),
                    ProfilePhotoThumbnail = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    AlternativePhoneNumber = table.Column<string>(type: "text", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    CityId = table.Column<int>(type: "integer", nullable: true),
                    PostCode = table.Column<string>(type: "text", nullable: true),
                    PreschoolId = table.Column<int>(type: "integer", nullable: true),
                    CurrentBusinessUnitId = table.Column<int>(type: "integer", nullable: true),
                    JobDescription = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordSalt = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_BusinessUnits_CurrentBusinessUnitId",
                        column: x => x.CurrentBusinessUnitId,
                        principalTable: "BusinessUnits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Preschools_PreschoolId",
                        column: x => x.PreschoolId,
                        principalTable: "Preschools",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    PreschoolId = table.Column<int>(type: "integer", nullable: true),
                    BusinessUnitId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ApplicationRoleId = table.Column<int>(type: "integer", nullable: true),
                    ApplicationUserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_ApplicationRoleId",
                        column: x => x.ApplicationRoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_BusinessUnits_BusinessUnitId",
                        column: x => x.BusinessUnitId,
                        principalTable: "BusinessUnits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Preschools_PreschoolId",
                        column: x => x.PreschoolId,
                        principalTable: "Preschools",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "IsDeleted", "ModifiedAt", "Name", "NormalizedName", "RoleLevel", "SignInAllowed" },
                values: new object[,]
                {
                    { 1, "1547f983-1707-49d3-9390-5ec84ec35dca", new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), false, null, "SuperAdministrator", "SUPERADMINISTRATOR", null, false },
                    { 2, "2547f983-1707-49d3-9390-5ec84ec35dca", new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), false, null, "Ministry", "MINISTRY", 1, false },
                    { 3, "3547f983-1707-49d3-9390-5ec84ec35dca", new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), false, null, "PreschoolAdministrator", "PRESCHOOLADMINISTRATOR", 2, false },
                    { 4, "4547f983-1707-49d3-9390-5ec84ec35dca", new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), false, null, "PreschoolManagement", "PRESCHOOLMANAGEMENT", 3, false },
                    { 5, "5547f983-1707-49d3-9390-5ec84ec35dca", new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), false, null, "BusinessUnitAdministrator", "BUSINESSUNITADMINISTRATOR", 4, false },
                    { 6, "6547f983-1707-49d3-9390-5ec84ec35dca", new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), false, null, "BusinessUnitEmployee", "BUSINESSUNITEMPLOYEE", 5, false },
                    { 7, "7547f983-1707-49d3-9390-5ec84ec35dca", new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), false, null, "Parent", "PARENT", 6, false },
                    { 8, "8547f983-1707-49d3-9390-5ec84ec35dca", new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), false, null, "Expert", "EXPERT", 7, false }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Abbreviation", "CreatedAt", "IsDeleted", "IsFavorite", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, "BIH", new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), false, true, null, "Bosna i Hercegovina" },
                    { 2, "HR", new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), false, false, null, "Hrvatska" },
                    { 3, "SR", new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), false, false, null, "Srbija" },
                    { 4, "CG", new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), false, false, null, "Crna Gora" },
                    { 5, "SLO", new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), false, false, null, "Slovenija" },
                    { 6, "A", new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), false, false, null, "Austrija" },
                    { 7, "MKD", new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), false, false, null, "Makedonija" }
                });

            migrationBuilder.InsertData(
                table: "Preschools",
                columns: new[] { "Id", "Active", "Address", "CreatedAt", "Email", "IDNumber", "Identifier", "InVatSystem", "IsDeleted", "Logo", "LogoThumbnail", "ModifiedAt", "Name", "PhoneNumber", "PostalCode", "TaxNumber", "VatIncludedInPrice", "WebPage" },
                values: new object[,]
                {
                    { 1, true, "Sjeverni Logor 12", new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), "zemzem@gmail.com", null, null, false, false, null, null, null, "ZemZem", "+387 36 222 333", "88208", "65487978654654", false, null },
                    { 2, true, "Alekse Šantića 5", new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), "djecija.radost@gmail.com", null, null, false, false, null, null, null, "Djecija radost", "+387 36 222 333", "88208", "65487978654654", false, null }
                });

            migrationBuilder.InsertData(
                table: "BusinessUnits",
                columns: new[] { "Id", "Active", "Address", "CreatedAt", "Email", "IDNumber", "Identifier", "IsDeleted", "Latitude", "Longitude", "ModifiedAt", "Name", "PhoneNumber", "PostalCode", "PreschoolId" },
                values: new object[,]
                {
                    { 1, true, "Sjeverni Logor 12", new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), "zemzem_sjeverni@gmail.com", "643218645312", null, false, null, null, null, "ZemZem Sjeveni", "+387 36 333 333", "88208", 1 },
                    { 2, true, "Zalik 12b", new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), "zemzem_zalik@gmail.com", "985518645312", null, false, null, null, null, "ZemZem Zalik", "+387 36 111 333", "88208", 1 }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "CreatedAt", "IsDeleted", "IsFavorite", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), false, false, null, "Sarajevo" },
                    { 2, 1, new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), false, true, null, "Mostar" },
                    { 3, 1, new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), false, false, null, "Tuzla" },
                    { 4, 1, new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), false, false, null, "Zenica" },
                    { 5, 1, new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), false, false, null, "Bihać" },
                    { 6, 2, new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), false, false, null, "Zagreb" },
                    { 7, 2, new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), false, false, null, "Split" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Active", "Address", "AlternativePhoneNumber", "CityId", "ConcurrencyStamp", "CreatedAt", "CurrentBusinessUnitId", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "IsDeleted", "JobDescription", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedAt", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PasswordSalt", "PhoneNumber", "PhoneNumberConfirmed", "PostCode", "PreschoolId", "ProfilePhoto", "ProfilePhotoThumbnail", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, false, null, null, 1, "9547f983-1707-49d3-9390-5ec84ec35dca", new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), null, null, "admin@preschool.ba", true, "Admin", 2, false, null, "PreSchool", false, null, null, "ADMIN@PRESCHOOL.BA", "ADMIN", "/jgjzf1nC8YDuZMV5q0kYrRqIarjCDgWjBERaZiyyO0=", "DFQVcTkMv8qWjq/5ars8Eg==", null, false, null, null, null, null, null, false, "admin" },
                    { 2, 0, false, null, null, 1, "9547f983-1707-49d3-9390-5ec84ec35dca", new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), null, null, "manager@preschool.ba", true, "Manager", 2, false, null, "PreSchool", false, null, null, "MANAGER@PRESCHOOL.BA", "MANAGER", "/jgjzf1nC8YDuZMV5q0kYrRqIarjCDgWjBERaZiyyO0=", "DFQVcTkMv8qWjq/5ars8Eg==", null, false, null, null, null, null, null, false, "manager" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "ApplicationRoleId", "ApplicationUserId", "BusinessUnitId", "CreatedAt", "Id", "IsDeleted", "ModifiedAt", "PreschoolId" },
                values: new object[,]
                {
                    { 1, 1, null, null, null, new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), 1, false, null, null },
                    { 4, 2, null, null, null, new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), 2, false, null, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_ApplicationRoleId",
                table: "AspNetUserRoles",
                column: "ApplicationRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_ApplicationUserId",
                table: "AspNetUserRoles",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_BusinessUnitId",
                table: "AspNetUserRoles",
                column: "BusinessUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_PreschoolId",
                table: "AspNetUserRoles",
                column: "PreschoolId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CityId",
                table: "AspNetUsers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CurrentBusinessUnitId",
                table: "AspNetUsers",
                column: "CurrentBusinessUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PreschoolId",
                table: "AspNetUsers",
                column: "PreschoolId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessUnits_PreschoolId",
                table: "BusinessUnits",
                column: "PreschoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BusinessUnits");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Preschools");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
