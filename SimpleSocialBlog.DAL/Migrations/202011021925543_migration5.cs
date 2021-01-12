namespace SimpleSocialBlog.DAL.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class migration5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TagArticles",
                c => new
                {
                    Tag_Id = c.Int(nullable: false),
                    Article_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Tag_Id, t.Article_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Articles", t => t.Article_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Article_Id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.TagArticles", "Article_Id", "dbo.Articles");
            DropForeignKey("dbo.TagArticles", "Tag_Id", "dbo.Tags");
            DropIndex("dbo.TagArticles", new[] { "Article_Id" });
            DropIndex("dbo.TagArticles", new[] { "Tag_Id" });
            DropTable("dbo.TagArticles");
        }
    }
}