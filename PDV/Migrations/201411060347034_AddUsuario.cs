namespace PDV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "UltimoLogin", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "UltimoLogin");
        }
    }
}
