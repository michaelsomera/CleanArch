using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArch.Infra.Data.Migrations
{
    public partial class SeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'38ab4096-1b25-4263-af31-4b8de34fdb64', N'CanManageMovies')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
