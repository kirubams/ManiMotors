using MM.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Utilities
{
    public static class GlobalSetup
    {
        public static int Userid = 1;
        public static string[] debitTypes = { "BOTH","BANK", "CASH" };
        public static string[] colors = colorsarr();
        public static string[] colors2 = colorsarr();
        public static string[] colors3 = colorsarr();
        public static string AdminPassword = "admin@123";
        public static string StaffPassword = "manimotors";

        public static string[] colorsarr()
        {
            string[] colorArray;
            using (var entities = new ManiMotorsEntities1())
            {
                colorArray = entities.Colors.Select(x => x.Description).ToArray();
            }
            return colorArray;
        }
    }
}
