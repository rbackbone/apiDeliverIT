using Microsoft.EntityFrameworkCore.Migrations;

namespace deliverAPI.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clContas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    ValOrig = table.Column<double>(nullable: false),
                    DtVenc = table.Column<string>(nullable: false),
                    DtPagto = table.Column<string>(nullable: false),
                    DiasAtraso = table.Column<int>(nullable: false),
                    Multa = table.Column<double>(nullable: false),
                    Juros = table.Column<double>(nullable: false),
                    ValorCorrigido = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clContas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clContas");
        }
    }
}
