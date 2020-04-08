using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArch.Infra.Data.Migrations
{
    public partial class SeedGenres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO [dbo].[Genres] ([Id], [Name]) VALUES (1, N'Action')
INSERT INTO [dbo].[Genres] ([Id], [Name]) VALUES (2, N'Thriller')
INSERT INTO [dbo].[Genres] ([Id], [Name]) VALUES (3, N'Family')
INSERT INTO [dbo].[Genres] ([Id], [Name]) VALUES (4, N'Romance')
INSERT INTO [dbo].[Genres] ([Id], [Name]) VALUES (5, N'Comedy')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
