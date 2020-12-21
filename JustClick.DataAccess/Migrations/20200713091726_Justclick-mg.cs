using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JustClick.DataAccess.Migrations
{
    public partial class Justclickmg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    EXT = table.Column<string>(nullable: true),
                    TITLE_THAI = table.Column<string>(nullable: true),
                    FNAME_THAI = table.Column<string>(nullable: true),
                    LNAME_THAI = table.Column<string>(nullable: true),
                    ACCESSSTATUS = table.Column<bool>(nullable: false),
                    TSR_PICTURE = table.Column<string>(nullable: true),
                    LICENSE = table.Column<string>(nullable: true),
                    TEAMLEADER_ID = table.Column<string>(nullable: true),
                    PROJECT_CODE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataProtectionKeys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FriendlyName = table.Column<string>(nullable: true),
                    Xml = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataProtectionKeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_BANK",
                columns: table => new
                {
                    URN = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PROJECT_CODE = table.Column<string>(maxLength: 10, nullable: false),
                    BANKNAME = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_BANK", x => x.URN);
                });

            migrationBuilder.CreateTable(
                name: "TBL_CALLBACK",
                columns: table => new
                {
                    CALLBACKCODE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PROJECT_CODE = table.Column<string>(maxLength: 10, nullable: false),
                    CALLBACKREASON = table.Column<string>(maxLength: 50, nullable: false),
                    NEEDTERMINATE = table.Column<string>(maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_CALLBACK", x => x.CALLBACKCODE);
                });

            migrationBuilder.CreateTable(
                name: "TBL_CARDTYPE",
                columns: table => new
                {
                    CARDCODE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PROJECT_CODE = table.Column<string>(maxLength: 10, nullable: false),
                    CARDTYPE = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_CARDTYPE", x => x.CARDCODE);
                });

            migrationBuilder.CreateTable(
                name: "TBL_FAIL",
                columns: table => new
                {
                    FAILCODE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PROJECT_CODE = table.Column<string>(maxLength: 10, nullable: false),
                    FAILREASON = table.Column<string>(maxLength: 50, nullable: false),
                    NEEDTERMINATE = table.Column<string>(maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_FAIL", x => x.FAILCODE);
                });

            migrationBuilder.CreateTable(
                name: "TBL_IDCARD",
                columns: table => new
                {
                    IDCARD_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PROJECT_CODE = table.Column<string>(maxLength: 10, nullable: false),
                    IDCARD_NAME = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_IDCARD", x => x.IDCARD_ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_INTRANET",
                columns: table => new
                {
                    INTRANET_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PROJECT_CODE = table.Column<string>(maxLength: 10, nullable: false),
                    INTRANET_HEADER = table.Column<string>(maxLength: 100, nullable: false),
                    INTRANET_URL = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_INTRANET", x => x.INTRANET_ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_NONTARGET",
                columns: table => new
                {
                    NONTARGETCODE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PROJECT_CODE = table.Column<string>(maxLength: 10, nullable: false),
                    NONTARGETREASON = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_NONTARGET", x => x.NONTARGETCODE);
                });

            migrationBuilder.CreateTable(
                name: "TBL_PROJECT_CONFIG",
                columns: table => new
                {
                    URN = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PROJECT_CODE = table.Column<string>(maxLength: 10, nullable: false),
                    PROJECT_NAME = table.Column<string>(nullable: false),
                    OWNER = table.Column<string>(nullable: false),
                    SCRIPT_1 = table.Column<string>(nullable: true),
                    SCRIPT_2 = table.Column<string>(nullable: true),
                    SCRIPT_3 = table.Column<string>(nullable: true),
                    SCRIPT_4 = table.Column<string>(nullable: true),
                    SCRIPT_5 = table.Column<string>(nullable: true),
                    SCRIPT_6 = table.Column<string>(nullable: true),
                    SCRIPT_7 = table.Column<string>(nullable: true),
                    SCRIPT_8 = table.Column<string>(nullable: true),
                    SCRIPT_9 = table.Column<string>(nullable: true),
                    SCRIPT_10 = table.Column<string>(nullable: true),
                    WARNINGCALL = table.Column<int>(nullable: false),
                    MAXCALL = table.Column<int>(nullable: false),
                    MAXCALLBACK = table.Column<int>(nullable: false),
                    ENDOFPROJECT = table.Column<DateTime>(nullable: false),
                    PATHREPORT = table.Column<string>(maxLength: 200, nullable: false),
                    MAXNOCONTACT = table.Column<int>(nullable: false),
                    PBXIP = table.Column<string>(maxLength: 40, nullable: false),
                    SP_STATUS = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PROJECT_CONFIG", x => x.URN);
                });

            migrationBuilder.CreateTable(
                name: "TBL_REFUSE",
                columns: table => new
                {
                    REFUSECODE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PROJECT_CODE = table.Column<string>(maxLength: 10, nullable: false),
                    REFUSEREASON = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_REFUSE", x => x.REFUSECODE);
                });

            migrationBuilder.CreateTable(
                name: "TBL_SCRIPT",
                columns: table => new
                {
                    SCRIPTID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PROJECT_CODE = table.Column<string>(maxLength: 10, nullable: false),
                    SCRIPTHEADER = table.Column<string>(maxLength: 100, nullable: false),
                    SCRIPTDESC = table.Column<string>(maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_SCRIPT", x => x.SCRIPTID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_SUCCESS",
                columns: table => new
                {
                    SUCCESSCODE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PROJECT_CODE = table.Column<string>(maxLength: 10, nullable: false),
                    SUCCESSREASON = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_SUCCESS", x => x.SUCCESSCODE);
                });

            migrationBuilder.CreateTable(
                name: "TBL_TITLE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TITLE_THAI = table.Column<string>(nullable: true),
                    TITLE_ENG = table.Column<string>(nullable: true),
                    SEQ = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_TITLE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DataProtectionKeys");

            migrationBuilder.DropTable(
                name: "TBL_BANK");

            migrationBuilder.DropTable(
                name: "TBL_CALLBACK");

            migrationBuilder.DropTable(
                name: "TBL_CARDTYPE");

            migrationBuilder.DropTable(
                name: "TBL_FAIL");

            migrationBuilder.DropTable(
                name: "TBL_IDCARD");

            migrationBuilder.DropTable(
                name: "TBL_INTRANET");

            migrationBuilder.DropTable(
                name: "TBL_NONTARGET");

            migrationBuilder.DropTable(
                name: "TBL_PROJECT_CONFIG");

            migrationBuilder.DropTable(
                name: "TBL_REFUSE");

            migrationBuilder.DropTable(
                name: "TBL_SCRIPT");

            migrationBuilder.DropTable(
                name: "TBL_SUCCESS");

            migrationBuilder.DropTable(
                name: "TBL_TITLE");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
