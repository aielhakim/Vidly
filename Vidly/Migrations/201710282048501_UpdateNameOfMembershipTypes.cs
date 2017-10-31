namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNameOfMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET NAME = 'PAY AS YOU GO' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET NAME = 'MONTHLY' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET NAME = 'THIRD OPTION' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET NAME = 'FORTH OPTION' WHERE Id = 4");
        }

        public override void Down()
        {
        }
    }
}
