﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecomm_2504_thu.DataAccess.Migrations
{
    public partial class StoredPro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE CreateCoverType @name varchar(50) AS insert CoverTypes values(@name) ");
            migrationBuilder.Sql(@"CREATE PROCEDURE UpdateCoverType @id int,@name varchar(50) AS update CoverTypes set name=@name where id=@id");
            migrationBuilder.Sql(@"CREATE PROCEDURE DeleteCoverType @id int AS delete from CoverTypes where id=@id");
            migrationBuilder.Sql(@"CREATE PROCEDURE GetCoverTypes AS select * from CoverTypes");
            migrationBuilder.Sql(@"CREATE PROCEDURE GetCoverType @id int AS select * from CoverTypes where id=@id");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
