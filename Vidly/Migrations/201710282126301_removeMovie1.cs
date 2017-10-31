namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class removeMovie1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Name = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Movies",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    GenreId = c.Int(nullable: false),
                    ReleaseDate = c.DateTime(nullable: false),
                    DateAdded = c.DateTime(nullable: false),
                    NumberInStock = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);

        }

        public override void Down()
        {
        }
    }
}
