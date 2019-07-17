using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace FirstAndroidApp.Interfaces
{
    public interface IDetailService
    {
        [Get("/s/2iodh4vg0eortkl/facts.json")]
        Task<CardDetailsModel> GetList();
    }
}
