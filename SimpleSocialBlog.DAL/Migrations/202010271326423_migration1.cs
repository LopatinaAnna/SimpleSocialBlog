namespace SimpleSocialBlog.DAL.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(),
                    Date = c.DateTime(nullable: false),
                    Text = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Questionaries",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Rate = c.Int(nullable: false),
                    Recommend = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Reviews",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Date = c.DateTime(nullable: false),
                    Text = c.String(),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Reviews");
            DropTable("dbo.Questionaries");
            DropTable("dbo.Articles");
        }
    }
}