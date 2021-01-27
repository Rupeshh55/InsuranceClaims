using InsuranceClaim.Interface;
using InsuranceClaim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace InsuranceClaim.Repository
{
    public class ClaimsRepository : IClaims
    {
        public List<Claims> GetClaimByDate(DateTime inputdate)
        {
            //Read CSV file line by line
            string[] ClaimLines = File.ReadAllLines(@"D:\10. My Notes- Technical\Interviews Faq\InsuranceClaim\InsuranceClaim\InsuranceClaim\CSVFiles\Claim.csv");
            string[] MemberLines = File.ReadAllLines(@"D:\10. My Notes- Technical\Interviews Faq\InsuranceClaim\InsuranceClaim\InsuranceClaim\CSVFiles\Member.csv");          

            //create a claimlist
            List<Claims> claimlist = new List<Claims>();
            Claims claimItem;            


            //parse line by line 
            for(int i=1; i<ClaimLines.Length;i++)
            {
                //Split and store eachfield in string array
                string[] claimFields = ClaimLines[i].Split(',');
                
                //check if the claimdate in within the input date. if So add that claim details to the list
                if( Convert.ToDateTime(claimFields[1]) <= inputdate)
                {
                    claimItem = new Claims();
                    claimItem.MemberID = Convert.ToInt32(claimFields[0]);
                    claimItem.ClaimDate = Convert.ToDateTime(claimFields[1]);
                    claimItem.ClaimAmount = Convert.ToDecimal(claimFields[2]);


                      // Map claimlist with Member details
                      for (int j = 1; j < MemberLines.Length; j++)
                      {
                          string[] MemberFields = MemberLines[j].Split(',');
                          if (claimItem.MemberID == Convert.ToInt32(MemberFields[0]))
                          {
                              claimItem.EnrolledMember.EnrollmentDate = Convert.ToDateTime(MemberFields[1]);
                              claimItem.EnrolledMember.FirstName = MemberFields[2];
                              claimItem.EnrolledMember.LastName = MemberFields[3];
                              break;
                          }
                      }

                 

                    claimlist.Add(claimItem);
                }
            }

            //Output 
            return claimlist;

      
        }
    }
}
