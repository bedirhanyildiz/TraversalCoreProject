using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migaddcomment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Destinations",
                table: "Destinations");

            migrationBuilder.RenameTable(
                name: "Destinations",
                newName: "Destination");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Destination",
                table: "Destination",
                column: "DestinationID");

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommentContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentState = table.Column<bool>(type: "bit", nullable: false),
                    DestinationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comment_Destination_DestinationID",
                        column: x => x.DestinationID,
                        principalTable: "Destination",
                        principalColumn: "DestinationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_DestinationID",
                table: "Comment",
                column: "DestinationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Destination",
                table: "Destination");

            migrationBuilder.RenameTable(
                name: "Destination",
                newName: "Destinations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Destinations",
                table: "Destinations",
                column: "DestinationID");
        }
    }
}
