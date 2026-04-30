using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PHOENIX.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    MinAge = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxAge = table.Column<int>(type: "INTEGER", nullable: false),
                    MinWeight = table.Column<double>(type: "REAL", nullable: false),
                    MaxWeight = table.Column<double>(type: "REAL", nullable: false),
                    DisciplineType = table.Column<int>(type: "INTEGER", nullable: false),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sportsmen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false),
                    Weight = table.Column<double>(type: "REAL", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sportsmen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sportsmen_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DisciplineType", "Gender", "MaxAge", "MaxWeight", "MinAge", "MinWeight", "Name" },
                values: new object[,]
                {
                    { 1, 0, 0, 6, 999.0, 6, 0.0, "KATA MALE 6 YEARS" },
                    { 2, 0, 0, 7, 999.0, 7, 0.0, "KATA MALE 7 YEARS" },
                    { 3, 0, 1, 7, 999.0, 6, 0.0, "KATA FEMALE 6-7 YEARS" },
                    { 4, 0, 0, 8, 999.0, 8, 0.0, "KATA MALE 8 YEARS" },
                    { 5, 0, 1, 9, 999.0, 8, 0.0, "KATA FEMALE 8-9 YEARS" },
                    { 6, 0, 0, 9, 999.0, 9, 0.0, "KATA MALE 9 YEARS" },
                    { 7, 0, 0, 10, 999.0, 10, 0.0, "KATA MALE 10 YEARS" },
                    { 8, 0, 1, 11, 999.0, 10, 0.0, "KATA FEMALE 10-11 YEARS" },
                    { 9, 0, 0, 11, 999.0, 11, 0.0, "KATA MALE 11 YEARS" },
                    { 10, 0, 0, 13, 999.0, 12, 0.0, "KATA MALE 12-13 YEARS" },
                    { 11, 0, 1, 13, 999.0, 12, 0.0, "KATA FEMALE 12-13 YEARS" },
                    { 12, 2, 0, 6, 999.0, 6, 0.0, "KUMITE PHANTOM MALE 6 YEARS" },
                    { 13, 2, 1, 6, 999.0, 6, 0.0, "KUMITE PHANTOM FEMALE 6 YEARS" },
                    { 14, 2, 0, 7, 999.0, 7, 0.0, "KUMITE PHANTOM MALE 7 YEARS" },
                    { 15, 2, 1, 7, 999.0, 7, 0.0, "KUMITE PHANTOM FEMALE 7 YEARS" },
                    { 16, 1, 0, 7, 23.0, 7, 0.0, "KUMITE MALE 7 YEARS -23 KG" },
                    { 17, 1, 0, 7, 26.0, 7, 23.010000000000002, "KUMITE MALE 7 YEARS -26 KG" },
                    { 18, 1, 0, 7, 999.0, 7, 26.010000000000002, "KUMITE MALE 7 YEARS 26+ KG" },
                    { 19, 1, 1, 7, 22.0, 7, 0.0, "KUMITE FEMALE 7 YEARS -22 KG" },
                    { 20, 1, 1, 7, 999.0, 7, 22.010000000000002, "KUMITE FEMALE 7 YEARS 22+ KG" },
                    { 21, 1, 0, 8, 27.0, 8, 0.0, "KUMITE MALE 8 YEARS -27 KG" },
                    { 22, 1, 0, 8, 30.0, 8, 27.010000000000002, "KUMITE MALE 8 YEARS -30 KG" },
                    { 23, 1, 0, 8, 999.0, 8, 30.010000000000002, "KUMITE MALE 8 YEARS 30+ KG" },
                    { 24, 1, 1, 9, 25.0, 8, 0.0, "KUMITE FEMALE 8-9 YEARS -25 KG" },
                    { 25, 1, 1, 9, 29.0, 8, 25.010000000000002, "KUMITE FEMALE 8-9 YEARS -29 KG" },
                    { 26, 1, 1, 9, 999.0, 8, 29.010000000000002, "KUMITE FEMALE 8-9 YEARS 29+ KG" },
                    { 27, 1, 0, 9, 29.0, 9, 0.0, "KUMITE MALE 9 YEARS -29 KG" },
                    { 28, 1, 0, 9, 33.0, 9, 29.010000000000002, "KUMITE MALE 9 YEARS -33 KG" },
                    { 29, 1, 0, 9, 999.0, 9, 33.009999999999998, "KUMITE MALE 9 YEARS 33+ KG" },
                    { 30, 1, 0, 11, 30.0, 10, 0.0, "KUMITE MALE 10-11 YEARS -30 KG" },
                    { 31, 1, 0, 11, 34.0, 10, 30.010000000000002, "KUMITE MALE 10-11 YEARS -34 KG" },
                    { 32, 1, 0, 11, 39.0, 10, 34.009999999999998, "KUMITE MALE 10-11 YEARS -39 KG" },
                    { 33, 1, 0, 11, 44.0, 10, 39.009999999999998, "KUMITE MALE 10-11 YEARS -44 KG" },
                    { 34, 1, 0, 11, 999.0, 10, 44.009999999999998, "KUMITE MALE 10-11 YEARS 44+ KG" },
                    { 35, 1, 1, 11, 33.0, 10, 0.0, "KUMITE FEMALE 10-11 YEARS -33 KG" },
                    { 36, 1, 1, 11, 39.0, 10, 33.009999999999998, "KUMITE FEMALE 10-11 YEARS -39 KG" },
                    { 37, 1, 1, 11, 999.0, 10, 39.009999999999998, "KUMITE FEMALE 10-11 YEARS 39+ KG" },
                    { 38, 1, 0, 13, 40.0, 12, 0.0, "KUMITE MALE 12-13 YEARS -40 KG" },
                    { 39, 1, 0, 13, 45.0, 12, 40.009999999999998, "KUMITE MALE 12-13 YEARS -45 KG" },
                    { 40, 1, 0, 13, 50.0, 12, 45.009999999999998, "KUMITE MALE 12-13 YEARS -50 KG" },
                    { 41, 1, 0, 13, 55.0, 12, 50.009999999999998, "KUMITE MALE 12-13 YEARS -55 KG" },
                    { 42, 1, 0, 13, 999.0, 12, 55.009999999999998, "KUMITE MALE 12-13 YEARS 55+ KG" },
                    { 43, 1, 1, 13, 42.0, 12, 0.0, "KUMITE FEMALE 12-13 YEARS -42 KG" },
                    { 44, 1, 1, 13, 47.0, 12, 42.009999999999998, "KUMITE FEMALE 12-13 YEARS -47 KG" },
                    { 45, 1, 1, 13, 52.0, 12, 47.009999999999998, "KUMITE FEMALE 12-13 YEARS -52 KG" },
                    { 46, 1, 1, 13, 999.0, 12, 52.009999999999998, "KUMITE FEMALE 12-13 YEARS 52+ KG" },
                    { 47, 0, 0, 15, 999.0, 14, 0.0, "CADET KATA MALE" },
                    { 48, 0, 1, 15, 999.0, 14, 0.0, "CADET KATA FEMALE" },
                    { 49, 1, 0, 15, 52.0, 14, 0.0, "CADET KUMITE MALE -52 KG" },
                    { 50, 1, 0, 15, 57.0, 14, 52.009999999999998, "CADET KUMITE MALE -57 KG" },
                    { 51, 1, 0, 15, 63.0, 14, 57.009999999999998, "CADET KUMITE MALE -63 KG" },
                    { 52, 1, 0, 15, 70.0, 14, 63.009999999999998, "CADET KUMITE MALE -70 KG" },
                    { 53, 1, 0, 15, 999.0, 14, 70.010000000000005, "CADET KUMITE MALE 70+ KG" },
                    { 54, 1, 1, 15, 47.0, 14, 0.0, "CADET KUMITE FEMALE -47 KG" },
                    { 55, 1, 1, 15, 54.0, 14, 47.009999999999998, "CADET KUMITE FEMALE -54 KG" },
                    { 56, 1, 1, 15, 61.0, 14, 54.009999999999998, "CADET KUMITE FEMALE -61 KG" },
                    { 57, 1, 1, 15, 999.0, 14, 61.009999999999998, "CADET KUMITE FEMALE 61+ KG" },
                    { 58, 0, 0, 17, 999.0, 16, 0.0, "JUNIOR KATA MALE" },
                    { 59, 0, 1, 17, 999.0, 16, 0.0, "JUNIOR KATA FEMALE" },
                    { 60, 1, 0, 17, 55.0, 16, 0.0, "JUNIOR KUMITE MALE -55 KG" },
                    { 61, 1, 0, 17, 61.0, 16, 55.009999999999998, "JUNIOR KUMITE MALE -61 KG" },
                    { 62, 1, 0, 17, 68.0, 16, 61.009999999999998, "JUNIOR KUMITE MALE -68 KG" },
                    { 63, 1, 0, 17, 76.0, 16, 68.010000000000005, "JUNIOR KUMITE MALE -76 KG" },
                    { 64, 1, 0, 17, 999.0, 16, 76.010000000000005, "JUNIOR KUMITE MALE 76+ KG" },
                    { 65, 1, 1, 17, 48.0, 16, 0.0, "JUNIOR KUMITE FEMALE -48 KG" },
                    { 66, 1, 1, 17, 53.0, 16, 48.009999999999998, "JUNIOR KUMITE FEMALE -53 KG" },
                    { 67, 1, 1, 17, 59.0, 16, 53.009999999999998, "JUNIOR KUMITE FEMALE -59 KG" },
                    { 68, 1, 1, 17, 66.0, 16, 59.009999999999998, "JUNIOR KUMITE FEMALE -66 KG" },
                    { 69, 1, 1, 17, 999.0, 16, 66.010000000000005, "JUNIOR KUMITE FEMALE 66+ KG" },
                    { 70, 0, 0, 20, 999.0, 18, 0.0, "U21 KATA MALE" },
                    { 71, 0, 1, 20, 999.0, 18, 0.0, "U21 KATA FEMALE" },
                    { 72, 1, 0, 20, 60.0, 18, 0.0, "U21 KUMITE MALE -60 KG" },
                    { 73, 1, 0, 20, 67.0, 18, 60.009999999999998, "U21 KUMITE MALE -67 KG" },
                    { 74, 1, 0, 20, 75.0, 18, 67.010000000000005, "U21 KUMITE MALE -75 KG" },
                    { 75, 1, 0, 20, 84.0, 18, 75.010000000000005, "U21 KUMITE MALE -84 KG" },
                    { 76, 1, 0, 20, 999.0, 18, 84.010000000000005, "U21 KUMITE MALE 84+ KG" },
                    { 77, 1, 1, 20, 50.0, 18, 0.0, "U21 KUMITE FEMALE -50 KG" },
                    { 78, 1, 1, 20, 55.0, 18, 50.009999999999998, "U21 KUMITE FEMALE -55 KG" },
                    { 79, 1, 1, 20, 61.0, 18, 55.009999999999998, "U21 KUMITE FEMALE -61 KG" },
                    { 80, 1, 1, 20, 68.0, 18, 61.009999999999998, "U21 KUMITE FEMALE -68 KG" },
                    { 81, 1, 1, 20, 999.0, 18, 68.010000000000005, "U21 KUMITE FEMALE 68+ KG" },
                    { 82, 0, 0, 99, 999.0, 16, 0.0, "MALE KATA" },
                    { 83, 0, 1, 99, 999.0, 16, 0.0, "FEMALE KATA" },
                    { 84, 1, 0, 99, 60.0, 18, 0.0, "MALE KUMITE -60 KG" },
                    { 85, 1, 0, 99, 67.0, 18, 60.009999999999998, "MALE KUMITE -67 KG" },
                    { 86, 1, 0, 99, 75.0, 18, 67.010000000000005, "MALE KUMITE -75 KG" },
                    { 87, 1, 0, 99, 84.0, 18, 75.010000000000005, "MALE KUMITE -84 KG" },
                    { 88, 1, 0, 99, 999.0, 18, 84.010000000000005, "MALE KUMITE 84+ KG" },
                    { 89, 1, 1, 99, 50.0, 18, 0.0, "FEMALE KUMITE -50 KG" },
                    { 90, 1, 1, 99, 55.0, 18, 50.009999999999998, "FEMALE KUMITE -55 KG" },
                    { 91, 1, 1, 99, 61.0, 18, 55.009999999999998, "FEMALE KUMITE -61 KG" },
                    { 92, 1, 1, 99, 68.0, 18, 61.009999999999998, "FEMALE KUMITE -68 KG" },
                    { 93, 1, 1, 99, 999.0, 18, 68.010000000000005, "FEMALE KUMITE 68+ KG" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sportsmen_CategoryId",
                table: "Sportsmen",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sportsmen");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
