using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Statistic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMeteorology : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meteorology_Categories_CategoryId",
                table: "Meteorology");

            migrationBuilder.DropForeignKey(
                name: "FK_Meteorology_Contacts_ContactId",
                table: "Meteorology");

            migrationBuilder.DropForeignKey(
                name: "FK_Meteorology_Source_SourceId",
                table: "Meteorology");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meteorology",
                table: "Meteorology");

            migrationBuilder.RenameTable(
                name: "Meteorology",
                newName: "Meteorologies");

            migrationBuilder.RenameIndex(
                name: "IX_Meteorology_SourceId",
                table: "Meteorologies",
                newName: "IX_Meteorologies_SourceId");

            migrationBuilder.RenameIndex(
                name: "IX_Meteorology_ContactId",
                table: "Meteorologies",
                newName: "IX_Meteorologies_ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_Meteorology_CategoryId",
                table: "Meteorologies",
                newName: "IX_Meteorologies_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meteorologies",
                table: "Meteorologies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Meteorologies_Categories_CategoryId",
                table: "Meteorologies",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meteorologies_Contacts_ContactId",
                table: "Meteorologies",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meteorologies_Source_SourceId",
                table: "Meteorologies",
                column: "SourceId",
                principalTable: "Source",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meteorologies_Categories_CategoryId",
                table: "Meteorologies");

            migrationBuilder.DropForeignKey(
                name: "FK_Meteorologies_Contacts_ContactId",
                table: "Meteorologies");

            migrationBuilder.DropForeignKey(
                name: "FK_Meteorologies_Source_SourceId",
                table: "Meteorologies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meteorologies",
                table: "Meteorologies");

            migrationBuilder.RenameTable(
                name: "Meteorologies",
                newName: "Meteorology");

            migrationBuilder.RenameIndex(
                name: "IX_Meteorologies_SourceId",
                table: "Meteorology",
                newName: "IX_Meteorology_SourceId");

            migrationBuilder.RenameIndex(
                name: "IX_Meteorologies_ContactId",
                table: "Meteorology",
                newName: "IX_Meteorology_ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_Meteorologies_CategoryId",
                table: "Meteorology",
                newName: "IX_Meteorology_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meteorology",
                table: "Meteorology",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Meteorology_Categories_CategoryId",
                table: "Meteorology",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meteorology_Contacts_ContactId",
                table: "Meteorology",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meteorology_Source_SourceId",
                table: "Meteorology",
                column: "SourceId",
                principalTable: "Source",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
