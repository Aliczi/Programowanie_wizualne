using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _145213.kdramasApp.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Pseudonym = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KDramas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KDramas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KDramaActors",
                columns: table => new
                {
                    ActorId = table.Column<int>(type: "INTEGER", nullable: false),
                    KDramaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KDramaActors", x => new { x.ActorId, x.KDramaId });
                    table.ForeignKey(
                        name: "FK_KDramaActors_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KDramaActors_KDramas_KDramaId",
                        column: x => x.KDramaId,
                        principalTable: "KDramas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StatusType = table.Column<int>(type: "INTEGER", nullable: false),
                    KDramaId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statuses_KDramas_KDramaId",
                        column: x => x.KDramaId,
                        principalTable: "KDramas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actors_Pseudonym",
                table: "Actors",
                column: "Pseudonym",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KDramaActors_KDramaId",
                table: "KDramaActors",
                column: "KDramaId");

            migrationBuilder.CreateIndex(
                name: "IX_KDramas_Title",
                table: "KDramas",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_KDramaId",
                table: "Statuses",
                column: "KDramaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KDramaActors");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "KDramas");
        }
    }
}
