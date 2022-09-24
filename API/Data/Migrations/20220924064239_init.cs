using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    CourseId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    VideoUrl = table.Column<string>(type: "character varying(355)", maxLength: 355, nullable: true),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    SectionId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WatchLogs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CourseId = table.Column<string>(type: "text", nullable: true),
                    LessonId = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    PercentageWatched = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WatchLogs_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WatchLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "a945757a-fc5d-4558-a3f6-8716545ab954", "Angular" },
                    { "befa383d-07d6-4b2b-aa57-8eea7132c4e5", "DotNet" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "ImageUrl" },
                values: new object[] { "7a1ddab6-59b9-449a-ae90-40701f9158ea", "Leon", "" });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "CourseId", "Name", "Order" },
                values: new object[,]
                {
                    { "75a08717-d091-49bc-867c-2340f4c6d058", "befa383d-07d6-4b2b-aa57-8eea7132c4e5", "Web API", 0 },
                    { "807548ea-cef2-4a58-a889-7e7bb133e963", "befa383d-07d6-4b2b-aa57-8eea7132c4e5", "MVC", 0 },
                    { "8b2245cd-7979-452b-96b5-f7e8ab40b83e", "befa383d-07d6-4b2b-aa57-8eea7132c4e5", "Entity Framework", 0 },
                    { "8c628339-02b3-4546-9e3f-a3dfbbfa564c", "a945757a-fc5d-4558-a3f6-8716545ab954", "Routing", 0 },
                    { "a5f742ec-af3b-41d7-b938-3f4c0de86b06", "a945757a-fc5d-4558-a3f6-8716545ab954", "Service", 0 },
                    { "d5b9ad05-d155-4c74-baee-1c2eb15bc98b", "a945757a-fc5d-4558-a3f6-8716545ab954", "Directive", 0 }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "Name", "Order", "SectionId", "VideoUrl" },
                values: new object[,]
                {
                    { "01c795f5-e89f-4b36-8e06-355a7ff48acd", "MVC: Lesson 6", 0, "807548ea-cef2-4a58-a889-7e7bb133e963", "" },
                    { "04d642c3-4c5a-4b7a-af97-1d4464da9fc4", "Entity Framework: Lesson 7", 0, "8b2245cd-7979-452b-96b5-f7e8ab40b83e", "" },
                    { "08975417-3eba-4c21-8a54-5b46be6a4574", "Service: Lesson 8", 0, "a5f742ec-af3b-41d7-b938-3f4c0de86b06", "" },
                    { "0aced6cd-ff98-4964-90a9-b690e8c97915", "Entity Framework: Lesson 15", 0, "8b2245cd-7979-452b-96b5-f7e8ab40b83e", "" },
                    { "0ebf02ad-413d-42d3-a28f-b2acfc93a2ca", "Service: Lesson 5", 0, "a5f742ec-af3b-41d7-b938-3f4c0de86b06", "" },
                    { "1341ea73-1c77-46c6-be4f-ff8c40f299c7", "Routing: Lesson 3", 0, "8c628339-02b3-4546-9e3f-a3dfbbfa564c", "" },
                    { "1a427c9a-4e62-45e6-b10f-358283c06453", "Entity Framework: Lesson 19", 0, "8b2245cd-7979-452b-96b5-f7e8ab40b83e", "" },
                    { "1b066bfd-2b3d-4de7-b8c4-254a087fb8d5", "Web API: Lesson 6", 0, "75a08717-d091-49bc-867c-2340f4c6d058", "" },
                    { "1b7fa50c-9e19-46be-a023-818efc72c3fb", "Entity Framework: Lesson 10", 0, "8b2245cd-7979-452b-96b5-f7e8ab40b83e", "" },
                    { "1d5e970e-e882-4262-9554-0834284478d1", "MVC: Lesson 1", 0, "807548ea-cef2-4a58-a889-7e7bb133e963", "" },
                    { "233b21eb-8160-448e-9b14-14c556cf3a40", "Service: Lesson 17", 0, "a5f742ec-af3b-41d7-b938-3f4c0de86b06", "" },
                    { "24517c22-378d-42c0-830e-72d7c41fde17", "Entity Framework: Lesson 11", 0, "8b2245cd-7979-452b-96b5-f7e8ab40b83e", "" },
                    { "2d152c64-bfb5-42f3-a531-23902a2a60b2", "Service: Lesson 10", 0, "a5f742ec-af3b-41d7-b938-3f4c0de86b06", "" },
                    { "300baf6a-2840-43dc-8d11-42b74852db9e", "Entity Framework: Lesson 1", 0, "8b2245cd-7979-452b-96b5-f7e8ab40b83e", "" },
                    { "31860ce5-81b4-407c-8189-682ecf94883e", "MVC: Lesson 3", 0, "807548ea-cef2-4a58-a889-7e7bb133e963", "" },
                    { "3273ab28-61be-443f-90a2-50afe6628bd6", "Web API: Lesson 1", 0, "75a08717-d091-49bc-867c-2340f4c6d058", "" },
                    { "33634191-15d7-47c6-a631-aa174e60460d", "Entity Framework: Lesson 16", 0, "8b2245cd-7979-452b-96b5-f7e8ab40b83e", "" },
                    { "3a6991c2-4ea5-440c-9628-aba773941c1c", "Service: Lesson 4", 0, "a5f742ec-af3b-41d7-b938-3f4c0de86b06", "" },
                    { "53625b4d-858a-44d3-9716-a2c3fccb07da", "Service: Lesson 20", 0, "a5f742ec-af3b-41d7-b938-3f4c0de86b06", "" },
                    { "5929ff7c-31d1-42d8-8e8e-329b60e07c69", "Directive: Lesson 1", 0, "d5b9ad05-d155-4c74-baee-1c2eb15bc98b", "" },
                    { "5bf8757d-befc-478a-b140-f44047cd66e1", "Routing: Lesson 1", 0, "8c628339-02b3-4546-9e3f-a3dfbbfa564c", "" },
                    { "604cc026-c1e0-492c-a1e1-820440e995fc", "MVC: Lesson 7", 0, "807548ea-cef2-4a58-a889-7e7bb133e963", "" },
                    { "62d321d0-a42f-46d2-8796-7ccb315edd57", "Entity Framework: Lesson 12", 0, "8b2245cd-7979-452b-96b5-f7e8ab40b83e", "" },
                    { "67bbf005-a335-42ce-a8bd-6d91b8ccf376", "Routing: Lesson 9", 0, "8c628339-02b3-4546-9e3f-a3dfbbfa564c", "" },
                    { "6c17833a-e966-4a30-8948-c40b5ef924e9", "Service: Lesson 3", 0, "a5f742ec-af3b-41d7-b938-3f4c0de86b06", "" },
                    { "6e7b5881-8319-453e-9e0b-50d98e376bc5", "Service: Lesson 6", 0, "a5f742ec-af3b-41d7-b938-3f4c0de86b06", "" },
                    { "70775f5b-3257-4739-b022-16098b16769e", "Web API: Lesson 4", 0, "75a08717-d091-49bc-867c-2340f4c6d058", "" },
                    { "727a7c6e-b346-4c6b-86a5-94f4e0dd8987", "Entity Framework: Lesson 6", 0, "8b2245cd-7979-452b-96b5-f7e8ab40b83e", "" },
                    { "75c0825b-f1de-497f-a289-fd339086f9ee", "Routing: Lesson 4", 0, "8c628339-02b3-4546-9e3f-a3dfbbfa564c", "" },
                    { "76e61d53-300b-450b-ac0f-eb9f93ecacca", "MVC: Lesson 8", 0, "807548ea-cef2-4a58-a889-7e7bb133e963", "" },
                    { "77ee978e-d135-44b1-9127-b8e39340e07e", "Entity Framework: Lesson 2", 0, "8b2245cd-7979-452b-96b5-f7e8ab40b83e", "" },
                    { "796f7615-1135-4084-acc4-c6e1e8f27dc1", "Entity Framework: Lesson 13", 0, "8b2245cd-7979-452b-96b5-f7e8ab40b83e", "" },
                    { "79cc9fe3-ae50-41ce-8fe1-eea369e5c07f", "Routing: Lesson 7", 0, "8c628339-02b3-4546-9e3f-a3dfbbfa564c", "" },
                    { "7d34115e-e389-4f17-a9f8-182519e4c104", "MVC: Lesson 9", 0, "807548ea-cef2-4a58-a889-7e7bb133e963", "" },
                    { "7e5af8f8-9908-402b-9617-83d9e6e33ac7", "Web API: Lesson 8", 0, "75a08717-d091-49bc-867c-2340f4c6d058", "" },
                    { "8036a483-b2ff-4610-a70c-ba1315492fc7", "Directive: Lesson 5", 0, "d5b9ad05-d155-4c74-baee-1c2eb15bc98b", "" },
                    { "828b5c4e-5d1c-49b4-b1a6-7b2470ee5e55", "Directive: Lesson 2", 0, "d5b9ad05-d155-4c74-baee-1c2eb15bc98b", "" },
                    { "85b7ce46-f691-4f65-8f1e-a26059b31a45", "Routing: Lesson 2", 0, "8c628339-02b3-4546-9e3f-a3dfbbfa564c", "" },
                    { "8ba324b4-0d8b-4bfe-a305-6b5dc3d86734", "Entity Framework: Lesson 9", 0, "8b2245cd-7979-452b-96b5-f7e8ab40b83e", "" },
                    { "949795f4-5baa-4fa9-b13a-7b9208c731b6", "MVC: Lesson 10", 0, "807548ea-cef2-4a58-a889-7e7bb133e963", "" },
                    { "95684232-976d-42a9-aea9-2971fb1a9a90", "MVC: Lesson 4", 0, "807548ea-cef2-4a58-a889-7e7bb133e963", "" },
                    { "96f007ef-3063-4e35-9732-863c86bd1cb2", "Service: Lesson 11", 0, "a5f742ec-af3b-41d7-b938-3f4c0de86b06", "" },
                    { "991bebd9-5151-4a27-9390-ab860dc3e8c2", "Service: Lesson 12", 0, "a5f742ec-af3b-41d7-b938-3f4c0de86b06", "" },
                    { "993ff438-e5c2-4ba9-bf17-b33c4559e9b8", "Directive: Lesson 4", 0, "d5b9ad05-d155-4c74-baee-1c2eb15bc98b", "" },
                    { "9a8fd836-c38c-4460-acaa-0f4eb5c81fad", "Service: Lesson 9", 0, "a5f742ec-af3b-41d7-b938-3f4c0de86b06", "" },
                    { "9b790b4e-ebb8-464c-b74c-b32550622f1e", "Web API: Lesson 7", 0, "75a08717-d091-49bc-867c-2340f4c6d058", "" },
                    { "a115d6d8-a08a-45c1-93ea-52b41d888589", "Service: Lesson 2", 0, "a5f742ec-af3b-41d7-b938-3f4c0de86b06", "" },
                    { "a6bd99c6-6217-47f9-a80c-b996fa41f757", "Routing: Lesson 10", 0, "8c628339-02b3-4546-9e3f-a3dfbbfa564c", "" },
                    { "af9d8a0f-0523-4300-a45d-63d407eb5285", "Entity Framework: Lesson 20", 0, "8b2245cd-7979-452b-96b5-f7e8ab40b83e", "" },
                    { "b0abf9c9-c702-4561-8387-6f80e76100c2", "MVC: Lesson 5", 0, "807548ea-cef2-4a58-a889-7e7bb133e963", "" },
                    { "b29da32b-f014-44f4-96cd-13a9b9e17688", "MVC: Lesson 2", 0, "807548ea-cef2-4a58-a889-7e7bb133e963", "" },
                    { "b340aa6a-8e79-4f37-8395-02771e42b234", "Routing: Lesson 8", 0, "8c628339-02b3-4546-9e3f-a3dfbbfa564c", "" },
                    { "b3867309-f262-4311-b52f-799b0e7477a3", "Directive: Lesson 3", 0, "d5b9ad05-d155-4c74-baee-1c2eb15bc98b", "" },
                    { "b5dd0389-87eb-46f7-a499-5407af560321", "Service: Lesson 15", 0, "a5f742ec-af3b-41d7-b938-3f4c0de86b06", "" },
                    { "bb9d597e-09a9-4ed5-8259-1aeed9c8e8b3", "Service: Lesson 13", 0, "a5f742ec-af3b-41d7-b938-3f4c0de86b06", "" },
                    { "bbe2c99d-b182-461a-81cd-21a0d9e96142", "Service: Lesson 1", 0, "a5f742ec-af3b-41d7-b938-3f4c0de86b06", "" },
                    { "c03d1e15-9e7f-4378-89f4-c121463f1938", "Entity Framework: Lesson 18", 0, "8b2245cd-7979-452b-96b5-f7e8ab40b83e", "" },
                    { "c146e570-bc2e-4189-820a-9025b64c27b5", "Service: Lesson 7", 0, "a5f742ec-af3b-41d7-b938-3f4c0de86b06", "" },
                    { "c57f32f1-33b3-4e30-9253-93c470d4bc2c", "Web API: Lesson 2", 0, "75a08717-d091-49bc-867c-2340f4c6d058", "" },
                    { "c8740a34-e786-429a-a949-5a069ab4d1d7", "Entity Framework: Lesson 4", 0, "8b2245cd-7979-452b-96b5-f7e8ab40b83e", "" },
                    { "d10c2413-45c7-4ba5-a918-3635690efd3b", "Entity Framework: Lesson 5", 0, "8b2245cd-7979-452b-96b5-f7e8ab40b83e", "" },
                    { "d6432df0-476d-4122-b086-1f90c756b8dc", "Web API: Lesson 3", 0, "75a08717-d091-49bc-867c-2340f4c6d058", "" },
                    { "d9332917-e901-4732-bb3b-361405403a4b", "Service: Lesson 19", 0, "a5f742ec-af3b-41d7-b938-3f4c0de86b06", "" },
                    { "da619eac-3590-4eaf-9db7-dcaa6e8560fb", "Service: Lesson 16", 0, "a5f742ec-af3b-41d7-b938-3f4c0de86b06", "" },
                    { "e5278d62-b6f5-44e5-b597-34d515e54ecb", "Routing: Lesson 5", 0, "8c628339-02b3-4546-9e3f-a3dfbbfa564c", "" },
                    { "eaf0c338-d84a-4bc7-9569-2a87fe8caeb3", "Web API: Lesson 9", 0, "75a08717-d091-49bc-867c-2340f4c6d058", "" },
                    { "eb1b0884-a7d5-464e-92dc-1b3a51ed3cb5", "Web API: Lesson 10", 0, "75a08717-d091-49bc-867c-2340f4c6d058", "" },
                    { "ee6fe37d-470d-4d1c-8e15-1be7312736c9", "Entity Framework: Lesson 17", 0, "8b2245cd-7979-452b-96b5-f7e8ab40b83e", "" },
                    { "efe69627-4e7d-4386-a9a8-f59a6e7a6a47", "Routing: Lesson 6", 0, "8c628339-02b3-4546-9e3f-a3dfbbfa564c", "" },
                    { "f1632cce-d548-4dfb-bd67-52121eefbb33", "Entity Framework: Lesson 3", 0, "8b2245cd-7979-452b-96b5-f7e8ab40b83e", "" },
                    { "f19b362d-6ec0-4cf8-9db8-833205bbc561", "Service: Lesson 14", 0, "a5f742ec-af3b-41d7-b938-3f4c0de86b06", "" },
                    { "f3eb5053-905d-4e00-b239-f037348de458", "Entity Framework: Lesson 8", 0, "8b2245cd-7979-452b-96b5-f7e8ab40b83e", "" },
                    { "f4d199c1-53e0-405b-b96e-cee437369e33", "Service: Lesson 18", 0, "a5f742ec-af3b-41d7-b938-3f4c0de86b06", "" },
                    { "fb23bf54-2ac6-4590-9f27-1387e49e525f", "Web API: Lesson 5", 0, "75a08717-d091-49bc-867c-2340f4c6d058", "" },
                    { "fed8cd74-afb4-4b2d-8e19-bebf2bea43b9", "Entity Framework: Lesson 14", 0, "8b2245cd-7979-452b-96b5-f7e8ab40b83e", "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_SectionId",
                table: "Lessons",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_CourseId",
                table: "Sections",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchLogs_LessonId",
                table: "WatchLogs",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchLogs_UserId",
                table: "WatchLogs",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WatchLogs");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
