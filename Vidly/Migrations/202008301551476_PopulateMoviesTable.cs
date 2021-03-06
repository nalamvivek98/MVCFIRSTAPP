namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMoviesTable : DbMigration
    {
        public override void Up()
        {
            //Sql("Insert into Movies (Name,Genre,Releasedate,DateAdded,No_in_stock) values ('Hangover','comedy',1-1-2100,1-2-2100,10)");

          //  Sql("Insert into Movies (Name,Genre,Releasedate,DateAdded,No_in_stock) values ('Die Hard','Action',1-1-2100,1-2-2100,10)");

           // Sql("Insert into Movies (Name,Genre,Releasedate,DateAdded,No_in_stock) values ('Terminator','Action',1-1-2100,1-2-2100,10)");

         //   Sql("Insert into Movies (Name,Genre,Releasedate,DateAdded,No_in_stock) values ('Toystory','Family',1-1-2100,1-2-2100,10)");

       //     Sql("Insert into Movies (Name,Genre,Releasedate,DateAdded,No_in_stock) values ('Titanic','Romance',1-1-2100,1-2-2100,10)");

            Sql("update Movies set releasedate='7-18-1998'");
            Sql("update Movies set DateAdded ='10-5-1998'");
        }
       
        public override void Down()
        {
        }
    }
}
