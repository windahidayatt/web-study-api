using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_study_api.EntityFrameworks.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "m_molecules",
                columns: table => new
                {
                    IdMolecules = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MoleculesName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MolDescription = table.Column<string>(type: "ntext", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_molecules", x => x.IdMolecules);
                });

            migrationBuilder.CreateTable(
                name: "m_study_status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_study_status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "m_study",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VersionId = table.Column<int>(type: "int", nullable: false),
                    ProtocolTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProtocolCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoleculesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudyStatusID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_study", x => x.Id);
                    table.ForeignKey(
                        name: "FK_m_study_m_molecules_MoleculesId",
                        column: x => x.MoleculesId,
                        principalTable: "m_molecules",
                        principalColumn: "IdMolecules",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_m_study_m_study_status_StudyStatusID",
                        column: x => x.StudyStatusID,
                        principalTable: "m_study_status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_m_study_MoleculesId",
                table: "m_study",
                column: "MoleculesId");

            migrationBuilder.CreateIndex(
                name: "IX_m_study_StudyStatusID",
                table: "m_study",
                column: "StudyStatusID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "m_study");

            migrationBuilder.DropTable(
                name: "m_molecules");

            migrationBuilder.DropTable(
                name: "m_study_status");
        }
    }
}
