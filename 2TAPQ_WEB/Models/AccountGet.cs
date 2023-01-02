﻿using BusinessObjects.Models;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace _2TAPQ_WEB.Models
{
    public class AccountGet
    {

        private readonly HttpClient client = null;

        //URL API
        private string AccountAPiUrl = "";
        private string WardAPiUrl = "";
        private string DistrictAPiUrl = "";
        private string ProvinceAPiUrl = "";
        private string MemberAPiUrl = "";
        private string RoleStaffAPiUrl = "";
        const int farm = 2;
        public AccountGet()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            AccountAPiUrl = "https://localhost:7291/api/Account";
            WardAPiUrl = "https://localhost:7291/api/Ward";
            DistrictAPiUrl = "https://localhost:7291/api/District";
            ProvinceAPiUrl = "https://localhost:7291/api/Province";
            MemberAPiUrl = "https://localhost:7291/api/Member";
            RoleStaffAPiUrl = "https://localhost:7291/api/RoleStaff";

        }
        public async Task<Account> GetAccountByID(string id)
        {
            HttpResponseMessage response = await client.GetAsync(AccountAPiUrl + "/id?id=" + id);
            string strDate = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            Account Account = JsonSerializer.Deserialize<Account>(strDate, options);
            return Account;
        }

        public async Task<Member> GetMemberByID(string id)
        {
            Member data = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(MemberAPiUrl + "/idfarm?idfarm=" + id);
                string strDate = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                data = JsonSerializer.Deserialize<Member>(strDate, options);
            }
            catch
            {
                return data;
            }
            return data;
        }

        public async Task<string> getidStaff()
        {
            HttpResponseMessage response = await client.GetAsync(RoleStaffAPiUrl + "/con?con=id");
            string strDate = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            string id = JsonSerializer.Deserialize<string>(strDate, options);
            return id;
        }

        public async Task<List<Account>> GetAccounts()
        {
            HttpResponseMessage response = await client.GetAsync(AccountAPiUrl);
            string strDate = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<Account> listAccounts = JsonSerializer.Deserialize<List<Account>>(strDate, options);
            return listAccounts;
        }
        public async Task<List<Account>> getAllAccountByStatus(int st)
        {
            List<Account> listAccounts = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(AccountAPiUrl + "/st?st=" + st);
                string strDate = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                listAccounts = JsonSerializer.Deserialize<List<Account>>(strDate, options);

                listAccounts = listAccounts.Where(a => a.IdRoleStaff == null).ToList();
            }
            catch
            {

            }
            return listAccounts;
        }

        public async Task<List<Account>> getAllAccountStaffFarm(string IdFarm)
        {
            HttpResponseMessage response = await client.GetAsync(AccountAPiUrl + "/IdFarm?IdFarm=" + IdFarm);
            string strDate = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<Account> listAccounts = JsonSerializer.Deserialize<List<Account>>(strDate, options);
            return listAccounts;
        }


        public async Task<List<Account>> getAllAccountByRole(int ro)
        {
            List<Account> listAccounts = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(AccountAPiUrl + "/ro?ro=" + ro);
                string strDate = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                listAccounts = JsonSerializer.Deserialize<List<Account>>(strDate, options);

                listAccounts = listAccounts.Where(a => a.IdRoleStaff == null).ToList();
            }
            catch
            {

            }
            return listAccounts;
        }
        public string MD5Password(string pass)
        {
            MD5 mh = MD5.Create();
            //Chuyển kiểu chuổi thành kiểu byte
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(pass);
            //mã hóa chuỗi đã chuyển
            byte[] hash = mh.ComputeHash(inputBytes);
            //tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }


        public async Task<List<Ward>> GetWards(string idarea)
        {
            HttpResponseMessage response = await client.GetAsync(WardAPiUrl + "/idarea?idarea=" + idarea);
            string strDate = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<Ward> listWards = JsonSerializer.Deserialize<List<Ward>>(strDate, options);
            return listWards;
        }
        public async Task<List<District>> GetDistricts(string idarea)
        {
            HttpResponseMessage response = await client.GetAsync(DistrictAPiUrl + "/idarea?idarea=" + idarea);
            string strDate = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<District> listDistricts = JsonSerializer.Deserialize<List<District>>(strDate, options);
            return listDistricts;
        }
        public async Task<List<Province>> GetProvinces()
        {
            HttpResponseMessage response = await client.GetAsync(ProvinceAPiUrl);
            string strDate = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<Province> listProvinces = JsonSerializer.Deserialize<List<Province>>(strDate, options);
            return listProvinces;
        }
    }
}
