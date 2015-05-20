using System;
using UIKit;
using CoreGraphics;

namespace ClassBox
{
    public class ClassRow : UITableViewCell
    {
        public const string CellKey = "ClassRow";

        public   ClassCellModel[] ModelInRow;

        private ClassBoxViewController _cbvc;

        public ClassRow(ClassBoxViewController cbvc)
        {
            _cbvc = cbvc;
        }

        public void WillDisplay(ClassCellModel[] modelInRow, int currentSelect, int row)
        {
            ModelInRow = modelInRow;
            nfloat currentLeft = 0;
            for (int i = 0; i < modelInRow.Length; i++)
            {
                var view = new ClassCell(modelInRow[i], row, i);
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
                view.Tapped += _cbvc.OnClassCellTapped;
                view.LongPressed += _cbvc.OnClassCellLongPressed;
            }

            var Separator = new UIView(new CGRect(0, 0, currentLeft, 1));
            Separator.BackgroundColor = UIColor.LightGray;
            this.ContentView.AddSubview(Separator); 
        }
    }
}

