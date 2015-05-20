using System;

using UIKit;
using PureLayout;

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
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
          

        }

        partial void UIButton10_TouchUpInside(UIButton sender)
        {
            this.ShowDetailViewController(new ClassBoxViewController(View.Frame), null);


        }
    }
}

