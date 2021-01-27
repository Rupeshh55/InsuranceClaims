using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceClaim.Models
{
    public class Claims
    {
        public Claims()
        {
            EnrolledMember = new Member();
        }

        public DateTime ClaimDate { get; set; }
        public decimal ClaimAmount { get; set; }
        public int MemberID { get; set; }
        public Member EnrolledMember { get; set; }



        
    }
}
