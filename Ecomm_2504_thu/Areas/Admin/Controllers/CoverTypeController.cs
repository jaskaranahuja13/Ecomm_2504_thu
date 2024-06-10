using Dapper;
using Ecomm_2504_thu.DataAccess.Data.Repository.IRepository;
using Ecomm_2504_thu.Models;
using Ecomm_2504_thu.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecomm_2504_thu.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        #region APIs
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.SPCALL.List<CoverType>(SD.SD_GetCoverTypes) });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var coverTypeInDb = _unitOfWork.CoverType.Get(id);
            if (coverTypeInDb == null) return Json(new { success = false, message = "Something went wrong while deleting data!!!" });
            //_unitOfWork.CoverType.Remove(coverTypeInDb);
            //_unitOfWork.Save();
            DynamicParameters param = new DynamicParameters();
            param.Add("id", id);
            _unitOfWork.SPCALL.Execute(SD.SD_DeleteCoverType, param);
            return Json(new { success = true, message = "Successfully deleted data!!!" });
        }

        #endregion
        public IActionResult Upsert(int? id)
        {
           CoverType coverType=new CoverType();
            if (id == null) return View(coverType);
            //coverType = _unitOfWork.CoverType.Get(id.GetValueOrDefault());
            DynamicParameters param = new DynamicParameters();
            param.Add("id", id);
            coverType = _unitOfWork.SPCALL.OneRecord<CoverType>(SD.SD_GetCoverType, param);
            if (coverType == null) return NotFound();
            return View(coverType);
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CoverType coverType)
        {
            if (coverType == null) return BadRequest();
            if (!ModelState.IsValid)
            {
                return View(coverType);
            }
            DynamicParameters param = new DynamicParameters();
            param.Add("name", coverType.Name);
            if (coverType.Id == 0)
                //_unitOfWork.CoverType.Add(coverType);
                _unitOfWork.SPCALL.Execute(SD.SD_CreateCoverType, param);
            else
            {
                param.Add("id", coverType.Id);
                _unitOfWork.SPCALL.Execute(SD.SD_UpdateCoverType, param);

            }
            //    _unitOfWork.CoverType.Update(coverType);
            //_unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

    }
}
