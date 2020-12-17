using HCP_Assessment.Helpers;
using HCP_Assessment.Models.Typicode;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HCP_Assessment.Models.HCP;

namespace HCP_Assessment
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            HttpClient httpClientTypicode = new HttpClient();
            httpClientTypicode.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

            Requests requestsTypicode = new Requests(httpClientTypicode);

            string responseTypicode = await requestsTypicode.GetRequest($"users");
            List<TypicodeUser> typicoUsers = JsonConvert.DeserializeObject<List<TypicodeUser>>(responseTypicode);
            


            List<HCPUser> hcpUsers;
            UserMapper mapper = new UserMapper();
            hcpUsers = mapper.ConvertToHCPUser(typicoUsers);

            HcpUsers users = new HcpUsers()
            {
                Userid = "henriquetedeschi3_7st@indeedemail.com",
                Password = "Qina8027!",
                Outputtype = "Json",
                Users = hcpUsers
            };

            string serializedHCPUsers = JsonConvert.SerializeObject(users);

            HttpClient httpClientHcp = new HttpClient();
            httpClientHcp.BaseAddress = new Uri("https://dev.app.homecarepulse.com/");

            Requests requestsHcp = new Requests(httpClientHcp);
            string responseHcp = await requestsHcp.PostRequest($"Primary/?FlowId=7423bd80-cddb-11ea-9160-326dddd3e106&Action=api", serializedHCPUsers);
            
        }
    }
}
