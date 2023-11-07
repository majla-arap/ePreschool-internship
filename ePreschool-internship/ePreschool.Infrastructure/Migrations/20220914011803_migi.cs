using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ePreschool.Infrastructure.Migrations
{
    public partial class migi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Employed = table.Column<bool>(type: "boolean", nullable: false),
                    EmployerName = table.Column<string>(type: "text", nullable: true),
                    EmployerCityId = table.Column<int>(type: "integer", nullable: true),
                    EmployerAdress = table.Column<string>(type: "text", nullable: true),
                    EmployerPhoneNumber = table.Column<string>(type: "text", nullable: true),
                    JobDescription = table.Column<string>(type: "text", nullable: true),
                    EducationLevel = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parents_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Parents_Cities_EmployerCityId",
                        column: x => x.EmployerCityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NumberOfHours = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessUnitPrograms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BusinessUnitId = table.Column<int>(type: "integer", nullable: false),
                    ProgramId = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessUnitPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessUnitPrograms_BusinessUnits_BusinessUnitId",
                        column: x => x.BusinessUnitId,
                        principalTable: "BusinessUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessUnitPrograms_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    GUID = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CityOfBirthId = table.Column<int>(type: "integer", nullable: false),
                    CountryOfBirthId = table.Column<int>(type: "integer", nullable: false),
                    FamilyMembers = table.Column<int>(type: "integer", nullable: false),
                    Adress = table.Column<string>(type: "text", nullable: true),
                    PreschoolId = table.Column<int>(type: "integer", nullable: false),
                    BusinessUnitId = table.Column<int>(type: "integer", nullable: false),
                    AlternativeBusinessUnitId = table.Column<int>(type: "integer", nullable: false),
                    ProgramId = table.Column<int>(type: "integer", nullable: false),
                    ChildDevelopmentStatus = table.Column<int>(type: "integer", nullable: false),
                    DiagnosticProcedure = table.Column<int>(type: "integer", nullable: true),
                    Rehabilitation = table.Column<bool>(type: "boolean", nullable: false),
                    SpecificHealthNeeds = table.Column<string>(type: "text", nullable: true),
                    PreviousPreschool = table.Column<string>(type: "text", nullable: true),
                    Siblings = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Children_BusinessUnits_AlternativeBusinessUnitId",
                        column: x => x.AlternativeBusinessUnitId,
                        principalTable: "BusinessUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Children_BusinessUnits_BusinessUnitId",
                        column: x => x.BusinessUnitId,
                        principalTable: "BusinessUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Children_Cities_CityOfBirthId",
                        column: x => x.CityOfBirthId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Children_Countries_CountryOfBirthId",
                        column: x => x.CountryOfBirthId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Children_Preschools_PreschoolId",
                        column: x => x.PreschoolId,
                        principalTable: "Preschools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Children_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParentChildren",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentId = table.Column<int>(type: "integer", nullable: false),
                    ChildId = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentChildren", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParentChildren_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParentChildren_Parents_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Parents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Parents",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "EducationLevel", "Email", "Employed", "EmployerAdress", "EmployerCityId", "EmployerName", "EmployerPhoneNumber", "FirstName", "IsDeleted", "JobDescription", "LastName", "ModifiedAt", "PhoneNumber", "UserId" },
                values: new object[] { 1, new DateTime(2022, 9, 14, 3, 18, 2, 182, DateTimeKind.Local).AddTicks(2056), new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), 7, "admir@gmail.com", true, null, null, null, null, "Admir", false, null, "Kajtaz", null, "+387 61 333 333", 1 });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "Id", "CreatedAt", "Description", "IsDeleted", "ModifiedAt", "Name", "NumberOfHours" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), "All day", false, null, "All day", 10 },
                    { 2, new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), "Half day", false, null, "Half day", 5 },
                    { 3, new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), "Nursery", false, null, "Nursery", 10 },
                    { 4, new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), "Playroom", false, null, "Playroom", 3 }
                });

            migrationBuilder.InsertData(
                table: "BusinessUnitPrograms",
                columns: new[] { "Id", "BusinessUnitId", "CreatedAt", "IsDeleted", "ModifiedAt", "ProgramId" },
                values: new object[] { 1, 1, new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), false, null, 1 });

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "Adress", "AlternativeBusinessUnitId", "BirthDate", "BusinessUnitId", "ChildDevelopmentStatus", "CityOfBirthId", "CountryOfBirthId", "CreatedAt", "DiagnosticProcedure", "FamilyMembers", "FirstName", "GUID", "IsDeleted", "LastName", "ModifiedAt", "PreschoolId", "PreviousPreschool", "ProgramId", "Rehabilitation", "Siblings", "SpecificHealthNeeds" },
                values: new object[,]
                {
                    { 1, "Solakovica br. 3", 2, new DateTime(2022, 9, 14, 3, 18, 2, 182, DateTimeKind.Local).AddTicks(2082), 1, 0, 2, 1, new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), null, 4, "Alin", null, false, "Kajtaz", null, 1, null, 1, false, null, null },
                    { 2, "Solakovica br. 3", 2, new DateTime(2022, 9, 14, 3, 18, 2, 182, DateTimeKind.Local).AddTicks(2087), 1, 0, 2, 1, new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), null, 4, "Nadja", null, false, "Kajtaz", null, 1, null, 1, false, null, null }
                });

            migrationBuilder.InsertData(
                table: "ParentChildren",
                columns: new[] { "Id", "ChildId", "CreatedAt", "IsDeleted", "ModifiedAt", "ParentId" },
                values: new object[] { 1, 1, new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local), false, null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessUnitPrograms_BusinessUnitId",
                table: "BusinessUnitPrograms",
                column: "BusinessUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessUnitPrograms_ProgramId",
                table: "BusinessUnitPrograms",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Children_AlternativeBusinessUnitId",
                table: "Children",
                column: "AlternativeBusinessUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Children_BusinessUnitId",
                table: "Children",
                column: "BusinessUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Children_CityOfBirthId",
                table: "Children",
                column: "CityOfBirthId");

            migrationBuilder.CreateIndex(
                name: "IX_Children_CountryOfBirthId",
                table: "Children",
                column: "CountryOfBirthId");

            migrationBuilder.CreateIndex(
                name: "IX_Children_PreschoolId",
                table: "Children",
                column: "PreschoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Children_ProgramId",
                table: "Children",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentChildren_ChildId",
                table: "ParentChildren",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentChildren_ParentId",
                table: "ParentChildren",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Parents_EmployerCityId",
                table: "Parents",
                column: "EmployerCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Parents_UserId",
                table: "Parents",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessUnitPrograms");

            migrationBuilder.DropTable(
                name: "ParentChildren");

            migrationBuilder.DropTable(
                name: "Children");

            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropTable(
                name: "Programs");
        }
    }
}
