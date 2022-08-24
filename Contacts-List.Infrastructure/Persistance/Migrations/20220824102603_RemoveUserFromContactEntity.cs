using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contacts_List.Infrastructure.Persistance.Migrations
{
    public partial class RemoveUserFromContactEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AspNetUsers_IdentityUserId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_IdentityUserId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Contacts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Contacts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_IdentityUserId",
                table: "Contacts",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_AspNetUsers_IdentityUserId",
                table: "Contacts",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
