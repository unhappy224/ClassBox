using System;

using UIKit;
using PureLayout;
using CoreGraphics;

namespace ClassBox
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle)
            : base(handle)
        {
        }

        

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            var cell = new LeftTableView.LeftCell();
            View.Add(cell);
//            cell.Frame = new CoreGraphics.CGRect(100, 100, Constants.LeftWidth, Constants.LeftHeight);
            cell.AutoCenterInSuperview();
            
            cell.AutoSetDimensionsToSize(new CoreGraphics.CGSize(Constants.LeftWidth, Constants.LeftHeight));
          
           
            cell.LB_Time.Text = "8:40";
            cell.LB_Node.Text = "1";

            var vc = new ClassBoxViewController(new CGRect(0, 50, View.Frame.Width, View.Frame.Height - 50), new []
                {
                    new ClassModel(){ DayInWeek = 1, Node = 1, Name = "高等数学", Room = "一教2-3" },
                    new ClassModel(){ DayInWeek = 1, Node = 2, Name = "复变函数", Room = "一教2-4" },
                    new ClassModel(){ DayInWeek = 2, Node = 4, Name = "体  育", Room = "田径场" },
                    new ClassModel(){ DayInWeek = 2, Node = 5, Name = "大学物理", Room = "三教105" },
                    new ClassModel(){ DayInWeek = 3, Node = 2, Name = "线性代数", Room = "五教2-3" },
                    new ClassModel(){ DayInWeek = 4, Node = 3, Name = "信号与系统", Room = "一教603" },
                    new ClassModel(){ DayInWeek = 5, Node = 4, Name = "无线通信", Room = "信息楼综合班-3" },
                    new ClassModel(){ DayInWeek = 6, Node = 6, Name = "模拟电路", Room = "1-1" }

                });
            View.Add(vc.View);
           
        }

        

        partial void UIButton10_TouchUpInside(UIButton sender)
        {
           

        }
    }
}

