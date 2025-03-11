using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projet.Data.Migrations
{
    /// <inheritdoc />
    public partial class ajoutadresse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdressesParticulier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodePostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdressesParticulier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdressesProfessionnels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodePostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdressesProfessionnels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AdressePostaleId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sexe = table.Column<int>(type: "int", nullable: true),
                    Siret = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatutJuridique = table.Column<int>(type: "int", nullable: true),
                    AdresseSiegeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_AdressesParticulier_AdressePostaleId",
                        column: x => x.AdressePostaleId,
                        principalTable: "AdressesParticulier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_AdressesProfessionnels_AdresseSiegeId",
                        column: x => x.AdresseSiegeId,
                        principalTable: "AdressesProfessionnels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComptesBancaires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroCompte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOuverture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Solde = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComptesBancaires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComptesBancaires_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionsBancaires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroCarte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Montant = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TypeOperation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOperation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Devise = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompteBancaireId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionsBancaires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionsBancaires_ComptesBancaires_CompteBancaireId",
                        column: x => x.CompteBancaireId,
                        principalTable: "ComptesBancaires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AdressesParticulier",
                columns: new[] { "Id", "CodePostal", "Complement", "Libelle", "Ville" },
                values: new object[] { 1, "94000", "", "12, rue des Oliviers", "CRETEIL" });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AdressePostaleId",
                table: "Clients",
                column: "AdressePostaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AdresseSiegeId",
                table: "Clients",
                column: "AdresseSiegeId");

            migrationBuilder.CreateIndex(
                name: "IX_ComptesBancaires_ClientId",
                table: "ComptesBancaires",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionsBancaires_CompteBancaireId",
                table: "TransactionsBancaires",
                column: "CompteBancaireId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionsBancaires");

            migrationBuilder.DropTable(
                name: "ComptesBancaires");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "AdressesParticulier");

            migrationBuilder.DropTable(
                name: "AdressesProfessionnels");
        }
    }
}
