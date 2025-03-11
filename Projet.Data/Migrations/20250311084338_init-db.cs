using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Projet.Data.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "ClientSequence");

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
                name: "AnomaliesTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroCarte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Montant = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TypeOperation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOperation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Devise = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Motif = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnomaliesTransactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComptesBancaires",
                columns: table => new
                {
                    NumeroCompte = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateOuverture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Solde = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComptesBancaires", x => x.NumeroCompte);
                });

            migrationBuilder.CreateTable(
                name: "ClientsParticuliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [ClientSequence]"),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AdressePostaleId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sexe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientsParticuliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientsParticuliers_AdressesParticulier_AdressePostaleId",
                        column: x => x.AdressePostaleId,
                        principalTable: "AdressesParticulier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientsProfessionnels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [ClientSequence]"),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AdressePostaleId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Siret = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatutJuridique = table.Column<int>(type: "int", nullable: false),
                    AdresseSiegeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientsProfessionnels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientsProfessionnels_AdressesParticulier_AdressePostaleId",
                        column: x => x.AdressePostaleId,
                        principalTable: "AdressesParticulier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientsProfessionnels_AdressesProfessionnels_AdresseSiegeId",
                        column: x => x.AdresseSiegeId,
                        principalTable: "AdressesProfessionnels",
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
                    CompteBancaireId = table.Column<int>(type: "int", nullable: false),
                    CompteBancaireNumeroCompte = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EstValide = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionsBancaires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionsBancaires_ComptesBancaires_CompteBancaireNumeroCompte",
                        column: x => x.CompteBancaireNumeroCompte,
                        principalTable: "ComptesBancaires",
                        principalColumn: "NumeroCompte",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AdressesParticulier",
                columns: new[] { "Id", "CodePostal", "Complement", "Libelle", "Ville" },
                values: new object[,]
                {
                    { 1, "94000", "", "12, rue des Oliviers", "CRETEIL" },
                    { 2, "94300", "Etage 2", "10, rue des Olivies", "VINCENNES" },
                    { 3, "94120", "", "15, rue de la République", "FONTENAY SOUS BOIS" },
                    { 4, "92100", "", "25, rue de la Paix", "LA DEFENSE" },
                    { 5, "93500", "", "3, aveenue des Parcs", "ROISSY EN France" },
                    { 6, "93200", "", "3, rue Lecourbe", "BAGNOLET" },
                    { 7, "94120", "digicode 1432", "125, rue LaFayette", "FONTENAY SOUS BOIS" },
                    { 8, "93500", "", "36, quai des Orfèvres", "ROISSY EN FRANCE" },
                    { 9, "75002", "Bat. C", "32, rue E. Renan", "PARIS" },
                    { 10, "92100", "", "23, av P. Valery", "LA DEFENSE" },
                    { 11, "75003", "Fond de Cour", "15, Place de la Bastille", "PARIS" }
                });

            migrationBuilder.InsertData(
                table: "AdressesProfessionnels",
                columns: new[] { "Id", "CodePostal", "Complement", "Libelle", "Ville" },
                values: new object[,]
                {
                    { 1, "94120", "Digicode 1432", "125, rue LaFayette", "FONTENAY SOUS BOIS" },
                    { 2, "92060", "", "10, esplanade de la Défense", "LA DEFENSE" },
                    { 3, "75002", "Bat. C", "32, rue E. Renan", "Paris" },
                    { 4, "92060", "Tour Franklin", "24, esplanade de la Défense", "LA DEFENSE" },
                    { 5, "75008", "", "10, rue de la Paix", "PARIS" }
                });

            migrationBuilder.InsertData(
                table: "ClientsParticuliers",
                columns: new[] { "Id", "AdressePostaleId", "DateNaissance", "Email", "Nom", "Prenom", "Sexe" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1985, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "bety@gmail.com", "BETY", "Daniel", 20 },
                    { 3, 2, new DateTime(1965, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "bodin@gmail.com", "BODIN", "Justin", 20 },
                    { 5, 3, new DateTime(1977, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "berris@gmail.com", "BERRIS", "Karine", 10 },
                    { 7, 4, new DateTime(1977, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "abenir@gmail.com", "ABENIR", "Alexandra", 10 },
                    { 9, 5, new DateTime(1976, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "bensaid@gmail.com", "BENSAID", "Georgia", 10 },
                    { 11, 6, new DateTime(1970, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ababou@gmail.com", "ABABOU", "Teddy", 20 }
                });

            migrationBuilder.InsertData(
                table: "ClientsProfessionnels",
                columns: new[] { "Id", "AdressePostaleId", "AdresseSiegeId", "Email", "Nom", "Siret", "StatutJuridique" },
                values: new object[,]
                {
                    { 2, 7, 1, "info@axa.com", "AXA", "12548795641122", 10 },
                    { 4, 8, 2, "info@paul.com", "PAUL", "87459564455444", 40 },
                    { 6, 9, 3, "info@primark.com", "PRIMARK", "08755897458455", 10 },
                    { 8, 10, 4, "info@zara.com", "ZARA", "65895874587854", 20 },
                    { 10, 11, 5, "info@leonidas.com", "LEONIDAS", "91235987456832", 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientsParticuliers_AdressePostaleId",
                table: "ClientsParticuliers",
                column: "AdressePostaleId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientsProfessionnels_AdressePostaleId",
                table: "ClientsProfessionnels",
                column: "AdressePostaleId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientsProfessionnels_AdresseSiegeId",
                table: "ClientsProfessionnels",
                column: "AdresseSiegeId");

            migrationBuilder.CreateIndex(
                name: "IX_ComptesBancaires_ClientId",
                table: "ComptesBancaires",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionsBancaires_CompteBancaireNumeroCompte",
                table: "TransactionsBancaires",
                column: "CompteBancaireNumeroCompte");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnomaliesTransactions");

            migrationBuilder.DropTable(
                name: "ClientsParticuliers");

            migrationBuilder.DropTable(
                name: "ClientsProfessionnels");

            migrationBuilder.DropTable(
                name: "TransactionsBancaires");

            migrationBuilder.DropTable(
                name: "AdressesParticulier");

            migrationBuilder.DropTable(
                name: "AdressesProfessionnels");

            migrationBuilder.DropTable(
                name: "ComptesBancaires");

            migrationBuilder.DropSequence(
                name: "ClientSequence");
        }
    }
}
