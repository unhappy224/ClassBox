using System;
using UIKit;

namespace ClassBox
{
    public static class Helper
    {
        static Random ran = new Random();

        public static  UIColor GetRandomColor()
        {
            return UIColor.FromRGB(ran.Next(255), ran.Next(255), ran.Next(255));
        }
    }
}

