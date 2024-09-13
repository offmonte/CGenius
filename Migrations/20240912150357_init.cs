using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CGenius.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atendentes",
                columns: table => new
                {
                    CpfAtendente = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false),
                    NomeAtendente = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Setor = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    PerfilAtendente = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendentes", x => x.CpfAtendente);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    DepartamentoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomeDepartamento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.DepartamentoId);
                });

            migrationBuilder.CreateTable(
                name: "Empregados",
                columns: table => new
                {
                    EmpId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Sobrenome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Nascimento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Genero = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DepartamentoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FotoUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empregados", x => x.EmpId);
                });

            migrationBuilder.CreateTable(
                name: "Planos",
                columns: table => new
                {
                    IdPlano = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomePlano = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    DescricaoPlano = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    ValorPlano = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planos", x => x.IdPlano);
                });

            migrationBuilder.CreateTable(
                name: "Scripts",
                columns: table => new
                {
                    IdScript = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DescricaoScript = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IdPlano = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scripts", x => x.IdScript);
                    table.ForeignKey(
                        name: "FK_Scripts_Planos_IdPlano",
                        column: x => x.IdPlano,
                        principalTable: "Planos",
                        principalColumn: "IdPlano",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    CpfCliente = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false),
                    NomeCliente = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    DtNascimento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Genero = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    Cep = table.Column<string>(type: "NVARCHAR2(8)", maxLength: 8, nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    PerfilCliente = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    IdScript = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.CpfCliente);
                    table.ForeignKey(
                        name: "FK_Clientes_Scripts_IdScript",
                        column: x => x.IdScript,
                        principalTable: "Scripts",
                        principalColumn: "IdScript",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Especificacoes",
                columns: table => new
                {
                    IdEspecificacao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TipoCartaoCredito = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    GastoMensal = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    ViajaFrequentemente = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    Interesses = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Profissao = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    RendaMensal = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Dependentes = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CpfCliente = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especificacoes", x => x.IdEspecificacao);
                    table.ForeignKey(
                        name: "FK_Especificacoes_Clientes_CpfCliente",
                        column: x => x.CpfCliente,
                        principalTable: "Clientes",
                        principalColumn: "CpfCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    IdVenda = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CpfAtendente = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false),
                    CpfCliente = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false),
                    IdScript = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdPlano = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdEspecificacao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.IdVenda);
                    table.ForeignKey(
                        name: "FK_Vendas_Atendentes_CpfAtendente",
                        column: x => x.CpfAtendente,
                        principalTable: "Atendentes",
                        principalColumn: "CpfAtendente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendas_Clientes_CpfCliente",
                        column: x => x.CpfCliente,
                        principalTable: "Clientes",
                        principalColumn: "CpfCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendas_Especificacoes_IdEspecificacao",
                        column: x => x.IdEspecificacao,
                        principalTable: "Especificacoes",
                        principalColumn: "IdEspecificacao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendas_Planos_IdPlano",
                        column: x => x.IdPlano,
                        principalTable: "Planos",
                        principalColumn: "IdPlano",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendas_Scripts_IdScript",
                        column: x => x.IdScript,
                        principalTable: "Scripts",
                        principalColumn: "IdScript",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IdScript",
                table: "Clientes",
                column: "IdScript");

            migrationBuilder.CreateIndex(
                name: "IX_Especificacoes_CpfCliente",
                table: "Especificacoes",
                column: "CpfCliente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Scripts_IdPlano",
                table: "Scripts",
                column: "IdPlano");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_CpfAtendente",
                table: "Vendas",
                column: "CpfAtendente");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_CpfCliente",
                table: "Vendas",
                column: "CpfCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_IdEspecificacao",
                table: "Vendas",
                column: "IdEspecificacao");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_IdPlano",
                table: "Vendas",
                column: "IdPlano");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_IdScript",
                table: "Vendas",
                column: "IdScript");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Empregados");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Atendentes");

            migrationBuilder.DropTable(
                name: "Especificacoes");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Scripts");

            migrationBuilder.DropTable(
                name: "Planos");
        }
    }
}
