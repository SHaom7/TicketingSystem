using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketingSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            string AdminRoleGuid = Guid.NewGuid().ToString();

            migrationBuilder.InsertData(
               table: "AspNetRoles",
               columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
               values: new object[] { AdminRoleGuid, "Support Manager", "Support Manager".ToUpper(), Guid.NewGuid().ToString() }
               );

            migrationBuilder.InsertData(
               table: "AspNetRoles",
               columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
               values: new object[] { Guid.NewGuid().ToString(), "Support Team Member", "Support Team Member".ToUpper(), Guid.NewGuid().ToString() }
               );

            migrationBuilder.InsertData(
               table: "AspNetRoles",
               columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
               values: new object[] { Guid.NewGuid().ToString(), "Client", "Client".ToUpper(), Guid.NewGuid().ToString() }
               );


            string AdminGuid = Guid.NewGuid().ToString();

            migrationBuilder.InsertData(
              table: "AspNetUsers",
              columns: new[] { "Id", "FullName", "LastName", "Address", "UserImage", "EmailConfirmed", "DateOfBirth", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnabled", "AccessFailedCount" },
              values: new object[] { AdminGuid, "Admin", "Admin".ToUpper(), "T2", "Test", true, DateOnly.FromDateTime(DateTime.Now), true, false, false, 0 }
              );

            migrationBuilder.InsertData(
              table: "AspNetUserRoles",
              columns: new[] { "UserId", "RoleId" },
              values: new object[] { AdminGuid, AdminRoleGuid }
              );



        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [AspNetUserRoles]");
            migrationBuilder.Sql("DELETE FROM [AspNetRoles]");

        }
    }
}
