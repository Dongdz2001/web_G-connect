using App.Business.Base;
using App.Business.Utils;
using App.Common.Base;
using App.Data;
using App.Data.Models.QTHT;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;

namespace App.Business.Services.QTHT
{
    public class NguoiDungService : GenericService<nguoi_dung>, INguoiDungService
    {
        public NguoiDungService(APPContext dbContext)
           : base(dbContext)
        {
            ///Khởi tạo mapperconfiuration
            _mapperCfg = new MapperConfiguration(cfg =>
            {               
                cfg.AddProfile<BaseProfile>();
                cfg.AddProfile<FileDinhKemProfile>();
                cfg.AddProfile<NguoiDungProfile>();
                cfg.AddProfile<DieuHuongProfile>();
            });
            _mapper = _mapperCfg.CreateMapper();
            _mapperCfg.AssertConfigurationIsValid();

        }

        protected override IQueryable<nguoi_dung> QueryBuilder(IQueryable<nguoi_dung> query, dynamic filter, string search)
        {
            if (filter != null)
            {

                query = query.Where(x => x.super_admin != true);
                String tai_khoan = filter.tai_khoan;
                if (!string.IsNullOrEmpty(tai_khoan))
                {
                    tai_khoan = tai_khoan.ToLower().Trim();
                    query = query.Where(x => x.tai_khoan.ToLower().Contains(tai_khoan));
                }
                String ten = filter.ten;
                if (!string.IsNullOrEmpty(ten))
                {
                    ten = ten.ToLower().Trim();
                    query = query.Where(x => x.ten.ToLower().Contains(ten));
                }
                String so_dien_thoai = filter.so_dien_thoai;
                if (!string.IsNullOrEmpty(so_dien_thoai))
                {
                    so_dien_thoai = so_dien_thoai.ToLower().Trim();
                    query = query.Where(x => x.so_dien_thoai.ToLower().Contains(so_dien_thoai));
                }
                String email = filter.email;
                if (!string.IsNullOrEmpty(email))
                {
                    email = email.ToLower().Trim();
                    query = query.Where(x => x.email.ToLower().Contains(email));
                }
                String str_chuc_vu_id = filter.chuc_vu_id;
                if (!string.IsNullOrEmpty(str_chuc_vu_id))
                {
                    Guid chuc_vu_id = Guid.Parse(str_chuc_vu_id);
                    query = query.Where(x => x.chuc_vu_id == chuc_vu_id);
                }
                if (filter.trang_thai != null)
                {
                    int trang_thai = filter.trang_thai;
                    query = query.Where(x => x.trang_thai == trang_thai);
                }
                string lstchuc_vu = filter.maChucVu;
                if (!string.IsNullOrEmpty(lstchuc_vu))
                {
                    query = query.Where(x => lstchuc_vu.Contains(x.chuc_vu.ma));
                }
            }
            if (search != null && search != "")
            {
                search = search.ToLower().Trim();
                query = query.Where(x => x.tai_khoan.ToLower().Contains(search) ||
                                         x.ten.ToLower().Contains(search) ||
                                         x.so_dien_thoai == search ||  
                                         x.email == search);
            }
            return query;
        }
        protected override void BeforeMapper<TDto>(bool isNew, ref TDto dto)
        {
            //check trùng dữ liệu
            if (typeof(TDto) == typeof(NguoiDungDTO))
            {
                NguoiDungDTO nguoidungDTO = (NguoiDungDTO)(object)dto;
                var isExits = _repo.Where(x => x.tai_khoan.ToLower() == nguoidungDTO.tai_khoan.ToLower() && x.id != nguoidungDTO.id).Count() > 0;
                if (isExits)
                {
                    ErrorCtr.DataExits("Tài khoản đã tồn tại, vui lòng kiểm tra lại thông tin");
                }
            }
        }
        protected override void BeforeAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref nguoi_dung entity)
        {
            if (typeof(TDto) != typeof(NguoiDungDTO))
            {
                return;
            }
            NguoiDungDTO nguoidungDTO = (NguoiDungDTO)(object)dto;
            if (isNew)
            {
                if (!string.IsNullOrEmpty(nguoidungDTO.mat_khau))
                {
                    var SaltCode = Salt.GetCode(8);
                    entity.salt_code = SaltCode;
                    entity.mat_khau = MD5algorithm.GetMd5Hash(nguoidungDTO.mat_khau, SaltCode);
                }
                else
                {
                    var SaltCode = Salt.GetCode(8);
                    var randomstr = "12345";
                    entity.salt_code = SaltCode;
                    entity.mat_khau = MD5algorithm.GetMd5Hash(randomstr, SaltCode);
                }
            }
        }

        protected override void AfterAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref nguoi_dung entity)
        {
            if (typeof(TDto) != typeof(NguoiDungDTO))
            {
                return;
            }
            NguoiDungDTO nguoidungDTO = (NguoiDungDTO)(object)dto;
            if (isNew)
            {
                #region add nhóm người dùng vào bảng trung gian
                if (nguoidungDTO.ds_nhomnguoidung != null)
                {
                    foreach (var item in nguoidungDTO.ds_nhomnguoidung)
                    {
                        var infoNhomNguoiDung = _dbContext.nhom_nguoi_dung.Where(x => x.id == item.id).FirstOrDefault();
                        if (infoNhomNguoiDung != null)
                        {
                            nguoi_dung_2_nhom_nguoi_dung nguoi_dung_2_nhom_nguoi_dung = new nguoi_dung_2_nhom_nguoi_dung();
                            nguoi_dung_2_nhom_nguoi_dung.nhom_nguoi_dung_id = infoNhomNguoiDung.id;
                            nguoi_dung_2_nhom_nguoi_dung.nguoi_dung_id = entity.id;
                            entity.ds_nhom_nguoi_dung.Add(nguoi_dung_2_nhom_nguoi_dung);
                        }
                    }
                }
                #endregion
            }

            #region update file dinh kem
            
            // add file moi
            if (nguoidungDTO.file != null)
            {
                // xoa file sinh kem cu
                if (entity.file_dinh_kem != null)
                {
                    var id_temp = entity.file_dinh_kem.id;
                    _dbContext.Set<file_dinh_kem>().Where(x => x.id == id_temp).BatchDelete();
                }

                // ad to file dinh kem
                file_dinh_kem efile = new file_dinh_kem();
                efile.id = Guid.NewGuid();
                efile.duong_dan = nguoidungDTO.file.linkFile;
                efile.ten = nguoidungDTO.file.tenFile;
                efile.type = nguoidungDTO.file.type;
                _dbContext.file_dinh_kem.Add(efile);

                entity.file_dinh_kem_id = efile.id;
                entity.anh_dai_dien_url = efile.duong_dan;

            }

            #endregion

        }

        public NguoiDungDTO XacThucDangNhap(string tai_khoan, string mat_khau)
        {
            try
            {
                NguoiDungDTO thongTinNguoiDung = null;
                var nguoiDung = _repo.Where(x => x.tai_khoan == tai_khoan).FirstOrDefault();
                if (nguoiDung != null)
                {
                    if(nguoiDung.trang_thai == 1)
                    {
                        ErrorCtr.Reject(System.Net.HttpStatusCode.BadRequest, "invalid", "Tài khoản đã bị khóa!");
                    }    
                    if (MD5algorithm.VerifyMd5Hash(mat_khau, nguoiDung.mat_khau, nguoiDung.salt_code))
                    {
                        thongTinNguoiDung = _mapper.Map<nguoi_dung, NguoiDungDTO>(nguoiDung);
                        return thongTinNguoiDung;
                    }

                }
                ErrorCtr.Reject(System.Net.HttpStatusCode.BadRequest, "invalid_password", "Mật khẩu không chính xác. Vui lòng kiểm tra lại!");
                return thongTinNguoiDung;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public bool ResetPassword(Guid id)
        {
            try
            {
                var user = _repo.Find(id);
                var SaltCode = Salt.GetCode(8);
                var randomstr = "12345";
                user.salt_code = SaltCode;
                user.mat_khau = MD5algorithm.GetMd5Hash(randomstr, SaltCode);
                _dbContext.Update(user);
                if (_dbContext.SaveChanges() >= 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool doimatkhau(string mat_khau)
        {
            try
            {
                var currentUser = AppHelpers.GetCurrentUser();
                if(currentUser != null && currentUser.id != null)
                {
                    var user = _repo.Find(currentUser.id);
                    var SaltCode = Salt.GetCode(8);
                    user.salt_code = SaltCode;
                    user.mat_khau = MD5algorithm.GetMd5Hash(mat_khau, SaltCode);
                    _dbContext.Update(user);
                    if (_dbContext.SaveChanges() >= 1)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool OpenUnlockAccount(Guid id)
        {
            try
            {
                var user = _repo.Find(id);
                user.trang_thai = user.trang_thai == 0 ? 1 : 0;
                _dbContext.Update(user);
                if (_dbContext.SaveChanges() >= 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckTkIsLock(Guid id)
        {
            try
            {
                var user = _repo.Find(id);
                if(user != null)
                {
                    if(user.trang_thai == 0)
                    {
                        return true;
                    }
                    return false;
                }    
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddGroupToUser(UpdateNhomNDFromND obj)
        {
            try
            {
                var nguoiDung = _dbContext.nguoi_dung.Find(obj.nguoi_dung_id);
                nguoiDung.ds_nhom_nguoi_dung.Clear();
                if (obj != null)
                {
                    foreach (var item in obj.lts_nhom_id)
                    {
                        var infoNhomNguoiDung = _dbContext.nhom_nguoi_dung.Where(x => x.id == item.id).FirstOrDefault();
                        if (infoNhomNguoiDung != null)
                        {
                            nguoi_dung_2_nhom_nguoi_dung nguoi_dung_2_nhom_nguoi_dung = new nguoi_dung_2_nhom_nguoi_dung();
                            nguoi_dung_2_nhom_nguoi_dung.nhom_nguoi_dung_id = infoNhomNguoiDung.id;
                            nguoi_dung_2_nhom_nguoi_dung.nguoi_dung_id = obj.nguoi_dung_id;
                            nguoiDung.ds_nhom_nguoi_dung.Add(nguoi_dung_2_nhom_nguoi_dung);
                            _dbContext.nguoi_dung.Update(nguoiDung);
                        }
                    }
                    if (_dbContext.SaveChanges() >= 1)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<string> GetPermissionUser(Guid id)
        {
            try
            {
                var res = new List<PermissionUserDTO>();
                var currentUser = _repo.Find(id);

                if (currentUser.super_admin)
                {
                    var ltsDieuHuong = _dbContext.dieu_huong
                    .Where(x => x.is_router == true)
                    .OrderBy(x => x.so_thu_tu).ToList();
                    if (ltsDieuHuong.Any())
                    {
                        res = _mapper.Map<List<dieu_huong>, List<PermissionUserDTO>>(ltsDieuHuong);
                    }
                }
                else
                {
                    var ltsDieuHuong = _dbContext.dieu_huong
                    .Where(x => x.is_router == true &&
                                x.ds_nhom_nguoi_dung.Any(y => y.nhom_nguoi_dung.ds_nguoi_dung.Any(t => t.nguoi_dung_id == id)))
                    .OrderBy(x => x.so_thu_tu).ToList();
                    if (ltsDieuHuong.Any())
                    {
                        res = _mapper.Map<List<dieu_huong>, List<PermissionUserDTO>>(ltsDieuHuong);
                    }
                }
                
                return res.Select(x => x.ma_quyen).OfType<string>().ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<string> GetPermissionUser()
        {
            try
            {
                var currentUser = AppHelpers.GetCurrentUser();
                return GetPermissionUser(currentUser.id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<NguoiDungEmailSelectDTO> GetAllNguoiDungEmail()
        {
            try
            {
                var query = _dbContext.nguoi_dung.AsQueryable().Where(x => !string.IsNullOrEmpty(x.email)).ToList();
                var res = _mapper.Map<List<nguoi_dung>, List<NguoiDungEmailSelectDTO>>(query);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<NguoiDungSelectDTO> GetAllNguoiDung()
        {
            try
            {
                var query = _dbContext.nguoi_dung.AsQueryable().ToList();
                var res = _mapper.Map<List<nguoi_dung>, List<NguoiDungSelectDTO>>(query);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<NguoiDungSelectDTO> GetAllNguoiDungByNhom(string ma_nhom)
        {
            try
            {
                var ma_nhom_ld = _dbContext.cau_hinh_ma.Where(x => x.ma == ma_nhom).Select(y => y.gia_tri).FirstOrDefault();
                
                var query = _dbContext.nguoi_dung.AsQueryable().Where(x => x.ds_nhom_nguoi_dung.Where(y => y.nhom_nguoi_dung.ma == ma_nhom_ld).Any()).ToList();
                var res = _mapper.Map<List<nguoi_dung>, List<NguoiDungSelectDTO>>(query);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InitialDataQTHT(APPContext appContext)
        {
            try
            {
                #region tạo id
                Guid user_id = Guid.NewGuid();
                Guid nhom_user_id = Guid.NewGuid();
                Guid dieu_huong_goc_id = Guid.NewGuid();
                Guid dh_user_id = Guid.NewGuid();
                Guid dh_nhomnguoidung_id = Guid.NewGuid();
                Guid dh_dieuhuong_id = Guid.NewGuid();
                Guid user_add_id = Guid.NewGuid();
                Guid user_remove_id = Guid.NewGuid();
                Guid user_view_id = Guid.NewGuid();
                Guid user_reset_pass_id = Guid.NewGuid();
                Guid user_lock_id = Guid.NewGuid();
                Guid nhom_user_add_id = Guid.NewGuid();
                Guid nhom_user_remove_id = Guid.NewGuid();
                Guid nhom_user_view_id = Guid.NewGuid();
                Guid dieuhuong_add_id = Guid.NewGuid();
                Guid dieuhuong_remove_id = Guid.NewGuid();
                Guid dieuhuong_view_id = Guid.NewGuid();
                #endregion

                #region thêm nhóm quản trị
                nhom_nguoi_dung nhom_nd = new nhom_nguoi_dung();
                nhom_nd.id = nhom_user_id;
                nhom_nd.ma = "QTHT";
                nhom_nd.ten = "Quản trị hệ thống";
                appContext.nhom_nguoi_dung.Add(nhom_nd);
                #endregion

                #region thêm tk quản trị
                nguoi_dung user = new nguoi_dung();
                var SaltCode = Salt.GetCode(8);
                var randomstr = "12345";
                user.id = user_id;
                user.salt_code = SaltCode;
                user.mat_khau = MD5algorithm.GetMd5Hash(randomstr, SaltCode);
                user.tai_khoan = "admin";
                user.super_admin = true;
                user.ten = "Super admin";
                user.trang_thai = 0;
                appContext.nguoi_dung.Add(user);
                #endregion

                #region thêm nguoi_dung_2_nhom_nguoi_dung
                nguoi_dung_2_nhom_nguoi_dung nguoi_dung_2_nhom_nguoi_dung = new nguoi_dung_2_nhom_nguoi_dung();
                nguoi_dung_2_nhom_nguoi_dung.nhom_nguoi_dung_id = nhom_user_id;
                nguoi_dung_2_nhom_nguoi_dung.nguoi_dung_id = user_id;
                appContext.nguoi_dung_2_nhom_nguoi_dung.Add(nguoi_dung_2_nhom_nguoi_dung);
                #endregion

                #region thêm dieu_huong
                // điều hướng cha
                dieu_huong dieu_huong = new dieu_huong();
                dieu_huong.id = dieu_huong_goc_id;
                dieu_huong.ma = "dash-quan-tri-he-thong";
                dieu_huong.ten = "Quản trị hệ thống";
                dieu_huong.duong_dan = "/user";
                dieu_huong.icon = "mdi:cog";
                dieu_huong.so_thu_tu = 4;
                dieu_huong.is_quan_tri = false;
                dieu_huong.mo_ta = null;
                dieu_huong.dieu_huong_cap_tren_id = null;
                dieu_huong.cap_dieu_huong = 1;
                dieu_huong.muc_luc = dieu_huong_goc_id.ToString();
                dieu_huong.super_admin = false;
                dieu_huong.is_router = false;
                dieu_huong.stt_order = "004";
                appContext.dieu_huong.Add(dieu_huong);

                #region điều hướng con User
                dieu_huong dh_user = new dieu_huong();
                dh_user.id = dh_user_id;
                dh_user.ma = "user";
                dh_user.ten = "Người dùng";
                dh_user.duong_dan = "/user";
                dh_user.icon = "mdi:account";
                dh_user.so_thu_tu = 1;
                dh_user.is_quan_tri = true;
                dh_user.mo_ta = null;
                dh_user.dieu_huong_cap_tren_id = dieu_huong_goc_id;
                dh_user.cap_dieu_huong = 2;
                dh_user.muc_luc = dieu_huong_goc_id.ToString() + "\\" + dh_user_id.ToString();
                dh_user.super_admin = false;
                dh_user.is_router = false;
                dh_user.stt_order = "004.001";
                appContext.dieu_huong.Add(dh_user);

                #region thêm quyền sử dụng User
                // ADD
                dieu_huong user_add = new dieu_huong();
                user_add.id = user_add_id;
                user_add.ma = "QTHT_ND_ADD";
                user_add.ten = "Thêm mới, cập nhật người dùng";
                user_add.duong_dan = "/";
                user_add.icon = null;
                user_add.so_thu_tu = 1;
                user_add.is_quan_tri = false;
                user_add.mo_ta = null;
                user_add.dieu_huong_cap_tren_id = dh_user_id;
                user_add.cap_dieu_huong = 3;
                user_add.muc_luc = dieu_huong_goc_id.ToString() + "\\" + dh_user_id.ToString() + "\\" + user_add_id.ToString();
                user_add.super_admin = false;
                user_add.is_router = true;
                user_add.stt_order = "004.001.001";
                appContext.dieu_huong.Add(user_add);

                // REMOVE
                dieu_huong user_remove = new dieu_huong();
                user_remove.id = user_remove_id;
                user_remove.ma = "QTHT_ND_DELETE";
                user_remove.ten = "Xóa người dùng";
                user_remove.duong_dan = "/";
                user_remove.icon = null;
                user_remove.so_thu_tu = 2;
                user_remove.is_quan_tri = false;
                user_remove.mo_ta = null;
                user_remove.dieu_huong_cap_tren_id = dh_user_id;
                user_remove.cap_dieu_huong = 3;
                user_remove.muc_luc = dieu_huong_goc_id.ToString() + "\\" + dh_user_id.ToString() + "\\" + user_remove_id.ToString();
                user_remove.super_admin = false;
                user_remove.is_router = true;
                user_remove.stt_order = "004.001.002";
                appContext.dieu_huong.Add(user_remove);

                // VIEW
                dieu_huong user_view = new dieu_huong();
                user_view.id = user_view_id;
                user_view.ma = "QTHT_ND_VIEW";
                user_view.ten = "Xem thông tin chi tiết người dùng";
                user_view.duong_dan = "/";
                user_view.icon = null;
                user_view.so_thu_tu = 3;
                user_view.is_quan_tri = false;
                user_view.mo_ta = null;
                user_view.dieu_huong_cap_tren_id = dh_user_id;
                user_view.cap_dieu_huong = 3;
                user_view.muc_luc = dieu_huong_goc_id.ToString() + "\\" + dh_user_id.ToString() + "\\" + user_view_id.ToString();
                user_view.super_admin = false;
                user_view.is_router = true;
                user_view.stt_order = "004.001.003";
                appContext.dieu_huong.Add(user_view);

                // RESET_PASS
                dieu_huong user_reset_pass = new dieu_huong();
                user_reset_pass.id = user_reset_pass_id;
                user_reset_pass.ma = "QTHT_ND_RESET_PASS";
                user_reset_pass.ten = "Reset mật khẩu người dùng";
                user_reset_pass.duong_dan = "/";
                user_reset_pass.icon = null;
                user_reset_pass.so_thu_tu = 4;
                user_reset_pass.is_quan_tri = false;
                user_reset_pass.mo_ta = null;
                user_reset_pass.dieu_huong_cap_tren_id = dh_user_id;
                user_reset_pass.cap_dieu_huong = 3;
                user_reset_pass.muc_luc = dieu_huong_goc_id.ToString() + "\\" + dh_user_id.ToString() + "\\" + user_reset_pass_id.ToString();
                user_reset_pass.super_admin = false;
                user_reset_pass.is_router = true;
                user_reset_pass.stt_order = "004.001.004";
                appContext.dieu_huong.Add(user_reset_pass);

                // LOCK
                dieu_huong user_lock = new dieu_huong();
                user_lock.id = user_lock_id;
                user_lock.ma = "QTHT_ND_LOCK";
                user_lock.ten = "Khóa tài khoản người dùng";
                user_lock.duong_dan = "/";
                user_lock.icon = null;
                user_lock.so_thu_tu = 5;
                user_lock.is_quan_tri = false;
                user_lock.mo_ta = null;
                user_lock.dieu_huong_cap_tren_id = dh_user_id;
                user_lock.cap_dieu_huong = 3;
                user_lock.muc_luc = dieu_huong_goc_id.ToString() + "\\" + dh_user_id.ToString() + "\\" + user_lock_id.ToString();
                user_lock.super_admin = false;
                user_lock.is_router = true;
                user_lock.stt_order = "004.001.005";
                appContext.dieu_huong.Add(user_lock);
                #endregion
                #endregion

                #region điều hướng con Nhóm người dùng
                dieu_huong dh_nhomnguoidung = new dieu_huong();
                dh_nhomnguoidung.id = dh_nhomnguoidung_id;
                dh_nhomnguoidung.ma = "nhom-nguoidung";
                dh_nhomnguoidung.ten = "Nhóm người dùng";
                dh_nhomnguoidung.duong_dan = "/nhom-nguoidung";
                dh_nhomnguoidung.icon = "mdi:badge-account-alert-outline";
                dh_nhomnguoidung.so_thu_tu = 2;
                dh_nhomnguoidung.is_quan_tri = true;
                dh_nhomnguoidung.mo_ta = null;
                dh_nhomnguoidung.dieu_huong_cap_tren_id = dieu_huong_goc_id;
                dh_nhomnguoidung.cap_dieu_huong = 2;
                dh_nhomnguoidung.muc_luc = dieu_huong_goc_id.ToString() + "\\" + dh_nhomnguoidung_id.ToString();
                dh_nhomnguoidung.super_admin = false;
                dh_nhomnguoidung.is_router = false;
                dh_nhomnguoidung.stt_order = "004.002";
                appContext.dieu_huong.Add(dh_nhomnguoidung);

                #region thêm quyền sử dụng Nhóm người dùng
                // ADD
                dieu_huong nhom_user_add = new dieu_huong();
                nhom_user_add.id = nhom_user_add_id;
                nhom_user_add.ma = "QTHT_NND_ADD";
                nhom_user_add.ten = "Thêm mới, cập nhật nhóm người dùng";
                nhom_user_add.duong_dan = "/";
                nhom_user_add.icon = null;
                nhom_user_add.so_thu_tu = 1;
                nhom_user_add.is_quan_tri = false;
                nhom_user_add.mo_ta = null;
                nhom_user_add.dieu_huong_cap_tren_id = dh_nhomnguoidung_id;
                nhom_user_add.cap_dieu_huong = 3;
                nhom_user_add.muc_luc = dieu_huong_goc_id.ToString() + "\\" + dh_nhomnguoidung_id.ToString() + "\\" + nhom_user_add_id.ToString();
                nhom_user_add.super_admin = false;
                nhom_user_add.is_router = true;
                nhom_user_add.stt_order = "004.002.001";
                appContext.dieu_huong.Add(nhom_user_add);

                // REMOVE
                dieu_huong nhom_user_remove = new dieu_huong();
                nhom_user_remove.id = nhom_user_remove_id;
                nhom_user_remove.ma = "QTHT_NND_DELETE";
                nhom_user_remove.ten = "Xóa nhóm người dùng";
                nhom_user_remove.duong_dan = "/";
                nhom_user_remove.icon = null;
                nhom_user_remove.so_thu_tu = 2;
                nhom_user_remove.is_quan_tri = false;
                nhom_user_remove.mo_ta = null;
                nhom_user_remove.dieu_huong_cap_tren_id = dh_nhomnguoidung_id;
                nhom_user_remove.cap_dieu_huong = 3;
                nhom_user_remove.muc_luc = dieu_huong_goc_id.ToString() + "\\" + dh_nhomnguoidung_id.ToString() + "\\" + nhom_user_remove_id.ToString();
                nhom_user_remove.super_admin = false;
                nhom_user_remove.is_router = true;
                nhom_user_remove.stt_order = "004.002.002";
                appContext.dieu_huong.Add(nhom_user_remove);

                // VIEW
                dieu_huong nhom_user_view = new dieu_huong();
                nhom_user_view.id = nhom_user_view_id;
                nhom_user_view.ma = "QTHT_NND_VIEW";
                nhom_user_view.ten = "Xem chi tiết nhóm người dùng";
                nhom_user_view.duong_dan = "/";
                nhom_user_view.icon = null;
                nhom_user_view.so_thu_tu = 3;
                nhom_user_view.is_quan_tri = false;
                nhom_user_view.mo_ta = null;
                nhom_user_view.dieu_huong_cap_tren_id = dh_nhomnguoidung_id;
                nhom_user_view.cap_dieu_huong = 3;
                nhom_user_view.muc_luc = dieu_huong_goc_id.ToString() + "\\" + dh_nhomnguoidung_id.ToString() + "\\" + nhom_user_view_id.ToString();
                nhom_user_view.super_admin = false;
                nhom_user_view.is_router = true;
                nhom_user_view.stt_order = "004.002.003";
                appContext.dieu_huong.Add(nhom_user_view);
                #endregion
                #endregion

                #region điều hướng con Điều hướng
                dieu_huong dh_dieuhuong = new dieu_huong();
                dh_dieuhuong.id = dh_dieuhuong_id;
                dh_dieuhuong.ma = "dieuhuong";
                dh_dieuhuong.ten = "Điều hướng";
                dh_dieuhuong.duong_dan = "/dieuhuong";
                dh_dieuhuong.icon = "mdi:source-branch";
                dh_dieuhuong.so_thu_tu = 3;
                dh_dieuhuong.is_quan_tri = true;
                dh_dieuhuong.mo_ta = null;
                dh_dieuhuong.dieu_huong_cap_tren_id = dieu_huong_goc_id;
                dh_dieuhuong.cap_dieu_huong = 2;
                dh_dieuhuong.muc_luc = dieu_huong_goc_id.ToString() + "\\" + dh_dieuhuong_id.ToString();
                dh_dieuhuong.super_admin = false;
                dh_dieuhuong.is_router = false;
                dh_dieuhuong.stt_order = "004.003";
                appContext.dieu_huong.Add(dh_dieuhuong);

                #region thêm quyền sử dụng Nhóm người dùng
                // ADD
                dieu_huong dieuhuong_add = new dieu_huong();
                dieuhuong_add.id = dieuhuong_add_id;
                dieuhuong_add.ma = "QTHT_DH_ADD";
                dieuhuong_add.ten = "Thêm mới, cập nhật điều hướng";
                dieuhuong_add.duong_dan = "/";
                dieuhuong_add.icon = null;
                dieuhuong_add.so_thu_tu = 1;
                dieuhuong_add.is_quan_tri = false;
                dieuhuong_add.mo_ta = null;
                dieuhuong_add.dieu_huong_cap_tren_id = dh_dieuhuong_id;
                dieuhuong_add.cap_dieu_huong = 3;
                dieuhuong_add.muc_luc = dieu_huong_goc_id.ToString() + "\\" + dh_dieuhuong_id.ToString() + "\\" + dieuhuong_add_id.ToString();
                dieuhuong_add.super_admin = false;
                dieuhuong_add.is_router = true;
                dieuhuong_add.stt_order = "004.003.001";
                appContext.dieu_huong.Add(dieuhuong_add);

                // REMOVE
                dieu_huong dieuhuong_remove = new dieu_huong();
                dieuhuong_remove.id = dieuhuong_remove_id;
                dieuhuong_remove.ma = "QTHT_DH_DELETE";
                dieuhuong_remove.ten = "Xóa điều hướng";
                dieuhuong_remove.duong_dan = "/";
                dieuhuong_remove.icon = null;
                dieuhuong_remove.so_thu_tu = 2;
                dieuhuong_remove.is_quan_tri = false;
                dieuhuong_remove.mo_ta = null;
                dieuhuong_remove.dieu_huong_cap_tren_id = dh_dieuhuong_id;
                dieuhuong_remove.cap_dieu_huong = 3;
                dieuhuong_remove.muc_luc = dieu_huong_goc_id.ToString() + "\\" + dh_dieuhuong_id.ToString() + "\\" + dieuhuong_remove_id.ToString();
                dieuhuong_remove.super_admin = false;
                dieuhuong_remove.is_router = true;
                dieuhuong_remove.stt_order = "004.003.002";
                appContext.dieu_huong.Add(dieuhuong_remove);

                // VIEW
                dieu_huong dieuhuong_view = new dieu_huong();
                dieuhuong_view.id = dieuhuong_view_id;
                dieuhuong_view.ma = "QTHT_DH_VIEW";
                dieuhuong_view.ten = "Xem thông tin chi tiết điều hướng";
                dieuhuong_view.duong_dan = "/";
                dieuhuong_view.icon = null;
                dieuhuong_view.so_thu_tu = 3;
                dieuhuong_view.is_quan_tri = false;
                dieuhuong_view.mo_ta = null;
                dieuhuong_view.dieu_huong_cap_tren_id = dh_dieuhuong_id;
                dieuhuong_view.cap_dieu_huong = 3;
                dieuhuong_view.muc_luc = dieu_huong_goc_id.ToString() + "\\" + dh_dieuhuong_id.ToString() + "\\" + dieuhuong_view_id.ToString();
                dieuhuong_view.super_admin = false;
                dieuhuong_view.is_router = true;
                dieuhuong_view.stt_order = "004.003.003";
                appContext.dieu_huong.Add(dieuhuong_view);
                #endregion
                #endregion

                #endregion
                appContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
