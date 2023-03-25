using FluchDerVika.WeeklySchedule.Client.Extention;

namespace UnitTest
{
  [TestClass]
  public class DateTimeUnitTest
  {
    [TestMethod]
    public void StartOfWeekTest()
    {
      DateTime test1 = new DateTime(2023, 03, 25, 18, 25, 37, DateTimeKind.Local);
      DateTime test2 = new DateTime(2023, 03, 26, 23, 59, 00, DateTimeKind.Local);
      DateTime test3 = new DateTime(2023, 03, 20, 00, 25, 37, DateTimeKind.Local);
      DateTime test4 = new DateTime(2023, 03, 19, 23, 59, 59, DateTimeKind.Local);

      DateTime expected1 = new DateTime(2023, 03, 20, 0, 0, 0, DateTimeKind.Local);
      DateTime expected2 = new DateTime(2023, 03, 13, 0, 0, 0, DateTimeKind.Local);

      var peekableVariable = test1.GetStartOfWeek();
      Assert.IsTrue(SameDate(peekableVariable, expected1));

      peekableVariable = test2.GetStartOfWeek();
      Assert.IsTrue(SameDate(peekableVariable.GetStartOfWeek(), expected1));

      peekableVariable = test3.GetStartOfWeek();
      Assert.IsTrue(SameDate(peekableVariable.GetStartOfWeek(), expected1));

      peekableVariable = test4.GetStartOfWeek();
      Assert.IsTrue(SameDate(peekableVariable.GetStartOfWeek(), expected2));
    }

    private bool SameDate(DateTime dateTime1, DateTime dateTime2)
    {
      return dateTime1.Year == dateTime2.Year 
        && dateTime1.Month == dateTime2.Month 
        && dateTime1.Day == dateTime2.Day 
        && dateTime1.Kind == dateTime2.Kind;
    }
  }
}