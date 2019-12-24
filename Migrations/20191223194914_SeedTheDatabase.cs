using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetAngularApp.Migrations
{
    public partial class SeedTheDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Makes1')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Makes2')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Makes3')");

            migrationBuilder.Sql("INSERT INTO Model (Name, MakeId) VALUES ('ModelA-Makes1', (SELECT Id from Makes WHERE Name='Makes1'))");
            migrationBuilder.Sql("INSERT INTO Model (Name, MakeId) VALUES ('ModelB-Makes1', (SELECT Id from Makes WHERE Name='Makes1'))");
            migrationBuilder.Sql("INSERT INTO Model (Name, MakeId) VALUES ('ModelC-Makes1', (SELECT Id from Makes WHERE Name='Makes1'))");

            migrationBuilder.Sql("INSERT INTO Model (Name, MakeId) VALUES ('ModelA-Makes2', (SELECT Id from Makes WHERE Name='Makes2'))");
            migrationBuilder.Sql("INSERT INTO Model (Name, MakeId) VALUES ('ModelB-Makes2', (SELECT Id from Makes WHERE Name='Makes2'))");
            migrationBuilder.Sql("INSERT INTO Model (Name, MakeId) VALUES ('ModelC-Makes2', (SELECT Id from Makes WHERE Name='Makes2'))");

            migrationBuilder.Sql("INSERT INTO Model (Name, MakeId) VALUES ('ModelA-Makes3', (SELECT Id from Makes WHERE Name='Makes3'))");
            migrationBuilder.Sql("INSERT INTO Model (Name, MakeId) VALUES ('ModelB-Makes3', (SELECT Id from Makes WHERE Name='Makes3'))");
            migrationBuilder.Sql("INSERT INTO Model (Name, MakeId) VALUES ('ModelC-Makes3', (SELECT Id from Makes WHERE Name='Makes3'))");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("DELETE FROM Makes WHERE Name IN ('Makes1','Makes2,'Makes3')");

        }
    }
}
