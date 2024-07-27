using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityService.Migrations
{
    /// <inheritdoc />
    public partial class Add_User_Op_Log : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedById",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedById",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "UserRoles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedById",
                table: "UserRoles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedById",
                table: "UserRoles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "UserPositions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedById",
                table: "UserPositions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedById",
                table: "UserPositions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "UserPageAccesses",
                type: "uniqueidentifier",
                
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedById",
                table: "UserPageAccesses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedById",
                table: "UserPageAccesses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Roles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedById",
                table: "Roles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedById",
                table: "Roles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Positions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedById",
                table: "Positions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedById",
                table: "Positions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Divisions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedById",
                table: "Divisions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedById",
                table: "Divisions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Departments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedById",
                table: "Departments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedById",
                table: "Departments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Companies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedById",
                table: "Companies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedById",
                table: "Companies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Apps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedById",
                table: "Apps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedById",
                table: "Apps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "AppPages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedById",
                table: "AppPages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedById",
                table: "AppPages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "AppApiKeys",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedById",
                table: "AppApiKeys",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedById",
                table: "AppApiKeys",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedById",
                table: "Users",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DeletedById",
                table: "Users",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UpdatedById",
                table: "Users",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_CreatedById",
                table: "UserRoles",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_DeletedById",
                table: "UserRoles",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UpdatedById",
                table: "UserRoles",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserPositions_CreatedById",
                table: "UserPositions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserPositions_DeletedById",
                table: "UserPositions",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserPositions_UpdatedById",
                table: "UserPositions",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserPageAccesses_CreatedById",
                table: "UserPageAccesses",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserPageAccesses_DeletedById",
                table: "UserPageAccesses",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserPageAccesses_UpdatedById",
                table: "UserPageAccesses",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_CreatedById",
                table: "Roles",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_DeletedById",
                table: "Roles",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UpdatedById",
                table: "Roles",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_CreatedById",
                table: "Positions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_DeletedById",
                table: "Positions",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_UpdatedById",
                table: "Positions",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_CreatedById",
                table: "Divisions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_DeletedById",
                table: "Divisions",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_UpdatedById",
                table: "Divisions",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CreatedById",
                table: "Departments",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DeletedById",
                table: "Departments",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_UpdatedById",
                table: "Departments",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CreatedById",
                table: "Companies",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_DeletedById",
                table: "Companies",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_UpdatedById",
                table: "Companies",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_CreatedById",
                table: "Apps",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_DeletedById",
                table: "Apps",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_UpdatedById",
                table: "Apps",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AppPages_CreatedById",
                table: "AppPages",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AppPages_DeletedById",
                table: "AppPages",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_AppPages_UpdatedById",
                table: "AppPages",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AppApiKeys_CreatedById",
                table: "AppApiKeys",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AppApiKeys_DeletedById",
                table: "AppApiKeys",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_AppApiKeys_UpdatedById",
                table: "AppApiKeys",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_AppApiKeys_Users_CreatedById",
                table: "AppApiKeys",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppApiKeys_Users_DeletedById",
                table: "AppApiKeys",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppApiKeys_Users_UpdatedById",
                table: "AppApiKeys",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppPages_Users_CreatedById",
                table: "AppPages",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppPages_Users_DeletedById",
                table: "AppPages",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppPages_Users_UpdatedById",
                table: "AppPages",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Apps_Users_CreatedById",
                table: "Apps",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Apps_Users_DeletedById",
                table: "Apps",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Apps_Users_UpdatedById",
                table: "Apps",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Users_CreatedById",
                table: "Companies",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Users_DeletedById",
                table: "Companies",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Users_UpdatedById",
                table: "Companies",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Users_CreatedById",
                table: "Departments",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Users_DeletedById",
                table: "Departments",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Users_UpdatedById",
                table: "Departments",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Divisions_Users_CreatedById",
                table: "Divisions",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Divisions_Users_DeletedById",
                table: "Divisions",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Divisions_Users_UpdatedById",
                table: "Divisions",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Users_CreatedById",
                table: "Positions",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Users_DeletedById",
                table: "Positions",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Users_UpdatedById",
                table: "Positions",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_CreatedById",
                table: "Roles",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_DeletedById",
                table: "Roles",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_UpdatedById",
                table: "Roles",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPageAccesses_Users_CreatedById",
                table: "UserPageAccesses",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPageAccesses_Users_DeletedById",
                table: "UserPageAccesses",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPageAccesses_Users_UpdatedById",
                table: "UserPageAccesses",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPositions_Users_CreatedById",
                table: "UserPositions",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPositions_Users_DeletedById",
                table: "UserPositions",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPositions_Users_UpdatedById",
                table: "UserPositions",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_CreatedById",
                table: "UserRoles",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_DeletedById",
                table: "UserRoles",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UpdatedById",
                table: "UserRoles",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_CreatedById",
                table: "Users",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_DeletedById",
                table: "Users",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_UpdatedById",
                table: "Users",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppApiKeys_Users_CreatedById",
                table: "AppApiKeys");

            migrationBuilder.DropForeignKey(
                name: "FK_AppApiKeys_Users_DeletedById",
                table: "AppApiKeys");

            migrationBuilder.DropForeignKey(
                name: "FK_AppApiKeys_Users_UpdatedById",
                table: "AppApiKeys");

            migrationBuilder.DropForeignKey(
                name: "FK_AppPages_Users_CreatedById",
                table: "AppPages");

            migrationBuilder.DropForeignKey(
                name: "FK_AppPages_Users_DeletedById",
                table: "AppPages");

            migrationBuilder.DropForeignKey(
                name: "FK_AppPages_Users_UpdatedById",
                table: "AppPages");

            migrationBuilder.DropForeignKey(
                name: "FK_Apps_Users_CreatedById",
                table: "Apps");

            migrationBuilder.DropForeignKey(
                name: "FK_Apps_Users_DeletedById",
                table: "Apps");

            migrationBuilder.DropForeignKey(
                name: "FK_Apps_Users_UpdatedById",
                table: "Apps");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Users_CreatedById",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Users_DeletedById",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Users_UpdatedById",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Users_CreatedById",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Users_DeletedById",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Users_UpdatedById",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Divisions_Users_CreatedById",
                table: "Divisions");

            migrationBuilder.DropForeignKey(
                name: "FK_Divisions_Users_DeletedById",
                table: "Divisions");

            migrationBuilder.DropForeignKey(
                name: "FK_Divisions_Users_UpdatedById",
                table: "Divisions");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Users_CreatedById",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Users_DeletedById",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Users_UpdatedById",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_CreatedById",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_DeletedById",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_UpdatedById",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPageAccesses_Users_CreatedById",
                table: "UserPageAccesses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPageAccesses_Users_DeletedById",
                table: "UserPageAccesses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPageAccesses_Users_UpdatedById",
                table: "UserPageAccesses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPositions_Users_CreatedById",
                table: "UserPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPositions_Users_DeletedById",
                table: "UserPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPositions_Users_UpdatedById",
                table: "UserPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_CreatedById",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_DeletedById",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UpdatedById",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_CreatedById",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_DeletedById",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_UpdatedById",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CreatedById",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_DeletedById",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UpdatedById",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_CreatedById",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_DeletedById",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_UpdatedById",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserPositions_CreatedById",
                table: "UserPositions");

            migrationBuilder.DropIndex(
                name: "IX_UserPositions_DeletedById",
                table: "UserPositions");

            migrationBuilder.DropIndex(
                name: "IX_UserPositions_UpdatedById",
                table: "UserPositions");

            migrationBuilder.DropIndex(
                name: "IX_UserPageAccesses_CreatedById",
                table: "UserPageAccesses");

            migrationBuilder.DropIndex(
                name: "IX_UserPageAccesses_DeletedById",
                table: "UserPageAccesses");

            migrationBuilder.DropIndex(
                name: "IX_UserPageAccesses_UpdatedById",
                table: "UserPageAccesses");

            migrationBuilder.DropIndex(
                name: "IX_Roles_CreatedById",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_DeletedById",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_UpdatedById",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Positions_CreatedById",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Positions_DeletedById",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Positions_UpdatedById",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Divisions_CreatedById",
                table: "Divisions");

            migrationBuilder.DropIndex(
                name: "IX_Divisions_DeletedById",
                table: "Divisions");

            migrationBuilder.DropIndex(
                name: "IX_Divisions_UpdatedById",
                table: "Divisions");

            migrationBuilder.DropIndex(
                name: "IX_Departments_CreatedById",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_DeletedById",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_UpdatedById",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Companies_CreatedById",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_DeletedById",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_UpdatedById",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Apps_CreatedById",
                table: "Apps");

            migrationBuilder.DropIndex(
                name: "IX_Apps_DeletedById",
                table: "Apps");

            migrationBuilder.DropIndex(
                name: "IX_Apps_UpdatedById",
                table: "Apps");

            migrationBuilder.DropIndex(
                name: "IX_AppPages_CreatedById",
                table: "AppPages");

            migrationBuilder.DropIndex(
                name: "IX_AppPages_DeletedById",
                table: "AppPages");

            migrationBuilder.DropIndex(
                name: "IX_AppPages_UpdatedById",
                table: "AppPages");

            migrationBuilder.DropIndex(
                name: "IX_AppApiKeys_CreatedById",
                table: "AppApiKeys");

            migrationBuilder.DropIndex(
                name: "IX_AppApiKeys_DeletedById",
                table: "AppApiKeys");

            migrationBuilder.DropIndex(
                name: "IX_AppApiKeys_UpdatedById",
                table: "AppApiKeys");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "UserPositions");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "UserPositions");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "UserPositions");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "UserPageAccesses");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "UserPageAccesses");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "UserPageAccesses");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Divisions");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "Divisions");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Divisions");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "AppPages");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "AppPages");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "AppPages");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "AppApiKeys");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "AppApiKeys");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "AppApiKeys");
        }
    }
}
