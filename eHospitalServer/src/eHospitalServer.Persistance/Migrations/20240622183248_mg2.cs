using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eHospitalServer.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mg2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UpdatedUserId",
                table: "Users",
                newName: "UpdatedUser");

            migrationBuilder.RenameColumn(
                name: "DeletedUserId",
                table: "Users",
                newName: "DeletedUser");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUser",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedUser",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedUser",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUser",
                table: "VehicleMissions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedUser",
                table: "VehicleMissions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedUser",
                table: "VehicleMissions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUser",
                table: "VehicleActions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedUser",
                table: "VehicleActions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedUser",
                table: "VehicleActions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUser",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUser",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedUser",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedUser",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUser",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedUser",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedUser",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUser",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedUser",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedUser",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUser",
                table: "RoomActions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedUser",
                table: "RoomActions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedUser",
                table: "RoomActions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUser",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedUser",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedUser",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUser",
                table: "Nurses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedUser",
                table: "Nurses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedUser",
                table: "Nurses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUser",
                table: "Faqs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedUser",
                table: "Faqs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedUser",
                table: "Faqs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUser",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedUser",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedUser",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUser",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedUser",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedUser",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUser",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedUser",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedUser",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUser",
                table: "Announcements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedUser",
                table: "Announcements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedUser",
                table: "Announcements",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedUser",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "DeletedUser",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "UpdatedUser",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "CreatedUser",
                table: "VehicleMissions");

            migrationBuilder.DropColumn(
                name: "DeletedUser",
                table: "VehicleMissions");

            migrationBuilder.DropColumn(
                name: "UpdatedUser",
                table: "VehicleMissions");

            migrationBuilder.DropColumn(
                name: "CreatedUser",
                table: "VehicleActions");

            migrationBuilder.DropColumn(
                name: "DeletedUser",
                table: "VehicleActions");

            migrationBuilder.DropColumn(
                name: "UpdatedUser",
                table: "VehicleActions");

            migrationBuilder.DropColumn(
                name: "CreatedUser",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedUser",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "DeletedUser",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "UpdatedUser",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "CreatedUser",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "DeletedUser",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "UpdatedUser",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "CreatedUser",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "DeletedUser",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "UpdatedUser",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CreatedUser",
                table: "RoomActions");

            migrationBuilder.DropColumn(
                name: "DeletedUser",
                table: "RoomActions");

            migrationBuilder.DropColumn(
                name: "UpdatedUser",
                table: "RoomActions");

            migrationBuilder.DropColumn(
                name: "CreatedUser",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DeletedUser",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "UpdatedUser",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "CreatedUser",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "DeletedUser",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "UpdatedUser",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "CreatedUser",
                table: "Faqs");

            migrationBuilder.DropColumn(
                name: "DeletedUser",
                table: "Faqs");

            migrationBuilder.DropColumn(
                name: "UpdatedUser",
                table: "Faqs");

            migrationBuilder.DropColumn(
                name: "CreatedUser",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DeletedUser",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UpdatedUser",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CreatedUser",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "DeletedUser",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "UpdatedUser",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "CreatedUser",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DeletedUser",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "UpdatedUser",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "CreatedUser",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "DeletedUser",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "UpdatedUser",
                table: "Announcements");

            migrationBuilder.RenameColumn(
                name: "UpdatedUser",
                table: "Users",
                newName: "UpdatedUserId");

            migrationBuilder.RenameColumn(
                name: "DeletedUser",
                table: "Users",
                newName: "DeletedUserId");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserId",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
