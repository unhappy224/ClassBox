using System;
using System.Linq;

namespace ClassBox
{
    public class ClassCellModelFactory
    {
        public static ClassCellModel[][] CreateFromClassModel(ClassModel[] models)
        {
            var result = new ClassCellModel[Constants.NodeInDay][];

            for (int node = 0; node < Constants.NodeInDay; node++)
            {
                result[node] = new ClassCellModel[Constants.DayInWeek];
                for (int day = 0; day < Constants.DayInWeek; day++)
                {
                    var model = models.FirstOrDefault(m => m.DayInWeek - 1 == day && m.Node - 1 == node);
                    if (model == null)
                    {
                        result[node][day] = new ClassCellModel(ClassCellModelType.None, null);
                    }
                    else
                    {
                        result[node][day] = new ClassCellModel(ClassCellModelType.Class, model);
                    }
                }
            }

            return result;
        }
    }
}

