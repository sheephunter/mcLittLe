namespace mcLittLe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.products",
                c => new
                    {
                        productId = c.Int(nullable: false, identity: true),
                        EAN = c.Long(nullable: false),
                        title = c.String(),
                        brand = c.String(),
                        shortDesc = c.String(),
                        fullDesc = c.String(),
                        imageLink = c.String(),
                        weight = c.String(),
                        price = c.Single(nullable: false),
                        category = c.String(),
                        subCategory = c.String(),
                        subsubCategory = c.String(),
                    })
                .PrimaryKey(t => t.productId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.products");
        }
    }
}
