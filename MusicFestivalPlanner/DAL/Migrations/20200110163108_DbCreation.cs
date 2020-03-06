using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class DbCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Festivals",
                columns: table => new
                {
                    FestivalId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FestivalName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Festivals", x => x.FestivalId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GenreName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Performers",
                columns: table => new
                {
                    PerformerId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PerformerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performers", x => x.PerformerId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleName = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Djs",
                columns: table => new
                {
                    DjId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StageName = table.Column<string>(maxLength: 128, nullable: true),
                    FirstName = table.Column<string>(maxLength: 128, nullable: true),
                    LastName = table.Column<string>(maxLength: 128, nullable: true),
                    FestivalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Djs", x => x.DjId);
                    table.ForeignKey(
                        name: "FK_Djs_Festivals_FestivalId",
                        column: x => x.FestivalId,
                        principalTable: "Festivals",
                        principalColumn: "FestivalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    SongId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SongName = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<DateTime>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.SongId);
                    table.ForeignKey(
                        name: "FK_Songs_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DjSongs",
                columns: table => new
                {
                    DjSongId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DjId = table.Column<int>(nullable: false),
                    SongId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DjSongs", x => x.DjSongId);
                    table.ForeignKey(
                        name: "FK_DjSongs_Djs_DjId",
                        column: x => x.DjId,
                        principalTable: "Djs",
                        principalColumn: "DjId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DjSongs_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerformerSongs",
                columns: table => new
                {
                    PerformerSongId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<int>(nullable: false),
                    PerformerId = table.Column<int>(nullable: false),
                    SongId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformerSongs", x => x.PerformerSongId);
                    table.ForeignKey(
                        name: "FK_PerformerSongs_Performers_PerformerId",
                        column: x => x.PerformerId,
                        principalTable: "Performers",
                        principalColumn: "PerformerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerformerSongs_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerformerSongs_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Djs_FestivalId",
                table: "Djs",
                column: "FestivalId");

            migrationBuilder.CreateIndex(
                name: "IX_DjSongs_DjId",
                table: "DjSongs",
                column: "DjId");

            migrationBuilder.CreateIndex(
                name: "IX_DjSongs_SongId",
                table: "DjSongs",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformerSongs_PerformerId",
                table: "PerformerSongs",
                column: "PerformerId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformerSongs_RoleId",
                table: "PerformerSongs",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformerSongs_SongId",
                table: "PerformerSongs",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_GenreId",
                table: "Songs",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DjSongs");

            migrationBuilder.DropTable(
                name: "PerformerSongs");

            migrationBuilder.DropTable(
                name: "Djs");

            migrationBuilder.DropTable(
                name: "Performers");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Festivals");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
