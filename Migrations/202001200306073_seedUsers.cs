namespace VidlyAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'004aacb9-7c65-46c4-8401-2d0f7bece8d7', N'admin@vidly.com', 0, N'AHM17JRsEUlPJAGe7vSIOr7FWOvsgExVsYUH5+H6g0kIYnN5mS/9dZs3mG+DsOcncA==', N'394fea9c-640a-4f08-9a54-0899b840732c', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cb47a1a7-257d-44b2-ad17-3fc9e7259adb', N'guest@vidly.com', 0, N'AFcuKd6zQC7XP/tp/3qCBr9QzEuDsx0SZIhP5qXFV8E6ojTit4Xrr4Nj0rX9Zrr1QA==', N'e0a61cb0-be3d-4326-8b6c-a55c16481ccb', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'66562d56-8fa8-4118-997b-2274d8c8b2c5', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'004aacb9-7c65-46c4-8401-2d0f7bece8d7', N'66562d56-8fa8-4118-997b-2274d8c8b2c5')
");
        }
        
        public override void Down()
        {
        }
    }
}
