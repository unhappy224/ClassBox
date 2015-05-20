using System;
using System.Linq;

namespace ClassBox
{
    public class HeaderModel
    {
        public string DayOfWeek{ get; set; }

        public string Date{ get; set; }

        public HeaderModel(DateTime date)
        {
            Date = date.ToString("M-d");
            DayOfWeek = date.ToString("ddd");
        }
    }

    public class HeaderModelFactory
    {
        public static HeaderModel[] Create()
        {
            var monday = GetMondayDate(DateTime.Now);
            return Enumerable.Range(0, 7).Select(i => new HeaderModel(monday.AddDays(i))).ToArray();
        }

        /// <summary> 
        /// 计算某日起始日期（礼拜一的日期） 
        /// </summary> 
        /// <param name="someDate">该周中任意一天</param> 
        /// <returns>返回礼拜一日期，后面的具体时、分、秒和传入值相等</returns> 
        public static DateTime GetMondayDate(DateTime someDate)
        {
            int i = someDate.DayOfWeek - DayOfWeek.Monday;
            if (i == -1)
                i = 6;// i值 > = 0 ，因为枚举原因，Sunday排在最前，此时Sunday-Monday=-1，必须+7=6。 
            TimeSpan ts = new TimeSpan(i, 0, 0, 0);
            return someDate.Subtract(ts);
        }
    }
}

