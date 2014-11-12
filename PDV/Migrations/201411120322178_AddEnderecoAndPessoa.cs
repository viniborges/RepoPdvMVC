namespace PDV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEnderecoAndPessoa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        PessoaId = c.Int(nullable: false),
                        EnderecoId = c.Int(nullable: false),
                        Logradouro = c.String(),
                        Numero = c.String(),
                        Bairro = c.String(),
                        Cidade = c.String(),
                        UF = c.String(),
                        Pais = c.String(),
                        CEP = c.String(),
                        Fone = c.String(),
                    })
                .PrimaryKey(t => t.PessoaId)
                .ForeignKey("dbo.Pessoa", t => t.PessoaId)
                .Index(t => t.PessoaId);
            
            CreateTable(
                "dbo.Pessoa",
                c => new
                    {
                        PessoaId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        CPFCNPJ = c.String(),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.PessoaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Endereco", "PessoaId", "dbo.Pessoa");
            DropIndex("dbo.Endereco", new[] { "PessoaId" });
            DropTable("dbo.Pessoa");
            DropTable("dbo.Endereco");
        }
    }
}
