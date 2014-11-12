namespace PDV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFkFornecEUserNaCompra : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Compra", "Fornecedor_PessoaId", c => c.Int());
            CreateIndex("dbo.Compra", "UsuarioId");
            CreateIndex("dbo.Compra", "Fornecedor_PessoaId");
            AddForeignKey("dbo.Compra", "Fornecedor_PessoaId", "dbo.Pessoa", "PessoaId");
            AddForeignKey("dbo.Compra", "UsuarioId", "dbo.Usuario", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Compra", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Compra", "Fornecedor_PessoaId", "dbo.Pessoa");
            DropIndex("dbo.Compra", new[] { "Fornecedor_PessoaId" });
            DropIndex("dbo.Compra", new[] { "UsuarioId" });
            DropColumn("dbo.Compra", "Fornecedor_PessoaId");
        }
    }
}
