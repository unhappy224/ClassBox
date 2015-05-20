using System;

namespace ClassBox
{
    public class LeftModel
    {
        public string Time{ get; set; }

        public int Node{ get; set; }

        public LeftModel(int node, string time)
        {
            Node = node;
            Time = time;
        }
    }

    public class LeftModelFactory
    {
        public static LeftModel[] Create()
        {
            return new []
            {
                new LeftModel(1, "8:00"),
                new LeftModel(2, "8:55"),
                new LeftModel(3, "10:00"),
                new LeftModel(4, "10:55"),
                new LeftModel(5, "14:00"),
                new LeftModel(6, "14:55"),
                new LeftModel(7, "16:00"),
                new LeftModel(8, "16:55"),
                new LeftModel(9, "19:00"),
                new LeftModel(10, "19:55") 
            };
        }
    }
}

