using AutoMapper;
using Common;
using Common.Http;
using Data;
using Domain.DTO_s;
using Domain.Entities;
using Infrastructure.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Positions
{
    public class PositionService : BaseController, IPositionService
    {
        private IMapper _mapper;
        private readonly IRepository<Position> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public PositionService(IMapper mapper, IRepository<Position> repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IQueryable<Position> GetAll()
        {
            try
            {
                return _repository.Queryable();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public bool Insert(PositionDTO dto)
        {
            var position = _mapper.Map<PositionDTO, Position>(dto);
            position.Id = new Guid();
            _repository.Insert(position);
            _unitOfWork.SaveChanges();

            return true;
        }

        public bool Delete(PositionDTO dto)
        {
            if (dto.Id == null)
            {
                return false;
            }
            dto.Id.ToString();
            _repository.Delete(dto.Id);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool Update(PositionDTO dto)
        {
            var data = _repository.Find(dto.Id);
            if (data == null)
            {
                return false;
            }
            data.Id = dto.Id;
            data.Name = dto.Name;
            _repository.Update(data);
            _unitOfWork.SaveChanges();

            return true;
        }
    }
}
