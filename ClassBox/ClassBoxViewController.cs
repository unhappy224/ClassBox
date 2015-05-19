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

            ClassTableView = new UITableView();
            ClassTableView.Frame = new CGRect(0, 0, Constants.CellWidth * Constants.DayInWeek, View.Frame.Height);
            ClassTableView.Bounces = false;
            ClassTableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            
            ClassTableView.Source = new ClassTableViewSource(ClassTableView, datas);
          
            var scv = new UIScrollView();
            View.Add(scv);
            scv.AutoPinEdgesToSuperviewEdgesWithInsets(UIEdgeInsets.Zero);
            scv.AddSubview(ClassTableView);
            scv.Bounces = false;
            scv.ContentSize = new CGSize(ClassTableView.Frame.Width, 0);

            scv.BackgroundColor = UIColor.Orange;
            View.BackgroundColor = UIColor.Orange;
             
        }

        private class ClassTableViewSource : UITableViewSource
        {
            public UITableView tableView;
            public ClassCellModel[][] Datas;

            public ClassTableViewSource(UITableView tablaView, ClassCellModel[][] datas)
            {
                this.tableView = tablaView;
                Datas = datas;
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
                UITableViewCell cell = tableView.DequeueReusableCell(ClassRow.CellKey);
                // if there are no cells to reuse, create a new one
                if (cell == null)
                    cell = new ClassRow(Datas[indexPath.Row], -1); 
                cell.SelectionStyle = UITableViewCellSelectionStyle.None;
                return cell;
            }

            

            public override nfloat GetHeightForHeader(UITableView tableView, nint section)
            {
                return Constants.HeaderHeight;
            }

            public UIView headView;

            public override UIView GetViewForHeader(UITableView tableView, nint section)
            {
                if (headView == null)
                {
                    headView = new UIView(new CGRect(0, 0, tableView.Frame.Width, 50));
                    headView.BackgroundColor = UIColor.Red;
                }
                return headView;
            }

            
        }
    }
}

