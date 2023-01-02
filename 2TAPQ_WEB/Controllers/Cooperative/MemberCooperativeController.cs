﻿using _2TAPQ_WEB.Models;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace _2TAPQ_WEB.Controllers.Cooperative
{
    public class MemberCooperativeController : Controller
    {
        private readonly HttpClient client = null;
        private string MemberAPiUrl = "";
        private string AccountAPiUrl = "";
        private string PondAPiUrl = "";

        notification notify = new notification();
        AccountGet acc = new AccountGet();

        private bool memberUpdate = false;

        public MemberCooperativeController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            MemberAPiUrl = "https://localhost:7291/api/Member";
            AccountAPiUrl = "https://localhost:7291/api/Account";
            PondAPiUrl = "https://localhost:7291/api/Pond";
        }


        public async Task<List<Member>> GetMembers(int st, string id)
        {

            HttpResponseMessage response = await client.GetAsync(MemberAPiUrl +"/" + st + "/" + id);
            string strDate = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<Member> listMembers = JsonSerializer.Deserialize<List<Member>>(strDate, options);
            return listMembers;
        }
        public async Task<List<Pond>> GetPonds(string idacc)
        {
            HttpResponseMessage response = await client.GetAsync(PondAPiUrl + "/idacc?idacc=" + idacc);
            string strDate = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<Pond> listPonds = JsonSerializer.Deserialize<List<Pond>>(strDate, options);

            return listPonds;
        }



        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddMemberCooperative()
        {
            var idsess = HttpContext.Session.GetString("IdUser");
            if (idsess == null)
            {
                return RedirectToAction("Login", "Account");
            }
            await getNotify();

            return View();
        }

        public async Task<IActionResult> EditMenberCooperative(string id)
        {
            var idsess = HttpContext.Session.GetString("IdUser");
            if (idsess == null)
            {
                return RedirectToAction("Login", "Account");
            }
            await getNotify();


            Account data = await acc.GetAccountByID(id);
            
            return View(data);
        }
        
        public async Task<IActionResult> DetailMemberCooperative(string id)
        {
            var idsess = HttpContext.Session.GetString("IdUser");
            if (idsess == null)
            {
                return RedirectToAction("Login", "Account");
            }
            await getNotify();
            await getNotify();

            Account data = await acc.GetAccountByID(id);
            List<Pond> listPonds = await GetPonds(id);

            ViewBag.Pond = listPonds.Count;

            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMember([Bind("IdAcc,Username,Password,Fullname,Email,Phone,Birthday,Address,Role,IdRoleStaff,IdWard,DateJoin,Image,Status")] Account account)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response1 = await client.PutAsJsonAsync(AccountAPiUrl + "/id?id=" + account.IdAcc, account);
                response1.EnsureSuccessStatusCode();
                memberUpdate = true;
                return RedirectToAction("MemberCooperative");
            }

            ViewBag.regis = 1;
            return View("EditMenberCooperative", account);
        }

        public async Task<IActionResult> ComfirmMember(string id)
        {
            var idsess = HttpContext.Session.GetString("IdUser");
            if (idsess == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var idc = HttpContext.Session.GetString("IdCoop");
            await getNotify();


            HttpResponseMessage response = await client.GetAsync(MemberAPiUrl + "/id?id=" + id);
            string strDate = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            Member data = JsonSerializer.Deserialize<Member>(strDate, options);

            HttpResponseMessage response1 = await client.PutAsJsonAsync(MemberAPiUrl + "/idAcc?id=" + data.IdMember, data);
            response1.EnsureSuccessStatusCode();

            notify.addnotifiFarm("Member", idc, "A000000001");
            await Task.Delay(100);

            return RedirectToAction("MemberCooperative");


        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMemberCooperative([Bind("IdFcategory,CategoryName,Image,HarvestTime,Description,Status")] Member Member)
        {

            if (ModelState.IsValid)
            {

                HttpResponseMessage response1 = await client.PostAsJsonAsync(MemberAPiUrl, Member);
                response1.EnsureSuccessStatusCode();


                return RedirectToAction("MemberCooperative");

            }

            return View("AddMemberCooperative");
        }



        public async Task<IActionResult> MemberCooperative(string? sea, int pg = 1)
        {
            var idsess = HttpContext.Session.GetString("IdUser");
            if (idsess == null)
            {
                return RedirectToAction("Login", "Account");
            }
            await getNotify();

            ViewBag.change = memberUpdate;
            var idusr = HttpContext.Session.GetString("IdCoop");
            var idroom = HttpContext.Session.GetString("IdRoom");
            List<Member> listMembers = await GetMembers(1, idroom);

            if (sea != null)
            {
                listMembers = listMembers.Where(a => a.IdUserNavigation.Phone.Contains(sea)).ToList();
                ViewBag.Search = sea;
            }

            const int pageSize = 6;
            if (pg < 1)
                pg = 1;
            int recsCount = listMembers.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = listMembers.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            return View(data);

        }


        public async Task<IActionResult> ComfirmMemberCooperative(string? sea, int pg = 1)
        {

            var idsess = HttpContext.Session.GetString("IdUser");
            if (idsess == null)
            {
                return RedirectToAction("Login", "Account");
            }
            await getNotify();

            var idusr = HttpContext.Session.GetString("IdCoop");
            var idroom = HttpContext.Session.GetString("IdRoom");
            List<Member> listMembers = await GetMembers(2, idroom);


            if (sea != null)
            {
                listMembers = listMembers.Where(a => a.IdUserNavigation.Phone.Contains(sea)).ToList();
                ViewBag.Search = sea;
            }

            const int pageSize = 6;
            if (pg < 1)
                pg = 1;
            int recsCount = listMembers.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = listMembers.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            return View(data);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SearchMember(string search)
        {
            return RedirectToAction("MemberCooperative", new { sea = search });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SearchConfirm(string search)
        {
            return RedirectToAction("ComfirmMemberCooperative", new { sea = search });
        }

        public async Task<IActionResult> DeleteAccount(string id)
        {
            HttpResponseMessage response1 = await client.DeleteAsync(
                     MemberAPiUrl + "/id?id=" + id);
            response1.EnsureSuccessStatusCode();
            memberUpdate = true;
            return RedirectToAction("MemberCooperative", "MemberCooperative");
        }
        public async Task<string> getNotify()
        {
            var idusr = HttpContext.Session.GetString("IdCoop");
            var id = HttpContext.Session.GetString("IdUser");

            List<Notify> not = await notify.GetNotifyfarm(idusr);
            var newnot = not.Where(a => a.Status == 2).Count();
            not = not.OrderByDescending(s => s.IdNotify).ToList();
            ViewBag.notifiAll = not;
            ViewBag.notifi = not.Take(4).ToList();
            ViewBag.notifiNum = newnot;
            Account a = await acc.GetAccountByID(id);
            ViewBag.User = a;
            return "";
        }
        public async Task<int[]> getMember(int year = 0)
        {
            if (year == 0)
            {
                year = DateTime.Now.Year;
            }
            await getNotify();
            int[] result = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var idroom = HttpContext.Session.GetString("IdRoom");
            List<Member> list = await GetMembers(1, idroom);
           

            foreach (Member p in list)
            {
                int i = Convert.ToDateTime(p.Date).Month;
                result[i - 1]++;
            }
            result[12] = list.Count;

            return result;
        }

    }
}
