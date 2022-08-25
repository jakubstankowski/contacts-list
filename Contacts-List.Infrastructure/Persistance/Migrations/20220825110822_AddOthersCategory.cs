using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contacts_List.Infrastructure.Persistance.Migrations
{
    public partial class AddOthersCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Category_CategoryId",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Contacts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "OthersCategory",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Category_CategoryId",
                table: "Contacts",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Category_CategoryId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "OthersCategory",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Category_CategoryId",
                table: "Contacts",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
