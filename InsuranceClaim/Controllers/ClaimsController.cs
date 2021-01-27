using InsuranceClaim.Interface;
using InsuranceClaim.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceClaim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {

        private readonly IClaims _iClaims;
        public ClaimsController(IClaims iClaims)
        {
            _iClaims = iClaims;            
        }


        [HttpGet]
        [Route("GetClaimByDate")]
        public ActionResult<List<Claims>> GetClaimByDate(DateTime inputDate)
        {
            var Claimlist = _iClaims.GetClaimByDate(inputDate);
            return Ok(Claimlist);
        }
        [HttpGet]
        [Route("GetName")]
        public ActionResult<string> GetName(string name)
        {
           
            return Ok("name");
        }

    }
}
