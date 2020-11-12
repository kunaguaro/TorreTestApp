using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RestSharp;
using Web.Domain.Entities;
using Web.Domain.Entities.ListElement;
using Web.Domain.Interfaces;
using Web.Domain.Interfaces.RootServices;
using Web.Domain.Views.ListElement;

namespace TorreWebApp.Controllers
{
    public class PersonController : Controller
    {
        private readonly IRootElementService rootService;
        public PersonController(IRootElementService rootService){
            this.rootService = rootService;
        }

        public IActionResult Index()
        {
            ViewBag.periodicityList = Listperiod();
            ViewBag.currencyList = Listcurrency();
            return View();
        }

        private List<SelectListItem> Listperiod()
        {
            List<SelectListItem> Skills = new List<SelectListItem>() {
                new SelectListItem {
                    Text = "hourly", Value = "hourly"
                },
                new SelectListItem {
                    Text = "monthly", Value = "monthly"
                },
                   new SelectListItem {
                    Text = "yearly", Value = "yearly"
                },
             };
            return Skills;
        }

        private List<SelectListItem> Listcurrency()
        {
            List<SelectListItem> Skills = new List<SelectListItem>() {
                new SelectListItem {
                    Text = "USD", Value = "USD"
                },
                new SelectListItem {
                    Text = "INR", Value = "INR"
                },
             };
            return Skills;
        }

        /// <summary>
        /// PAGINATE LOGIC
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="pageNo"></param>
        /// <param name="firstLoad"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetList(ListElementCriteria criteria, int? pageNo, bool firstLoad)
        {
           
            ViewBag.periodicityList = Listperiod();
            ViewBag.currencyList = Listcurrency();
            try
            {
                if (!firstLoad)
                {
                    if (!ModelState.IsValid)
                    {
                        var dataHtmlError = await Utils.BaseUtils.RenderViewAsync(this, "_PersonList", criteria, true);
                        return Json(new { success = "false", html = dataHtmlError });
                    }
                }
                int indexPage = pageNo == null ? 1 : pageNo.Value;
                var listado = rootService.GetPaginateResultOrdersListView(criteria, indexPage, firstLoad);
                var dataHtmlOk = await Utils.BaseUtils.RenderViewAsync(this, "_PersonList", listado, true);

                return Json(new { success = "true", html = dataHtmlOk });
            }
            catch (Exception ex)
            {
                var listado = rootService.GetPaginateResultOrdersListView(criteria, 0, true);
                var dataHtmlError = await Utils.BaseUtils.RenderViewAsync(this, "_PersonList", listado, true);
                return Json(new { success = "error", html = dataHtmlError, message = ex.Message.ToString() });

            }

        }


        [HttpGet]
        public async Task<IActionResult> GetPeopleAsync(string nombreUsuario)
        {
            Root obj = new Root();
            try
            {

                obj = await rootService.FindUserAsync(nombreUsuario);
                return PartialView("_Details", obj);
            }
            catch (Exception ex)
            {
                return PartialView("_Details", obj);
            }

        }

    }
}
