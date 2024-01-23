using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SkillQuizLight;
using SkillQuizLight.Models;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace SkillQuizLight
{
    public class Program
    {
        public const string cResetPassword = "Bingo";
        public const string cNmTypLogIsQuestOpenUser = "IsQuestOpenUser";

        public const int cCancel = 0;
        public const int cQuit = 1;
        public const int cBlocked = 2;

        public static mUser currentUser { get; set; }
        public static mUserExam_Display currentUserExam{ get; set; }
        public static mExamTest_Questionnaire_Display currentTest_Questionnaire { get; set; }
        public static mExamQuestionnaire_Display currentQuestionnaire { get; set; }
        public static HttpClient client = new HttpClient();
        public static string vCurrentPge = "";

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            //Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
            //CreateHostBuilder(args).Build().Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<test>();
        //        });
    }
}
