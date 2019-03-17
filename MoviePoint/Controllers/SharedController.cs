using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviePoint.Controllers
{
    public class SharedController : Controller
    {
		// GET: Shared
		public JsonResult UploadImage()
		{
			JsonResult result = new JsonResult();
			result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
			try
			{
				var file = Request.Files[0];
				var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
				var path = Path.Combine(Server.MapPath("~/Assets/UploadedImages/"), fileName);

				file.SaveAs(path);

				result.Data = new { Success = true, ImageUrl = string.Format("/Assets/UploadedImages/{0}", fileName) };


			}
			catch (Exception ex)
			{
				result.Data = new { Success = false, Messege = ex.Message };
			}

			return result;
		}
	}
}