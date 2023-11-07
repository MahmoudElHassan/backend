using AutoMapper;
using Financial_DAL;

namespace Financial_BL;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Transaction, ReadTransactionDTO>();
        CreateMap<UpdateTransactionDTO, Transaction>();
        CreateMap<AddTrasnactionDTO, Transaction>();

        CreateMap<Category, ReadCateoriesDTOS>();
        CreateMap<UpdateCateoriesDTOS, Category>();
        CreateMap<AddCateoriesDTOS, Category>();

        CreateMap<Category, ReadCateoriesDTOS>();
        CreateMap<UpdateCateoriesDTOS, Category>();
        CreateMap<AddCateoriesDTOS, Category>();

        CreateMap<Payment, ReadPaymentDTO>();
        CreateMap<UpdatePaymentDTO, Payment>();
        CreateMap<AddPaymentDTO, Payment>();

        CreateMap<ToDoList, ReadToDoListsDTO>();
        CreateMap<UpdateToDoListsDTO, ToDoList>();
        CreateMap<AddToDoListsDTO, ToDoList>();

        CreateMap<Project, ReadProjectDTO>();
        CreateMap<UpdateProjectDTO, Project>();
        CreateMap<AddProjectDTO, Project>();

        CreateMap<UserDatabase, ReadBoysDTO>();
        CreateMap<UpdateBoysDTO, UserDatabase>();
        CreateMap<AddBoysDTO, UserDatabase>();

        CreateMap<UserDatabase, ReadBoysGirlsDTO>();
        CreateMap<UpdateBoysGirlsDTO, UserDatabase>();
        CreateMap<AddBoysGirlsDTO, UserDatabase>();

        CreateMap<MainCategory, ReadMainCategoryDTO>();
        CreateMap<UpdateMainCategoryDTO, MainCategory>();
        CreateMap<AddMainCategoryDTO, MainCategory>();

        CreateMap<SubCategory, ReadSubCategoryDTO>();
        CreateMap<UpdateSubCategoryDTO, SubCategory>();
        CreateMap<AddSubCategoryDTO, SubCategory>();

        CreateMap<Goal, ReadGoalDTO>();
        CreateMap<UpdateGoalDTO, Goal>();
        CreateMap<AddGoalDTO, Goal>();

        CreateMap<Area, ReadAreaDTO>();
        CreateMap<UpdateAreaDTO, Area>();
        CreateMap<AddAreaDTO, Area>();

        CreateMap<Calender, ReadCalenderDTO>();
        CreateMap<UpdateCalenderDTO, Calender>();
        CreateMap<AddCalenderDTO, Calender>();

        CreateMap<Habit, ReadHabitDTO>();
        CreateMap<UpdateHabitDTO, Habit>();
        CreateMap<AddHabitDTO, Habit>();

        CreateMap<Sale, ReadSaleDTO>();

        CreateMap<Statu, ReadStatusDTOs>();

        CreateMap<Source, ReadSourcesDTOs>();

        CreateMap<Priority, ReadPriorityDTO>();

        CreateMap<Assign, ReadAssignsDTO>();

    }
}
