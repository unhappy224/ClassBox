using System;
using UIKit;
using CoreGraphics;


namespace ClassBox
{
    public class LeftTableView : UITableView
    {
        public readonly LeftModel[] Models;

        public LeftTableView(LeftModel[] models)
        {
            Models = models;
            this.Source = new LeftTableViewSource(models);
            this.Bounces = false;
            this.SeparatorStyle = UITableViewCellSeparatorStyle.None;
        }

        public class LeftTableViewSource : UITableViewSource
        {
            public readonly LeftModel[] Models;

            public LeftTableViewSource(LeftModel[] models)
            {
                Models = models;
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return Models.Length;
            }

            public override nfloat GetHeightForRow(UITableView tableView, Foundation.NSIndexPath indexPath)
            {
                return Constants.LeftHeight;
            }

            public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
            {
                LeftCell cell = tableView.DequeueReusableCell(LeftCell.CellKey) as LeftCell;
                // if there are no cells to reuse, create a new one
                if (cell == null)
                    cell = new LeftCell(); 
                cell.SelectionStyle = UITableViewCellSelectionStyle.None;
                cell.WillDisplay(Models[indexPath.Row]);
                return cell;
            }
        }

        #region LeftCell

        public class LeftCell : UITableViewCell
        {
            public static string CellKey = "LeftCell";

            public UILabel LB_Node;
            public UILabel LB_Time;

            public LeftCell()
            {
                LB_Time = new UILabel(new CGRect(0, 0, Constants.LeftWidth, Constants.LeftHeight * 0.4));
                LB_Time.TextAlignment = UITextAlignment.Center;
                LB_Time.Font = UIFont.SystemFontOfSize(10);
                LB_Time.TextColor = UIColor.DarkGray;
 
                LB_Node = new UILabel(new CGRect(0, Constants.LeftHeight * 0.4, Constants.LeftWidth, Constants.LeftHeight * 0.6));
                LB_Node.TextAlignment = UITextAlignment.Center;
                LB_Time.Font = UIFont.SystemFontOfSize(14);
                LB_Node.TextColor = UIColor.Black;

                this.Layer.BorderWidth = .5f;
                this.Layer.BorderColor = UIColor.Black.CGColor;
                this.ContentView.Add(LB_Time);
                this.ContentView.Add(LB_Node);
            }

            public void WillDisplay(LeftModel model)
            {
                LB_Node.Text = model.Node.ToString();
                LB_Time.Text = model.Time;
            }
        }

        #endregion
    }
}

