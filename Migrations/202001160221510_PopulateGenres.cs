namespace VidlyAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO dbo.Genres (Id, Name)
                VALUES
                (1, 'Adventure'),
                (2, 'Action'),
                (3, 'Drama'),
                (4, 'Comedy'),
                (5, 'Thriller'),
                (6, 'Horror'),
                (7, 'Musical'),
                (8, 'Documentary');");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM dbo.Genres WHERE Id BETWEEN 1 AND 8;");
        }
    }
}
