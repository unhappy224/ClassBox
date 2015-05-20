using System;
using UIKit;

namespace ClassBox
{
    public static class Constants
    {
        public static float CellHeight = 200f;
        public static float CellWidth = CellHeight * .6f;

        public static float HeaderHeight = 50f;
        public static float SelectCellWidth = CellWidth * 1.5f;

        public static float LeftHeight = CellHeight / 2;
        public static float LeftWidth = CellWidth * .8f;

        //一周7天
        public static int DayInWeek = 7;

        //每天5大节课
        public static int NodeInDay = 5;

        public static UIColor MainBackgroundColor = UIColor.FromRGB(246, 250, 251);
    }
}

