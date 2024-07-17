using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StaffPortal.Server.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Genders_GenderId",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Qualifications_QualificationId",
                table: "Staff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Qualifications",
                table: "Qualifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genders",
                table: "Genders");

            migrationBuilder.RenameTable(
                name: "Qualifications",
                newName: "Qualification");

            migrationBuilder.RenameTable(
                name: "Genders",
                newName: "Gender");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Qualification",
                table: "Qualification",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gender",
                table: "Gender",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" }
                });

            migrationBuilder.InsertData(
                table: "Qualification",
                columns: new[] { "Id", "Description", "Level" },
                values: new object[,]
                {
                    { 1, "Diploma", 5 },
                    { 2, "Degree", 6 },
                    { 3, "Post Graduate", 7 },
                    { 4, "Master’s Degree", 8 }
                });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "Id", "DateOfBirth", "EmployeeNumber", "FirstName", "GenderId", "LastName", "QualificationId", "Salary", "YearsOfWorkExperience" },
                values: new object[] { 1, new DateTime(1985, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "EMP001", "John", 1, "Doe", 2, 0m, 5 });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "Id", "DateOfBirth", "EmployeeNumber", "FirstName", "GenderId", "LastName", "QualificationId", "Salary", "YearsOfWorkExperience" },
                values: new object[] { 2, new DateTime(1990, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "EMP002", "Jane", 2, "Smith", 3, 0m, 3 });

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Gender_GenderId",
                table: "Staff",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Qualification_QualificationId",
                table: "Staff",
                column: "QualificationId",
                principalTable: "Qualification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Gender_GenderId",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Qualification_QualificationId",
                table: "Staff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Qualification",
                table: "Qualification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gender",
                table: "Gender");

            migrationBuilder.DeleteData(
                table: "Qualification",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Qualification",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Gender",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Gender",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Qualification",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Qualification",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "Qualification",
                newName: "Qualifications");

            migrationBuilder.RenameTable(
                name: "Gender",
                newName: "Genders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Qualifications",
                table: "Qualifications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genders",
                table: "Genders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Genders_GenderId",
                table: "Staff",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Qualifications_QualificationId",
                table: "Staff",
                column: "QualificationId",
                principalTable: "Qualifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
