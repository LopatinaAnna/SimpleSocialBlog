namespace SimpleSocialBlog.DAL.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class migration2_added_tags : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    TagName = c.String(),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Tags");
        }
    }
}