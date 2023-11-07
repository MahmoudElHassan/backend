namespace Financial_DAL;

public interface ICalenderRepo : IGenericRepo<Calender>
{
    Calender FindCalenderByYearMonth(int year, int month);
}
