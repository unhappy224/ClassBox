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

            var vc = new ClassBoxViewController(new CGRect(0, 50, View.Frame.Width, 600));
            View.Add(vc.View);
             
        }

        

        partial void UIButton10_TouchUpInside(UIButton sender)
        {
           

        }
    }
}

