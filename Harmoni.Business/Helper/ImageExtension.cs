using Harmoni.Business.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Business.Helper
{
    public static partial class Extensions
    {
		public static string FileAdd(this IWebHostEnvironment env, string folder, IFormFile file, string content)
		{
			if (!file.ContentType.Contains("image/") && !file.ContentType.Contains("video/"))
			{
				throw new FileExtensionsException("File must be an image or video!");
			}

			string extension = Path.GetExtension(file.FileName);
			string fileName = content + "-" + Guid.NewGuid().ToString().ToLower() + extension;
			var path = Path.Combine(env.WebRootPath, folder, fileName);

			using (FileStream fs = new FileStream(path, FileMode.Create))
			{
				file.CopyTo(fs);
			}

			return fileName;
		}

		public static void ArchiveFile(this IWebHostEnvironment env, string folder, string fileName)
		{
			var actualPath = Path.Combine(env.WebRootPath, folder, fileName);

			if (File.Exists(actualPath))
			{
				var archivePath = Path.Combine(env.WebRootPath, folder, $"archive-{DateTime.Now:yyyyMMddHHmmss}-{fileName}");

				using (FileStream stream = new FileStream(actualPath, FileMode.Open))
				{
					using (FileStream archiveStream = new FileStream(archivePath, FileMode.Create))
					{
						stream.CopyTo(archiveStream);
					}
				}
				File.Delete(actualPath);
			}
			else
			{
				throw new FileDoesNotExsistException($"File does not exist in {actualPath}");
			}
		}
	}
}
