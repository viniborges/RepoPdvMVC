namespace PDV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFkProdutoNoCompraItemENoVendaItem : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.CompraItem", "ProdutoID");
            CreateIndex("dbo.VendaItem", "ProdutoId");
            AddForeignKey("dbo.CompraItem", "ProdutoID", "dbo.Produto", "ProdutoID", cascadeDelete: true);
            AddForeignKey("dbo.VendaItem", "ProdutoId", "dbo.Produto", "ProdutoID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VendaItem", "ProdutoId", "dbo.Produto");
            DropForeignKey("dbo.CompraItem", "ProdutoID", "dbo.Produto");
            DropIndex("dbo.VendaItem", new[] { "ProdutoId" });
            DropIndex("dbo.CompraItem", new[] { "ProdutoID" });
        }
    }
}
