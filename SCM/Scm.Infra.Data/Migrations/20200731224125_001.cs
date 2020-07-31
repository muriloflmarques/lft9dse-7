using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Scm.Infra.Data.Migrations
{
    public partial class _001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ChangeDate = table.Column<DateTime>(nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    TeacherName = table.Column<string>(maxLength: 150, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Capacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ChangeDate = table.Column<DateTime>(nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    Surname = table.Column<string>(maxLength: 120, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    AddresLineOne = table.Column<string>(maxLength: 120, nullable: false),
                    AddresLineTwo = table.Column<string>(maxLength: 120, nullable: true),
                    Number = table.Column<int>(nullable: true),
                    City = table.Column<string>(maxLength: 100, nullable: true),
                    CountyOrProvince = table.Column<string>(maxLength: 100, nullable: true),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Countries_Id",
                        column: x => x.Id,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Afghanistan" },
                    { 126, "Netherlands" },
                    { 127, "New Zealand" },
                    { 128, "Nicaragua" },
                    { 129, "Niger" },
                    { 130, "Nigeria" },
                    { 131, "Norway" },
                    { 132, "Oman" },
                    { 133, "Pakistan" },
                    { 134, "Palau" },
                    { 125, "Nepal" },
                    { 135, "Panama" },
                    { 137, "Paraguay" },
                    { 138, "Peru" },
                    { 139, "Philippines" },
                    { 140, "Poland" },
                    { 141, "Portugal" },
                    { 142, "Qatar" },
                    { 143, "Romania" },
                    { 144, "Russian Federation" },
                    { 145, "Rwanda" },
                    { 136, "Papua New Guinea" },
                    { 124, "Nauru" },
                    { 123, "Namibia" },
                    { 122, "Myanmar" },
                    { 101, "Liechtenstein" },
                    { 102, "Lithuania" },
                    { 103, "Luxembourg" },
                    { 104, "Macedonia" },
                    { 105, "Madagascar" },
                    { 106, "Malawi" },
                    { 107, "Malaysia" },
                    { 108, "Maldives" },
                    { 109, "Mali" },
                    { 110, "Malta" },
                    { 111, "Marshall Islands" },
                    { 112, "Mauritania" },
                    { 113, "Mauritius" },
                    { 114, "Mexico" },
                    { 115, "Micronesia" },
                    { 116, "Moldova" },
                    { 117, "Monaco" },
                    { 118, "Mongolia" },
                    { 119, "Montenegro" },
                    { 120, "Morocco" },
                    { 121, "Mozambique" },
                    { 146, "St Kitts and Nevis" },
                    { 100, "Libya" },
                    { 147, "St Lucia" },
                    { 149, "Samoa" },
                    { 175, "Thailand" },
                    { 176, "Togo" },
                    { 177, "Tonga" },
                    { 178, "Trinidad & Tobago" },
                    { 179, "Tunisia" },
                    { 180, "Turkey" },
                    { 181, "Turkmenistan" },
                    { 182, "Tuvalu" },
                    { 183, "Uganda" },
                    { 174, "Tanzania" },
                    { 184, "Ukraine" },
                    { 186, "United Kingdom" },
                    { 187, "United States" },
                    { 188, "Uruguay" },
                    { 189, "Uzbekistan" },
                    { 190, "Vanuatu" },
                    { 191, "Vatican City" },
                    { 192, "Venezuela" },
                    { 193, "Vietnam" },
                    { 194, "Yemen" },
                    { 185, "United Arab Emirates" },
                    { 173, "Tajikistan" },
                    { 172, "Taiwan" },
                    { 171, "Syria" },
                    { 150, "San Marino" },
                    { 151, "Sao Tome &Principe" },
                    { 152, "Saudi Arabia" },
                    { 153, "Senegal" },
                    { 154, "Serbia" },
                    { 155, "Seychelles" },
                    { 156, "Sierra Leone" },
                    { 157, "Singapore" },
                    { 158, "Slovakia" },
                    { 159, "Slovenia" },
                    { 160, "Solomon Islands" },
                    { 161, "Somalia" },
                    { 162, "South Africa" },
                    { 163, "South Sudan" },
                    { 164, "Spain" },
                    { 165, "Sri Lanka" },
                    { 166, "Sudan" },
                    { 167, "Suriname" },
                    { 168, "Swaziland" },
                    { 169, "Sweden" },
                    { 170, "Switzerland" },
                    { 148, "Saint Vincent &the Grenadines" },
                    { 99, "Liberia" },
                    { 98, "Lesotho" },
                    { 97, "Lebanon" },
                    { 27, "Burkina" },
                    { 28, "Burundi" },
                    { 29, "Cambodia" },
                    { 30, "Cameroon" },
                    { 31, "Canada" },
                    { 32, "Cape Verde" },
                    { 33, "Central African Republic" },
                    { 34, "Chad" },
                    { 35, "Chile" },
                    { 26, "Bulgaria" },
                    { 36, "China" },
                    { 38, "Comoros" },
                    { 39, "Congo" },
                    { 40, "Democratic Republic Of Congo" },
                    { 41, "Costa Rica" },
                    { 42, "Croatia" },
                    { 43, "Cuba" },
                    { 44, "Cyprus" },
                    { 45, "Czech Republic" },
                    { 46, "Denmark" },
                    { 37, "Colombia" },
                    { 25, "Brunei" },
                    { 24, "Brazil" },
                    { 23, "Botswana" },
                    { 2, "Albania" },
                    { 3, "Algeria" },
                    { 4, "Andorra" },
                    { 5, "Angola" },
                    { 6, "antigua and Barbuda" },
                    { 7, "Argentina" },
                    { 8, "Armenia" },
                    { 9, "Australia" },
                    { 10, "Austria" },
                    { 11, "Azerbaijan" },
                    { 12, "Bahamas" },
                    { 13, "Bahrain" },
                    { 14, "Bangladesh" },
                    { 15, "Barbados" },
                    { 16, "Belarus" },
                    { 17, "Belgium" },
                    { 18, "Belize" },
                    { 19, "Benin" },
                    { 20, "Bhutan" },
                    { 21, "Bolivia" },
                    { 22, "Bosnia Herzegovina" },
                    { 47, "Djibouti" },
                    { 48, "Dominica" },
                    { 49, "Dominican Republic" },
                    { 50, "East Timor" },
                    { 76, "India" },
                    { 77, "Indonesia" },
                    { 78, "Iran" },
                    { 79, "Iraq" },
                    { 80, "Republic Of Ireland" },
                    { 81, "Israel" },
                    { 82, "Italy" },
                    { 83, "Ivory Coast" },
                    { 84, "Jamaica" },
                    { 85, "Japan" },
                    { 86, "Jordan" },
                    { 87, "Kazakhstan" },
                    { 88, "Kenya" },
                    { 89, "Kiribati" },
                    { 90, "Korea North" },
                    { 91, "Korea South" },
                    { 92, "Kosovo" },
                    { 93, "Kuwait" },
                    { 94, "Kyrgyzstan" },
                    { 95, "Laos" },
                    { 96, "Latvia" },
                    { 75, "Iceland" },
                    { 195, "Zambia" },
                    { 74, "Hungary" },
                    { 72, "Haiti" },
                    { 51, "Ecuador" },
                    { 52, "Egypt" },
                    { 53, "El Salvador" },
                    { 54, "Equatorial Guinea" },
                    { 55, "Eritrea" },
                    { 56, "Estonia" },
                    { 57, "Ethiopia" },
                    { 58, "Fiji" },
                    { 59, "Finland" },
                    { 60, "France" },
                    { 61, "Gabon" },
                    { 62, "Gambia" },
                    { 63, "Georgia" },
                    { 64, "Germany" },
                    { 65, "Ghana" },
                    { 66, "Greece" },
                    { 67, "Grenada" },
                    { 68, "Guatemala" },
                    { 69, "Guinea" },
                    { 70, "Guinea-Bissau" },
                    { 71, "Guyana" },
                    { 73, "Honduras" },
                    { 196, "Zimbabwe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StudentId",
                table: "Addresses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourses",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
