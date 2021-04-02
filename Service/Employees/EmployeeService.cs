using AutoMapper;
using Common;
using Common.Http;
using Data;
using Domain.DTO_s;
using Domain.Entities;
using Infrastructure.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Service.Departments;
using Service.Positions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Employees
{
    public class EmployeeService : BaseController, IEmployeeService
    {
        private IMapper _mapper;
        private readonly IRepository<Employee> _repository;

        private readonly IRepository<Department> _repositoryDepartment;
        private readonly IRepository<Position> _repositoryPosition;
        private readonly IUnitOfWork _unitOfWork;
        public Department department;
        public Position position;
        public Employee employeeId;


        //private DepartmentService _department;
        //private PositionService _position;
        public EmployeeService(IMapper mapper, IRepository<Employee> repository, IUnitOfWork unitOfWork, IRepository<Department> repositoryDepartment,
            IRepository<Position> repositoryPosition)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
            //_department = department;
            //_position = position;
            _repositoryDepartment = repositoryDepartment;
            _repositoryPosition = repositoryPosition;
        }

        public IQueryable<Employee> GetAll()
        {

            try
            {
                var listEmployee = _repository.Queryable();
                return listEmployee;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public bool Insert(EmployeeDTO dto)
        {
            var employee = _mapper.Map<EmployeeDTO, Employee>(dto);
            employee.Id = new Guid();
            department = _repositoryDepartment.Queryable().Where(r => r.Name == dto.DepartmentName).FirstOrDefault();
            position = _repositoryPosition.Queryable().Where(r => r.Name == dto.PositionName).FirstOrDefault();


            employee.DepartmentId = department.Id;
            employee.PositionId = position.Id;
            if(employee != null)
            {
                _repository.Insert(employee);
                _unitOfWork.SaveChanges();
            }

            return true;
        }

        public bool Delete(EmployeeDTO dto)
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

        public bool Update(EmployeeDTO dto)
        {
            var data = _repository.Find(dto.Id);
            if (data == null)
            {
                return false;
            }
            data.Id = dto.Id;
            data.Name = dto.Name;
            var department = _repositoryDepartment.Find(dto.DepartmentName);
            var position = _repositoryPosition.Find(dto.PositionName);
            data.Id = department.Id;
            data.PositionId = position.Id;
            _repository.Update(data);
            _unitOfWork.SaveChanges();

            return true;
        }
    }
}
