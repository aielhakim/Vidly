namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0d94d5ef-d789-4cf9-9e4c-b28cce59435d', N'admin@vidly.com', 0, N'AM136eaP60ZF2Z93/VxIuXA46nvdrNfIQxHDLPSZaLKPGz2BON42HqD+ygbmD3sfMA==', N'35e9518b-f77a-41d7-8ba4-75a59190caca', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fbc9e0d4-67a2-4b06-b3b8-2274183c0503', N'guest@vidly.com', 0, N'AEcswczprNuAdqqS3rUXbrWbEwJSacQl4snRxNItyzDJbHl9ehtxPSfEAFPFigNuYA==', N'ae7ce591-ad2a-4519-a842-de11f853c17a', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd6b38534-0be7-4f52-afa6-05725860d01d', N'CanManageMovie')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0d94d5ef-d789-4cf9-9e4c-b28cce59435d', N'd6b38534-0be7-4f52-afa6-05725860d01d')


");
        }

        public override void Down()
        {
        }
    }
}
