using Application.Models;
using AutoMapper;
using Domain.Models;

namespace Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<GameViewModel, Game>().MaxDepth(1);
            CreateMap<FriendViewModel, Friend>().MaxDepth(1);
            CreateMap<BorrowingViewModel, Borrowing>().MaxDepth(1);
            CreateMap<UserViewModel, User>();
        }
    }
}
