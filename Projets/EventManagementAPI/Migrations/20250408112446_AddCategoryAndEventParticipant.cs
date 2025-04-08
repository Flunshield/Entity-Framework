using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryAndEventParticipant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipants_Events_EventsId",
                table: "EventParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipants_Participants_ParticipantsId",
                table: "EventParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Category_CategoryId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Participants_ParticipantId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Sessions_SessionId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_Locations_LocationId",
                table: "Room");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Room_RoomId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Speakers_SpeakerId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_SpeakerId",
                table: "Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rating",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "SpeakerId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Participants");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "Rating",
                newName: "Ratings");

            migrationBuilder.RenameColumn(
                name: "ParticipantsId",
                table: "EventParticipants",
                newName: "ParticipantId");

            migrationBuilder.RenameColumn(
                name: "EventsId",
                table: "EventParticipants",
                newName: "EventId");

            migrationBuilder.RenameIndex(
                name: "IX_EventParticipants_ParticipantsId",
                table: "EventParticipants",
                newName: "IX_EventParticipants_ParticipantId");

            migrationBuilder.RenameIndex(
                name: "IX_Room_LocationId",
                table: "Rooms",
                newName: "IX_Rooms_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_SessionId",
                table: "Ratings",
                newName: "IX_Ratings_SessionId");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_ParticipantId",
                table: "Ratings",
                newName: "IX_Ratings_ParticipantId");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Participants",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Participants",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParticipantId",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AttendanceStatus",
                table: "EventParticipants",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "EventParticipants",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SessionSpeaker",
                columns: table => new
                {
                    SessionsId = table.Column<int>(type: "int", nullable: false),
                    SpeakersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionSpeaker", x => new { x.SessionsId, x.SpeakersId });
                    table.ForeignKey(
                        name: "FK_SessionSpeaker_Sessions_SessionsId",
                        column: x => x.SessionsId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionSpeaker_Speakers_SpeakersId",
                        column: x => x.SpeakersId,
                        principalTable: "Speakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ParticipantId",
                table: "Events",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionSpeaker_SpeakersId",
                table: "SessionSpeaker",
                column: "SpeakersId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipants_Events_EventId",
                table: "EventParticipants",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipants_Participants_ParticipantId",
                table: "EventParticipants",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Category_CategoryId",
                table: "Events",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Participants_ParticipantId",
                table: "Events",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Participants_ParticipantId",
                table: "Ratings",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Sessions_SessionId",
                table: "Ratings",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Locations_LocationId",
                table: "Rooms",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Rooms_RoomId",
                table: "Sessions",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipants_Events_EventId",
                table: "EventParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipants_Participants_ParticipantId",
                table: "EventParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Category_CategoryId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Participants_ParticipantId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Participants_ParticipantId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Sessions_SessionId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Locations_LocationId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Rooms_RoomId",
                table: "Sessions");

            migrationBuilder.DropTable(
                name: "SessionSpeaker");

            migrationBuilder.DropIndex(
                name: "IX_Events_ParticipantId",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "ParticipantId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "AttendanceStatus",
                table: "EventParticipants");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "EventParticipants");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Room");

            migrationBuilder.RenameTable(
                name: "Ratings",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "ParticipantId",
                table: "EventParticipants",
                newName: "ParticipantsId");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "EventParticipants",
                newName: "EventsId");

            migrationBuilder.RenameIndex(
                name: "IX_EventParticipants_ParticipantId",
                table: "EventParticipants",
                newName: "IX_EventParticipants_ParticipantsId");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_LocationId",
                table: "Room",
                newName: "IX_Room_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_SessionId",
                table: "Rating",
                newName: "IX_Rating_SessionId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_ParticipantId",
                table: "Rating",
                newName: "IX_Rating_ParticipantId");

            migrationBuilder.AddColumn<int>(
                name: "SpeakerId",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Participants",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Events",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rating",
                table: "Rating",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_SpeakerId",
                table: "Sessions",
                column: "SpeakerId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipants_Events_EventsId",
                table: "EventParticipants",
                column: "EventsId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipants_Participants_ParticipantsId",
                table: "EventParticipants",
                column: "ParticipantsId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Category_CategoryId",
                table: "Events",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Participants_ParticipantId",
                table: "Rating",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Sessions_SessionId",
                table: "Rating",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Locations_LocationId",
                table: "Room",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Room_RoomId",
                table: "Sessions",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Speakers_SpeakerId",
                table: "Sessions",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
