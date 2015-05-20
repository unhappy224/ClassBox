using System;
using UIKit;
using PureLayout;

namespace ClassBox
{
    public class ClassCell : UIView,IUITextViewDelegate
    {
        public readonly ClassCellModel Model;

        public readonly int Row;
        public readonly int Column;

        public ClassCell(ClassCellModel model, int row, int column)
        {
            Model = model; 
            Row = row;
            Column = column;
            switch (model.Type)
            {
                case ClassCellModelType.None:
                    this.BackgroundColor = Constants.MainBackgroundColor;
                    break;
                case ClassCellModelType.Class:
                    var tv = new UITextView();
                    this.Add(tv);
                    tv.AutoPinEdgesToSuperviewEdgesWithInsets(UIEdgeInsets.Zero);
                    tv.BackgroundColor = model.Background; 
                    tv.TextColor = model.TextColor;  
                    tv.Delegate = this;
                    tv.Text = model.ClassName + Environment.NewLine + "@" + model.ClassRoom;
                    tv.Font = UIFont.SystemFontOfSize(16);
                    var ges = new UITapGestureRecognizer(r =>
                        { 
                            if (Tapped != null)
                                Tapped(this, new GestureRecognizerEventArgs(r, this));
                        });
                    tv.AddGestureRecognizer(ges);
                   
                    var longes = new UILongPressGestureRecognizer(r =>
                        {
                            if (LongPressed != null)
                                LongPressed(this, new GestureRecognizerEventArgs(r, this));
                        });
                    break;
            }
        }

        public event EventHandler<GestureRecognizerEventArgs> Tapped;

        public event EventHandler<GestureRecognizerEventArgs> LongPressed;

        [Foundation.Export("textViewShouldBeginEditing:")]
        public bool EditingStarted(UITextView textView)
        {
            return false;
        }
    }

    public class GestureRecognizerEventArgs :EventArgs
    {
        public readonly UIGestureRecognizer Recognizer;
        public readonly ClassCell Cell;

        public GestureRecognizerEventArgs(UIGestureRecognizer Recognizer, ClassCell cell)
        {
            this.Recognizer = Recognizer;
            Cell = cell;
        }
    }
}

