namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class DropGenre : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.movies");
            DropTable("dbo.Genres");
        }

        public override void Down()
        {
        }
    }
}
