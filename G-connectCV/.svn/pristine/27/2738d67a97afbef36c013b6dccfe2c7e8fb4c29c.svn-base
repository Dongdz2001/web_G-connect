using App.Business.Services;
using App.Data;
using App.Data.Models;
using App.Data.Models.QTHT;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace App.Business.Utils
{
    static class KeyPhieuDeXuatDTO
    {
        public const string VaiTroHoiDong = "VAITROHOIDONG";
        public const string ChuTich = "Chủ tịch";
        public const string PhoChuTich = "Phó Chủ tịch";
        public const string MaBuocI0202 = "I.02.02"; // Đính kèm công văn rà soát đã ban hành
        public const string MaBuocI0203 = "I.02.03"; // Đính kèm công văn phúc đáp
        public const string MaBuocI0204 = "I.02.04"; // Cập nhật kết quả rà soát 
        public const string MaBuocI0302 = "I.03.02"; // Đính kèm công văn đã ban hành
        public const string MaBuocI0303 = "I.03.03"; // Đính kèm công văn phúc đáp của VĐG 
        public const string MaBuocI0402 = "I.04.02";
        public const string MaBuocI0401 = "I.04.01";
        public const string MaBuocI0403 = "I.04.03"; //Cập nhật quyết định thành lập hội đồng
        public const string MaBuocI0501 = "I.05.01";
        public const string MaBuocI0502 = "I.05.02"; // Ủy quyền dự án
        public const string MaBuocI0503 = "I.05.03";
        public const string MaBuocI0504 = "I.05.04"; // Gửi mail mời họp
        public const string MaBuocI0505 = "I.05.05"; //Cập nhật kết quả họp HĐ
        public const string MaBuocI0506 = "I.05.06"; //Đánh giá chuyên gia
        public const string MaBuocI0801 = "I.08.01"; // Xin ý kiến chuyên gia
        public const string MaBuocI0802 = "I.08.02"; // Cập nhật ý kiên chuyên gia tư vấn
        // Nhiệm vụ
        public const string MaBuocI0601 = "I.06.01";
        public const string MaBuocI0603 = "I.06.03";
        public const string MaBuocI0701 = "I.07.01";
        public const string MaBuocI0702 = "I.07.02"; // Ủy quyền nhiệm vụ
        public const string MaBuocI0703 = "I.07.03";
        public const string MaBuocI0704 = "I.07.04"; // Gửi mail mời họp
        public const string MaBuocI0705 = "I.07.05"; // Cập nhật kết quả họp HĐ
        public const string MaBuocI0706 = "I.07.06"; // Đánh giá chuyên gia
        public const string MaBuocI0902 = "I.09.02"; // phê duyệt dự án
        public const string MaBuocI1002 = "I.10.02"; // phê duyệt nhiệm vụ


        //II tuyển chọn trực tiếp
        public const string MaBuocII0102 = "II.01.02"; // Quản lý tiếp nhận hồ sơ
        public const string MaBuocII0202 = "II.02.02"; // Đính kèm công văn rà soát đã ban hành: công văn rà soát
        public const string MaBuocII0203 = "II.02.03";
        public const string MaBuocII0501 = "II.05.01";
        public const string MaBuocII0503 = "II.05.03"; // Cập nhật quyết định thành lập hội đồng: du an
        public const string MaBuocII0701 = "II.07.01";
        public const string MaBuocII0703 = "II.07.03"; // Cập nhật quyết định thành lập hội đồng: nhiem vu
        public const string MaBuocII0801 = "II.08.01";
        public const string MaBuocII0802 = "II.08.02";
        public const string MaBuocII0601 = "II.06.01";
        public const string MaBuocII0602 = "II.06.02";

        //Thẩm định kinh phí
        public const string MaBuocIII0103 = "III.01.03";
        public const string MaBuocIII0201 = "III.02.01";
        public const string MaBuocIII0303 = "III.03.03";
        public const string MaBuocIII0401 = "III.04.01";
        public const string MaBuocIII0402 = "III.04.02";
        public const string MaBuocIII0202 = "III.02.02";
        public const string MaBuocIII0301 = "III.03.01";
        public const string MaBuocIII0101 = "III.01.01";

        //phê duyệt nhiệm vụ
        public const string MaBuocIV0202 = "IV.02.02";
        public const string MaBuocIV0302 = "IV.03.02";

    }
    // note: Để ý region Dùng chung. Hàm nào có rồi thì sẽ gọi lại. không viết lặp lại lần 2
    public static class CommonHelper
    {

    }
}
