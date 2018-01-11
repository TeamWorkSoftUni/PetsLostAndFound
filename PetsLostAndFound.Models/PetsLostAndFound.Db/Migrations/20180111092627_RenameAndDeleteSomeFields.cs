using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PetsLostAndFound.Db.Migrations
{
    public partial class RenameAndDeleteSomeFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageLinks",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "Town",
                table: "Locations",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "TownName",
                table: "AspNetUsers",
                newName: "Images");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "AspNetUsers",
                newName: "Address");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Locations",
                newName: "Town");

            migrationBuilder.RenameColumn(
                name: "Images",
                table: "AspNetUsers",
                newName: "TownName");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "AspNetUsers",
                newName: "Image");

            migrationBuilder.AddColumn<string>(
                name: "ImageLinks",
                table: "Pets",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "Pets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
