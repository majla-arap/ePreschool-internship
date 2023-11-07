﻿using ePreschool.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Service
{
    public interface IBusinessUnitService : IBaseService<BusinessUnitDto>
    {
        Task<IEnumerable<EntityItemDto>> GetSelectListAsync();
    }
}
