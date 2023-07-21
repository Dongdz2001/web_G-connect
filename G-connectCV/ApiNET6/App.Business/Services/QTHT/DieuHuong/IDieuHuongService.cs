using App.Business.Base;
using App.Data.Models.QTHT;
using System;
using System.Collections.Generic;

namespace App.Business.Services.QTHT
{
    public interface IDieuHuongService : IGenericService<dieu_huong>
    {
        List<TreeDieuHuongDTO> GetTreeDieuHuong();
        List<TreeDieuHuongDTO> GetTreeDieuHuongForm();
        List<DieuHuongDTO> GetFlatDieuHuong();
        PhanLoaiDieuHuongDTO PhanLoaiDieuHuong();
        bool DeleteByMucLuc(Guid id);
        void UpdateSttOrder();
        int? GetStt(Guid? dieu_huong_cap_tren_id);    
    }
}
