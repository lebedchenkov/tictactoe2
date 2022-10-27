using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TicTac.Models;

namespace TicTac.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static GameModel model;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            model = new GameModel();
        }

        [HttpGet]
        public IActionResult Index(string id) => View();

        [Route("Home/GetInfo/{a1?}/{a2?}/{a3?}/{b1?}/{b2?}/{b3?}/{c1?}/{c2?}/{c3?}")]
        public IActionResult GetInfo(string a1, string a2, string a3, string b1, string b2, string b3, string c1, string c2, string c3, GameModel model)
        {
            

            List<string> list = new List<string>() { a1, a2, a3, b1, b2, b3, c1, c2, c3 };
            string[] win1 = { a1, a2, a3 };
            string[] win2 = { b1, b2, b3 };
            string[] win3 = { c1, c2, c3 };

            string[] win4 = { a1, b1, c1 };
            string[] win5 = { a2, b2, c2 };
            string[] win6 = { a3, b3, c3 };

            string[] win7 = { a1, b2, c3 };
            string[] win8 = { a3, b2, c1 };

            string[][] winComb = { win1, win2, win3, win4, win5, win6, win7, win8 };

            foreach (string[] e in winComb)
            {
                
                int compare_1 = string.Compare(e[0], e[1]);
                int compare_2 = string.Compare(e[1], e[2]);
                int compare_3 = string.Compare(e[0], e[2]);
                if (compare_1 == 0
                    && compare_2 == 0
                    && compare_3 == 0
                    && !String.IsNullOrEmpty(e[0])
                    && !String.IsNullOrEmpty(e[1])
                    && !String.IsNullOrEmpty(e[2]))
                {
                    list.Add($"Победа {e[0]}");
                    if (list[9] == "Победа X") ViewBag.Winner = "Победа крестиков";
                    else if (e[0] == "O") ViewBag.Winner = "Победа ноликов";
                    return Json(list);
                }
                int status = 0;
                foreach (string l in list)
                {
                    if (l == null) status++;
                }
                if (status == 0)
                {
                    list.Add("Ничья");
                    return Json(list);
                }
            }

            
            if (a1 == "O" && a2 == "O" && a3 == null) list[2] = "O";
            else if (a1 == "O" && a2 == null && a3 == "O") list[1] = "O";
            else if (a1 == null && a2 == "O" && a3 == "O") list[0] = "O";

            else if (b1 == "O" && b2 == "O" && b3 == null) list[5] = "O";
            else if (b1 == "O" && b2 == null && b3 == "O") list[4] = "O";
            else if (b1 == null && b2 == "O" && b3 == "O") list[3] = "O";

            else if (c1 == "O" && c2 == "O" && c3 == null) list[8] = "O";
            else if (c1 == "O" && c2 == null && c3 == "O") list[7] = "O";
            else if (c1 == null && c2 == "O" && c3 == "O") list[6] = "O";

            else if (a1 == "O" && b1 == "O" && c1 == null) list[6] = "O";
            else if (a1 == "O" && b1 == null && c1 == "O") list[3] = "O";
            else if (a1 == null && b1 == "O" && c1 == "O") list[0] = "O";

            else if (a2 == "O" && b2 == "O" && c2 == null) list[7] = "O";
            else if (a2 == "O" && b2 == null && c2 == "O") list[4] = "O";
            else if (a2 == null && b2 == "O" && c2 == "O") list[1] = "O";

            else if (a3 == "O" && b3 == "O" && c3 == null) list[8] = "O";
            else if (a3 == "O" && b3 == null && c3 == "O") list[5] = "O";
            else if (a3 == null && b3 == "O" && c3 == "O") list[2] = "O";

            else if (a1 == "O" && b2 == "O" && c3 == null) list[8] = "O";
            else if (a1 == "O" && b2 == null && c3 == "O") list[4] = "O";
            else if (a1 == null && b2 == "O" && c3 == "O") list[0] = "O";

            else if (a3 == "O" && b2 == "O" && c1 == null) list[6] = "O";
            else if (a3 == "O" && b2 == null && c1 == "O") list[4] = "O";
            else if (a3 == null && b2 == "O" && c1 == "O") list[2] = "O";

            
            else if (a1 == "X" && a2 == "X" && a3 == null) list[2] = "O";
            else if (a1 == "X" && a2 == null && a3 == "X") list[1] = "O";
            else if (a1 == null && a2 == "X" && a3 == "X") list[0] = "O";

            else if (b1 == "X" && b2 == "X" && b3 == null) list[5] = "O";
            else if (b1 == "X" && b2 == null && b3 == "X") list[4] = "O";
            else if (b1 == null && b2 == "X" && b3 == "X") list[3] = "O";

            else if (c1 == "X" && c2 == "X" && c3 == null) list[8] = "O";
            else if (c1 == "X" && c2 == null && c3 == "X") list[7] = "O";
            else if (c1 == null && c2 == "X" && c3 == "X") list[6] = "O";

            else if (a1 == "X" && b1 == "X" && c1 == null) list[6] = "O";
            else if (a1 == "X" && b1 == null && c1 == "X") list[3] = "O";
            else if (a1 == null && b1 == "X" && c1 == "X") list[0] = "O";

            else if (a2 == "X" && b2 == "X" && c2 == null) list[7] = "O";
            else if (a2 == "X" && b2 == null && c2 == "X") list[4] = "O";
            else if (a2 == null && b2 == "X" && c2 == "X") list[1] = "O";

            else if (a3 == "X" && b3 == "X" && c3 == null) list[8] = "O";
            else if (a3 == "X" && b3 == null && c3 == "X") list[5] = "O";
            else if (a3 == null && b3 == "X" && c3 == "X") list[2] = "O";

            else if (a1 == "X" && b2 == "X" && c3 == null) list[8] = "O";
            else if (a1 == "X" && b2 == null && c3 == "X") list[4] = "O";
            else if (a1 == null && b2 == "X" && c3 == "X") list[0] = "O";

            else if (a3 == "X" && b2 == "X" && c1 == null) list[6] = "O";
            else if (a3 == "X" && b2 == null && c1 == "X") list[4] = "O";
            else if (a3 == null && b2 == "X" && c1 == "X") list[2] = "O";

           
            else
            {
                Random rnd = new Random();
                while (true)
                {
                    int rand = rnd.Next(0, 8);

                    if (list[rand] == null)
                    {
                        list[rand] = "O"; break;
                    }
                }
            }

            win1[0] = list[0]; win1[1] = list[1]; win1[2] = list[2];   // 1
            win2[0] = list[3]; win2[1] = list[4]; win2[2] = list[5];   // 2
            win3[0] = list[6]; win3[1] = list[7]; win3[2] = list[8];   // 3

            win4[0] = list[0]; win4[1] = list[3]; win4[2] = list[6];   // 4
            win5[0] = list[1]; win5[1] = list[4]; win5[2] = list[7];   // 5
            win6[0] = list[2]; win6[1] = list[5]; win6[2] = list[8];   // 6

            win7[0] = list[0]; win7[1] = list[4]; win7[2] = list[8];   // 7
            win8[0] = list[2]; win8[1] = list[4]; win8[2] = list[6];   // 8

            string[][] result = { win1, win2, win3, win4, win5, win6, win7, win8 };

            foreach (string[] e in result)
            {
             
                int compare_1 = string.Compare(e[0], e[1]);
                int compare_2 = string.Compare(e[1], e[2]);
                int compare_3 = string.Compare(e[0], e[2]);
                if (compare_1 == 0
                    && compare_2 == 0
                    && compare_3 == 0
                    && !String.IsNullOrEmpty(e[0])
                    && !String.IsNullOrEmpty(e[1])
                    && !String.IsNullOrEmpty(e[2]))
                {
                   
                    list.Add($"Победа {e[0]}");
                    if (list[9] == "Победа X") ;
                    else if (e[0] == "O") ;
                    return Json(list);
                }
                int status = 0;
                foreach (string l in list)
                {
                    if (l == null) status++;
                }
                if (status == 0)
                {
                    list.Add("Ничья");
                    return Json(list);
                }
            }

            return Json(list);
        }

        public IActionResult Game(string id) => View();

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}