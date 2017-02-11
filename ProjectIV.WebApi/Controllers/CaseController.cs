using Byaxiom.Logger;
using ProjectIV.Core.Models;
using ProjectIV.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectIV.WebApi.Controllers
{
    //  [Authorize]
    public class CaseController : ApiController
    {
        private readonly ICaseServices _caseService;

        public CaseController(ICaseServices caseService)
        {
            this._caseService = caseService;
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody]CaseVM oCaseVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var result = _caseService.Add(oCaseVM);
                if (result >= 1)
                    return Ok(oCaseVM);
                return BadRequest("Server could not fulfil request");
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return InternalServerError(ex);
            }

        }

        [HttpGet]
        public IHttpActionResult Get([FromUri]string CaseNumber, [FromUri]string companyId)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var oCaseVM = _caseService.Get(CaseNumber, companyId);
                if (oCaseVM != null)
                    return Ok(oCaseVM);
                return NotFound();
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return InternalServerError(ex);
            }

        }

        [HttpGet]
        public IHttpActionResult Get([FromUri]string companyId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var oCaseVM = _caseService.GetList(companyId);
                if (oCaseVM != null)
                    return Ok(oCaseVM);
                return NotFound();
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return InternalServerError(ex);
            }



        }

        [HttpGet]
        [Route("api/case/client")]
        public IHttpActionResult GetByClient([FromUri]int clientId, [FromUri]string companyId)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var oCaseVM = _caseService.GetList(clientId, companyId);
                if (oCaseVM != null)
                    return Ok(oCaseVM);
                return NotFound();
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return InternalServerError(ex);
            }

        }

        [HttpGet]
        [Route("api/case/assigned/list")]
        public IHttpActionResult GetAssignedList([FromUri]int caseId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var oCaseVM = _caseService.GetAssignedStaff(caseId);
                if (oCaseVM != null)
                    return Ok(oCaseVM);
                return NotFound();
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return InternalServerError(ex);
            }

        }

    }
}
