using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contacts_List.Infrastructure.Persistance.Migrations
{
    public partial class AddIdentityUserToContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Contacts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_UserId1",
                table: "Contacts",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_AspNetUsers_UserId1",
                table: "Contacts",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AspNetUsers_UserId1",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_UserId1",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Contacts");
        }
    }
}
