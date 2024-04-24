using System;
namespace ClassLibrary
{
    public class LateCalculator
    {

        public static TimeSpan CalculateLate(DateTime shiftStart, DateTime shiftEnd, DateTime breakStart, DateTime breakEnd, DateTime signIn, DateTime? leaveFrom = null, DateTime? leaveTo = null)
        {

            TimeSpan late = TimeSpan.Zero;
            TimeSpan breakPeriod = breakEnd - breakStart;
            TimeSpan shift = shiftEnd - shiftStart - breakPeriod;
            //check if the signIn time is after the shift end time
            if (signIn >= shiftEnd)
            {
                late = shift + (signIn - shiftEnd);
            }
            //check if signIn in shift
            if (signIn > shiftStart && signIn < shiftEnd)
            {
                if (signIn < breakStart)
                {
                    late = signIn - shiftStart;
                }
                else if (signIn >= breakStart && signIn <= breakEnd)
                {
                    late = breakStart - shiftStart;
                }
                else if (signIn > breakEnd)
                {
                    //check if the signIn is after the breakEnd 
                    TimeSpan shift1 = breakStart - shiftStart;
                    late = signIn - breakEnd + shift1;
                }
                if (leaveFrom.HasValue && leaveTo.HasValue)
                {

                    TimeSpan leavePeriod = (TimeSpan)(leaveTo - leaveFrom);
              
                    if (signIn >= leaveFrom && signIn <= leaveTo)
                    {
                        late = (TimeSpan)(leaveFrom - shiftStart);
                    }
                    else if (signIn > leaveFrom)
                    {
                        //check if there is leave time overlapping with the sign in time or break end time
                        if (leaveFrom <= breakStart && leaveTo >= breakEnd)
                        {
                            late -= leavePeriod - breakPeriod;
                        }
                        else
                        {
                            late -= leavePeriod;
                        }
                    }
                }

            }

            return late;
        }
    }
}


