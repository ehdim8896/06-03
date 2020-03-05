namespace gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Judges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JsonId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.Int(nullable: false),
                        Country = c.String(),
                        Discipline = c.Int(nullable: false),
                        Category = c.Int(nullable: false),
                        Birth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Judges");
        }
    }
}
