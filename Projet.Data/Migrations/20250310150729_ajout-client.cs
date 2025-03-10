using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Projet.Data.Migrations
{
    /// <inheritdoc />
    public partial class ajoutclient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AdressesParticulier",
                columns: new[] { "Id", "CodePostal", "Complement", "Libelle", "Ville" },
                values: new object[,]
                {
                    { 2, "94300", "Etage 2", "10, rue des Olivies", "VINCENNES" },
                    { 3, "94120", "", "15, rue de la République", "FONTENAY SOUS BOIS" },
                    { 4, "92100", "", "25, rue de la Paix", "LA DEFENSE" },
                    { 5, "93500", "", "3, aveenue des Parcs", "ROISSY EN France" },
                    { 6, "93200", "", "3, rue Lecourbe", "BAGNOLET" }
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
                table: "Clients",
                columns: new[] { "Id", "AdressePostaleId", "DateNaissance", "Discriminator", "Email", "Nom", "Prenom", "Sexe" },
                values: new object[] { 1, 1, new DateTime(1985, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ClientParticulier", "bety@gmail.com", "BETY", "Daniel", 20 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdressesParticulier",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AdressesParticulier",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AdressesParticulier",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AdressesParticulier",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AdressesParticulier",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AdressesProfessionnels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AdressesProfessionnels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AdressesProfessionnels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AdressesProfessionnels",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AdressesProfessionnels",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
