﻿using eProdaja.Model;
using eProdaja.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public interface IService<TModel, TSearch> where TSearch : BaseSearchObject
    {
        public PagedResult<TModel> GetPaged(TSearch search);

        TModel GetById (int id);

    }
}
