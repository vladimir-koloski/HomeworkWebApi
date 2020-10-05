using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Homework01.TodoApp.DataModels.Migrations
{
    public partial class Init_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Todo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Subject = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 300, nullable: true),
                    IsDone = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    TimeTodo = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Todo_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { 1, "Bob", "Bobsky", "(?\\?-??3#>L?q", "bob007" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { 2, "Vladimir", "Koloski", "(?\\?-??3#>L?q", "vlatko" });

            migrationBuilder.InsertData(
                table: "Todo",
                columns: new[] { "Id", "CreatedOn", "Description", "IsDone", "Subject", "TimeTodo", "UserId" },
                values: new object[] { 1, new DateTime(2020, 10, 4, 10, 6, 3, 700, DateTimeKind.Local), "In ramstore mall, in store of Peko, i should buy new shoes", false, "Shoping", new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Todo",
                columns: new[] { "Id", "CreatedOn", "Description", "IsDone", "Subject", "TimeTodo", "UserId" },
                values: new object[] { 2, new DateTime(2020, 10, 4, 10, 6, 3, 703, DateTimeKind.Local), "Dont forget to take some water", false, "Running", new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Todo",
                columns: new[] { "Id", "CreatedOn", "Description", "IsDone", "Subject", "TimeTodo", "UserId" },
                values: new object[] { 3, new DateTime(2020, 10, 4, 10, 6, 3, 703, DateTimeKind.Local), "To build a service for TODO as WebApi", false, "Homework", new DateTime(2020, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Todo_UserId",
                table: "Todo",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todo");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
