using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using Registration.Models;
using System.Text;

#nullable disable

namespace Registration.Data.Migrations
{
    public partial class admin : Migration
    {
        const string _adminUserGuid = "098d8cf2-76cc-4ae5-a6ae-56f020c2d39f";
        const string _adminRoleGuid = "a0664afd-e4bf-4634-8e6d-990036fd4d8b";
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            var passwordHashed = hasher.HashPassword(null, "Q123456a");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("INSERT INTO AspNetUsers(Id, UserName, NormalizedUserName, Email, EmailConfirmed, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, NormalizedEmail, PasswordHash, SecurityStamp, FirstName)");
            sb.AppendLine("VALUES(");
            sb.AppendLine($"'{_adminUserGuid}'");
            sb.AppendLine(", 'admin@admin.com'");
            sb.AppendLine(", 'ADMIN@ADMIN.COM'");
            sb.AppendLine(", 'admin@admin.com'");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 'ADMIN@ADMIN.COM'");
            sb.AppendLine($", '{passwordHashed}'");
            sb.AppendLine(", ''");
            sb.AppendLine(", 'Admin'");
            sb.AppendLine(")");

            //insert korisnika
            migrationBuilder.Sql(sb.ToString());

            //insert rola
            migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES('{_adminRoleGuid}', 'Admin', 'ADMIN')");

            //insert rola za korisnika
            migrationBuilder.Sql($"INSERT INTO AspNetUserRoles(UserId, RoleId) VALUES ('{_adminUserGuid}', '{_adminRoleGuid}')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM AspNetUserRoles WHERE UserId = '{_adminUserGuid}' AND RoleId = '{_adminRoleGuid}'");
            migrationBuilder.Sql($"DELETE FROM AspNetUsers WHERE Id='{_adminUserGuid}'");
            migrationBuilder.Sql($"DELETE FROM AspNetRoles WHERE Id='{_adminRoleGuid}'");
        }
    }
}
