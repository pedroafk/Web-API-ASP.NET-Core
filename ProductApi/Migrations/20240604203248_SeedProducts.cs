using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Products(Name, Price, Description, Stock, ImageURL, CategoryId) VALUES('Caderno', 7.55, 'Caderno Branco', 10, 'caderno.jpg',1)");

            mb.Sql("INSERT INTO Products(Name, Price, Description, Stock, ImageURL, CategoryId) VALUES('Lápis', 3.45, 'Lápis Preto', 20, 'lapis.jpg',1)");

            mb.Sql("INSERT INTO Products(Name, Price, Description, Stock, ImageURL, CategoryId) VALUES('Clips', 5.55, 'Clips Colorido', 50, 'clips.jpg',2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Products");
        }
    }
}
