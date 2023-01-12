using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iHealthAPI.Migrations
{
    public partial class AddPerson1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaceId = table.Column<int>(type: "int", nullable: true),
                    ClinicId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MapsLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkerId = table.Column<int>(type: "int", nullable: false),
                    ClinicId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Place_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clinic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClinicType = table.Column<int>(type: "int", nullable: false),
                    ClinicTypeString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PlaceId = table.Column<int>(type: "int", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    WorkerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clinic_Place_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clinic_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Worker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Salary = table.Column<float>(type: "real", nullable: false),
                    Bonuses = table.Column<float>(type: "real", nullable: false),
                    WorkingDayAndStartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkingDayAndEndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsEmployee = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: true),
                    ClinicId = table.Column<int>(type: "int", nullable: true),
                    NurseId = table.Column<int>(type: "int", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    OtherStaffId = table.Column<int>(type: "int", nullable: true),
                    PlaceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Worker_Place_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMBG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaceId = table.Column<int>(type: "int", nullable: true),
                    ClinicId = table.Column<int>(type: "int", nullable: false),
                    WorkerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_Clinic_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patient_Place_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClinicWorker",
                columns: table => new
                {
                    ClinicsId = table.Column<int>(type: "int", nullable: false),
                    WorkersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicWorker", x => new { x.ClinicsId, x.WorkersId });
                    table.ForeignKey(
                        name: "FK_ClinicWorker_Clinic_ClinicsId",
                        column: x => x.ClinicsId,
                        principalTable: "Clinic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClinicWorker_Worker_WorkersId",
                        column: x => x.WorkersId,
                        principalTable: "Worker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Faksimil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctor_Worker_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Worker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Nurse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Speciallity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nurse_Worker_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Worker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OtherStaff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkingDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherStaff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherStaff_Worker_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Worker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientWorker",
                columns: table => new
                {
                    PatientsId = table.Column<int>(type: "int", nullable: false),
                    WorkersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientWorker", x => new { x.PatientsId, x.WorkersId });
                    table.ForeignKey(
                        name: "FK_PatientWorker_Patient_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientWorker_Worker_WorkersId",
                        column: x => x.WorkersId,
                        principalTable: "Worker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "ClinicId", "Email", "Name", "Password", "PlaceId", "Surname", "Token" },
                values: new object[] { 1, 1, "halimifat@gmail.com", "Fat Main User", "तྛ䔵㨴╉⚻ছ㺎睲બꊽ矎퉚閾", 1, "Halimi ", null });

            migrationBuilder.InsertData(
                table: "Worker",
                columns: new[] { "Id", "Bonuses", "ClinicId", "DoctorId", "IsDeleted", "IsEmployee", "NurseId", "OtherStaffId", "PatientId", "PlaceId", "Salary", "WorkingDayAndEndTime", "WorkingDayAndStartTime" },
                values: new object[] { 1, 300f, 1, 1, false, true, 1, 1, 1, null, 32000f, new DateTime(2020, 1, 1, 13, 10, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 12, 10, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "Id", "BirthDate", "Email", "Faksimil", "Gender", "Image", "Name", "PhoneNumber", "Surname", "Token", "WorkerId" },
                values: new object[] { 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "halimifat@gmail.com", "0012343", "Male", "DemoClinic.png", "Doctor Fat Halimi", "070224560", "Doctor Halimi", null, 1 });

            migrationBuilder.InsertData(
                table: "Nurse",
                columns: new[] { "Id", "BirthDate", "Gender", "Name", "Speciallity", "Surname", "WorkerId" },
                values: new object[] { 1, new DateTime(2020, 1, 1, 12, 10, 0, 0, DateTimeKind.Unspecified), "Female", "DemoNurse", "Orthodont", "DemoNurseSurname", 1 });

            migrationBuilder.InsertData(
                table: "OtherStaff",
                columns: new[] { "Id", "BirthDate", "Gender", "Name", "Surname", "WorkerId", "WorkingDescription" },
                values: new object[] { 1, new DateTime(2020, 1, 1, 12, 10, 0, 0, DateTimeKind.Unspecified), "Female", "OtherStaffName", "OtherStaffSurname", 1, "Hygienist" });

            migrationBuilder.InsertData(
                table: "Place",
                columns: new[] { "Id", "Address", "CityName", "ClinicId", "CountyName", "Latitude", "Longitude", "MapsLink", "PatientId", "Region", "UserId", "WorkerId", "ZipCode" },
                values: new object[] { 1, "Demo Address", "Demo City", 1, "Demo Country", "12.200", "12.200", "https://www.google.com/maps", 1, "Demo Region", 1, 1, "Demo ZipCode" });

            migrationBuilder.InsertData(
                table: "Clinic",
                columns: new[] { "Id", "ClinicType", "ClinicTypeString", "Email", "Image", "Name", "PatientId", "PhoneNumber", "PlaceId", "RegistrationNo", "UserId", "WorkerId" },
                values: new object[] { 1, 1, "GeneralPurposeClinic", "halimifat@gmail.com", "DemoClinic.png", "First Demo Clinic", 1, "070224560", 1, "0012343", 1, 1 });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "BirthDate", "ClinicId", "EMBG", "Email", "Gender", "Image", "IsDeleted", "Name", "PhoneNumber", "PlaceId", "Surname", "WorkerId" },
                values: new object[] { 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "0012343", "halimifat@gmail.com", "Male", "DemoClinic.png", false, "Patient Fat", "070224560", 1, "Patient Halimi", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Clinic_PlaceId",
                table: "Clinic",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Clinic_UserId",
                table: "Clinic",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicWorker_WorkersId",
                table: "ClinicWorker",
                column: "WorkersId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_WorkerId",
                table: "Doctor",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Nurse_WorkerId",
                table: "Nurse",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherStaff_WorkerId",
                table: "OtherStaff",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_ClinicId",
                table: "Patient",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_PlaceId",
                table: "Patient",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientWorker_WorkersId",
                table: "PatientWorker",
                column: "WorkersId");

            migrationBuilder.CreateIndex(
                name: "IX_Place_UserId",
                table: "Place",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Worker_PlaceId",
                table: "Worker",
                column: "PlaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClinicWorker");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Nurse");

            migrationBuilder.DropTable(
                name: "OtherStaff");

            migrationBuilder.DropTable(
                name: "PatientWorker");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Worker");

            migrationBuilder.DropTable(
                name: "Clinic");

            migrationBuilder.DropTable(
                name: "Place");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
