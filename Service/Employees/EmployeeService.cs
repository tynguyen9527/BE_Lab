using AutoMapper;
using Common;
using Common.Http;
using Common.Paganation;
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
        public Paganation<EmployeeDTO> GetAll(SerachPaganationDTO<EmployeeDTO> dto)
        {

            try
            {
                var a = new EmployeeDTO();
                var listEmployee = _repository.Queryable();
                var listDepartment = _repositoryDepartment.Queryable();
                var listPosition = _repositoryPosition.Queryable();
                var employeeDTO =
                (from emp in listEmployee
                 from dep in listDepartment
                 from pos in listPosition
                 where emp.DepartmentId == dep.Id && emp.PositionId == pos.Id
                 select new EmployeeDTO
                 {
                     Id = emp.Id,
                     Name = emp.Name,
                     PositionName = pos.Name,
                     DepartmentName = dep.Name

                 }).OrderBy(it => it.DepartmentName)
                   .ThenBy(it => it.Name)
                   .Take(dto.Take)
                   .Skip(dto.Skip)
                   .ToList();
                var result = _mapper.Map<SerachPaganationDTO<EmployeeDTO>, Paganation<EmployeeDTO>>(dto);
                result.Data = employeeDTO;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }
        //public List<EmployeeDTO> GetAll()
        //{

        //    try
        //    {
        //        var a = new EmployeeDTO();
        //        var listEmployee = _repository.Queryable();
        //        var listDepartment = _repositoryDepartment.Queryable();
        //        var listPosition = _repositoryPosition.Queryable();
        //        var employeeDTO = 
        //        (from emp in listEmployee
        //        from dep in listDepartment
        //        from pos in listPosition
        //        where emp.DepartmentId == dep.Id && emp.PositionId == pos.Id
        //        select new EmployeeDTO
        //        {
        //            Id = emp.Id,
        //            Name = emp.Name,
        //            PositionName = pos.Name,
        //            DepartmentName = dep.Name

        //        }).ToList();
        //        return employeeDTO;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Couldn't retrieve entities: {ex.Message}");
        //    }
        //}

        public bool Insert(EmployeeDTO dto)
        {
            var employee = _mapper.Map<EmployeeDTO, Employee>(dto);
            employee.Id = new Guid();
            var department = _repositoryDepartment.Queryable().Where(r => r.Name == dto.DepartmentName).FirstOrDefault();
            var position = _repositoryPosition.Queryable().Where(r => r.Name == dto.PositionName).FirstOrDefault();
            if (department == null || position == null)
            {
                return false;
            }
            employee.DepartmentId = department.Id;
            employee.PositionId = position.Id;



            _repository.Insert(employee);
            _unitOfWork.SaveChanges();
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
            var employee = _repository.Find(dto.Id);
            if (employee == null)
            {
                return false;
            }
            //employee.Id = dto.Id;
            employee.Name = dto.Name;
            var department = _repositoryDepartment.Queryable().Where(r => r.Name == dto.DepartmentName).FirstOrDefault();
            var position = _repositoryPosition.Queryable().Where(r => r.Name == dto.PositionName).FirstOrDefault();

            employee.DepartmentId = department.Id;
            employee.PositionId = position.Id;
            _repository.Update(employee);
            _unitOfWork.SaveChanges();

            return true;
        }
    }
}
