using System;
using UIKit;

namespace ClassBox
{
    public class ClassCellModel
    {
        public ClassCellModelType Type;

        public string ClassName { get; set; }

        public string ClassRoom { get; set; }

        public UIColor Background { get; set; }

        public UIColor TextColor { get; set; }

        public ClassModel Model;

        public ClassCellModel(ClassCellModelType type, ClassModel model = null)
        {
            Type = type;
            Model = model;
            if (model != null)
            {
                Background = Helper.GetRandomColor();
                TextColor = UIColor.White;
                ClassName = model.Name;
                ClassRoom = model.Room;
            }
        }
    }

    public enum ClassCellModelType
    {
        None = 0,
        Class = 1,
        Image = 2
    }
}

