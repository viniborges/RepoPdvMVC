namespace PDV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPessoaClienteFornecedor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pessoa", "ClienteId", c => c.Int());
            AddColumn("dbo.Pessoa", "Contato", c => c.String());
            AddColumn("dbo.Pessoa", "UltimaVenda", c => c.DateTime());
            AddColumn("dbo.Pessoa", "FornecedorId", c => c.Int());
            AddColumn("dbo.Pessoa", "InscricaoEstadual", c => c.String());
            AddColumn("dbo.Pessoa", "UltimaCompra", c => c.DateTime());
            AddColumn("dbo.Pessoa", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pessoa", "Discriminator");
            DropColumn("dbo.Pessoa", "UltimaCompra");
            DropColumn("dbo.Pessoa", "InscricaoEstadual");
            DropColumn("dbo.Pessoa", "FornecedorId");
            DropColumn("dbo.Pessoa", "UltimaVenda");
            DropColumn("dbo.Pessoa", "Contato");
            DropColumn("dbo.Pessoa", "ClienteId");
        }
    }
}
