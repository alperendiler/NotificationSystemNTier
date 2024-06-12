using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class notificationSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtpAuthenticators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SecretKey = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtpAuthenticators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtpAuthenticators_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiresDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RevokedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevokedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonRevoked = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperationClaimId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 11, 23, 45, 30, 816, DateTimeKind.Utc).AddTicks(1282), null, "Admin", null },
                    { 2, new DateTime(2024, 6, 11, 23, 45, 30, 816, DateTimeKind.Utc).AddTicks(1291), null, "Auth.Admin", null },
                    { 3, new DateTime(2024, 6, 11, 23, 45, 30, 816, DateTimeKind.Utc).AddTicks(1292), null, "Auth.Read", null },
                    { 4, new DateTime(2024, 6, 11, 23, 45, 30, 816, DateTimeKind.Utc).AddTicks(1292), null, "Auth.Write", null },
                    { 5, new DateTime(2024, 6, 11, 23, 45, 30, 816, DateTimeKind.Utc).AddTicks(1293), null, "Auth.RevokeToken", null },
                    { 6, new DateTime(2024, 6, 11, 23, 45, 30, 816, DateTimeKind.Utc).AddTicks(1294), null, "OperationClaims.Admin", null },
                    { 7, new DateTime(2024, 6, 11, 23, 45, 30, 816, DateTimeKind.Utc).AddTicks(1295), null, "OperationClaims.Read", null },
                    { 8, new DateTime(2024, 6, 11, 23, 45, 30, 816, DateTimeKind.Utc).AddTicks(1296), null, "OperationClaims.Write", null },
                    { 9, new DateTime(2024, 6, 11, 23, 45, 30, 816, DateTimeKind.Utc).AddTicks(1296), null, "OperationClaims.Create", null },
                    { 10, new DateTime(2024, 6, 11, 23, 45, 30, 816, DateTimeKind.Utc).AddTicks(1297), null, "OperationClaims.Update", null },
                    { 11, new DateTime(2024, 6, 11, 23, 45, 30, 816, DateTimeKind.Utc).AddTicks(1298), null, "OperationClaims.Delete", null },
                    { 12, new DateTime(2024, 6, 11, 23, 45, 30, 816, DateTimeKind.Utc).AddTicks(1299), null, "UserOperationClaims.Admin", null },
                    { 13, new DateTime(2024, 6, 11, 23, 45, 30, 816, DateTimeKind.Utc).AddTicks(1299), null, "UserOperationClaims.Read", null },
                    { 14, new DateTime(2024, 6, 11, 23, 45, 30, 816, DateTimeKind.Utc).AddTicks(1300), null, "UserOperationClaims.Write", null },
                    { 15, new DateTime(2024, 6, 11, 23, 45, 30, 816, DateTimeKind.Utc).AddTicks(1301), null, "UserOperationClaims.Create", null },
                    { 16, new DateTime(2024, 6, 11, 23, 45, 30, 816, DateTimeKind.Utc).AddTicks(1302), null, "UserOperationClaims.Update", null },
                    { 17, new DateTime(2024, 6, 11, 23, 45, 30, 816, DateTimeKind.Utc).AddTicks(1303), null, "UserOperationClaims.Delete", null },
                    { 18, new DateTime(2024, 6, 11, 23, 45, 30, 816, DateTimeKind.Utc).AddTicks(1303), null, "Users.Admin", null },
                    { 19, new DateTime(2024, 6, 11, 23, 45, 30, 816, DateTimeKind.Utc).AddTicks(1304), null, "Users.Read", null },
                    { 20, new DateTime(2024, 6, 11, 23, 45, 30, 816, DateTimeKind.Utc).AddTicks(1305), null, "Users.Write", null },
                    { 21, new DateTime(2024, 6, 11, 23, 45, 30, 816, DateTimeKind.Utc).AddTicks(1305), null, "Users.Create", null },
                    { 22, new DateTime(2024, 6, 11, 23, 45, 30, 816, DateTimeKind.Utc).AddTicks(1306), null, "Users.Update", null },
                    { 23, new DateTime(2024, 6, 11, 23, 45, 30, 816, DateTimeKind.Utc).AddTicks(1307), null, "Users.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("28bf94e6-1340-40a2-b18b-be960c40c9bf"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "alperendiler1@gmail.com", "Alperen", "Diler", new byte[] { 54, 146, 130, 162, 65, 183, 249, 188, 176, 137, 127, 106, 123, 42, 45, 161, 141, 37, 180, 92, 18, 216, 100, 86, 142, 237, 250, 10, 99, 127, 115, 88, 72, 113, 108, 44, 140, 130, 26, 42, 121, 141, 221, 182, 208, 6, 70, 129, 194, 157, 10, 81, 24, 13, 71, 143, 4, 181, 4, 109, 115, 69, 110, 184 }, new byte[] { 46, 63, 170, 231, 0, 91, 92, 70, 12, 244, 93, 133, 173, 35, 23, 43, 44, 188, 19, 200, 169, 14, 27, 116, 63, 221, 150, 228, 223, 238, 37, 112, 82, 160, 24, 236, 93, 115, 173, 77, 198, 77, 190, 224, 130, 135, 118, 12, 80, 146, 11, 191, 137, 218, 184, 212, 60, 222, 251, 203, 245, 216, 234, 253, 175, 244, 57, 164, 178, 251, 192, 17, 80, 39, 110, 212, 47, 222, 103, 220, 131, 89, 140, 209, 116, 160, 238, 0, 174, 192, 59, 53, 138, 42, 173, 44, 101, 101, 135, 110, 53, 147, 234, 106, 166, 233, 180, 148, 60, 178, 207, 3, 226, 131, 37, 158, 223, 41, 118, 184, 70, 158, 64, 45, 54, 23, 61, 165 }, null, "alperen" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId", "UserId1" },
                values: new object[] { new Guid("cf7720ee-ffcf-47c5-aa6c-63b2afe35e2e"), new DateTime(2024, 6, 11, 23, 45, 30, 818, DateTimeKind.Utc).AddTicks(2472), null, 1, null, new Guid("28bf94e6-1340-40a2-b18b-be960c40c9bf"), null });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OtpAuthenticators_UserId",
                table: "OtpAuthenticators",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_UserId",
                table: "UserOperationClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_UserId1",
                table: "UserOperationClaims",
                column: "UserId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "OtpAuthenticators");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
