using System;

namespace HotelsWizard.Models
{
    public class DateRange
    {
        public const int RANGE_SET_FROM = 1;
        public const int RANGE_SET_TO = 2;
        private const int RANGE_SET_NONE = 0;
        public DateTime From;
        public DateTime To;
        private int SelectState = RANGE_SET_NONE;
         // public DateRange(long fromMillis, long toMillis)
        // {
        //     from = Calendar.getInstance(Locale.getDefault());
        //     to = Calendar.getInstance(Locale.getDefault());
        //     from.setTimeInMillis(fromMillis);
        //     to.setTimeInMillis(toMillis);
        // }

        // public DateRange(DateRange dateRange)
        // {
        //     this(dateRange.from.getTimeInMillis(), dateRange.to.getTimeInMillis());
        // }

        public static DateRange getInstance()
        {
            DateRange range = new DateRange();
            range.From = new DateTime();
            range.To = new DateTime();
            range.To.AddDays(1);
            range.SelectState = RANGE_SET_NONE;
            return range;
        }

        public void Set(DateRange range)
        {
            From = range.From;
            To = range.To;
        }

        public void SetDay(DateTime day)
        {
            if (SelectState == RANGE_SET_NONE || SelectState == RANGE_SET_FROM)
            {
                SetFrom(day);
                SelectState = RANGE_SET_TO;
            }
            else
            {
                SetTo(day);
                //mSelectState = RANGE_SET_FROM;
            }

        }

        private void SetFrom(DateTime day)
        {
            From = day;
            if (day.CompareTo(To) > 0)
            {
                To = day;
                To.AddDays(1);
                SelectState = RANGE_SET_FROM;
            }
        }

        private void SetTo(DateTime day)
        {
            if (day.CompareTo(From) < 0)
            {
                From = day;
                To = day;
                To.AddDays(1);
                SelectState = RANGE_SET_TO;
            }
            else
            {
                To = day;
            }
        }


        public int Days()
        {
            return (int)(To - From).TotalDays;
        }
    }
}