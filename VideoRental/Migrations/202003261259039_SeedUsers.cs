namespace VideoRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'135b11f8-80d9-4c33-8fe8-44b5f7ed4c37', N'guest@vidly.com', 0, N'AOqz+VGw8ITv2MCUYkyqF4f6Gbs/AH9HLpt9TMJePpc/G68DsIpkqWvjFSYI4pT6Pg==', N'a7e14f11-479f-4ec4-b203-f9105c069f78', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1d537eed-81bb-46b8-b48e-ce8bc148f84b', N'admin@vidly.com', 0, N'APFKCp6/rbZte0nlqE2/kDjNdzsyzQaqtV75jGwzSVKz2E5oFEhCDxCNun18txHogA==', N'11951291-ab84-49ba-a971-3c2cb85b0d3a', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd816593b-8650-4f43-8a4f-5a9b4c177af7', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1d537eed-81bb-46b8-b48e-ce8bc148f84b', N'd816593b-8650-4f43-8a4f-5a9b4c177af7')

");
        }
         
        public override void Down()
        {
        }
    }
}
