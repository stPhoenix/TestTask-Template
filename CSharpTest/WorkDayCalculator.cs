using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {

            if (weekEnds == null) return startDate.AddDays(dayCount - 1);

            DateTime endDate = startDate;
            int weekEndCounter = 0;

            for (int i = 1; i < dayCount; i++)
            {
                if (weekEnds.Length <= weekEndCounter) return endDate.AddDays(dayCount-i);

                if (weekEnds.Length > weekEndCounter && weekEnds[weekEndCounter].StartDate == endDate)
                {
                    endDate = weekEnds[weekEndCounter].EndDate.AddDays(1);
                    weekEndCounter++;
                }

                endDate = endDate.AddDays(1);
            }

            return endDate;
        }
    }
}
