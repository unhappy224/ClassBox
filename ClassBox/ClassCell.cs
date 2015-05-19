using System;
using UIKit;
using PureLayout;

namespace ClassBox
{
    public class ClassCell : UIView,IUITextViewDelegate
    {
        public readonly ClassCellModel Model;

        public ClassCell(ClassCellModel model)
        {
            Model = model; 
            switch (model.Type)
            {
                case ClassCellModelType.Class:
                    var tv = new UITextView();
                    this.Add(tv);
                    tv.AutoPinEdgesToSuperviewEdgesWithInsets(UIEdgeInsets.Zero);
                    tv.BackgroundColor = model.Background; 
                    tv.TextColor = model.TextColor;  
                    tv.Delegate = this;
                    tv.Text = model.ClassName + Environment.NewLine + "@" + model.ClassRoom;
                    var ges = new UITapGestureRecognizer(r =>
                        {
                            if (Tapped != null)
                                Tapped(this, EventArgs.Empty);
                        });
                    tv.AddGestureRecognizer(ges);

                    var longes = new UILongPressGestureRecognizer(r =>
                        {
                            if (LongPressed != null)
                                LongPressed(this, EventArgs.Empty);
                        });
                    break;
            }
        }

        public event EventHandler Tapped;

        public event EventHandler LongPressed;

        [Foundation.Export("textViewShouldBeginEditing:")]
        public bool EditingStarted(UITextView textView)
        {
            return false;
        }
    }
}

