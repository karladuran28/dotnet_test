using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Formularios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formularios", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Inputs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FormularioId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoDato = table.Column<int>(type: "int", nullable: false),
                    EsObligatorio = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inputs_Formularios_FormularioId",
                        column: x => x.FormularioId,
                        principalTable: "Formularios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RespuestasFormularios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FormularioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespuestasFormularios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RespuestasFormularios_Formularios_FormularioId",
                        column: x => x.FormularioId,
                        principalTable: "Formularios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RespuestasInputs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InputId = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RespuestaFormularioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespuestasInputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RespuestasInputs_Inputs_InputId",
                        column: x => x.InputId,
                        principalTable: "Inputs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RespuestasInputs_RespuestasFormularios_RespuestaFormularioId",
                        column: x => x.RespuestaFormularioId,
                        principalTable: "RespuestasFormularios",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Inputs_FormularioId",
                table: "Inputs",
                column: "FormularioId");

            migrationBuilder.CreateIndex(
                name: "IX_RespuestasFormularios_FormularioId",
                table: "RespuestasFormularios",
                column: "FormularioId");

            migrationBuilder.CreateIndex(
                name: "IX_RespuestasInputs_InputId",
                table: "RespuestasInputs",
                column: "InputId");

            migrationBuilder.CreateIndex(
                name: "IX_RespuestasInputs_RespuestaFormularioId",
                table: "RespuestasInputs",
                column: "RespuestaFormularioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RespuestasInputs");

            migrationBuilder.DropTable(
                name: "Inputs");

            migrationBuilder.DropTable(
                name: "RespuestasFormularios");

            migrationBuilder.DropTable(
                name: "Formularios");
        }
    }
}
