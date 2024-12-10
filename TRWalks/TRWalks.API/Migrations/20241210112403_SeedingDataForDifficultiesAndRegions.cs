using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TRWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForDifficultiesAndRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_walks_regions_RegionId",
                table: "walks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_regions",
                table: "regions");

            migrationBuilder.RenameTable(
                name: "regions",
                newName: "Regions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Regions",
                table: "Regions",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a1c8db32-d39d-41af-bb82-89c622c8c555"), "Easy" },
                    { new Guid("b34ef5a1-73e4-4d22-9124-1bde6a25d53b"), "Medium" },
                    { new Guid("f3e8cf4a-a789-4bc7-9255-c9c8f2468d44"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("3a8f4b2c-d7c1-43a2-9f17-8e5b8f2c1d6a"), "HQ", "Historical Quarters", "https://example.com/images/historical-quarters.jpg" },
                    { new Guid("8c34ba72-4a1b-4a8e-8d23-1b5c81c56b77"), "SFR", "Siberian Forest", "https://example.com/images/siberian-forest.jpg" },
                    { new Guid("c1e7ad3b-f2a6-4c2f-9f91-2f5c8b5a6d8c"), "LDN", "Lenin District", null },
                    { new Guid("d7c8a1c8-c349-4f27-9f17-a555e3c8c789"), "TSC", "Tomsk Central", "https://example.com/images/tomsk-central.jpg" },
                    { new Guid("e8f12ab3-a71d-4e2c-9f23-b8c9f3d8e74a"), "UA", "University Area", "https://example.com/images/university-area.jpg" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_walks_Regions_RegionId",
                table: "walks",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_walks_Regions_RegionId",
                table: "walks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Regions",
                table: "Regions");

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("a1c8db32-d39d-41af-bb82-89c622c8c555"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("b34ef5a1-73e4-4d22-9124-1bde6a25d53b"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("f3e8cf4a-a789-4bc7-9255-c9c8f2468d44"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("3a8f4b2c-d7c1-43a2-9f17-8e5b8f2c1d6a"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("8c34ba72-4a1b-4a8e-8d23-1b5c81c56b77"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c1e7ad3b-f2a6-4c2f-9f91-2f5c8b5a6d8c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d7c8a1c8-c349-4f27-9f17-a555e3c8c789"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e8f12ab3-a71d-4e2c-9f23-b8c9f3d8e74a"));

            migrationBuilder.RenameTable(
                name: "Regions",
                newName: "regions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_regions",
                table: "regions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_walks_regions_RegionId",
                table: "walks",
                column: "RegionId",
                principalTable: "regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
