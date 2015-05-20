using System;
using UIKit;
using CoreGraphics;

namespace ClassBox
{
    public class HeaderRow :  UIView
    {
        public readonly HeaderModel[] Models;

        public HeaderRow(HeaderModel[] models)
        {
            this.Models = models;
        }

        public void Display(int selectIndex)
        {
            float left = 0;
            for (int i = 0; i < Models.Length; i++)
            {
                var cell = new HeaderCell(
                               new CGRect(left, 0, selectIndex == i ? Constants.SelectCellWidth : Constants.CellWidth, Constants.HeaderHeight),
                               selectIndex == i,
                               Models[i]);
                left += selectIndex == i ? Constants.SelectCellWidth : Constants.CellWidth;
                Add(cell);
            }

            this.SetNeedsDisplay();
        }
    }
}

