namespace PDV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNomeAndAdminToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "Nome", c => c.String());
            AddColumn("dbo.Usuario", "Admin", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "Admin");
            DropColumn("dbo.Usuario", "Nome");
        }
    }
}
