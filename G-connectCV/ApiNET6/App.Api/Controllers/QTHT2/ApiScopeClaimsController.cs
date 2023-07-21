using App.Business.Services.QTHT2;
using App.Business.Services.QTHT;
using App.Common.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Api.Controllers.QTHT2
{
    /// <summary>
    /// ApiScopeClaims
    /// </summary>
    [Route("api/link-ApiScopeClaims")]
    //phongnhxxx [AuthorizeApi]
    [ApiController]
    public class ApiScopeClaimsController : ControllerBase
    {
        private readonly ApiScopeClaimsIService _serviceApiScopeClaims;
        private readonly INhatKyHeThongService _nhatkyhethongservice;
        public ApiScopeClaimsController(ApiScopeClaimsIService serviceApiScopeClaims,
            INhatKyHeThongService nhatkyhethongservice)
        {
            _serviceApiScopeClaims = serviceApiScopeClaims;
            _nhatkyhethongservice = nhatkyhethongservice;
        }

        #region GetPage
        /// <summary>
        /// Lấy danh sách 
        /// </summary>
        /// <param name="page">default = 1, lựa chọn page hiển thị</param>
        /// <param name="page_size"> cấu hình số dòng trả ra trong 1 page </param>
        /// <param name="sort">  sort = { field:value }</param>
        /// <param name="filter"> filter = { field:value }</param>
        /// <param name="search">Từ khóa tìm kiếm </param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<ActionResult> Get(int page = 1, int page_size = 0, string sort = null, string filter = null, string search = null)
        {
            try
            {
                var result = await _serviceApiScopeClaims.GetManyAsync<ApiScopeClaimsDTO>(page, page_size, sort, filter, search);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var err = ErrorCtr.ExtractErrorInfo(ex);
                return StatusCode(Convert.ToInt32(err.statusCode), err);
            }
        }
        #endregion
        #region GetAll 
        /// <summary>
        /// Lấy danh sách 
        /// </summary>
        /// <param name="page">default = 1, lựa chọn page hiển thị</param>
        /// <param name="page_size"> cấu hình số dòng trả ra trong 1 page </param>
        /// <param name="sort">  sort = { field:value }</param>
        /// <param name="filter"> filter = { field:value }</param>
        /// <param name="search">Từ khóa tìm kiếm </param>
        /// <returns></returns>
        [HttpGet]
        [Route("all")]
        public async Task<ActionResult> GetAll(string sort = null, string filter = null, string search = null)
        {
            try
            {
                var result = await _serviceApiScopeClaims.GetManyAsync<ApiScopeClaimsDTO>(1, 1000000, sort, filter, search);
                return Ok(result.data);
            }
            catch (Exception ex)
            {
                var err = ErrorCtr.ExtractErrorInfo(ex);
                return StatusCode(Convert.ToInt32(err.statusCode), err);
            }
        }
        #endregion
        #region Get2Select
        /// <summary>
        /// Lấy danh sách 
        /// </summary>
        /// <param name="page">default = 1, lựa chọn page hiển thị</param>
        /// <param name="page_size"> cấu hình số dòng trả ra trong 1 page </param>
        /// <param name="sort">  sort = { field:value }</param>
        /// <param name="filter"> filter = { field:value }</param>
        /// <param name="search">Từ khóa tìm kiếm </param>
        /// <returns></returns>
        [HttpGet]
        [Route("select")]
        public async Task<ActionResult> GetSelect(string sort = null, string filter = null, string search = null)
        {
            try
            {
                var result = await _serviceApiScopeClaims.GetManyAsync<ApiScopeClaimsSelectDTO>(1, 1000000, sort, filter, search);
                return Ok(result.data);
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
        /// Lấy thông tin 1 bản ghi
        /// </summary>
        /// <param name="id">là id của bản ghi</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var result = await _serviceApiScopeClaims.GetByIdAsync<ApiScopeClaimsDTO>(id);
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
        /// Thêm mới 
        /// </summary>
        /// <param name="obj">object dạng json chứa dữ liệu thêm mới</param>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create([FromBody] ApiScopeClaimsDTO obj)
        {
            try
            {
                var result = await _serviceApiScopeClaims.CreateAsync<ApiScopeClaimsDTO>(obj);

                try
                {
                    if (result != null)
                    {
                        NhatKyHeThongDTO nkht = new NhatKyHeThongDTO();
                        nkht.bang = "ApiScopeClaims";
                        nkht.ban_ghi_id = App.Business.Base.CommonInit.IntToGuid(result.id);
                        nkht.duong_dan = "/link-ApiScopeClaims-view/" + result.id.ToString();
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
        /// Cập nhật 
        /// </summary>
        /// <param name="obj">object dạng json chứa dữ liệu cập nhật</param>
        /// <param name="id">id của bản ghi</param>
        /// <returns></returns>
        [HttpPut("{id}")]

        public async Task<ActionResult> Update([FromBody] ApiScopeClaimsDTO obj, int id)
        {
            try
            {
                var result = await _serviceApiScopeClaims.UpdateAsync<ApiScopeClaimsDTO>(obj, id);

                try
                {
                    if (result != null)
                    {
                        NhatKyHeThongDTO nkht = new NhatKyHeThongDTO();
                        nkht.bang = "ApiScopeClaims";
                        nkht.ban_ghi_id = App.Business.Base.CommonInit.IntToGuid(result.id);
                        nkht.duong_dan = "/link-ApiScopeClaims-view/" + result.id.ToString();
                        nkht.hanh_dong = "234";

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
        /// Xóa 1
        /// </summary>
        /// <param name="id">id của bản ghi</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _serviceApiScopeClaims.DeleteAsync(id);

                try
                {
                    if (result > 0)
                    {
                        NhatKyHeThongDTO nkht = new NhatKyHeThongDTO();
                        nkht.bang = "ApiScopeClaims";
                        nkht.ban_ghi_id = App.Business.Base.CommonInit.IntToGuid(id);
                        nkht.duong_dan = "";
                        nkht.hanh_dong = "235";

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
        /// Xóa nhiều 
        /// </summary>
        /// <param name="ids"> VD: ids=id1,id2,id3</param>
        /// <returns></returns>
        [HttpPost]
        [Route("deletes")]
        public async Task<ActionResult> Deletes([FromBody] List<int> ids)
        {

            try
            {
                var result = await _serviceApiScopeClaims.DeletesAsync(ids);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var err = ErrorCtr.ExtractErrorInfo(ex);
                return StatusCode(Convert.ToInt32(err.statusCode), err);
            }
        }
        #endregion

//add more actions

    }
}

