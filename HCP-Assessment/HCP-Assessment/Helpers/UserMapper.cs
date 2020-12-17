using HCP_Assessment.Models.HCP;
using HCP_Assessment.Models.Typicode;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HCP_Assessment.Helpers
{
    public class UserMapper
    {
        public List<TypicodeUser> TypicodeUsers { get; set; }
        public List<HCPUser> HCPUsers { get; set; }

        public List<HCPUser> ConvertToHCPUser(List<TypicodeUser> typicodeUsers)
        {
            if (TypicodeUsers == null || !TypicodeUsers.Any())
            {
                if (typicodeUsers == null || !typicodeUsers.Any())
                {
                    return new List<HCPUser>();
                }

                TypicodeUsers = typicodeUsers;
            }

            List<HCPUser> listUsers = new List<HCPUser>();

            TypicodeUsers.ForEach(u =>
            {
                string fName, lName;
                SplitName.Split(u.Name, out fName, out lName);

                string phone = u.Phone.Split(" ")[0];
                phone = Regex.Replace(phone, @"\(|\)|-|\.", "");
                phone = phone.Substring(phone.Length - 10);

                HCPUser user = new HCPUser
                {
                    FirstName = fName,
                    LastName = lName,
                    CompanyName = u.Company.Name,
                    CompanyFullAddress = $"{u.Address.Street} {u.Address.Suite}, {u.Address.City}, {u.Address.Zipcode}",
                    Website = u.Website,
                    Phone = phone
                };
                
                listUsers.Add(user);
            });

            return listUsers;
        }
    }
}
