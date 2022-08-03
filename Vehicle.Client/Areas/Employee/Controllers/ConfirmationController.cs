using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vehicle.Bll.Repositories;
using Vehicle.Client.Areas.Employee.Models;

namespace Vehicle.Client.Areas.Employee.Controllers
{
    public class ConfirmationController : Controller
    {
        #region Connections

        private readonly IConfirmationServiceBusiness _confirmationServiceBusiness;
        public ConfirmationController(IConfirmationServiceBusiness confirmationServiceBusiness)
        {
            _confirmationServiceBusiness = confirmationServiceBusiness;
        }

        #endregion

        // GET: Employee/Confirmation
        public ActionResult Confirmations()
        {
            return View();
        }

        public JsonResult GetConfirmations(GetConfirmationsVm model)
        {  
            var result = _confirmationServiceBusiness.GetConfirmationsByUserId(model.EmployeeId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}