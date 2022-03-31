using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Tasnim.Data.Migrations
{
    public partial class EditOtherModelsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Audios_AudioId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Videos_VideoId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Statements");

            migrationBuilder.DropIndex(
                name: "IX_Posts_AudioId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_VideoId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "AudioId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "VideoId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "Audios");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Videos",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Audio",
                table: "Posts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Video",
                table: "Posts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TrainingId",
                table: "Mentors",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mentors_TrainingId",
                table: "Mentors",
                column: "TrainingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mentors_Trainings_TrainingId",
                table: "Mentors",
                column: "TrainingId",
                principalTable: "Trainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mentors_Trainings_TrainingId",
                table: "Mentors");

            migrationBuilder.DropIndex(
                name: "IX_Mentors_TrainingId",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Audio",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Video",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "TrainingId",
                table: "Mentors");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Videos",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Videos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AudioId",
                table: "Posts",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "VideoId",
                table: "Posts",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Audios",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Statements",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statements", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AudioId",
                table: "Posts",
                column: "AudioId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_VideoId",
                table: "Posts",
                column: "VideoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Audios_AudioId",
                table: "Posts",
                column: "AudioId",
                principalTable: "Audios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Videos_VideoId",
                table: "Posts",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
