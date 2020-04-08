using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArch.Infra.Data.Migrations
{
    public partial class SeedCustomerAndMovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"SET IDENTITY_INSERT [dbo].[Customers] ON
                INSERT INTO [dbo].[Customers] ([Id], [Name], [IsSubscribeToNewsletter], [MembershipTypeId], [BirthDate]) VALUES (1, 'Michael Roy Somera', 0, 2, '1998-07-06 00:00:00')
                INSERT INTO [dbo].[Customers] ([Id], [Name], [IsSubscribeToNewsletter], [MembershipTypeId], [BirthDate]) VALUES (7, 'Aubrey Aromin', 0, 2, '2000-01-01 00:00:00')
                INSERT INTO [dbo].[Customers] ([Id], [Name], [IsSubscribeToNewsletter], [MembershipTypeId], [BirthDate]) VALUES (8, 'Kim Roselyn Frias', 0, 3, '1995-01-01 00:00:00')
                SET IDENTITY_INSERT [dbo].[Customers] OFF
                SET IDENTITY_INSERT [dbo].[Movies] ON
                INSERT INTO [dbo].[Movies] ([Id], [Name], [GenresId], [ReleaseDate], [DateAdded], [NumberInStock], [NumberAvailable]) VALUES (2, 'Toy Story', 3, '2000-01-01 00:00:00', N'2020-03-17 21:12:25', 9, 12)
                INSERT INTO [dbo].[Movies] ([Id], [Name], [GenresId], [ReleaseDate], [DateAdded], [NumberInStock], [NumberAvailable]) VALUES (8, 'Detective Pikachu', 2, '2000-01-01 00:00:00', N'2020-03-02 21:12:25', 18, 18)
                INSERT INTO [dbo].[Movies] ([Id], [Name], [GenresId], [ReleaseDate], [DateAdded], [NumberInStock], [NumberAvailable]) VALUES (12, 'Sample Movie', 2, '2000-01-01 00:00:00', N'2020-03-21 21:05:35', 11, 12)
                SET IDENTITY_INSERT [dbo].[Movies] OFF
                SET IDENTITY_INSERT [dbo].[Rentals] ON
                INSERT INTO [dbo].[Rentals] ([Id], [DateRented], [DateReturned], [CustomerId], [MovieId]) VALUES (5, '2020-03-27 16:36:57', NULL, 1, 2)
                INSERT INTO [dbo].[Rentals] ([Id], [DateRented], [DateReturned], [CustomerId], [MovieId]) VALUES (6, '2020-03-27 16:37:05', NULL, 1, 2)
                INSERT INTO [dbo].[Rentals] ([Id], [DateRented], [DateReturned], [CustomerId], [MovieId]) VALUES (7, '2020-03-27 16:37:07', NULL, 1, 2)
                INSERT INTO [dbo].[Rentals] ([Id], [DateRented], [DateReturned], [CustomerId], [MovieId]) VALUES (8, '2020-03-27 16:42:58', NULL, 7, 12)
                SET IDENTITY_INSERT [dbo].[Rentals] OFF");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
