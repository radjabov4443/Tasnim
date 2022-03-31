using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;

namespace Tasnim.Data.Migrations
{
    public partial class TasnimSecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Religion",
                table: "Users",
                newName: "State");

            migrationBuilder.AddColumn<long>(
                name: "MentorId",
                table: "Videos",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SavedContentId",
                table: "Videos",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Length",
                table: "Audios",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MentorId",
                table: "Audios",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Audios",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SavedContentId",
                table: "Audios",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Mentors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SavedContents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    SavedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavedContents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tag = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Test_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    MentorId = table.Column<long>(type: "bigint", nullable: false),
                    AudioId = table.Column<long>(type: "bigint", nullable: true),
                    VideoId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    SavedContentId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Audios_AudioId",
                        column: x => x.AudioId,
                        principalTable: "Audios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_Mentors_MentorId",
                        column: x => x.MentorId,
                        principalTable: "Mentors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_SavedContents_SavedContentId",
                        column: x => x.SavedContentId,
                        principalTable: "SavedContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Videos_MentorId",
                table: "Videos",
                column: "MentorId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_SavedContentId",
                table: "Videos",
                column: "SavedContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Audios_MentorId",
                table: "Audios",
                column: "MentorId");

            migrationBuilder.CreateIndex(
                name: "IX_Audios_SavedContentId",
                table: "Audios",
                column: "SavedContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AudioId",
                table: "Posts",
                column: "AudioId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_MentorId",
                table: "Posts",
                column: "MentorId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_SavedContentId",
                table: "Posts",
                column: "SavedContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_VideoId",
                table: "Posts",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedContents_UserId",
                table: "SavedContents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Test_UserId",
                table: "Test",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Audios_Mentors_MentorId",
                table: "Audios",
                column: "MentorId",
                principalTable: "Mentors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Audios_SavedContents_SavedContentId",
                table: "Audios",
                column: "SavedContentId",
                principalTable: "SavedContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Mentors_MentorId",
                table: "Videos",
                column: "MentorId",
                principalTable: "Mentors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_SavedContents_SavedContentId",
                table: "Videos",
                column: "SavedContentId",
                principalTable: "SavedContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Audios_Mentors_MentorId",
                table: "Audios");

            migrationBuilder.DropForeignKey(
                name: "FK_Audios_SavedContents_SavedContentId",
                table: "Audios");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Mentors_MentorId",
                table: "Videos");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_SavedContents_SavedContentId",
                table: "Videos");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropTable(
                name: "Mentors");

            migrationBuilder.DropTable(
                name: "SavedContents");

            migrationBuilder.DropIndex(
                name: "IX_Videos_MentorId",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Videos_SavedContentId",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Audios_MentorId",
                table: "Audios");

            migrationBuilder.DropIndex(
                name: "IX_Audios_SavedContentId",
                table: "Audios");

            migrationBuilder.DropColumn(
                name: "MentorId",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "SavedContentId",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Audios");

            migrationBuilder.DropColumn(
                name: "MentorId",
                table: "Audios");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Audios");

            migrationBuilder.DropColumn(
                name: "SavedContentId",
                table: "Audios");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Users",
                newName: "Religion");
        }
    }
}
