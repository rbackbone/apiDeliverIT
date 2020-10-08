using Microsoft.EntityFrameworkCore.Migrations;

namespace deliverAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clContas",
                columns: table => new
                {
                    Nome = table.Column<string>(nullable: false),
                    ValOrig = table.Column<double>(nullable: false),
                    DtVenc = table.Column<string>(nullable: false),
                    DtPagto = table.Column<string>(nullable: false),
                    DiasAtraso = table.Column<int>(nullable: false),
                    RegraCalculo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clContas", x => x.Nome);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clContas");
        }
    }
}
