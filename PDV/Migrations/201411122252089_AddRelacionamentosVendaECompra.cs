namespace PDV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelacionamentosVendaECompra : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompraItem",
                c => new
                    {
                        CompraItemId = c.Int(nullable: false, identity: true),
                        ProdutoID = c.Int(nullable: false),
                        PrecoUnitarioCompra = c.Double(nullable: false),
                        Qtde = c.Int(nullable: false),
                        PrecoTotalItem = c.Double(nullable: false),
                        CompraId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompraItemId)
                .ForeignKey("dbo.Compra", t => t.CompraId, cascadeDelete: true)
                .Index(t => t.CompraId);
            
            CreateTable(
                "dbo.Compra",
                c => new
                    {
                        CompraId = c.Int(nullable: false, identity: true),
                        FornecedorId = c.Int(nullable: false),
                        DataMovimento = c.DateTime(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                        ValorTotalCompra = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.CompraId);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        ProdutoID = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        PrecoCusto = c.Double(nullable: false),
                        Qtde = c.Int(nullable: false),
                        PrecoVenda = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ProdutoID);
            
            CreateTable(
                "dbo.VendaItem",
                c => new
                    {
                        VendaItemId = c.Int(nullable: false, identity: true),
                        ProdutoID = c.Int(nullable: false),
                        PrecoUnitarioVenda = c.Double(nullable: false),
                        Qtde = c.Int(nullable: false),
                        PrecoTotalItem = c.Double(nullable: false),
                        ValorDesconto = c.Double(nullable: false),
                        VendaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VendaItemId)
                .ForeignKey("dbo.Venda", t => t.VendaId, cascadeDelete: true)
                .Index(t => t.VendaId);
            
            CreateTable(
                "dbo.Venda",
                c => new
                    {
                        VendaId = c.Int(nullable: false, identity: true),
                        ClienteID = c.Int(nullable: false),
                        DataMovimento = c.DateTime(nullable: false),
                        VendedorId = c.Int(nullable: false),
                        ValorTotalVenda = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.VendaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VendaItem", "VendaId", "dbo.Venda");
            DropForeignKey("dbo.CompraItem", "CompraId", "dbo.Compra");
            DropIndex("dbo.VendaItem", new[] { "VendaId" });
            DropIndex("dbo.CompraItem", new[] { "CompraId" });
            DropTable("dbo.Venda");
            DropTable("dbo.VendaItem");
            DropTable("dbo.Produto");
            DropTable("dbo.Compra");
            DropTable("dbo.CompraItem");
        }
    }
}
