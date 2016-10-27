using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ReadFromText
{
    static class Program
    {

        static void Main(string[] args)
        {
            //string[] lines = System.IO.File.ReadAllLines(@"C:\Users\samil.altin\Desktop\FileLog.txt");
            var lines = System.IO.File.ReadAllText(@"C:\Logs\RollingFileLog.txt");

            var reg = new Regex(@"\-BEGIN\-(?<Content>(.|\n)*?)\-END\-");
            var matches = reg.Matches(lines);
            foreach (Match match in matches)
            {
                var message = match.Groups["Content"].Value;
                string[] cells = message.Split('|');
                //var cell1 = cells[0].Trim(new char[] { '\r', '\n' }).Trim();
                var cell1 = cells[0].TrimNewLines();
                var cell2 = cells[1].TrimNewLines().TrimCharacter();
                var cell3 = cells[2].TrimNewLines();
                var cell4 = cells[3].TrimNewLines();
                MongoClient client = new MongoClient();
                //var server = client.GetServer();
                //var db = server.GetDatabase("logsDB");
                var db = client.GetDatabase("logsDB");
                var collection = db.GetCollection<Log>("Log");
                Log log = new Log()
                {
                    Date = cell1,
                    Logger = cell2,
                    Level = cell3,
                    Message = cell4

                };
                collection.InsertOne(log);
            }
        }

        public class Log
        {
            public ObjectId Id { get; set; }
            public string Date { get; set; }
            public string Logger { get; set; }
            public string Level { get; set; }
            public string Message { get; set; }

        }

       
    }
}

