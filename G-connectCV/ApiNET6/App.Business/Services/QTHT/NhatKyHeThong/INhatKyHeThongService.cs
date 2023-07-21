using App.Business.Base;
using App.Common.Base;
using App.Data.Models.QTHT;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Business.Services.QTHT
{
    public interface INhatKyHeThongService : IGenericService<nhat_ky_he_thong>
    {
        Task<bool> CreateNhatKyHeThong(NhatKyHeThongDTO objNhatKy);
        bool DeleteNhatKyHeThong(Guid id);
    }
}
