namespace VidlyAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO dbo.MembershipTypes (Id, Name, Discount, SignUpFee) 
                VALUES
                (1, 'PayAsYouGo', 0, 0),
                (2, 'Monthly', 5, 30),
                (3, 'Quarterly', 10, 75),
                (4, 'Annual', 15, 250);");
        }
        
        public override void Down()
        {
            Sql(@"DELETE FROM dbo.MembershipTypes WHERE Id BETWEEN 1 AND 4;");
        }
    }
}
