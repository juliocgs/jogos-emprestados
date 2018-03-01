using Application.Models;
using AutoMapper;
using Domain.Models;

namespace Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Game, GameViewModel>().MaxDepth(1);
            CreateMap<Friend, FriendViewModel>().MaxDepth(1);
            CreateMap<Borrowing, BorrowingViewModel>().MaxDepth(1);
            CreateMap<User, UserViewModel>();
        }
    }
}
