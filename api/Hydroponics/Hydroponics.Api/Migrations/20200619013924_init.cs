using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hydroponics.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estufa",
                columns: table => new
                {
                    id_estufa = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    dataInicio = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Estufa__58AD6956DDA5CB1C", x => x.id_estufa);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id_usuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(unicode: false, maxLength: 70, nullable: false),
                    email = table.Column<string>(unicode: false, maxLength: 70, nullable: false),
                    senha = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    imagem = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario__4E3E04AD3CF9B712", x => x.id_usuario);
                });

            migrationBuilder.CreateTable(
                name: "Bancada",
                columns: table => new
                {
                    id_bancada = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    semeio = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    dataInicio = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    dataFim = table.Column<DateTime>(type: "datetime", nullable: false),
                    statusBancada = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
                    sensorTempBancMax = table.Column<double>(nullable: false),
                    sensorTempBancMin = table.Column<double>(nullable: false),
                    sensorTempSolMax = table.Column<double>(nullable: false),
                    sensorTempSolMin = table.Column<double>(nullable: false),
                    sensorPhMax = table.Column<double>(nullable: false),
                    sensorPhMin = table.Column<double>(nullable: false),
                    sensorEcMax = table.Column<double>(nullable: false),
                    sensorEcMin = table.Column<double>(nullable: false),
                    id_estufa = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Bancada__028BFB5B9CDA8DBC", x => x.id_bancada);
                    table.ForeignKey(
                        name: "FK__Bancada__id_estu__5070F446",
                        column: x => x.id_estufa,
                        principalTable: "Estufa",
                        principalColumn: "id_estufa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BancadaSensores",
                columns: table => new
                {
                    id_bancadaSensores = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dataAtual = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    sensorTempBanc = table.Column<double>(nullable: false),
                    sensorTempSol = table.Column<double>(nullable: false),
                    sensorPh = table.Column<double>(nullable: false),
                    sensorEc = table.Column<double>(nullable: false),
                    id_bancada = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BancadaS__609AC5D6682B5785", x => x.id_bancadaSensores);
                    table.ForeignKey(
                        name: "FK__BancadaSe__id_ba__5441852A",
                        column: x => x.id_bancada,
                        principalTable: "Bancada",
                        principalColumn: "id_bancada",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bancada_id_estufa",
                table: "Bancada",
                column: "id_estufa");

            migrationBuilder.CreateIndex(
                name: "IX_BancadaSensores_id_bancada",
                table: "BancadaSensores",
                column: "id_bancada");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BancadaSensores");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Bancada");

            migrationBuilder.DropTable(
                name: "Estufa");
        }
    }
}
