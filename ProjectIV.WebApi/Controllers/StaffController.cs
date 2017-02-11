using Byaxiom.Logger;
using MyAppTools.Services;
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
    public class StaffController : ApiController
    {
        private readonly IStaffServices _staffService;

        public StaffController(IStaffServices authService)
        {
            this._staffService = authService;
        }

        [HttpGet]
        [Route("api/staff/authenticate")]
        public IHttpActionResult AuthenticateUser()
        {
            try
            {
                var emailAddress = UtilityServices.GetHeaderValue(Request, "emailaddress");
                var password = UtilityServices.GetHeaderValue(Request, "password");

                var oStaffProfile = _staffService.Authenticate(emailAddress, password);
                if (oStaffProfile == null)
                    return BadRequest("Invalid Username/Password");
                return Ok(oStaffProfile);
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/staff/assignment/list")]
        public IHttpActionResult GetStaffForAssignment()
        {
            try
            {
                var companyId = UtilityServices.GetHeaderValue(Request, "companyId");

                var oStaffProfile = _staffService.GetListForAssignment(companyId);
                if (oStaffProfile == null)
                    return BadRequest("Failed to create");
                return Ok(oStaffProfile);
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return InternalServerError(ex);
            }

        }

        [HttpGet]
        [Route("api/staff")]
        public IHttpActionResult GetStaff()
        {
            try
            {
                var companyId = UtilityServices.GetHeaderValue(Request, "companyId");

                var oStaffProfile = _staffService.GetList(companyId);
                if (oStaffProfile == null)
                    return NotFound();
                return Ok(oStaffProfile);
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return InternalServerError(ex);
            }

        }

        [HttpPost]
        [Route("api/staff")]
        public IHttpActionResult Post([FromBody]StaffVM oStaffModel)
        {
            try
            {
                var result = _staffService.Add(oStaffModel);
                if (result != 1)
                    return BadRequest("Failed to create");
                return Ok();
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return InternalServerError(ex);
            }

        }

        [HttpPut]
        [Route("api/staff/update")]
        public IHttpActionResult Update([FromBody]StaffVM oStaffModel)
        {
            try
            {
                var result = _staffService.Update(oStaffModel);
                if (result != 1)
                    return BadRequest("Failed to update");
                return Ok();
            }

            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return InternalServerError(ex);
            }

        }
    }
}
