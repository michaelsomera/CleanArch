using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArch.Infra.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"INSERT INTO [dbo].[MembershipTypes] ([Id], [SignUpFee], [DurationInMonths], [DiscountRate], [Name]) VALUES (1, 0, 0, 0, 'Pay as you Go')
                INSERT INTO [dbo].[MembershipTypes] ([Id], [SignUpFee], [DurationInMonths], [DiscountRate], [Name]) VALUES (2, 30, 1, 10, 'Monthly')
                INSERT INTO [dbo].[MembershipTypes] ([Id], [SignUpFee], [DurationInMonths], [DiscountRate], [Name]) VALUES (3, 90, 3, 15, 'Quarterly')
                INSERT INTO [dbo].[MembershipTypes] ([Id], [SignUpFee], [DurationInMonths], [DiscountRate], [Name]) VALUES (4, 300, 12, 20, 'Annual')
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
