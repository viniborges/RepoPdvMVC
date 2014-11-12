namespace PDV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFkClienteEUsuarioNaVenda : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Venda", "UsuarioId", c => c.Int(nullable: false));
            AddColumn("dbo.Venda", "Cliente_PessoaId", c => c.Int());
            CreateIndex("dbo.Venda", "UsuarioId");
            CreateIndex("dbo.Venda", "Cliente_PessoaId");
            AddForeignKey("dbo.Venda", "Cliente_PessoaId", "dbo.Pessoa", "PessoaId");
            AddForeignKey("dbo.Venda", "UsuarioId", "dbo.Usuario", "Id", cascadeDelete: true);
            DropColumn("dbo.Venda", "VendedorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Venda", "VendedorId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Venda", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Venda", "Cliente_PessoaId", "dbo.Pessoa");
            DropIndex("dbo.Venda", new[] { "Cliente_PessoaId" });
            DropIndex("dbo.Venda", new[] { "UsuarioId" });
            DropColumn("dbo.Venda", "Cliente_PessoaId");
            DropColumn("dbo.Venda", "UsuarioId");
        }
    }
}
