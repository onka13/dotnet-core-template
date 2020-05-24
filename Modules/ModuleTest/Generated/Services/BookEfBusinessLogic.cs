/*
Auto generated file. Do not edit!
*/
using System;
using System.Collections.Generic;
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
using CoreCommon.Data.EntityFrameworkBase.Base;

namespace ModuleTest.Services
{
    public partial class BookEfBusinessLogic : EntityFrameworkBaseBusinessLogic<BookEfEntity, IBookEfRepository>, IBookEfBusinessLogic
    {
        public override IBookEfRepository Repository { get; set; }
        

        public ServiceResult<int> DeleteById(int id)
        {
            var response = ServiceResult<int>.Instance.ErrorResult(ServiceResultCode.Error);
            response.Value = Repository.DeleteById(id);
            if (response.Value > 0)
            {
                response.SuccessResult(response.Value, ServiceResultCode.Deleted);
            }
            return response;
        }

        public ServiceResult<BookEfEntity> GetById(int id)
        {
            var response = ServiceResult<BookEfEntity>.Instance.ErrorResult(ServiceResultCode.Error);
            response.Value = Repository.GetById(id);
            if (response.Value != null)
            {
                response.SuccessResult(response.Value);
            }
            return response;
        }

        public ServiceResult<List<object>> Search(int? id,string name,decimal? price,string category,string author, string orderBy, bool asc, int skip, int take, out long _total)
        {
            var response = ServiceResult<List<object>>.Instance.ErrorResult(ServiceResultCode.Error); 
            response.Value = Repository.Search(id,name,price,category,author, orderBy, asc, skip, take, out _total);
            if (response.Value != null)
            {
                response.SuccessResult(response.Value);
            }
            return response;
        }
    }
}
