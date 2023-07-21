using App.Business.Base;
using App.Data.Models.QTHT;
using System;

namespace App.Business.Services.QTHT
{
    public interface ICauHinhMaService : IGenericService<cau_hinh_ma>
    {
        string GetCHMa(string ma);

    }
}
