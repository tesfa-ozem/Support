using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Support.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgentLogins",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(maxLength: 50, nullable: true),
                    Valid = table.Column<bool>(nullable: true),
                    LoginDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentLogins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    SUBCOUNTY = table.Column<string>(nullable: true),
                    WARD = table.Column<string>(nullable: true),
                    VILLAGE = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    TerminalId = table.Column<string>(maxLength: 450, nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    IdNumber = table.Column<string>(maxLength: 450, nullable: true),
                    DateRegistered = table.Column<DateTime>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    SUBCOUNTY = table.Column<string>(nullable: true),
                    WARD = table.Column<string>(nullable: true),
                    VILLAGE = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    TerminalId = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    IdNumber = table.Column<string>(nullable: true),
                    DateRegistered = table.Column<DateTime>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BulkPayments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    IdentificationNo = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BulkPayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientProfile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientName = table.Column<string>(maxLength: 50, nullable: false),
                    ClientCode = table.Column<string>(maxLength: 7, nullable: false),
                    Business = table.Column<string>(maxLength: 50, nullable: true),
                    Mediaurl = table.Column<string>(maxLength: 80, nullable: true),
                    Country = table.Column<string>(maxLength: 50, nullable: true),
                    Currency = table.Column<string>(maxLength: 10, nullable: true),
                    DefaultCode = table.Column<string>(maxLength: 50, nullable: true),
                    Language = table.Column<string>(maxLength: 50, nullable: true),
                    Datecreated = table.Column<DateTime>(type: "date", nullable: true),
                    DateModified = table.Column<DateTime>(type: "date", nullable: true),
                    Isactive = table.Column<bool>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    ModifiedUserId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    Comments = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientProfile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientSetup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientCode = table.Column<string>(maxLength: 7, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    MinContribution = table.Column<decimal>(nullable: false),
                    MaxContribution = table.Column<decimal>(nullable: false),
                    ActivationAmount = table.Column<decimal>(nullable: false),
                    TotalSubscriptionAmount = table.Column<decimal>(nullable: false),
                    CardReplacementFee = table.Column<decimal>(nullable: false),
                    NotifyViaSMS = table.Column<bool>(nullable: false),
                    NotificationOnActivation = table.Column<bool>(nullable: false),
                    NotificationOnPayment = table.Column<bool>(nullable: false),
                    NotificationOnVisit = table.Column<bool>(nullable: false),
                    NotificationOnDischarge = table.Column<bool>(nullable: false),
                    PaymentPlansInstallments = table.Column<int>(nullable: false),
                    SpecialistsCovered = table.Column<bool>(nullable: false),
                    NotificationOnCardReady = table.Column<bool>(nullable: false),
                    NotificationOnCardCollected = table.Column<bool>(nullable: false),
                    FingerPrintAuthentification = table.Column<bool>(nullable: false),
                    AgentCanReceiveCash = table.Column<bool>(nullable: false),
                    AgeException = table.Column<int>(nullable: false),
                    MaximumNoofDependents = table.Column<int>(nullable: false),
                    FacialAuthentification = table.Column<bool>(nullable: false),
                    OpticalAuthentification = table.Column<bool>(nullable: false),
                    VoiceAuthentification = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientSetup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "constituencies",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OBJECTID = table.Column<long>(nullable: true),
                    COUNTY_NAM = table.Column<string>(maxLength: 255, nullable: true),
                    CONST_CODE = table.Column<double>(nullable: true),
                    CONSTITUEN = table.Column<string>(maxLength: 255, nullable: true),
                    COUNTY_ASS = table.Column<double>(nullable: true),
                    COUNTY_A_1 = table.Column<string>(maxLength: 255, nullable: true),
                    REGIST_CEN = table.Column<double>(nullable: true),
                    REGISTRATI = table.Column<string>(maxLength: 255, nullable: true),
                    COUNTY_COD = table.Column<double>(nullable: true),
                    Shape_Leng = table.Column<double>(nullable: true),
                    Shape_Area = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_constituencies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "counties",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OBJECTID = table.Column<long>(nullable: true),
                    ID_ = table.Column<long>(nullable: true),
                    COUNTY_NAM = table.Column<string>(maxLength: 255, nullable: true),
                    CONST_CODE = table.Column<long>(nullable: true),
                    CONSTITUEN = table.Column<string>(maxLength: 255, nullable: true),
                    COUNTY_COD = table.Column<long>(nullable: true),
                    Shape_Leng = table.Column<double>(nullable: true),
                    Shape_Area = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_counties", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DepositRequests",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ResultCode = table.Column<int>(nullable: false),
                    CheckoutRequestId = table.Column<string>(nullable: true),
                    ResultDesc = table.Column<string>(nullable: true),
                    MerchantRequestId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deposits",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Balance = table.Column<double>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    DocumentNo = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    AccountNo = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    ResultCode = table.Column<int>(nullable: false),
                    CheckoutRequestId = table.Column<string>(nullable: true),
                    ResultDesc = table.Column<string>(nullable: true),
                    MerchantRequestId = table.Column<string>(nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SentToJournal = table.Column<bool>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    TransactionStatus = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime", nullable: false),
                    ReceiptNo = table.Column<string>(nullable: true),
                    TerminalId = table.Column<string>(nullable: true),
                    Zone = table.Column<string>(nullable: true),
                    CountyName = table.Column<string>(nullable: true),
                    Span = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Facility",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FacilityName = table.Column<string>(maxLength: 50, nullable: true),
                    FacilityAddress = table.Column<string>(maxLength: 50, nullable: true),
                    KEPHLevel = table.Column<int>(nullable: true),
                    FacilityCategory = table.Column<int>(nullable: true),
                    OperationStatus = table.Column<int>(nullable: true),
                    HasBeds = table.Column<bool>(nullable: true),
                    Open24hrs = table.Column<bool>(nullable: true),
                    OpenWeekends = table.Column<bool>(nullable: true),
                    OpenPublicholidays = table.Column<bool>(nullable: true),
                    FacilityOwnerCategory = table.Column<int>(nullable: true),
                    FacilityOwner = table.Column<string>(maxLength: 50, nullable: true),
                    FacilityLongitude = table.Column<string>(maxLength: 50, nullable: true),
                    FacilityLatitude = table.Column<string>(maxLength: 50, nullable: true),
                    WardId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facility", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacilityKEPHLevel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KEPHLevel = table.Column<string>(maxLength: 50, nullable: false),
                    KEPHLevelName = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityKEPHLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageData",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    PhotoImage = table.Column<string>(nullable: true),
                    Signature = table.Column<string>(nullable: true),
                    LeftThumbprint = table.Column<string>(nullable: true),
                    RightThumbprint = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "kituiSubcounties",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID_0 = table.Column<double>(nullable: true),
                    ISO = table.Column<string>(maxLength: 255, nullable: true),
                    NAME_0 = table.Column<string>(maxLength: 255, nullable: true),
                    ID_1 = table.Column<double>(nullable: true),
                    NAME_1 = table.Column<string>(maxLength: 255, nullable: true),
                    ID_2 = table.Column<double>(nullable: true),
                    NAME_2 = table.Column<string>(maxLength: 255, nullable: true),
                    HASC_2 = table.Column<string>(maxLength: 255, nullable: true),
                    CCN_2 = table.Column<double>(nullable: true),
                    CCA_2 = table.Column<string>(maxLength: 255, nullable: true),
                    TYPE_2 = table.Column<string>(maxLength: 255, nullable: true),
                    ENGTYPE_2 = table.Column<string>(maxLength: 255, nullable: true),
                    NL_NAME_2 = table.Column<string>(maxLength: 255, nullable: true),
                    VARNAME_2 = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kituiSubcounties", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MemberLedgerEntries",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberId = table.Column<long>(nullable: false),
                    PostingDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    TransactionTypeId = table.Column<long>(nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime", nullable: false),
                    PaymentEndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ExternalDocumentNo = table.Column<string>(nullable: true),
                    DocumentNo = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberLedgerEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PaymentMode = table.Column<string>(maxLength: 50, nullable: true),
                    PaymentType = table.Column<string>(maxLength: 50, nullable: true),
                    MemberNo = table.Column<string>(maxLength: 50, nullable: true),
                    PhoneNo = table.Column<string>(maxLength: 50, nullable: true),
                    AccountNo = table.Column<string>(maxLength: 50, nullable: true),
                    CardNo = table.Column<string>(maxLength: 50, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    Status = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    DocumentNo = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 100, nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    PaymentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    IdentificationType = table.Column<string>(maxLength: 50, nullable: true),
                    IdentificationNo = table.Column<string>(maxLength: 50, nullable: true),
                    MemberType = table.Column<string>(maxLength: 50, nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 100, nullable: true),
                    PhysicalAddress = table.Column<string>(maxLength: 150, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 50, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime", nullable: false),
                    Signature = table.Column<string>(nullable: true),
                    LeftThumb = table.Column<string>(nullable: true),
                    RightThumb = table.Column<string>(nullable: true),
                    PhotoImage = table.Column<string>(nullable: true),
                    TerminalId = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime", nullable: false),
                    MemberNo = table.Column<string>(maxLength: 30, nullable: true),
                    Height = table.Column<double>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    MaritalStatus = table.Column<string>(maxLength: 50, nullable: true),
                    NhifNo = table.Column<double>(nullable: false),
                    Occupation = table.Column<string>(maxLength: 60, nullable: true),
                    PinNo = table.Column<string>(maxLength: 50, nullable: true),
                    CardUID = table.Column<string>(maxLength: 150, nullable: true),
                    WardId = table.Column<long>(nullable: true),
                    CardPrinted = table.Column<bool>(nullable: true),
                    CardPrintDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OldMemberNo = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RemmittancePlans",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime", nullable: false),
                    CorporateId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemmittancePlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TheCounties",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ContactEmail = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheCounties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    SUBCOUNTY = table.Column<string>(nullable: true),
                    WARD = table.Column<string>(nullable: true),
                    VILLAGE = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    TerminalId = table.Column<string>(maxLength: 450, nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    IdNumber = table.Column<string>(maxLength: 450, nullable: true),
                    DateRegistered = table.Column<DateTime>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wards",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CONST_CODE = table.Column<long>(nullable: true),
                    Shape_Area = table.Column<double>(nullable: true),
                    OBJECTID_1 = table.Column<long>(nullable: true),
                    NAME = table.Column<string>(maxLength: 255, nullable: true),
                    OBJECTID = table.Column<long>(nullable: true),
                    CONSTITUEN = table.Column<string>(maxLength: 255, nullable: true),
                    COUNTY_ASS = table.Column<long>(nullable: true),
                    SPOILT = table.Column<long>(nullable: true),
                    COUNTY_A_1 = table.Column<string>(maxLength: 255, nullable: true),
                    REJECTED = table.Column<long>(nullable: true),
                    REPORTED = table.Column<long>(nullable: true),
                    SPOILT_VAL = table.Column<double>(nullable: true),
                    VALID = table.Column<long>(nullable: true),
                    DISPUTED = table.Column<long>(nullable: true),
                    RESULT = table.Column<string>(maxLength: 255, nullable: true),
                    COUNTY_COD = table.Column<long>(nullable: true),
                    Shape_Leng = table.Column<double>(nullable: true),
                    COUNTY_NAM = table.Column<string>(maxLength: 255, nullable: true),
                    Shape_Le_1 = table.Column<double>(nullable: true),
                    REGISTERED = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wards", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Principals",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    NationalId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Principals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.Principals_dbo.People_Id",
                        column: x => x.Id,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RemmittanceMatrices",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlanId = table.Column<long>(nullable: false),
                    DestinationCorporateId = table.Column<long>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemmittanceMatrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.RemmittanceMatrices_dbo.RemmittancePlans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "RemmittancePlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountyOfficers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    NationalId = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    WardId = table.Column<long>(nullable: true),
                    CountyId = table.Column<long>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountyOfficers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.CountyOfficers_dbo.TheCounties_CountyId",
                        column: x => x.CountyId,
                        principalTable: "TheCounties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TheSubCounties",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ContactEmail = table.Column<string>(nullable: true),
                    CountyId = table.Column<long>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheSubCounties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.TheSubCounties_dbo.TheCounties_CountyId",
                        column: x => x.CountyId,
                        principalTable: "TheCounties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dependants",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    BirthCertificateNo = table.Column<string>(nullable: true),
                    PrincipalId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.Dependants_dbo.People_Id",
                        column: x => x.Id,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbo.Dependants_dbo.Principals_PrincipalId",
                        column: x => x.PrincipalId,
                        principalTable: "Principals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Spouses",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    NationalId = table.Column<string>(nullable: true),
                    PrincipalId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.Spouses_dbo.People_Id",
                        column: x => x.Id,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbo.Spouses_dbo.Principals_PrincipalId",
                        column: x => x.PrincipalId,
                        principalTable: "Principals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TheWards",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ContactEmail = table.Column<string>(nullable: true),
                    SubCountyId = table.Column<long>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheWards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.TheWards_dbo.TheSubCounties_SubCountyId",
                        column: x => x.SubCountyId,
                        principalTable: "TheSubCounties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountyOfficers_CountyId",
                table: "CountyOfficers",
                column: "CountyId");

            migrationBuilder.CreateIndex(
                name: "IX_Dependants_PrincipalId",
                table: "Dependants",
                column: "PrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_RemmittanceMatrices_PlanId",
                table: "RemmittanceMatrices",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Spouses_PrincipalId",
                table: "Spouses",
                column: "PrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_TheSubCounties_CountyId",
                table: "TheSubCounties",
                column: "CountyId");

            migrationBuilder.CreateIndex(
                name: "IX_TheWards_SubCountyId",
                table: "TheWards",
                column: "SubCountyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgentLogins");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "BulkPayments");

            migrationBuilder.DropTable(
                name: "ClientProfile");

            migrationBuilder.DropTable(
                name: "ClientSetup");

            migrationBuilder.DropTable(
                name: "constituencies");

            migrationBuilder.DropTable(
                name: "counties");

            migrationBuilder.DropTable(
                name: "CountyOfficers");

            migrationBuilder.DropTable(
                name: "Dependants");

            migrationBuilder.DropTable(
                name: "DepositRequests");

            migrationBuilder.DropTable(
                name: "Deposits");

            migrationBuilder.DropTable(
                name: "Facility");

            migrationBuilder.DropTable(
                name: "FacilityKEPHLevel");

            migrationBuilder.DropTable(
                name: "ImageData");

            migrationBuilder.DropTable(
                name: "kituiSubcounties");

            migrationBuilder.DropTable(
                name: "MemberLedgerEntries");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "RemmittanceMatrices");

            migrationBuilder.DropTable(
                name: "Spouses");

            migrationBuilder.DropTable(
                name: "TheWards");

            migrationBuilder.DropTable(
                name: "TransactionTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Wards");

            migrationBuilder.DropTable(
                name: "RemmittancePlans");

            migrationBuilder.DropTable(
                name: "Principals");

            migrationBuilder.DropTable(
                name: "TheSubCounties");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "TheCounties");
        }
    }
}
