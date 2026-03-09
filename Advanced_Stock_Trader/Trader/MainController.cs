using Advanced_Stock_Trader.Trader.DataBase;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advanced_Stock_Trader.Trader
{
    public class MainController : Controller
    {
        DB _DB;
        GetDB _GetDB;
        SetDB _SetDB;

        public MainController(DB db, GetDB getdb, SetDB setdb)
        {
            _DB = db;
            _GetDB = getdb;
            _SetDB = setdb;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
