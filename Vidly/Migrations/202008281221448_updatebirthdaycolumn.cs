namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatebirthdaycolumn : DbMigration
    {
        public override void Up()
        {
            Sql("update customers set birthday='1/2/1980' where name='John Smith'");
        }
        
        public override void Down()
        {
        }
    }
}
