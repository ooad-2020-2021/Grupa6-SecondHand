using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace SecondHand.Migrations
{
    public partial class PrvaMigracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: false),
                    Passwrod = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentInformation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(nullable: false),
                    CardNumber = table.Column<string>(nullable: false),
                    ValidThru = table.Column<string>(nullable: false),
                    CVV = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    JoiningDate = table.Column<DateTime>(nullable: false),
                    Adress = table.Column<string>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    ProfilePicture = table.Column<string>(nullable: true),
                    CartId = table.Column<int>(nullable: true),
                    PaymentInformationId = table.Column<int>(nullable: true),
                    UserRating = table.Column<double>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_PaymentInformation_PaymentInformationId",
                        column: x => x.PaymentInformationId,
                        principalTable: "PaymentInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Color = table.Column<int>(nullable: false),
                    Material = table.Column<int>(nullable: false),
                    Condition = table.Column<int>(nullable: false),
                    Brand = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    OwnerId = table.Column<string>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    AccessoriesCategory = table.Column<int>(nullable: true),
                    ClothingSize = table.Column<int>(nullable: true),
                    ClothingCategory = table.Column<int>(nullable: true),
                    ShoeSize = table.Column<int>(nullable: true),
                    ShoesCategory = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Product_User_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Rating = table.Column<int>(nullable: false),
                    OwnerId = table.Column<string>(nullable: false),
                    ReviewedUserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Review_User_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_User_ReviewedUserId",
                        column: x => x.ReviewedUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProductID = table.Column<int>(nullable: false),
                    BuyerId = table.Column<string>(nullable: false),
                    SelerId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Transactions_User_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_User_SelerId",
                        column: x => x.SelerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_OwnerId",
                table: "Product",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_OwnerId",
                table: "Review",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ReviewedUserId",
                table: "Review",
                column: "ReviewedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BuyerId",
                table: "Transactions",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ProductID",
                table: "Transactions",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SelerId",
                table: "Transactions",
                column: "SelerId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CartId",
                table: "User",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_User_PaymentInformationId",
                table: "User",
                column: "PaymentInformationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "PaymentInformation");
        }
    }
}
