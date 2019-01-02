using EFCoreSeedMigrations.Context;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreSeedMigrations.Seeds
{
    public class IntitialMigrationSeed : IMigrationSeed
    {

        private object[,] _productData = new object[,]
        {
            { "56c492a6-89b6-46a7-b8b5-7e7646f154f8", "1d5703be-dba2-42d7-94f9-b882a717f9ff", "Iphone" },
            { "93fdf5e8-605a-4eff-8f53-f0b87fda6604", "6bbff65c-f374-436c-9d82-55f95014f8a4", "Samson" },
        };

        private object[,] _productGroupData = new object[,]
        {
            { "1d5703be-dba2-42d7-94f9-b882a717f9ff", "Phones" },
            { "6bbff65c-f374-436c-9d82-55f95014f8a4", "Another Staff" },
        };

        public void DownSeed(MigrationBuilder migrationBuilder)
        {
        }

        public void UpSeed(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                "ProductGroups",
                new string[] { "Id", "Name" },
               _productGroupData);


            migrationBuilder.InsertData(
                "Products",
                new string[] { "Id", "GroupId", "Name" },
                _productData);
        }
    }
}
