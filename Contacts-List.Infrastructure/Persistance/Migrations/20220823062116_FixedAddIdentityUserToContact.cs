using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contacts_List.Infrastructure.Persistance.Migrations
{
    public partial class FixedAddIdentityUserToContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AspNetUsers_UserId1",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "Contacts",
                newName: "IdentityUserId1");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Contacts",
                newName: "IdentityUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_UserId1",
                table: "Contacts",
                newName: "IX_Contacts_IdentityUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_AspNetUsers_IdentityUserId1",
                table: "Contacts",
                column: "IdentityUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AspNetUsers_IdentityUserId1",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "IdentityUserId1",
                table: "Contacts",
                newName: "UserId1");

            migrationBuilder.RenameColumn(
                name: "IdentityUserId",
                table: "Contacts",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_IdentityUserId1",
                table: "Contacts",
                newName: "IX_Contacts_UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_AspNetUsers_UserId1",
                table: "Contacts",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
