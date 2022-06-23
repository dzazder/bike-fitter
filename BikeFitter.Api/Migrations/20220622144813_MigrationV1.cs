using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeFitter.Api.Migrations
{
    public partial class MigrationV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brake",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brake", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cassette",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cassette", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Crankset",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crankset", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Derailleur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Derailleur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fork",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fork", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shifter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tire", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bike",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CassetteId = table.Column<int>(type: "int", nullable: false),
                    CranksetId = table.Column<int>(type: "int", nullable: false),
                    DerailleurId = table.Column<int>(type: "int", nullable: false),
                    ForkId = table.Column<int>(type: "int", nullable: false),
                    ShifterId = table.Column<int>(type: "int", nullable: false),
                    StemId = table.Column<int>(type: "int", nullable: false),
                    BrakesId = table.Column<int>(type: "int", nullable: false),
                    RimsId = table.Column<int>(type: "int", nullable: false),
                    TiresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bike", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bike_Brake_BrakesId",
                        column: x => x.BrakesId,
                        principalTable: "Brake",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bike_Cassette_CassetteId",
                        column: x => x.CassetteId,
                        principalTable: "Cassette",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bike_Course_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bike_Crankset_CranksetId",
                        column: x => x.CranksetId,
                        principalTable: "Crankset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bike_Derailleur_DerailleurId",
                        column: x => x.DerailleurId,
                        principalTable: "Derailleur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bike_Fork_ForkId",
                        column: x => x.ForkId,
                        principalTable: "Fork",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bike_Rim_RimsId",
                        column: x => x.RimsId,
                        principalTable: "Rim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bike_Shifter_ShifterId",
                        column: x => x.ShifterId,
                        principalTable: "Shifter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bike_Stem_StemId",
                        column: x => x.StemId,
                        principalTable: "Stem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bike_Tire_TiresId",
                        column: x => x.TiresId,
                        principalTable: "Tire",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bike_BrakesId",
                table: "Bike",
                column: "BrakesId");

            migrationBuilder.CreateIndex(
                name: "IX_Bike_CassetteId",
                table: "Bike",
                column: "CassetteId");

            migrationBuilder.CreateIndex(
                name: "IX_Bike_CranksetId",
                table: "Bike",
                column: "CranksetId");

            migrationBuilder.CreateIndex(
                name: "IX_Bike_DerailleurId",
                table: "Bike",
                column: "DerailleurId");

            migrationBuilder.CreateIndex(
                name: "IX_Bike_ForkId",
                table: "Bike",
                column: "ForkId");

            migrationBuilder.CreateIndex(
                name: "IX_Bike_ManufacturerId",
                table: "Bike",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bike_RimsId",
                table: "Bike",
                column: "RimsId");

            migrationBuilder.CreateIndex(
                name: "IX_Bike_ShifterId",
                table: "Bike",
                column: "ShifterId");

            migrationBuilder.CreateIndex(
                name: "IX_Bike_StemId",
                table: "Bike",
                column: "StemId");

            migrationBuilder.CreateIndex(
                name: "IX_Bike_TiresId",
                table: "Bike",
                column: "TiresId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bike");

            migrationBuilder.DropTable(
                name: "Brake");

            migrationBuilder.DropTable(
                name: "Cassette");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Crankset");

            migrationBuilder.DropTable(
                name: "Derailleur");

            migrationBuilder.DropTable(
                name: "Fork");

            migrationBuilder.DropTable(
                name: "Rim");

            migrationBuilder.DropTable(
                name: "Shifter");

            migrationBuilder.DropTable(
                name: "Stem");

            migrationBuilder.DropTable(
                name: "Tire");
        }
    }
}
