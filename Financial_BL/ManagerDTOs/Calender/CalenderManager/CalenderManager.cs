using AutoMapper;
using Financial_DAL;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Serialization;
using System.Linq;

namespace Financial_BL;

public class CalenderManager : ICalenderManager
{
    #region Field
    private readonly ICalenderRepo _calenderRepo;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public CalenderManager(ICalenderRepo calenderRepo, IMapper maapper)
    {
        _calenderRepo = calenderRepo;
        _mapper = maapper;
    }
    #endregion

    #region Method
    public List<ReadCalenderDTO> GetAll()
    {
        var dbCalender = _calenderRepo.GetAll()
            .OrderBy(x => x.Year).ThenBy(z => z.Month)
            .Where(d => d.IsDelete == false);

        return _mapper.Map<List<ReadCalenderDTO>>(dbCalender);
    }

    public ReadCalenderDTO GetById(int id)
    {
        var dbCalender = _calenderRepo.GetByintId(id);

        if (dbCalender == null)
            return null;

        return _mapper.Map<ReadCalenderDTO>(dbCalender);
    }

    public ReadCalenderDTO Add(AddCalenderDTO calenderDTO)
    {
        var dbModel = _mapper.Map<Calender>(calenderDTO);

        var calender = _calenderRepo.FindCalenderByYearMonth(calenderDTO.Year, calenderDTO.Month);

        if (calender != null)
            throw new Exception("This Calender is exists");

        dbModel.ArrayLength = DateTime.DaysInMonth(calenderDTO.Year, calenderDTO.Month);

        dbModel.Days = Enumerable.Range(1, dbModel.ArrayLength).ToArray();

        _calenderRepo.Add(dbModel);
        _calenderRepo.SaveChanges();

        return _mapper.Map<ReadCalenderDTO>(dbModel);
    }

    public bool Update(UpdateCalenderDTO calenderDTO)
    {
        var dbCalender = _calenderRepo.GetByintId(calenderDTO.CalenderId);

        if (dbCalender == null)
            return false;

        var calender = _calenderRepo.FindCalenderByYearMonth(calenderDTO.Year, calenderDTO.Month);

        if (calender != null)
        {
            if (calender.Year == calenderDTO.Year &&
                    calender.Month == calenderDTO.Month)
            {
                throw new Exception("This Calender is exists");
            }
            else
            {
                calenderDTO.ArrayLength = DateTime.DaysInMonth(calenderDTO.Year, calenderDTO.Month);

                calenderDTO.Days = Enumerable.Range(1, calenderDTO.ArrayLength).ToArray();
            }
        }

        _mapper.Map(calenderDTO, dbCalender);

        _calenderRepo.Update(dbCalender);
        _calenderRepo.SaveChanges();

        return true;
    }

    public void Delete(int id)
    {
        _calenderRepo.DeleteByintId(id);
        _calenderRepo.SaveChanges();
    }

    #endregion
}
