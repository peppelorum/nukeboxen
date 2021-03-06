using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pitchserver.Models;

namespace pitchserver.Controllers
{
    public class MusicController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public MusicController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Player()
        {
            return View();
        }

        public IEnumerable<string> GetFiles()
        {
            string folder = "Music/Funk/";
            string path = Directory.GetCurrentDirectory() + "/wwwroot/"+ folder;
            string url = $"{Request.Scheme}://{Request.Host.Value}/";

            Console.WriteLine(Directory.GetCurrentDirectory());
            Console.WriteLine(Directory.GetParent(Directory.GetCurrentDirectory()));

            Console.WriteLine(path);
            Console.WriteLine(url);
            Console.WriteLine(Request.Path);

            List<string> files = new List<string>();
            DirectoryInfo dirInfo = new DirectoryInfo(path);

            foreach (FileInfo fInfo in dirInfo.GetFiles())
            {
                files.Add(url + folder + fInfo.Name);      
            }

            return files;
        }
        public class FilePath
        {
            public string path { get; set; }
        }

    }
}
