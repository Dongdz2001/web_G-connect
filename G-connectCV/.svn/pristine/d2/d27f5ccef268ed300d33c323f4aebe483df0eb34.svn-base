using App.Business.Base;
using App.Data;
using App.Data.Models.QTHT;
using System;
using System.Collections.Generic;

namespace App.Business.Services.QTHT
{
    public interface INguoiDungService : IGenericService<nguoi_dung>
    {
        NguoiDungDTO XacThucDangNhap(string tai_khoan, string mat_khau);
        bool ResetPassword(Guid id);
        bool OpenUnlockAccount(Guid id);
        bool AddGroupToUser(UpdateNhomNDFromND obj);
        List<string> GetPermissionUser(Guid id);
        bool CheckTkIsLock(Guid id);
        bool doimatkhau(string mat_khau);
        List<string> GetPermissionUser();
        List<NguoiDungEmailSelectDTO> GetAllNguoiDungEmail();
        List<NguoiDungSelectDTO> GetAllNguoiDung();
        List<NguoiDungSelectDTO> GetAllNguoiDungByNhom(string ma_nhom);
        void InitialDataQTHT(APPContext appContext);
    }
}
