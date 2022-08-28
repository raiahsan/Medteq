﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class reset_password_template : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "EmailTemplates",
                type: "varchar(150)",
                unicode: false,
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "EmailTemplates",
                type: "varchar(150)",
                unicode: false,
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "EmailTemplates",
                type: "varchar(500)",
                unicode: false,
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "EmailTemplates",
                type: "varchar(max)",
                unicode: false,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "ID", "Active", "Body", "Description", "Name", "Subject" },
                values: new object[] { 1, true, "<!DOCTYPE html>  <html xmlns='http://www.w3.org/1999/xhtml'>  <head>      <link href='https://fonts.googleapis.com/css2?family=Roboto&display=swap'  rel='stylesheet' />      <style type='text/css'>            @font-face {              font-family: Roboto;              src: url('Roboto');               src: url('Roboto-webfont.eot?#iefix') format('embedded-opentype'), url('Roboto-webfont.woff')  format('woff'), url('Roboto-webfont.ttf') format('truetype'), url('Roboto-webfont.svg#Sri-TSCRegular') format('svg');     font-weight: normal;              font-style: normal;          }            body {              font-family: Roboto, serif;    font-size: 12px;              font-style: normal;              font-weight: 400;              padding: 0;      text-align: center;              background: #f6f6f6;          }            .bigscreen1 {              padding-bottom: 20px;    border-left: 40px solid #006aff;              border-right: 40px solid #006aff;          }            .bigscreen {     padding-bottom: 20px;              border-left: 40px solid #006aff;              border-right: 40px solid #006aff;      border-top: 30px solid #006aff;          }          .innertablewidth {              width: 60%;          }    @media only screen and (max-width: 600px) {              .bigscreen {                  padding-bottom: 20px;     border-left: 0;                  border-right: 0;                  border-top: 0;              }                .bigscreen1 {    padding-bottom: 20px;                  border-left: 0;                  border-right: 0;              }    .innertablewidth {                  width: 90%;              }          }      </style>      <meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />      <meta name='viewport' content='width=device-width, initial-scale=1.0' />  </head>  <body>    <table border='0' cellpadding='0' cellspacing='0' width='100%'>            <tr>              <td style='padding-bottom: 30px; padding-top: 10px; background: #f6f6f6'>                   <table class='innertablewidth' align='center' border='0' cellpadding='0' cellspacing='0'>                 <tr>                            <td style='padding-top:10px; background-color: #006aff'></td>              </tr>                      <tr>                              <td align='center' bgcolor='#ffffff' class='bigscreen' style='padding-top:30px;'>      <P style='padding-top:5px; padding-left: 10px;padding-right: 10px;width: 100%;max-width: 255px;font-size: 25px;'>   <b>Medteq</b> </p>                           </td>                        </tr>                      <tr>       <td align='center' bgcolor='#ffffff' class='bigscreen1' style='color: #006aff; font-weight: bold; font-size: 24px;  line-height: 29px; padding-top: 15px;'>                                Hi [First Name]                           </td>                      </tr>                      <tr>                            <td bgcolor='#ffffff' style='padding-bottom: 30px; padding-right: 40px; padding-left: 40px;'>   <table border='0' cellpadding='0' cellspacing='0' width='100%'>                                  <tr>      <td style='padding-top:20px; font-size: 16px; line-height: 23px; color: #000000; text-align:left;'>          We’ve received a request to reset your password, if you did not submit this request please ignore this email.   Click on the link below to reset your password..<br/> <b><a href='[URL]'</a>Click Here</b>      </td>                                  </tr>                                    <tr>       <td style='padding-top:20px; color: #000; font-weight: 500; font-size: 16px;line-height:19px; text-align:left;'>   </td>                                  </tr>                                   <tr>                 <td align='center' style='padding-top:30px; font-weight: 400; letter-spacing: 0px; font-size: 32px; line-height: 38px;  color: #006aff;'>                                            Have a great day,                                      </td>     </tr>                                  <tr>                                         <td align='center' style='padding-bottom:15px; font-weight: 900; letter-spacing: 0px; font-size: 32px; line-height: 38px; color: #006aff;'>                                            The Medteq                                      </td>                                  </tr>                              </table>                          </td>                      </tr>                  </table>              </td>            </tr>      </table>  </body></html>", "Reset Password Email", "Reset_Password_Email", "Reset Password Email" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "EmailTemplates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldUnicode: false,
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "EmailTemplates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldUnicode: false,
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "EmailTemplates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldUnicode: false,
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "EmailTemplates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false);
        }
    }
}
