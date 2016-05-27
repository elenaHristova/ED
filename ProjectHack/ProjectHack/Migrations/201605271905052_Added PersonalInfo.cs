namespace ProjectHack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPersonalInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonalInfo",
                c => new
                    {
                        PersonalInfoId = c.Int(nullable: false, identity: true),
                        Fullname = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonalInfoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PersonalInfo");
        }
    }
}
