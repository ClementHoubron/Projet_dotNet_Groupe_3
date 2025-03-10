using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Projet.Data.Migrations
{
    /// <inheritdoc />
    public partial class ajoutdata2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4);

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
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AdressePostaleId", "DateNaissance", "Email", "Nom", "Prenom", "Sexe" },
                values: new object[] { 2, new DateTime(1965, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "bodin@gmail.com", "BODIN", "Justin", 20 });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AdressePostaleId", "DateNaissance", "Email", "Nom", "Prenom" },
                values: new object[] { 3, new DateTime(1977, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "berris@gmail.com", "BERRIS", "Karine" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AdressePostaleId", "AdresseSiegeId", "Email", "Nom", "Siret", "StatutJuridique" },
                values: new object[] { 10, 4, "info@zara.com", "ZARA", "65895874587854", 20 });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AdressePostaleId", "AdresseSiegeId", "Email", "Nom", "Siret", "StatutJuridique" },
                values: new object[] { 11, 5, "info@leonidas.com", "LEONIDAS", "91235987456832", 30 });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AdressePostaleId", "AdresseSiegeId", "Discriminator", "Email", "Nom", "Siret", "StatutJuridique" },
                values: new object[,]
                {
                    { 2, 7, 1, "ClientProfessionnel", "info@axa.com", "AXA", "12548795641122", 10 },
                    { 4, 8, 2, "ClientProfessionnel", "info@paul.com", "PAUL", "87459564455444", 40 },
                    { 6, 9, 3, "ClientProfessionnel", "info@primark.com", "PRIMARK", "08755897458455", 10 }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AdressePostaleId", "DateNaissance", "Discriminator", "Email", "Nom", "Prenom", "Sexe" },
                values: new object[,]
                {
                    { 7, 4, new DateTime(1977, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ClientParticulier", "abenir@gmail.com", "ABENIR", "Alexandra", 10 },
                    { 9, 5, new DateTime(1976, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "ClientParticulier", "bensaid@gmail.com", "BENSAID", "Georgia", 10 },
                    { 11, 6, new DateTime(1970, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ClientParticulier", "ababou@gmail.com", "ABABOU", "Teddy", 20 }
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
                keyValue: 4);

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
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AdressePostaleId", "DateNaissance", "Email", "Nom", "Prenom", "Sexe" },
                values: new object[] { 3, new DateTime(1977, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "berris@gmail.com", "BERRIS", "Karine", 10 });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AdressePostaleId", "DateNaissance", "Email", "Nom", "Prenom" },
                values: new object[] { 5, new DateTime(1976, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "bensaid@gmail.com", "BENSAID", "Georgia" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AdressePostaleId", "AdresseSiegeId", "Email", "Nom", "Siret", "StatutJuridique" },
                values: new object[] { 8, 2, "info@paul.com", "PAUL", "87459564455444", 40 });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AdressePostaleId", "AdresseSiegeId", "Email", "Nom", "Siret", "StatutJuridique" },
                values: new object[] { 10, 4, "info@zara.com", "ZARA", "65895874587854", 20 });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AdressePostaleId", "DateNaissance", "Discriminator", "Email", "Nom", "Prenom", "Sexe" },
                values: new object[,]
                {
                    { 2, 2, new DateTime(1965, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "ClientParticulier", "bodin@gmail.com", "BODIN", "Justin", 20 },
                    { 4, 4, new DateTime(1977, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ClientParticulier", "abenir@gmail.com", "ABENIR", "Alexandra", 10 },
                    { 6, 6, new DateTime(1970, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ClientParticulier", "ababou@gmail.com", "ABABOU", "Teddy", 20 }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AdressePostaleId", "AdresseSiegeId", "Discriminator", "Email", "Nom", "Siret", "StatutJuridique" },
                values: new object[,]
                {
                    { 7, 7, 1, "ClientProfessionnel", "info@axa.com", "AXA", "12548795641122", 10 },
                    { 9, 9, 3, "ClientProfessionnel", "info@primark.com", "PRIMARK", "08755897458455", 10 },
                    { 11, 11, 5, "ClientProfessionnel", "info@leonidas.com", "LEONIDAS", "91235987456832", 30 }
                });
        }
    }
}
