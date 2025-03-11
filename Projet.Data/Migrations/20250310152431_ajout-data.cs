using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Projet.Data.Migrations
{
    /// <inheritdoc />
    public partial class ajoutdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AdressesParticulier",
                columns: new[] { "Id", "CodePostal", "Complement", "Libelle", "Ville" },
                values: new object[,]
                {
                    { 7, "94120", "digicode 1432", "125, rue LaFayette", "FONTENAY SOUS BOIS" },
                    { 8, "93500", "", "36, quai des Orfèvres", "ROISSY EN FRANCE" },
                    { 9, "75002", "Bat. C", "32, rue E. Renan", "PARIS" },
                    { 10, "92100", "", "23, av P. Valery", "LA DEFENSE" },
                    { 11, "75003", "Fond de Cour", "15, Place de la Bastille", "PARIS" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AdressePostaleId", "DateNaissance", "Discriminator", "Email", "Nom", "Prenom", "Sexe" },
                values: new object[,]
                {
                    { 2, 2, new DateTime(1965, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "ClientParticulier", "bodin@gmail.com", "BODIN", "Justin", 20 },
                    { 3, 3, new DateTime(1977, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "ClientParticulier", "berris@gmail.com", "BERRIS", "Karine", 10 },
                    { 4, 4, new DateTime(1977, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ClientParticulier", "abenir@gmail.com", "ABENIR", "Alexandra", 10 },
                    { 5, 5, new DateTime(1976, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "ClientParticulier", "bensaid@gmail.com", "BENSAID", "Georgia", 10 },
                    { 6, 6, new DateTime(1970, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ClientParticulier", "ababou@gmail.com", "ABABOU", "Teddy", 20 }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AdressePostaleId", "AdresseSiegeId", "Discriminator", "Email", "Nom", "Siret", "StatutJuridique" },
                values: new object[,]
                {
                    { 7, 7, 1, "ClientProfessionnel", "info@axa.com", "AXA", "12548795641122", 10 },
                    { 8, 8, 2, "ClientProfessionnel", "info@paul.com", "PAUL", "87459564455444", 40 },
                    { 9, 9, 3, "ClientProfessionnel", "info@primark.com", "PRIMARK", "08755897458455", 10 },
                    { 10, 10, 4, "ClientProfessionnel", "info@zara.com", "ZARA", "65895874587854", 20 },
                    { 11, 11, 5, "ClientProfessionnel", "info@leonidas.com", "LEONIDAS", "91235987456832", 30 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AdressesParticulier",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AdressesParticulier",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AdressesParticulier",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AdressesParticulier",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AdressesParticulier",
                keyColumn: "Id",
                keyValue: 11);
        }
    }
}
