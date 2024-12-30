﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RIIMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3dca8f33-ecf0-484f-a28b-ebd04e7247b6", "3dca8f33-ecf0-484f-a28b-ebd04e7247b6", "User", "USER" },
                    { "745b9f24-a569-4f1c-bc34-5d9911b2d644", "745b9f24-a569-4f1c-bc34-5d9911b2d644", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Gjuhet",
                columns: new[] { "Id", "EmriGjuhes" },
                values: new object[,]
                {
                    { new Guid("06ba1732-25ea-43e4-aa9b-11f7ab0c4b21"), "Dutch" },
                    { new Guid("08b5fc95-2576-41fc-85e6-12a5263fc1ee"), "Samoan" },
                    { new Guid("0ac41a4e-01dd-40af-b3fe-b0113a59369c"), "Armenian" },
                    { new Guid("0af1d222-e087-4ce2-9237-63e0ac045c3a"), "Bosnian" },
                    { new Guid("17bacb90-b7cb-41ae-bb21-949e7d849231"), "Maltese" },
                    { new Guid("1919d45e-280a-41e1-a330-c314ab487ec0"), "Urdu" },
                    { new Guid("1eb9b4d9-19c3-4c85-a9e9-50a47147b4b7"), "Serbian" },
                    { new Guid("1fe293fd-bc1f-40f1-9c79-7af39c00e911"), "Haitian Creole" },
                    { new Guid("2cdc39a5-8f2e-452b-8d4d-14f99b2a6614"), "Danish" },
                    { new Guid("331e6eca-c849-4a42-bae5-34986d6bbaa3"), "Estonian" },
                    { new Guid("3436d59f-7d2c-4faf-b871-40f85287b8e2"), "Azerbaijani" },
                    { new Guid("351ad052-aa07-4e8e-9a29-b1572bb37977"), "Portuguese" },
                    { new Guid("3f47cb97-d7cd-4f40-a59f-2fd2b7125767"), "Swahili" },
                    { new Guid("4014b4d6-2656-486c-bda5-7364fdd930ae"), "Hindi" },
                    { new Guid("437132bc-1985-46a3-9c55-f24dcef3b3f0"), "Tamil" },
                    { new Guid("44c0df9d-77e9-46a8-95a1-e1e5abcff685"), "Malayalam" },
                    { new Guid("4bcc6295-978d-4bd2-8ff3-34f01d238b74"), "Korean" },
                    { new Guid("4fb75533-88eb-4373-9e4e-72c870ff43b9"), "English" },
                    { new Guid("50e2df1f-ea8b-43dd-989f-fef6f5cda2c5"), "Thai" },
                    { new Guid("55a6fd9a-beac-4c06-a697-9d58e662320a"), "Bulgarian" },
                    { new Guid("55ee730c-a579-48eb-aa07-c994e2637f91"), "Belarusian" },
                    { new Guid("58e004d7-fdbb-47ef-a493-5adedbe02271"), "Kurdish" },
                    { new Guid("5caa257a-19d7-449e-93a4-f584a1d4c7db"), "Xhosa" },
                    { new Guid("5fcc64b1-97af-4ef1-8ff6-024902ed73e6"), "Malay" },
                    { new Guid("606c241c-3e3e-4730-8cda-28cbbfbbc7f1"), "Hebrew" },
                    { new Guid("60e8cca6-cdc6-488e-9df4-d195207056b1"), "Macedonian" },
                    { new Guid("6c462ef0-00bc-4cff-a166-4282c7bb3f75"), "Marathi" },
                    { new Guid("6cb4a59d-43a7-485c-a42a-2d53731e4a42"), "Mongolian" },
                    { new Guid("6f799343-b897-4c01-8c28-686fd89053b8"), "Finnish" },
                    { new Guid("70dd0051-da8c-4533-ab93-0d27beff5e7f"), "Pashto" },
                    { new Guid("72b4b137-8018-4fe5-b0bd-4f44cc26e604"), "Galician" },
                    { new Guid("731d2d0c-c77b-4d45-9e5d-b2fccbeebd63"), "Arabic" },
                    { new Guid("73ff14da-36df-4330-b668-f786f34db78b"), "Vietnamese" },
                    { new Guid("74722c3b-f235-49bb-85ad-b257a68c8b17"), "Japanese" },
                    { new Guid("756b040a-501e-447d-a703-0dba28307ca1"), "Persian" },
                    { new Guid("8022cc56-f02f-4e0b-ae09-fea2726f8d97"), "Basque" },
                    { new Guid("82274f16-c47f-4f36-8c04-b403c5e3e55b"), "Telugu" },
                    { new Guid("84bed73e-4f4a-4067-b822-2cefee3bbf45"), "Slovenian" },
                    { new Guid("8644f2b0-339c-45b4-be8b-3c9a10a06f0f"), "Javanese" },
                    { new Guid("8da15382-61a1-4003-ab59-4946e28603ba"), "Latvian" },
                    { new Guid("9263b275-11a5-4e2c-9d1c-b76c6b7919b9"), "Slovak" },
                    { new Guid("9629d1fb-bb54-42b0-872f-a41a69a37614"), "Croatian" },
                    { new Guid("9a18522f-31df-4016-85ec-04d6b9415bcf"), "Kyrgyz" },
                    { new Guid("9aafe0a4-8229-4974-b44c-ecadf8263a84"), "Icelandic" },
                    { new Guid("9b19c334-7047-419b-8440-6da592859922"), "Czech" },
                    { new Guid("aad60ef4-0b8d-4b99-8b4e-2d68467701a8"), "Norwegian" },
                    { new Guid("ac6bc702-67a2-4674-8a8c-600424fc9933"), "Spanish" },
                    { new Guid("b2aef1e5-cbb8-406b-977b-e479380e481f"), "Lao" },
                    { new Guid("b37fae09-4578-45c8-9e05-5aca670193c6"), "Zulu" },
                    { new Guid("b70c7665-1982-4f1e-b6ff-31710f90ad10"), "Swedish" },
                    { new Guid("b820c74b-5342-43e4-9d7c-da7546dc4800"), "Maori" },
                    { new Guid("b9314cdc-d869-451f-b3dc-9e9b678ff115"), "Romanian" },
                    { new Guid("ba014c88-de3e-4349-aad4-8e24d5afc2c4"), "Italian" },
                    { new Guid("bb5eefbc-c9a6-461a-986d-aa717f33f834"), "Bengali" },
                    { new Guid("bded2a98-155d-42e5-afbd-ae8142962b11"), "Uzbek" },
                    { new Guid("c6bb8c19-b90f-4554-a80f-c90a21f712b6"), "German" },
                    { new Guid("c7156ce4-d4b3-4e0b-a4f1-816b02c9bfcc"), "Hungarian" },
                    { new Guid("c993bdc3-b1de-4103-96d4-e977346e7ed2"), "Greek" },
                    { new Guid("cc8f4d07-9c10-4a7f-86cd-6f2a2413ad33"), "Chinese" },
                    { new Guid("cd001b96-f3de-4857-909d-a8197018b404"), "Amharic" },
                    { new Guid("d0ea4583-d485-4290-acf1-9e32db784d62"), "Punjabi" },
                    { new Guid("d181099b-74ff-4120-a78b-f3676ab03bd5"), "French" },
                    { new Guid("d3d5f4b6-c735-425a-83b4-777456991d90"), "Ukrainian" },
                    { new Guid("deb1c84f-15b5-4424-b23f-c0cf31e49633"), "Kannada" },
                    { new Guid("df9ffed4-6354-43da-adf6-8be3adcbf46d"), "Somali" },
                    { new Guid("dfa4a645-147a-4d34-8c6e-b9adc38544b7"), "Georgian" },
                    { new Guid("dff2380e-b62e-4489-940d-155116ab9b91"), "Gujarati" },
                    { new Guid("e02e91b9-12b6-4981-a94c-c0cb2a1cac42"), "Yoruba" },
                    { new Guid("e1a628e0-6a2c-49f4-8371-8b5e21e045b6"), "Albanian" },
                    { new Guid("e5500cac-cbcd-4b41-a3c3-8c7f629c9638"), "Turkish" },
                    { new Guid("e82c10e0-ec34-47ea-8e40-e9f44848daf9"), "Nepali" },
                    { new Guid("ea267650-83cb-4817-985c-df11d25a5b61"), "Yiddish" },
                    { new Guid("ea81c50e-7068-4d54-a65f-0c2914fefb00"), "Lithuanian" },
                    { new Guid("eb71526f-530e-4477-b808-7c05608d5734"), "Polish" },
                    { new Guid("ebd9f689-e11b-44dd-a885-7e3ad24cf336"), "Kazakh" },
                    { new Guid("ecaee039-3d79-4b68-a2ff-5f999eeeac56"), "Khmer" },
                    { new Guid("eefca401-9791-4aa4-a834-823f94a4593c"), "Catalan" },
                    { new Guid("f2f84fae-17b2-496a-bf91-977b44604f1e"), "Welsh" },
                    { new Guid("f43ca4fb-06ca-4068-89d3-0008754cffc9"), "Russian" },
                    { new Guid("f4ddfa46-6a87-4376-815b-af6cab990d52"), "Indonesian" },
                    { new Guid("f63ac235-418d-4b60-93cc-cedd249837be"), "Afrikaans" },
                    { new Guid("ffd5dabb-63e1-4cb7-acb3-53f2b041cd17"), "Irish" }
                });

            migrationBuilder.InsertData(
                table: "Institucioni",
                columns: new[] { "Id", "Emri" },
                values: new object[,]
                {
                    { new Guid("496cc2c1-cc09-4c64-a53d-9529c2486b48"), "UBT" },
                    { new Guid("94c1f26d-3feb-4b96-91e5-68d077a5b804"), "UP" }
                });

            migrationBuilder.InsertData(
                table: "NiveliAkademik",
                columns: new[] { "Id", "lvl" },
                values: new object[,]
                {
                    { new Guid("6f67cd1a-d096-4dc6-a011-f733be57f74c"), "M.Sc." },
                    { new Guid("f53512ec-7466-4a98-90bd-862ca65e5cfd"), "Ph.D." },
                    { new Guid("fe75fb45-6c06-4324-a2a2-092b6e4a493e"), "B.Sc." }
                });

            migrationBuilder.InsertData(
                table: "NiveliGjuhesor",
                columns: new[] { "Id", "Niveli" },
                values: new object[,]
                {
                    { new Guid("2ea9d919-b3ea-4d0e-9e76-311c6955c4e7"), "C1" },
                    { new Guid("4f965348-1db2-4212-88bf-1bc868338209"), "B1" },
                    { new Guid("81ebd457-1e9a-480b-bde1-d62196c51d75"), "C2" },
                    { new Guid("a5c0e948-be3d-4ebd-beba-8b0a9fc0285b"), "B2" },
                    { new Guid("c7c2b680-c679-4de2-83d0-28464165f115"), "A2" },
                    { new Guid("e52fa674-6854-4539-aeb8-89e716698f21"), "A1" }
                });

            migrationBuilder.InsertData(
                table: "Departamenti",
                columns: new[] { "Id", "Emri", "InstitucioniId" },
                values: new object[,]
                {
                    { new Guid("05251f11-0354-4d11-8dca-4422d284160b"), "Politika Publike dhe Menaxhimi", new Guid("496cc2c1-cc09-4c64-a53d-9529c2486b48") },
                    { new Guid("0a2c57ba-17fb-4f79-bcc4-cef9e704bf3d"), "Menaxhment, Biznes dhe Ekonomi", new Guid("496cc2c1-cc09-4c64-a53d-9529c2486b48") },
                    { new Guid("1e962ebf-9721-4fab-b489-6f0a1de1f0e8"), "Psikologji", new Guid("496cc2c1-cc09-4c64-a53d-9529c2486b48") },
                    { new Guid("1efbe13e-9b02-4860-8715-f80b035f93e2"), "Shkenca Kompjuterike dhe Inxhineri", new Guid("496cc2c1-cc09-4c64-a53d-9529c2486b48") },
                    { new Guid("273b38a2-4cd7-47e4-968b-d5d48d364edd"), "Shkenca e Ushqimit dhe bioteknologji", new Guid("496cc2c1-cc09-4c64-a53d-9529c2486b48") },
                    { new Guid("2c6b9320-7b40-4234-867c-03e3ae05f7ba"), "Menaxhment i Mekatronikës", new Guid("496cc2c1-cc09-4c64-a53d-9529c2486b48") },
                    { new Guid("3f6e8e7a-58dc-4e60-9fad-fa4b2be412cd"), "Juridik", new Guid("496cc2c1-cc09-4c64-a53d-9529c2486b48") },
                    { new Guid("4debc353-f2cc-4d75-82c8-0e356999a77a"), "Arti dhe Mediat Digjitale", new Guid("496cc2c1-cc09-4c64-a53d-9529c2486b48") },
                    { new Guid("571348c4-aadf-42b2-be6b-c2219e4dd845"), "AgriKulturë dhe Inxhineri e Ambientit", new Guid("496cc2c1-cc09-4c64-a53d-9529c2486b48") },
                    { new Guid("5d193df8-ef18-48d8-a722-7d94dbf636c6"), "Farmaci", new Guid("496cc2c1-cc09-4c64-a53d-9529c2486b48") },
                    { new Guid("6d76ebfe-ef5b-43e5-8813-bbf98f2e7657"), "Sistemet e Informacionit", new Guid("496cc2c1-cc09-4c64-a53d-9529c2486b48") },
                    { new Guid("7300a7d2-a6a0-4ca4-96c6-940e7b0c865e"), "Teknik i Radiologjisë", new Guid("496cc2c1-cc09-4c64-a53d-9529c2486b48") },
                    { new Guid("7b6a59f2-d536-45c2-b981-ce54917084c0"), "Dizajn i Integruar", new Guid("496cc2c1-cc09-4c64-a53d-9529c2486b48") },
                    { new Guid("7bb0e204-8a1a-4d40-b08f-81015d5c3c4e"), "Infermieri", new Guid("496cc2c1-cc09-4c64-a53d-9529c2486b48") },
                    { new Guid("7da76f05-491c-44b4-9377-7e99c3ffd97b"), "Teknik i Anesteziologjisë", new Guid("496cc2c1-cc09-4c64-a53d-9529c2486b48") },
                    { new Guid("985167e8-cb59-4e1a-8bc8-268a3caf2911"), "Stomatologji", new Guid("496cc2c1-cc09-4c64-a53d-9529c2486b48") },
                    { new Guid("9aa12dbb-746c-41de-88b5-19da7de10516"), "Muzika Moderne, Prodhimi Digjital dhe Menaxhimi", new Guid("496cc2c1-cc09-4c64-a53d-9529c2486b48") },
                    { new Guid("9e789309-441e-4f3f-af5f-69ba940902db"), "Shkenca Politike", new Guid("496cc2c1-cc09-4c64-a53d-9529c2486b48") },
                    { new Guid("b010567e-5b9c-461a-9d4b-1a9c36148f03"), "Inxhineri e Energjisë", new Guid("496cc2c1-cc09-4c64-a53d-9529c2486b48") },
                    { new Guid("b47eb467-7e2c-476c-b50b-25751692b447"), "Aktrim", new Guid("496cc2c1-cc09-4c64-a53d-9529c2486b48") },
                    { new Guid("dc1db886-3100-4ce9-99cc-493d88f603d5"), "Media dhe Komunikim", new Guid("496cc2c1-cc09-4c64-a53d-9529c2486b48") },
                    { new Guid("dd90af7b-1852-42af-942d-c51fd8c6e854"), "Arkitekturë dhe Planifikimi Hapësinor", new Guid("496cc2c1-cc09-4c64-a53d-9529c2486b48") },
                    { new Guid("f9944afc-5811-4960-96ab-d585f0210707"), "Inxhineri Ndërtimore(Ndërtimtari) dhe Infrastrukturë", new Guid("496cc2c1-cc09-4c64-a53d-9529c2486b48") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3dca8f33-ecf0-484f-a28b-ebd04e7247b6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "745b9f24-a569-4f1c-bc34-5d9911b2d644");

            migrationBuilder.DeleteData(
                table: "Departamenti",
                keyColumn: "Id",
                keyValue: new Guid("05251f11-0354-4d11-8dca-4422d284160b"));

            migrationBuilder.DeleteData(
                table: "Departamenti",
                keyColumn: "Id",
                keyValue: new Guid("0a2c57ba-17fb-4f79-bcc4-cef9e704bf3d"));

            migrationBuilder.DeleteData(
                table: "Departamenti",
                keyColumn: "Id",
                keyValue: new Guid("1e962ebf-9721-4fab-b489-6f0a1de1f0e8"));

            migrationBuilder.DeleteData(
                table: "Departamenti",
                keyColumn: "Id",
                keyValue: new Guid("1efbe13e-9b02-4860-8715-f80b035f93e2"));

            migrationBuilder.DeleteData(
                table: "Departamenti",
                keyColumn: "Id",
                keyValue: new Guid("273b38a2-4cd7-47e4-968b-d5d48d364edd"));

            migrationBuilder.DeleteData(
                table: "Departamenti",
                keyColumn: "Id",
                keyValue: new Guid("2c6b9320-7b40-4234-867c-03e3ae05f7ba"));

            migrationBuilder.DeleteData(
                table: "Departamenti",
                keyColumn: "Id",
                keyValue: new Guid("3f6e8e7a-58dc-4e60-9fad-fa4b2be412cd"));

            migrationBuilder.DeleteData(
                table: "Departamenti",
                keyColumn: "Id",
                keyValue: new Guid("4debc353-f2cc-4d75-82c8-0e356999a77a"));

            migrationBuilder.DeleteData(
                table: "Departamenti",
                keyColumn: "Id",
                keyValue: new Guid("571348c4-aadf-42b2-be6b-c2219e4dd845"));

            migrationBuilder.DeleteData(
                table: "Departamenti",
                keyColumn: "Id",
                keyValue: new Guid("5d193df8-ef18-48d8-a722-7d94dbf636c6"));

            migrationBuilder.DeleteData(
                table: "Departamenti",
                keyColumn: "Id",
                keyValue: new Guid("6d76ebfe-ef5b-43e5-8813-bbf98f2e7657"));

            migrationBuilder.DeleteData(
                table: "Departamenti",
                keyColumn: "Id",
                keyValue: new Guid("7300a7d2-a6a0-4ca4-96c6-940e7b0c865e"));

            migrationBuilder.DeleteData(
                table: "Departamenti",
                keyColumn: "Id",
                keyValue: new Guid("7b6a59f2-d536-45c2-b981-ce54917084c0"));

            migrationBuilder.DeleteData(
                table: "Departamenti",
                keyColumn: "Id",
                keyValue: new Guid("7bb0e204-8a1a-4d40-b08f-81015d5c3c4e"));

            migrationBuilder.DeleteData(
                table: "Departamenti",
                keyColumn: "Id",
                keyValue: new Guid("7da76f05-491c-44b4-9377-7e99c3ffd97b"));

            migrationBuilder.DeleteData(
                table: "Departamenti",
                keyColumn: "Id",
                keyValue: new Guid("985167e8-cb59-4e1a-8bc8-268a3caf2911"));

            migrationBuilder.DeleteData(
                table: "Departamenti",
                keyColumn: "Id",
                keyValue: new Guid("9aa12dbb-746c-41de-88b5-19da7de10516"));

            migrationBuilder.DeleteData(
                table: "Departamenti",
                keyColumn: "Id",
                keyValue: new Guid("9e789309-441e-4f3f-af5f-69ba940902db"));

            migrationBuilder.DeleteData(
                table: "Departamenti",
                keyColumn: "Id",
                keyValue: new Guid("b010567e-5b9c-461a-9d4b-1a9c36148f03"));

            migrationBuilder.DeleteData(
                table: "Departamenti",
                keyColumn: "Id",
                keyValue: new Guid("b47eb467-7e2c-476c-b50b-25751692b447"));

            migrationBuilder.DeleteData(
                table: "Departamenti",
                keyColumn: "Id",
                keyValue: new Guid("dc1db886-3100-4ce9-99cc-493d88f603d5"));

            migrationBuilder.DeleteData(
                table: "Departamenti",
                keyColumn: "Id",
                keyValue: new Guid("dd90af7b-1852-42af-942d-c51fd8c6e854"));

            migrationBuilder.DeleteData(
                table: "Departamenti",
                keyColumn: "Id",
                keyValue: new Guid("f9944afc-5811-4960-96ab-d585f0210707"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("06ba1732-25ea-43e4-aa9b-11f7ab0c4b21"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("08b5fc95-2576-41fc-85e6-12a5263fc1ee"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("0ac41a4e-01dd-40af-b3fe-b0113a59369c"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("0af1d222-e087-4ce2-9237-63e0ac045c3a"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("17bacb90-b7cb-41ae-bb21-949e7d849231"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("1919d45e-280a-41e1-a330-c314ab487ec0"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("1eb9b4d9-19c3-4c85-a9e9-50a47147b4b7"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("1fe293fd-bc1f-40f1-9c79-7af39c00e911"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("2cdc39a5-8f2e-452b-8d4d-14f99b2a6614"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("331e6eca-c849-4a42-bae5-34986d6bbaa3"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("3436d59f-7d2c-4faf-b871-40f85287b8e2"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("351ad052-aa07-4e8e-9a29-b1572bb37977"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("3f47cb97-d7cd-4f40-a59f-2fd2b7125767"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("4014b4d6-2656-486c-bda5-7364fdd930ae"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("437132bc-1985-46a3-9c55-f24dcef3b3f0"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("44c0df9d-77e9-46a8-95a1-e1e5abcff685"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("4bcc6295-978d-4bd2-8ff3-34f01d238b74"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("4fb75533-88eb-4373-9e4e-72c870ff43b9"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("50e2df1f-ea8b-43dd-989f-fef6f5cda2c5"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("55a6fd9a-beac-4c06-a697-9d58e662320a"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("55ee730c-a579-48eb-aa07-c994e2637f91"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("58e004d7-fdbb-47ef-a493-5adedbe02271"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("5caa257a-19d7-449e-93a4-f584a1d4c7db"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("5fcc64b1-97af-4ef1-8ff6-024902ed73e6"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("606c241c-3e3e-4730-8cda-28cbbfbbc7f1"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("60e8cca6-cdc6-488e-9df4-d195207056b1"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("6c462ef0-00bc-4cff-a166-4282c7bb3f75"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("6cb4a59d-43a7-485c-a42a-2d53731e4a42"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("6f799343-b897-4c01-8c28-686fd89053b8"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("70dd0051-da8c-4533-ab93-0d27beff5e7f"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("72b4b137-8018-4fe5-b0bd-4f44cc26e604"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("731d2d0c-c77b-4d45-9e5d-b2fccbeebd63"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("73ff14da-36df-4330-b668-f786f34db78b"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("74722c3b-f235-49bb-85ad-b257a68c8b17"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("756b040a-501e-447d-a703-0dba28307ca1"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("8022cc56-f02f-4e0b-ae09-fea2726f8d97"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("82274f16-c47f-4f36-8c04-b403c5e3e55b"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("84bed73e-4f4a-4067-b822-2cefee3bbf45"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("8644f2b0-339c-45b4-be8b-3c9a10a06f0f"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("8da15382-61a1-4003-ab59-4946e28603ba"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("9263b275-11a5-4e2c-9d1c-b76c6b7919b9"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("9629d1fb-bb54-42b0-872f-a41a69a37614"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("9a18522f-31df-4016-85ec-04d6b9415bcf"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("9aafe0a4-8229-4974-b44c-ecadf8263a84"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("9b19c334-7047-419b-8440-6da592859922"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("aad60ef4-0b8d-4b99-8b4e-2d68467701a8"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("ac6bc702-67a2-4674-8a8c-600424fc9933"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("b2aef1e5-cbb8-406b-977b-e479380e481f"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("b37fae09-4578-45c8-9e05-5aca670193c6"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("b70c7665-1982-4f1e-b6ff-31710f90ad10"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("b820c74b-5342-43e4-9d7c-da7546dc4800"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("b9314cdc-d869-451f-b3dc-9e9b678ff115"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("ba014c88-de3e-4349-aad4-8e24d5afc2c4"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("bb5eefbc-c9a6-461a-986d-aa717f33f834"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("bded2a98-155d-42e5-afbd-ae8142962b11"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("c6bb8c19-b90f-4554-a80f-c90a21f712b6"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("c7156ce4-d4b3-4e0b-a4f1-816b02c9bfcc"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("c993bdc3-b1de-4103-96d4-e977346e7ed2"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("cc8f4d07-9c10-4a7f-86cd-6f2a2413ad33"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("cd001b96-f3de-4857-909d-a8197018b404"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("d0ea4583-d485-4290-acf1-9e32db784d62"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("d181099b-74ff-4120-a78b-f3676ab03bd5"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("d3d5f4b6-c735-425a-83b4-777456991d90"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("deb1c84f-15b5-4424-b23f-c0cf31e49633"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("df9ffed4-6354-43da-adf6-8be3adcbf46d"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("dfa4a645-147a-4d34-8c6e-b9adc38544b7"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("dff2380e-b62e-4489-940d-155116ab9b91"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("e02e91b9-12b6-4981-a94c-c0cb2a1cac42"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("e1a628e0-6a2c-49f4-8371-8b5e21e045b6"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("e5500cac-cbcd-4b41-a3c3-8c7f629c9638"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("e82c10e0-ec34-47ea-8e40-e9f44848daf9"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("ea267650-83cb-4817-985c-df11d25a5b61"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("ea81c50e-7068-4d54-a65f-0c2914fefb00"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("eb71526f-530e-4477-b808-7c05608d5734"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("ebd9f689-e11b-44dd-a885-7e3ad24cf336"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("ecaee039-3d79-4b68-a2ff-5f999eeeac56"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("eefca401-9791-4aa4-a834-823f94a4593c"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("f2f84fae-17b2-496a-bf91-977b44604f1e"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("f43ca4fb-06ca-4068-89d3-0008754cffc9"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("f4ddfa46-6a87-4376-815b-af6cab990d52"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("f63ac235-418d-4b60-93cc-cedd249837be"));

            migrationBuilder.DeleteData(
                table: "Gjuhet",
                keyColumn: "Id",
                keyValue: new Guid("ffd5dabb-63e1-4cb7-acb3-53f2b041cd17"));

            migrationBuilder.DeleteData(
                table: "Institucioni",
                keyColumn: "Id",
                keyValue: new Guid("94c1f26d-3feb-4b96-91e5-68d077a5b804"));

            migrationBuilder.DeleteData(
                table: "NiveliAkademik",
                keyColumn: "Id",
                keyValue: new Guid("6f67cd1a-d096-4dc6-a011-f733be57f74c"));

            migrationBuilder.DeleteData(
                table: "NiveliAkademik",
                keyColumn: "Id",
                keyValue: new Guid("f53512ec-7466-4a98-90bd-862ca65e5cfd"));

            migrationBuilder.DeleteData(
                table: "NiveliAkademik",
                keyColumn: "Id",
                keyValue: new Guid("fe75fb45-6c06-4324-a2a2-092b6e4a493e"));

            migrationBuilder.DeleteData(
                table: "NiveliGjuhesor",
                keyColumn: "Id",
                keyValue: new Guid("2ea9d919-b3ea-4d0e-9e76-311c6955c4e7"));

            migrationBuilder.DeleteData(
                table: "NiveliGjuhesor",
                keyColumn: "Id",
                keyValue: new Guid("4f965348-1db2-4212-88bf-1bc868338209"));

            migrationBuilder.DeleteData(
                table: "NiveliGjuhesor",
                keyColumn: "Id",
                keyValue: new Guid("81ebd457-1e9a-480b-bde1-d62196c51d75"));

            migrationBuilder.DeleteData(
                table: "NiveliGjuhesor",
                keyColumn: "Id",
                keyValue: new Guid("a5c0e948-be3d-4ebd-beba-8b0a9fc0285b"));

            migrationBuilder.DeleteData(
                table: "NiveliGjuhesor",
                keyColumn: "Id",
                keyValue: new Guid("c7c2b680-c679-4de2-83d0-28464165f115"));

            migrationBuilder.DeleteData(
                table: "NiveliGjuhesor",
                keyColumn: "Id",
                keyValue: new Guid("e52fa674-6854-4539-aeb8-89e716698f21"));

            migrationBuilder.DeleteData(
                table: "Institucioni",
                keyColumn: "Id",
                keyValue: new Guid("496cc2c1-cc09-4c64-a53d-9529c2486b48"));
        }
    }
}
