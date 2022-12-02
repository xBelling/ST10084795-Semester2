using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POEST10084795.Data.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SemesterAndModule",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SemesterStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SemesterWeeks = table.Column<int>(type: "int", nullable: false),
                    ModuleCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModuleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModuleCredits = table.Column<int>(type: "int", nullable: false),
                    ModuleClassHrs = table.Column<int>(type: "int", nullable: false),
                    SelfStudyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SelfStudyHrs = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemesterAndModule", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SetAsideDay",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DaySetAside = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetAsideDay", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SemesterAndModule");

            migrationBuilder.DropTable(
                name: "SetAsideDay");
        }
    }
}
