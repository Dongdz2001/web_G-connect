using App.Business.Services.QTHT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Api.Controllers.UploadFile
{
    [Route("api/file")]
    [RequestSizeLimit(314572800)]
    public class UploadFileController : ControllerBase
    {
        private IFileDinhKemService _service;
        public UploadFileController(IFileDinhKemService _fileDinhKemService)
        {
            _service = _fileDinhKemService;
        }
        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Upload(FileUpload fileUpload)
        {
            try
            {
                var NowTime = DateTime.Now;
                var rootPath = "wwwroot/uploadFiles" + "/" + fileUpload.urlPath + "/" + NowTime.ToString("dd-MM-yyyy");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), rootPath);
                var lstUrl = new List<outPutUploadFile>();
                if (fileUpload.files.Count() > 0)
                {
                    foreach (var formFile in fileUpload.files)
                    {
                        outPutUploadFile outPutUploadFile = new outPutUploadFile();
                        var fileName = NowTime.ToString("hh-mm-ss") + "_" + formFile.FileName;
                        var linkFile = $"uploadFiles/{fileUpload.urlPath}/{DateTime.Now:dd-MM-yyyy}/{fileName}";
                        if (!(Directory.Exists(pathToSave)))
                        {
                            Directory.CreateDirectory(pathToSave);
                        }
                        using (var fs = new FileStream(Path.Combine(pathToSave, fileName), FileMode.Create))
                        {
                            formFile.CopyTo(fs);
                            fs.Close();
                            fs.Dispose();
                        
                        }
                        outPutUploadFile.linkFile = linkFile;
                        outPutUploadFile.tenFile = formFile.FileName;
                        outPutUploadFile.type = formFile.ContentType;
                        lstUrl.Add(outPutUploadFile);
                    }

                }
                return Ok(new { lstUrl });

            }
            catch (IOException ioExp)
            {
                Console.WriteLine(ioExp.Message);
                return Problem(detail: ioExp.Message);
            }
        }

        [HttpPost]
        [Route("delete")]
        public async Task<ActionResult> Delete([FromBody] outPutUploadFile outPutUploadFile)
        {

            try
            {
                var cultureInfo = new CultureInfo("de-DE");
                var rootPath = "wwwroot/" + outPutUploadFile.linkFile;
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), rootPath);
                if (System.IO.File.Exists(pathToSave))
                {
                    System.IO.File.Delete(pathToSave);
                    return Ok(new { data = "File deleted" });
                }
                return Problem(detail: "File not found");
            }
            catch (IOException ioExp)
            {
                Console.WriteLine(ioExp.Message);
                return Problem(detail: ioExp.Message);
            }
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("preview")]
        public async Task<ActionResult> Preview(Guid id_file)
        {

            try
            {
                var result = await _service.GetByIdAsync<FileDinhKemDTO>(id_file);
                if (result != null)
                {
                    return File(result.noi_dung_tep, result.type, result.tenFile); // returns a File
                }
                return NotFound(); // returns a NotFoundResult with Status404NotFound response.

            }
            catch (IOException ioExp)
            {
                Console.WriteLine(ioExp.Message);
                return Problem(detail: ioExp.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("docx")]
        public ActionResult Docx(Guid id_file)
        {

            try
            {
                var result = _service.convertTodoc(id_file);
                if (result != null)
                {
                    return File(result.noi_dung_tep, result.type, result.tenFile); // returns a File
                }
                return NotFound(); // returns a NotFoundResult with Status404NotFound response.

            }
            catch (IOException ioExp)
            {
                Console.WriteLine(ioExp.Message);
                return Problem(detail: ioExp.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("pdf")]
        public async Task<ActionResult> Pdf(Guid id_file)
        {

            try
            {
                var result = await _service.GetByIdAsync<FileDinhKemDTO>(id_file);
                if (result != null)
                {
                    return File(result.file_finish, result.type, result.tenFile); // returns a File
                }
                return NotFound(); // returns a NotFoundResult with Status404NotFound response.

            }
            catch (IOException ioExp)
            {
                Console.WriteLine(ioExp.Message);
                return Problem(detail: ioExp.Message);
            }
        }
        //[HttpPost]
        //[Route("update-file-finish")]
        //public ActionResult upDateFile([FromBody] inPutViewFile inPutViewFile)
        //{

        //    try
        //    {
        //        _service.upDateFileFinish(inPutViewFile.file_dinh_kem_id,inPutViewFile.du_lieu_mau);
        //        return Ok(); // returns a File.

        //    }
        //    catch (IOException ioExp)
        //    {
        //        Console.WriteLine(ioExp.Message);
        //        return Problem(detail: ioExp.Message);
        //    }
        //}
    }
}
