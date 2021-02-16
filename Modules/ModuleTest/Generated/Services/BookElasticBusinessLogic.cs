/*
Auto generated file. Do not edit!
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CoreCommon.Business.Service.Base;
using CoreCommon.Data.Domain.Business;
using CoreCommon.Data.Domain.Entitites;
using CoreCommon.Data.Domain.Enums;
using ModuleTest.Generated.Entities;
using ModuleTest.Generated.Enums;
using ModuleTest.Repositories;
using ModuleTest.IServices;
using ModuleTest.IRepositories;
using CoreCommon.Data.ElasticSearch.Base;
using Nest;

namespace ModuleTest.Services
{
    public partial class BookElasticBusinessLogic : ElasticSearchBaseBusinessLogic<BookElasticEntity, string, IBookElasticRepository>, IBookElasticBusinessLogic
    {
        public override IBookElasticRepository Repository { get; set; }
        

        public ServiceResult<List<BookElasticEntity>> Search(string id,string name,decimal? price,string category,string author, string orderBy, bool asc, int skip, int take, out long _total)
        {
            var response = ServiceResult<List<BookElasticEntity>>.Instance.ErrorResult(ServiceResultCode.Error); 
            response.Value = Repository.Search(id,name,price,category,author, orderBy, asc, skip, take, out _total);
            if (response.Value != null)
            {
                response.SuccessResult(response.Value);
            }
            return response;
        }
    }
}
