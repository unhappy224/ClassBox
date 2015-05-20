using System;
using UIKit;
using CoreGraphics;

namespace ClassBox
{
    public class ClassRow : UITableViewCell
    {
        public const string CellKey = "ClassRow";

        public   ClassCellModel[] ModelInRow;

        public ClassRow()
        {
           
        }

        public void WillDisplay(ClassCellModel[] modelInRow, int currentSelect)
        {
            ModelInRow = modelInRow;
            nfloat currentLeft = 0;
            for (int i = 0; i < modelInRow.Length; i++)
            {
                var view = new ClassCell(modelInRow[i]);
                if (currentSelect == i)
                {
                    view.Frame = new  CGRect(currentLeft, 1, Constants.SelectCellWidth, Constants.CellHeight - 1);
                    currentLeft += Constants.SelectCellWidth;
                }
                else
                {
                    view.Frame = new  CGRect(currentLeft, 1, Constants.CellWidth, Constants.CellHeight - 1);
                    currentLeft += Constants.CellWidth;
                }
                this.ContentView.AddSubview(view); 
            }

            var Separator = new UIView(new CGRect(0, 0, currentLeft, 1));
            Separator.BackgroundColor = UIColor.LightGray;
            this.ContentView.AddSubview(Separator); 
        }
    }
}

