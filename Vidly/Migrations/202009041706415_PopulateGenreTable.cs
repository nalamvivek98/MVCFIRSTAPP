namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into GenreTypes (Name) values ('Action')");
            Sql("Insert into GenreTypes (Name) values ('Thriller')");
            Sql("Insert into GenreTypes (Name) values ('Family')");
            Sql("Insert into GenreTypes (Name) values ('Romance')");
            Sql("Insert into GenreTypes (Name) values ('Comedy')");
            Sql("Insert into GenreTypes (Name) values ('Horror')");
        }
        
        public override void Down()
        {
        }
    }
}
