using AutoMapper;
using Financial_BL.DTOs;
using Financial_BL.DTOs.SalesDTO;
using Financial_BL.DTOs.TransactionsDTO;
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

        CreateMap<Customer, ReadCustomersDTOs>();
        CreateMap<UpdateCustomersDTOs, Customer>();
        CreateMap<AddCustomersDTOs, Customer>();

        CreateMap<ToDoList, ReadToDoListsDTO>();
        CreateMap<UpdateToDoListsDTO,ToDoList>();
        CreateMap<AddToDoListsDTO, ToDoList>();

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

        CreateMap<Sale, ReadSaleDTO>();

        CreateMap<Statu, ReadStatusDTOs>();

        CreateMap<Source, ReadSourcesDTOs>();

        CreateMap<Priority, ReadPriorityDTO>();

        CreateMap<Assign,ReadAssignsDTO>();

    }
}
