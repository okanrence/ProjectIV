using Byaxiom.Logger;
using ProjectIV.Core.Domain;
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
    public class ClientController : ApiController
    {
        private readonly IClientServices _clientService;

        public ClientController(IClientServices clientService)
        {
            this._clientService = clientService;
        }
        [HttpPost]
        public IHttpActionResult Add([FromBody]ClientVM oClientVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var oStaffProfile = _clientService.Add(oClientVM);
                if (oStaffProfile >= 1)
                    return Ok(oClientVM);
                return BadRequest("Sever could not fulfil request");
            }
            catch (Exception ex) {
                LogHelper.Log(ex);
                return InternalServerError(ex);
            }

        }

        [HttpPut]
        public IHttpActionResult Put([FromBody]ClientVM oClientVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var oStaffProfile = _clientService.Update(oClientVM);
                if (oStaffProfile >= 1)
                    return Ok();
                return BadRequest("Sever could not fulfil request");
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return InternalServerError(ex);
            }

        }

        [HttpGet]
        public IHttpActionResult Get([FromUri]string clientNumber, [FromUri]string companyId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var oStaffProfile = _clientService.Get(clientNumber, companyId);
                if (oStaffProfile != null)
                    return Ok(oStaffProfile);
                return NotFound();
            }
            catch(Exception ex)
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

                var oStaffProfile = _clientService.GetList(companyId);
                if (oStaffProfile != null)
                    return Ok(oStaffProfile);
                return NotFound();
            }
            catch(Exception ex)
            {
                LogHelper.Log(ex);
                return InternalServerError(ex);
            }
           
        }

    }
}
