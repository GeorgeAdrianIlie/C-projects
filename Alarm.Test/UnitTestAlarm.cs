using System.Net.Sockets;
using Xunit;

namespace Alarm.Test
{
    public class UnitTestAlarm
    {
        [Fact]
        public void CheckAlarmDay_ShouldReturnTrue_IfAlarmDaysContains_DayToCheck()
        {
            Days days = Days.Tu;
            Days dayToCheck = Days.Tu;
            Assert.True(Program.CheckAlarmDay(days, dayToCheck));
        }

        [Fact]
        public void AddDayToAlert_ShouldReturnExistingFlag_IfDays_Contains_Day(Program program)
        {
            Alert arhive = new Alert();
            arhive.Time.Hour = 11;
            arhive.Time.Minutes = 40;
            arhive.Days = Days.Tu;
            Days day = Days.We;
            arhive.Days |= day;
            Alert result = new Alert();
            result.Time.Hour = 10;
            result.Time.Minutes = 30;
            result.Days = Days.Tu;
            Assert.Equal(arhive.Days, Program.AddDayToAlert(ref result, day));
        }
    }
}