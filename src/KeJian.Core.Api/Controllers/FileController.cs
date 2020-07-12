using System;
using System.IO;
using System.Threading.Tasks;
using KeJian.Core.Library.Exception;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;

namespace KeJian.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly string _fileUploadingPath;
        private readonly string _fileServerHost;

        public FileController(IConfiguration configuration)
        {
#if DEBUG
            _fileUploadingPath = "C:\\temp";
#else
            _fileUploadingPath = configuration.GetSection("FileUploadingPath").Value;
            _fileServerHost = configuration.GetSection("FileServerHost").Value;
#endif
        }

        /// <summary>
        ///     流式文件上传
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        [HttpPost("UploadingStream")]
        public async Task<string> UploadingStream(string fileName)
        {
            var boundary = HeaderUtilities.RemoveQuotes(MediaTypeHeaderValue.Parse(Request.ContentType).Boundary).Value;

            if (boundary == null)
                throw new StringResponseException("boundary is null");

            var reader = new MultipartReader(boundary, HttpContext.Request.Body);
            var section = await reader.ReadNextSectionAsync();

            while (section != null)
            {
                var hasContentDispositionHeader =
                    ContentDispositionHeaderValue.TryParse(section.ContentDisposition, out _);
                if (hasContentDispositionHeader)
                {
                    await WriteFileAsync(section.Body, Path.Combine(_fileUploadingPath, fileName));
                }

                section = await reader.ReadNextSectionAsync();
            }

            return _fileServerHost + "/" + fileName;
        }

        /// <summary>
        ///     缓存式文件上传
        /// </summary>
        [HttpPost("UploadingFormFile")]
        public async Task<IActionResult> UploadingFormFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new StringResponseException("file is null");

            await using var stream = file.OpenReadStream();
            var fileExtension = Path.GetExtension(file.FileName);
            var randomFileName = Guid.NewGuid() + "." + fileExtension;
            await WriteFileAsync(stream, Path.Combine(_fileUploadingPath, randomFileName));
            return Created(nameof(FileController), null);
        }

        /// <summary>
        ///     写文件导到磁盘
        /// </summary>
        /// <param name="stream">文件流</param>
        /// <param name="path">文件保存路径</param>
        /// <returns></returns>
        private static async Task<int> WriteFileAsync(Stream stream, string path)
        {
            const int fileWriteSize = 84975; //写出缓冲区大小
            var writeCount = 0;
            await using var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write,
                fileWriteSize, true);

            var byteArr = new byte[fileWriteSize];
            var readCount = 0;
            while ((readCount = await stream.ReadAsync(byteArr, 0, byteArr.Length)) > 0)
            {
                await fileStream.WriteAsync(byteArr, 0, readCount);
                writeCount += readCount;
            }

            return writeCount;
        }
    }
}