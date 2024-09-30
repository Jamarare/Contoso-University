using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContosoUniversity.Migrations
{
    /// <inheritdoc />
    public partial class blablablabloblo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseAssingments_Course_CourseID",
                table: "CourseAssingments");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseAssingments_Instructors_InstructorID",
                table: "CourseAssingments");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficeAssignments_Instructors_InstructorID",
                table: "OfficeAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OfficeAssignments",
                table: "OfficeAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructors",
                table: "Instructors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseAssingments",
                table: "CourseAssingments");

            migrationBuilder.RenameTable(
                name: "OfficeAssignments",
                newName: "OfficeAssignment");

            migrationBuilder.RenameTable(
                name: "Instructors",
                newName: "Instructor");

            migrationBuilder.RenameTable(
                name: "CourseAssingments",
                newName: "CourseAssignment");

            migrationBuilder.RenameIndex(
                name: "IX_CourseAssingments_InstructorID",
                table: "CourseAssignment",
                newName: "IX_CourseAssignment_InstructorID");

            migrationBuilder.RenameIndex(
                name: "IX_CourseAssingments_CourseID",
                table: "CourseAssignment",
                newName: "IX_CourseAssignment_CourseID");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Course",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfficeAssignment",
                table: "OfficeAssignment",
                column: "InstructorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructor",
                table: "Instructor",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseAssignment",
                table: "CourseAssignment",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Budget = table.Column<decimal>(type: "Money", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Aadress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstructorId = table.Column<int>(type: "int", maxLength: 30, nullable: true),
                    RowVersion = table.Column<byte>(type: "tinyint", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_Department_Instructor_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructor",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Department_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_DepartmentId",
                table: "Course",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_InstructorId",
                table: "Department",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_StudentId",
                table: "Department",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Department_DepartmentId",
                table: "Course",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseAssignment_Course_CourseID",
                table: "CourseAssignment",
                column: "CourseID",
                principalTable: "Course",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseAssignment_Instructor_InstructorID",
                table: "CourseAssignment",
                column: "InstructorID",
                principalTable: "Instructor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeAssignment_Instructor_InstructorID",
                table: "OfficeAssignment",
                column: "InstructorID",
                principalTable: "Instructor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Department_DepartmentId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseAssignment_Course_CourseID",
                table: "CourseAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseAssignment_Instructor_InstructorID",
                table: "CourseAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficeAssignment_Instructor_InstructorID",
                table: "OfficeAssignment");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Course_DepartmentId",
                table: "Course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OfficeAssignment",
                table: "OfficeAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructor",
                table: "Instructor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseAssignment",
                table: "CourseAssignment");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "OfficeAssignment",
                newName: "OfficeAssignments");

            migrationBuilder.RenameTable(
                name: "Instructor",
                newName: "Instructors");

            migrationBuilder.RenameTable(
                name: "CourseAssignment",
                newName: "CourseAssingments");

            migrationBuilder.RenameIndex(
                name: "IX_CourseAssignment_InstructorID",
                table: "CourseAssingments",
                newName: "IX_CourseAssingments_InstructorID");

            migrationBuilder.RenameIndex(
                name: "IX_CourseAssignment_CourseID",
                table: "CourseAssingments",
                newName: "IX_CourseAssingments_CourseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfficeAssignments",
                table: "OfficeAssignments",
                column: "InstructorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructors",
                table: "Instructors",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseAssingments",
                table: "CourseAssingments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseAssingments_Course_CourseID",
                table: "CourseAssingments",
                column: "CourseID",
                principalTable: "Course",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseAssingments_Instructors_InstructorID",
                table: "CourseAssingments",
                column: "InstructorID",
                principalTable: "Instructors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeAssignments_Instructors_InstructorID",
                table: "OfficeAssignments",
                column: "InstructorID",
                principalTable: "Instructors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
