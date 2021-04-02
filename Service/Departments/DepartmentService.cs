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

namespace Service.Departments
{
    public class DepartmentService : BaseController, IDepartmentService
    {
        private IMapper _mapper;
        private readonly IRepository<Department> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentService(IMapper mapper, IRepository<Department> repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public IQueryable<Department> GetAll()
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

        public bool Insert(DepartmentDTO dto)
        {
            var department = _mapper.Map<DepartmentDTO, Department>(dto);
            department.Id = new Guid();
            _repository.Insert(department);
            _unitOfWork.SaveChanges();

            return true;
        }
        public bool Delete(DepartmentDTO dto)
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

        public bool Update(DepartmentDTO dto)
        {
            var data = _repository.Find(dto.Id);
            if (data == null)
            {
                return false;
            }
            data.Name = dto.Name;
            _repository.Update(data);
            _unitOfWork.SaveChanges();

            return true;
        }

    }
}
