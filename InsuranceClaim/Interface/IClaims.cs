using InsuranceClaim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceClaim.Interface
{
    public interface IClaims
    {
        //Get claims based on Date
        List<Claims> GetClaimByDate(DateTime inputDate);
    }
}
