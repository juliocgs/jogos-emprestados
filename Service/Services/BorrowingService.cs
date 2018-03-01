using Application.Models;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Service.Interfaces;
using System;
using System.Collections.Generic;

namespace Service.Services
{
    public class BorrowingService : IBorrowingService
    {
        private readonly IMapper _mapper;
        private readonly IBorrowingRepository _borrowingRepository;

        public BorrowingService(IMapper mapper, IBorrowingRepository borrowingRepository)
        {
            _mapper = mapper;
            _borrowingRepository = borrowingRepository;
        }

        public void Create(BorrowingViewModel borrowing)
        {
            _borrowingRepository.BeginTransaction();
            _borrowingRepository.Create(_mapper.Map<Borrowing>(borrowing));
            _borrowingRepository.Commit();
        }

        public IList<BorrowingViewModel> GetAll()
        {
            return _mapper.Map<IList<BorrowingViewModel>>(_borrowingRepository.GetAll());
        }

        public BorrowingViewModel GetById(Guid id)
        {
            return _mapper.Map<BorrowingViewModel>(_borrowingRepository.GetById(id));
        }

        public void ReturnGameByBorrowingId(Guid id)
        {
            var borrowing = _borrowingRepository.GetById(id);
            borrowing.ReturnDate = DateTime.Now;

            _borrowingRepository.BeginTransaction();
            _borrowingRepository.Update(borrowing);
            _borrowingRepository.Commit();
        }
    }
}
