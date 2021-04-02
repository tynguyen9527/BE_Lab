using Domain.DTO_s;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Positions
{
    public interface IPositionService
    {
        IQueryable<Position> GetAll();

        bool Insert(PositionDTO dto);

        bool Delete(PositionDTO dto);

        bool Update(PositionDTO dto);
    }
}
