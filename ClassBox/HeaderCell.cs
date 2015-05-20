using System;
using UIKit;
using CoreGraphics;

namespace ClassBox
{
    public class HeaderCell : UIView
    {
        public UILabel LB_DayOfWeek;
        public UILabel LB_Date;

        public HeaderCell(CGRect frame, bool selected, HeaderModel model)
            : base(frame)
        {
            LB_DayOfWeek = new UILabel(new CGRect(0, 0, frame.Width, frame.Height * .6f));
            LB_DayOfWeek.TextAlignment = UITextAlignment.Center;
            LB_DayOfWeek.TextColor = selected ? UIColor.FromRGB(46, 142, 206) : UIColor.Black;
            LB_DayOfWeek.Text = model.DayOfWeek;
            Add(LB_DayOfWeek);


            LB_Date = new UILabel(new CGRect(0, frame.Height * .6f, frame.Width, frame.Height * .4f));
            LB_Date.TextColor = selected ? UIColor.FromRGB(46, 142, 206) : UIColor.Black;
            LB_Date.TextAlignment = UITextAlignment.Center;
            LB_Date.Text = model.Date;

            Add(LB_Date);
            BackgroundColor = UIColor.White;
        }
    }
}

