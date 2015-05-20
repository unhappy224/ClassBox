using System;
using UIKit;
using CoreGraphics;
using PureLayout;

namespace ClassBox
{
    public class ClassBoxViewController : UIViewController
    {
        public ClassBoxViewController(IntPtr handle)
            : base(handle)
        {
        }

        public ClassBoxViewController(CGRect frame)
            : base()
        {
            View.Frame = frame; 
        }

        public UITableView ClassTableView { get; private set; }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var leftView = new LeftTableView(LeftModelFactory.Create());
            var scv = new UIScrollView();
            ClassTableView = new UITableView();
             

            var datas = ClassCellModelFactory.CreateFromClassModel(new []
                {
                    new ClassModel(){ DayInWeek = 1, Node = 1, Name = "1+1", Room = "1-1" },
                    new ClassModel(){ DayInWeek = 1, Node = 2, Name = "1+1", Room = "1-1" },
                    new ClassModel(){ DayInWeek = 2, Node = 4, Name = "1+1", Room = "1-1" },
                    new ClassModel(){ DayInWeek = 2, Node = 5, Name = "1+1", Room = "1-1" },
                    new ClassModel(){ DayInWeek = 3, Node = 2, Name = "1+1", Room = "1-1" },
                    new ClassModel(){ DayInWeek = 4, Node = 3, Name = "1+1", Room = "1-1" },
                    new ClassModel(){ DayInWeek = 5, Node = 4, Name = "1+1", Room = "1-1" },
                    new ClassModel(){ DayInWeek = 6, Node = 6, Name = "1+1", Room = "1-1" }
                            
                });

           
//            ClassTableView.Frame = new CGRect(0, 0, Constants.CellWidth * (Constants.DayInWeek - 1) + Constants.SelectCellWidth, View.Frame.Height);
           
           
            ClassTableView.Bounces = false;
            ClassTableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            ClassTableView.BackgroundColor = Constants.MainBackgroundColor;
            ClassTableView.Source = new ClassTableViewSource(ClassTableView, datas, leftView);
            

            View.Add(scv);
            scv.AutoPinEdgesToSuperviewEdgesWithInsets(new UIEdgeInsets(0, Constants.LeftWidth, 0, 0));
            scv.AddSubview(ClassTableView);
            ClassTableView.AutoSetDimension(ALDimension.Width, Constants.CellWidth * (Constants.DayInWeek - 1) + Constants.SelectCellWidth);
            ClassTableView.AutoMatchDimension(ALDimension.Height, ALDimension.Height, scv);
            ClassTableView.AutoPinEdgeToSuperviewEdge(ALEdge.Top);
            ClassTableView.AutoPinEdgeToSuperviewEdge(ALEdge.Left);
            scv.Bounces = false;
           
            scv.ContentSize = new CGSize(Constants.CellWidth * (Constants.DayInWeek - 1) + Constants.SelectCellWidth, 0);


            View.Add(leftView);
            leftView.AutoPinEdgesToSuperviewEdgesWithInsets(new UIEdgeInsets(Constants.HeaderHeight, 0, 0, 0), ALEdge.Right);
            leftView.AutoPinEdge(ALEdge.Right, ALEdge.Left, scv); 
            leftView.ScrollEnabled = false;
            this.View.BackgroundColor = UIColor.Orange;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        void ClassTableView_Scrolled(object sender, EventArgs e)
        {
            
        }

        private class ClassTableViewSource : UITableViewSource
        {
            public UITableView tableView;
            public ClassCellModel[][] Datas;

            public UITableView LeftView;

            public ClassTableViewSource(UITableView tablaView, ClassCellModel[][] datas, UITableView leftView)
            {
                this.tableView = tablaView;
                Datas = datas;
                LeftView = leftView;
            }

            public override void Scrolled(UIScrollView scrollView)
            {
//                CGFloat offsetY= self.myTableView.contentOffset.y;
//                CGPoint timeOffsetY=self.timeView.timeTableView.contentOffset;
//                timeOffsetY.y=offsetY;
//                self.timeView.timeTableView.contentOffset=timeOffsetY;
//                if(offsetY==0){
//                    self.timeView.timeTableView.contentOffset=CGPointZero;
//                }
                if (LeftView == null)
                    return;
                var offsetY = tableView.ContentOffset.Y;
                var leftOffset = LeftView.ContentOffset;
                LeftView.ContentOffset = new CGPoint(leftOffset.X, offsetY);
                if (offsetY == 0)
                {
                    LeftView.ContentOffset = CGPoint.Empty;
                }
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return Datas.Length;
            }

            public override nfloat GetHeightForRow(UITableView tableView, Foundation.NSIndexPath indexPath)
            {
                return Constants.CellHeight;
            }

            public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
            {
                ClassRow cell = tableView.DequeueReusableCell(ClassRow.CellKey) as ClassRow;
                // if there are no cells to reuse, create a new one
                if (cell == null)
                    cell = new ClassRow(); 
                cell.WillDisplay(Datas[indexPath.Row], (int)DateTime.Now.DayOfWeek - 1);
                cell.SelectionStyle = UITableViewCellSelectionStyle.None;
                return cell;
            }

            

            public override nfloat GetHeightForHeader(UITableView tableView, nint section)
            {
                return Constants.HeaderHeight;
            }

            public HeaderRow header;

            public override UIView GetViewForHeader(UITableView tableView, nint section)
            {
                if (header == null)
                {
                    header = new HeaderRow(HeaderModelFactory.Create());
                    header.Frame = new CGRect(0, 0, tableView.Frame.Width, Constants.HeaderHeight);
                    header.Display((int)DateTime.Now.DayOfWeek - 1);
                }
                return header;
            }

            
        }
    }
}

