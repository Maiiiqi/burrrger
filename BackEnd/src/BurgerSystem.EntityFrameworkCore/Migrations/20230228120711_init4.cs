using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerSystem.EntityFrameworkCore.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StoreName",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "PassWord",
                table: "User",
                newName: "Password");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Store",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "CommentCount",
                table: "Store",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "TasteScoreAverage",
                table: "Store",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TextureScoreAverage",
                table: "Store",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "VisualScoreAverage",
                table: "Store",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<int>(
                name: "VisualScore",
                table: "Comment",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "TextureScore",
                table: "Comment",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "TasteScore",
                table: "Comment",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "Comment",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "CommentCount",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "TasteScoreAverage",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "TextureScoreAverage",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "VisualScoreAverage",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "User",
                newName: "PassWord");

            migrationBuilder.AlterColumn<string>(
                name: "VisualScore",
                table: "Comment",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "TextureScore",
                table: "Comment",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "TasteScore",
                table: "Comment",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "StoreName",
                table: "Comment",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
