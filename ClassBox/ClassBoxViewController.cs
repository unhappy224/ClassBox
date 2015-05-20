using System;
using UIKit;
using CoreGraphics;
using PureLayout;

namespace ClassBox
{
    public class ClassBoxViewController : UIViewController
    {
        public int SelectIndex = (int)DateTime.Now.DayOfWeek - 1;

        public readonly ClassModel[] Classes;

        public ClassBoxViewController(IntPtr handle)
            : base(handle)
        {
        }

        public ClassBoxViewController(CGRect frame, ClassModel[] classes)
            : base()
        {
            Classes = classes;
            View.Frame = frame;  

        }

        public UITableView ClassTableView { get; private set; }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var leftView = new LeftTableView(LeftModelFactory.Create());
            var scv = new UIScrollView();
            ClassTableView = new UITableView();
             

            var datas = ClassCellModelFactory.CreateFromClassModel(Classes);

           
//            ClassTableView.Frame = new CGRect(0, 0, Constants.CellWidth * (Constants.DayInWeek - 1) + Constants.SelectCellWidth, View.Frame.Height);
           
           
            ClassTableView.Bounces = false;
            ClassTableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            ClassTableView.BackgroundColor = Constants.MainBackgroundColor;
            ClassTableView.Source = new ClassTableViewSource(this, datas, leftView);
            

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
             
        }

       
        public void OnClassCellTapped(object sender, GestureRecognizerEventArgs e)
        {
            if (e.Cell.Column == SelectIndex)
                return;
            SelectIndex = e.Cell.Column;
            ((ClassTableViewSource)ClassTableView.Source).Header = null;
            ClassTableView.ReloadData();
        }

        public void OnClassCellLongPressed(object sender, GestureRecognizerEventArgs e)
        {

        }


        private class ClassTableViewSource : UITableViewSource
        {
            private ClassBoxViewController _cbvc;
            public ClassCellModel[][] Datas;

            public UITableView LeftView;

            public ClassTableViewSource(ClassBoxViewController cbvc, ClassCellModel[][] datas, UITableView leftView)
            { 
                Datas = datas;
                LeftView = leftView;
                _cbvc = cbvc;
            }

            public override void Scrolled(UIScrollView scrollView)
            { 
                if (LeftView == null)
                    return;
                var offsetY = _cbvc.ClassTableView.ContentOffset.Y;
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
                    cell = new ClassRow(_cbvc); 
                cell.WillDisplay(Datas[indexPath.Row], _cbvc.SelectIndex, indexPath.Row);
                cell.SelectionStyle = UITableViewCellSelectionStyle.None;
                return cell;
            }


            public override nfloat GetHeightForHeader(UITableView tableView, nint section)
            {
                return Constants.HeaderHeight;
            }


            public HeaderRow Header;

            public override UIView GetViewForHeader(UITableView tableView, nint section)
            {
                if (Header == null)
                {
                    Header = new HeaderRow(HeaderModelFactory.Create());
                    Header.Frame = new CGRect(0, 0, tableView.Frame.Width, Constants.HeaderHeight);
                    Header.Display(_cbvc.SelectIndex);
                }
                return Header;
            }

            
        }
    }
}

