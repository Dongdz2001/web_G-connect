using App.Business.Base;
using App.Data.Models.QTHT;
using System.Collections.Generic;

namespace App.Business.Services.QTHT
{
    public interface INhomNguoiDungService : IGenericService<nhom_nguoi_dung>
    {
        bool AddUserToGroup(UpdateNguoiDungFromNhomND obj);
        List<SelectSimpleDTO> danhSachNguoiDungQLTC();
    }
}
