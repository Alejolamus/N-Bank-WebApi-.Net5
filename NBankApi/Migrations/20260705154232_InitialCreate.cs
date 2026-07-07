using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBankApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Aliados",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    partners_code = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    partner_type = table.Column<int>(type: "int", nullable: false),
                    nit = table.Column<int>(type: "int", nullable: false),
                    location = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    collection_commission = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    hashApiPass = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    aliadoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aliados", x => x.id);
                    table.ForeignKey(
                        name: "FK_Aliados_Aliados_aliadoid",
                        column: x => x.aliadoid,
                        principalTable: "Aliados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Divisas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    iso_alpha_2 = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    iso_alpha_3 = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    country = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    currency_code = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    currency_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    symbol = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisas", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EstadosFinancieros",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idInvoice = table.Column<int>(type: "int", nullable: false),
                    seguro = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    cuota = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    mora = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosFinancieros", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Miembros",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    hassPass = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    rol = table.Column<int>(type: "int", nullable: false),
                    typeDoc = table.Column<int>(type: "int", nullable: false),
                    documentNum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miembros", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    department = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    municipality = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_location = table.Column<int>(type: "int", nullable: false),
                    document_type = table.Column<int>(type: "int", nullable: false),
                    document = table.Column<int>(type: "int", nullable: false),
                    password_hash = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cellphone = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MunicipalityColid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Clientes_Municipios_MunicipalityColid",
                        column: x => x.MunicipalityColid,
                        principalTable: "Municipios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PerfilesMonetarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    income_range_label = table.Column<int>(type: "int", nullable: false),
                    min_income = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    max_income = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    expense = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    id_client = table.Column<int>(type: "int", nullable: false),
                    id_credit = table.Column<int>(type: "int", nullable: false),
                    id_money = table.Column<int>(type: "int", nullable: false),
                    Clientsid = table.Column<int>(type: "int", nullable: true),
                    Currencysid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilesMonetarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_PerfilesMonetarios_Clientes_Clientsid",
                        column: x => x.Clientsid,
                        principalTable: "Clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PerfilesMonetarios_Divisas_Currencysid",
                        column: x => x.Currencysid,
                        principalTable: "Divisas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Creditos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    star_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    payment_frequency = table.Column<int>(type: "int", nullable: false),
                    installment_count = table.Column<int>(type: "int", nullable: false),
                    next_cutoff_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    state = table.Column<int>(type: "int", nullable: false),
                    value = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    outstanding_balance = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    overdue_balance = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    past_due_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    id_currency = table.Column<int>(type: "int", nullable: false),
                    acceptConditions = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    insurancePremium = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    installamentAmount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PaidInstallament = table.Column<int>(type: "int", nullable: false),
                    perfilid = table.Column<int>(type: "int", nullable: true),
                    Clientsid = table.Column<int>(type: "int", nullable: true),
                    Currencysid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creditos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Creditos_Clientes_Clientsid",
                        column: x => x.Clientsid,
                        principalTable: "Clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Creditos_Divisas_Currencysid",
                        column: x => x.Currencysid,
                        principalTable: "Divisas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Creditos_PerfilesMonetarios_perfilid",
                        column: x => x.perfilid,
                        principalTable: "PerfilesMonetarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    invoice_number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_credit = table.Column<int>(type: "int", nullable: false),
                    current_balance = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    on_time_payment = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    estadoDeRecudoid = table.Column<int>(type: "int", nullable: true),
                    Creditsid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Facturas_Creditos_Creditsid",
                        column: x => x.Creditsid,
                        principalTable: "Creditos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Facturas_EstadosFinancieros_estadoDeRecudoid",
                        column: x => x.estadoDeRecudoid,
                        principalTable: "EstadosFinancieros",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Recaudos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idInvoice = table.Column<int>(type: "int", nullable: false),
                    collection = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    paymentDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    paymentType = table.Column<int>(type: "int", nullable: false),
                    idPartner = table.Column<int>(type: "int", nullable: false),
                    AuthorizationCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Creditsid = table.Column<int>(type: "int", nullable: true),
                    Currencysid = table.Column<int>(type: "int", nullable: true),
                    Invoiceid = table.Column<int>(type: "int", nullable: true),
                    Partnersid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recaudos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Recaudos_Aliados_Partnersid",
                        column: x => x.Partnersid,
                        principalTable: "Aliados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recaudos_Creditos_Creditsid",
                        column: x => x.Creditsid,
                        principalTable: "Creditos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recaudos_Divisas_Currencysid",
                        column: x => x.Currencysid,
                        principalTable: "Divisas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recaudos_Facturas_Invoiceid",
                        column: x => x.Invoiceid,
                        principalTable: "Facturas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Aliados_aliadoid",
                table: "Aliados",
                column: "aliadoid");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_MunicipalityColid",
                table: "Clientes",
                column: "MunicipalityColid");

            migrationBuilder.CreateIndex(
                name: "IX_Creditos_Clientsid",
                table: "Creditos",
                column: "Clientsid");

            migrationBuilder.CreateIndex(
                name: "IX_Creditos_Currencysid",
                table: "Creditos",
                column: "Currencysid");

            migrationBuilder.CreateIndex(
                name: "IX_Creditos_perfilid",
                table: "Creditos",
                column: "perfilid");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_Creditsid",
                table: "Facturas",
                column: "Creditsid");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_estadoDeRecudoid",
                table: "Facturas",
                column: "estadoDeRecudoid");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilesMonetarios_Clientsid",
                table: "PerfilesMonetarios",
                column: "Clientsid");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilesMonetarios_Currencysid",
                table: "PerfilesMonetarios",
                column: "Currencysid");

            migrationBuilder.CreateIndex(
                name: "IX_Recaudos_Creditsid",
                table: "Recaudos",
                column: "Creditsid");

            migrationBuilder.CreateIndex(
                name: "IX_Recaudos_Currencysid",
                table: "Recaudos",
                column: "Currencysid");

            migrationBuilder.CreateIndex(
                name: "IX_Recaudos_Invoiceid",
                table: "Recaudos",
                column: "Invoiceid");

            migrationBuilder.CreateIndex(
                name: "IX_Recaudos_Partnersid",
                table: "Recaudos",
                column: "Partnersid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Miembros");

            migrationBuilder.DropTable(
                name: "Recaudos");

            migrationBuilder.DropTable(
                name: "Aliados");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Creditos");

            migrationBuilder.DropTable(
                name: "EstadosFinancieros");

            migrationBuilder.DropTable(
                name: "PerfilesMonetarios");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Divisas");

            migrationBuilder.DropTable(
                name: "Municipios");
        }
    }
}
