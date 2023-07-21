﻿using App.Business.Services.QTHT;
using App.Business.Utils;
using App.Common.Base;
using App.Data.Models.QTHT;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static NetOffice.OfficeApi.Tools.Contribution.DialogUtils;

namespace App.Api.Controllers.QTHT
{
    /// <summary>
    /// QTHT - Người dùng
    /// </summary>
    [Route("api/qtht-nguoi-dung")]
    //phongnhxxx [AuthorizeApi]
    [ApiController]
    public class QTHT_NguoiDungController : ControllerBase
    {
        private readonly INguoiDungService _nguoiDungService;
        private readonly INhatKyHeThongService _nhatkyhethongservice;
        public QTHT_NguoiDungController(INguoiDungService nguoiDungService,
            INhatKyHeThongService nhatkyhethongservice
            )
        {
            _nguoiDungService = nguoiDungService;
            _nhatkyhethongservice = nhatkyhethongservice;
        }

        #region GetAll 
        /// <summary>
        /// Lấy danh sách người dùng
        /// </summary>
        /// <param name="page">default = 1, lựa chọn page hiển thị</param>
        /// <param name="page_size"> cấu hình số dòng trả ra trong 1 page </param>
        /// <param name="sort">  sort = { field:value }</param>
        /// <param name="filter"> filter = { field:value }</param>
        /// <param name="search">Từ khóa tìm kiếm </param>
        /// <param name="is_select_data">Từ khóa tìm kiếm </param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<ActionResult> Get(int page = 1, int page_size = 0, string sort = null, string filter = null, string search = null, bool is_select_data = false)
        {
            try
            {
                if (!is_select_data)
                {
                    var result = await _nguoiDungService.GetManyAsync<NguoiDungDTO>(page, page_size, sort, filter, search);
                    return Ok(result);
                }
                else
                {
                    var result = await _nguoiDungService.GetManyAsync<NguoiDungSelectDTO>(page, page_size, sort, filter, search);
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                var err = ErrorCtr.ExtractErrorInfo(ex);
                return StatusCode(Convert.ToInt32(err.statusCode), err);
            }
        }
        #endregion
        #region GetbyId
        /// <summary>
        /// Lấy thông tin 1 người dùng
        /// </summary>
        /// <param name="id">là id của bản ghi</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _nguoiDungService.GetByIdAsync<NguoiDungDTO>(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var err = ErrorCtr.ExtractErrorInfo(ex);
                return StatusCode(Convert.ToInt32(err.statusCode), err);
            }
        }
        #endregion
        #region Create
        /// <summary>
        /// Thêm mới người dùng
        /// </summary>
        /// <param name="obj">object dạng json chứa dữ liệu thêm mới</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] NguoiDungDTO obj)
        {
            try
            {
                var result = await _nguoiDungService.CreateAsync<NguoiDungDTO>(obj);

                try
                {
                    if (result != null)
                    {
                        NhatKyHeThongDTO nkht = new NhatKyHeThongDTO();
                        nkht.bang = "qtht_nguoi_dung";
                        nkht.ban_ghi_id = result.id;
                        nkht.duong_dan = "/user-view/" + result.id.ToString();
                        nkht.hanh_dong = "208";

                        _nhatkyhethongservice.CreateNhatKyHeThong(nkht);
                    }
                }
                catch (Exception ex)
                {
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                var err = ErrorCtr.ExtractErrorInfo(ex);
                return StatusCode(Convert.ToInt32(err.statusCode), err);
            }
        }
        #endregion
        #region Update
        /// <summary>
        /// Cập nhật người dùng
        /// </summary>
        /// <param name="obj">object dạng json chứa dữ liệu cập nhật</param>
        /// <param name="id">id của bản ghi</param>
        /// <returns></returns>
        [HttpPut("{id}")]

        public async Task<ActionResult> Update([FromBody] NguoiDungDTO obj, Guid id)
        {
            try
            {
                var result = await _nguoiDungService.UpdateAsync<NguoiDungDTO>(obj, id);

                try
                {
                    if (result != null)
                    {
                        NhatKyHeThongDTO nkht = new NhatKyHeThongDTO();
                        nkht.bang = "qtht_nguoi_dung";
                        nkht.ban_ghi_id = result.id;
                        nkht.duong_dan = "/user-view/" + result.id.ToString();
                        nkht.hanh_dong = "209";

                        _nhatkyhethongservice.CreateNhatKyHeThong(nkht);
                    }
                }
                catch (Exception ex)
                {
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                var err = ErrorCtr.ExtractErrorInfo(ex);
                return StatusCode(Convert.ToInt32(err.statusCode), err);
            }
        }
        #endregion
        #region Delete
        /// <summary>
        /// Xóa 1 người dùng
        /// </summary>
        /// <param name="id">id của bản ghi</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var result = await _nguoiDungService.DeleteAsync(id);

                try
                {
                    if (result > 0)
                    {
                        NhatKyHeThongDTO nkht = new NhatKyHeThongDTO();
                        nkht.bang = "qtht_nguoi_dung";
                        nkht.ban_ghi_id = id;
                        nkht.duong_dan = "";
                        nkht.hanh_dong = "211";

                        _nhatkyhethongservice.CreateNhatKyHeThong(nkht);
                    }
                }
                catch (Exception ex)
                {
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                var err = ErrorCtr.ExtractErrorInfo(ex);
                return StatusCode(Convert.ToInt32(err.statusCode), err);
            }

        }
        #endregion
        #region Deletes
        /// <summary>
        /// Xóa nhiều người dùng 
        /// </summary>
        /// <param name="ids"> VD: ids=id1,id2,id3</param>
        /// <returns></returns>
        [HttpPost]
        [Route("deletes")]
        public async Task<ActionResult> Deletes([FromBody] List<Guid> ids)
        {

            try
            {
                var result = await _nguoiDungService.DeletesAsync(ids);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var err = ErrorCtr.ExtractErrorInfo(ex);
                return StatusCode(Convert.ToInt32(err.statusCode), err);
            }
        }
        #endregion
        #region Reset password
        /// <summary>
        /// Reset password
        /// </summary>
        /// <param name="id">id của bản ghi</param>
        /// <returns></returns>
        [HttpGet]
        [Route("reset-password/{id}")]
        public async Task<ActionResult> ResetPassword(Guid id)
        {
            try
            {
                var result = _nguoiDungService.ResetPassword(id);

                try
                {
                    if (result == true)
                    {
                        NhatKyHeThongDTO nkht = new NhatKyHeThongDTO();
                        nkht.bang = "qtht_nguoi_dung";
                        nkht.ban_ghi_id = id;
                        nkht.duong_dan = "/user-view/" + id.ToString();
                        nkht.hanh_dong = "210";

                        _nhatkyhethongservice.CreateNhatKyHeThong(nkht);
                    }
                }
                catch (Exception ex)
                {
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                var err = ErrorCtr.ExtractErrorInfo(ex);
                return StatusCode(Convert.ToInt32(err.statusCode), err);
            }

        }
        #endregion

        #region Thêm mới nhóm cho người dùng vào bảng trung gian
        /// <summary>
        /// Thêm mới nhóm cho người dùng vào bảng trung gian
        /// </summary>
        /// <param name="obj">object dạng json chứa dữ liệu thêm mới</param>
        /// <returns></returns>
        [HttpPost]
        [Route("add-group-to-user")]
        public async Task<ActionResult> AddGroupToUser(UpdateNhomNDFromND obj)
        {
            try
            {
                var result = _nguoiDungService.AddGroupToUser(obj);

                try
                {
                    if (result == true)
                    {
                        NhatKyHeThongDTO nkht = new NhatKyHeThongDTO();
                        nkht.bang = "qtht_nguoi_dung";
                        nkht.ban_ghi_id = obj.nguoi_dung_id;
                        nkht.duong_dan = "/user-view/" + obj.nguoi_dung_id.ToString();
                        nkht.hanh_dong = "213";

                        _nhatkyhethongservice.CreateNhatKyHeThong(nkht);
                    }
                }
                catch (Exception ex)
                {
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                var err = ErrorCtr.ExtractErrorInfo(ex);
                return StatusCode(Convert.ToInt32(err.statusCode), err);
            }
        }
        #endregion
        #region OpenUnlockAccount
        /// <summary>
        /// Khóa, mở tài khoản
        /// </summary>
        /// <param name="id">id của bản ghi</param>
        /// <returns></returns>
        [HttpGet]
        [Route("open-unlock-acount/{id}")]
        public async Task<ActionResult> OpenUnlockAccount(Guid id)
        {
            try
            {
                var result = _nguoiDungService.OpenUnlockAccount(id);

                try
                {
                    if (result == true)
                    {
                        NhatKyHeThongDTO nkht = new NhatKyHeThongDTO();
                        nkht.bang = "qtht_nguoi_dung";
                        nkht.ban_ghi_id = id;
                        nkht.duong_dan = "/user-view/" + id.ToString();
                        nkht.hanh_dong = "211";

                        _nhatkyhethongservice.CreateNhatKyHeThong(nkht);
                    }
                }
                catch (Exception ex)
                {
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                var err = ErrorCtr.ExtractErrorInfo(ex);
                return StatusCode(Convert.ToInt32(err.statusCode), err);
            }

        }
        #endregion

        #region Check lock tài khoản
        /// <summary>
        /// Khóa, mở tài khoản
        /// </summary>
        /// <param name="id">id của bản ghi</param>
        /// <returns></returns>
        [HttpGet]
        [Route("checkLock/{id}")]
        public async Task<ActionResult> CheckLockTK(Guid id)
        {
            try
            {
                var result = _nguoiDungService.CheckTkIsLock(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var err = ErrorCtr.ExtractErrorInfo(ex);
                return StatusCode(Convert.ToInt32(err.statusCode), err);
            }

        }
        #endregion

        #region OpenUnlockAccount
        /// <summary>
        /// Khóa, mở tài khoản
        /// </summary>
        /// <param name="id">id của bản ghi</param>
        /// <returns></returns>
        [HttpGet]
        [Route("doimatkhau")]
        public async Task<ActionResult> DoiMatKhau(string mat_khau)
        {
            try
            {
                var result = _nguoiDungService.doimatkhau(mat_khau);

                try
                {
                    if (result == true)
                    {
                        var currentUser = AppHelpers.GetCurrentUser();

                        NhatKyHeThongDTO nkht = new NhatKyHeThongDTO();
                        nkht.bang = "qtht_nguoi_dung";
                        nkht.ban_ghi_id = currentUser.id;
                        nkht.duong_dan = "/thong-tin-tai-khoan";
                        nkht.hanh_dong = "377";

                        _nhatkyhethongservice.CreateNhatKyHeThong(nkht);
                    }
                }
                catch (Exception ex)
                {
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                var err = ErrorCtr.ExtractErrorInfo(ex);
                return StatusCode(Convert.ToInt32(err.statusCode), err);
            }

        }
        [HttpGet]
        [Route("checkmatkhau")]
        public async Task<ActionResult> CheckMatKhau(string mat_khau)
        {
            try
            {
                var currentUser = AppHelpers.GetCurrentUser();

                var nguoiDung = _nguoiDungService.XacThucDangNhap(currentUser.tai_khoan, mat_khau);
                if (nguoiDung != null)
                {
                    return Ok(true);
                }
                else
                    return Ok(null);
            }
            catch (Exception ex)
            {
                var err = ErrorCtr.ExtractErrorInfo(ex);
                return StatusCode(Convert.ToInt32(err.statusCode), err);
            }

        }
        #endregion


        #region GetPermissionUser
        /*
        /// <summary>
        /// Lấy quyền người dùng
        /// </summary>
        /// <returns></returns>*/
        [HttpGet]
        [Route("get-permission-user")]
        public async Task<ActionResult> GetPermissionUser()
        {
            try
            {
                var result = _nguoiDungService.GetPermissionUser();
                return Ok(result);
            }
            catch (Exception ex)
            {
                var err = ErrorCtr.ExtractErrorInfo(ex);
                return StatusCode(Convert.ToInt32(err.statusCode), err);
            }

        }
        #endregion

        #region
        [HttpGet]
        [Route("get-all-nguoi-dung-email")]
        public  ActionResult GetAllNguoiDungEmail()
        {
            try
            {
                var result = _nguoiDungService.GetAllNguoiDungEmail();
                return Ok(result);
            }
            catch (Exception ex)
            {
                var err = ErrorCtr.ExtractErrorInfo(ex);
                return StatusCode(Convert.ToInt32(err.statusCode), err);
            }
        }
        #endregion
        #region
        [HttpGet]
        [Route("get-all-nguoi-dung")]
        public ActionResult GetAllNguoiDung()
        {
            try
            {
                var result = _nguoiDungService.GetAllNguoiDung();
                return Ok(result);
            }
            catch (Exception ex)
            {
                var err = ErrorCtr.ExtractErrorInfo(ex);
                return StatusCode(Convert.ToInt32(err.statusCode), err);
            }
        }
        #endregion

        #region
        [HttpGet]
        [Route("get-all-nguoi-dung-by-nhom")]
        public ActionResult GetAllNguoiDungByNhom(string ma_nhom)
        {
            try
            {
                var result = _nguoiDungService.GetAllNguoiDungByNhom(ma_nhom);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var err = ErrorCtr.ExtractErrorInfo(ex);
                return StatusCode(Convert.ToInt32(err.statusCode), err);
            }
        }
        #endregion
    }
}