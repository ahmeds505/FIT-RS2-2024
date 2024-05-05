﻿using eProdaja.Model;
using eProdaja.Model.SearchObjects;
using eProdaja.Services.Database;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class BaseService<TModel, TSearch, TDbEntity> : IService<TModel, TSearch> 
        where TSearch : BaseSearchObject where TDbEntity : class where TModel : class
    {
        public EProdajaContext Context { get; set; }

        public IMapper Mapper { get; set; }
        public BaseService(EProdajaContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public PagedResult<TModel> GetPaged(TSearch search)
        {
            var query = Context.Set<TDbEntity>().AsQueryable();

            int count = query.Count();

            query = AddFilter(search, query);

            if (search.Page.HasValue == true && search.PageSize.HasValue == true)
            {
                query = query.Skip(search.Page.Value * search.PageSize.Value).Take(search.PageSize.Value);
            }

            var list = query.ToList();

            List<TModel> result = new List<TModel>();

            result = Mapper.Map(list, result);

            PagedResult<TModel> pagedResult = new PagedResult<TModel>();
            pagedResult.ResultList = result;
            pagedResult.Count = count;

            return pagedResult;
        }

        public virtual IQueryable<TDbEntity> AddFilter(TSearch search, IQueryable<TDbEntity> query)
        {
            return query;
        }

        public TModel GetById(int id)
        {
            var entity = Context.Set<TDbEntity>().Find(id);

            if(entity != null)
            {
                return Mapper.Map<TModel>(entity);
            }
            else
            {
                return null;
            }

        }
    }
}
