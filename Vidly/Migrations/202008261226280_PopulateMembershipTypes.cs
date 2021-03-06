﻿namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("insert into MembershipTypes(SignupFee,DurationInMonths,DiscountRate) values (0,0,0)");
            Sql("insert into MembershipTypes(SignupFee,DurationInMonths,DiscountRate) values (30,1,10)");
            Sql("insert into MembershipTypes(SignupFee,DurationInMonths,DiscountRate) values (90,3,15)");
            Sql("insert into MembershipTypes(SignupFee,DurationInMonths,DiscountRate) values (200,12,20)");
        }

        public override void Down()
        {
        }
    }
}
