using _2TAPQ_WEB.Models;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace _2TAPQ_WEB.Controllers.Cooperative
{
    public class CooperativeRoomCooperativeController : Controller
    {
        private readonly HttpClient client = null;
        private string MemberAPiUrl = "";
        private string CooperativeRoomAPiUrl = "";
        private string PondAPiUrl = "";
        private string FishCategoryAPiUrl = "";

        notification notify = new notification();
        AccountGet acc = new AccountGet();
        public CooperativeRoomCooperativeController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            CooperativeRoomAPiUrl = "https://localhost:7291/api/CooperativeRoom";
            PondAPiUrl = "https://localhost:7291/api/Pond";
            FishCategoryAPiUrl = "https://localhost:7291/api/FishCategory";
            MemberAPiUrl = "https://localhost:7291/api/Member";
        }
        public async Task<List<Member>> GetMembers(int st, string id)
        {

            HttpResponseMessage response = await client.GetAsync(MemberAPiUrl + "/" + st + "/" + id);
            string strDate = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<Member> listMembers = JsonSerializer.Deserialize<List<Member>>(strDate, options);
            return listMembers;
        }
        public async Task<List<CooperativeRoom>> GetCooperativeRooms()
        {
            HttpContext.Session.SetString("IdRoom", "R000000001");
            HttpResponseMessage response = await client.GetAsync(CooperativeRoomAPiUrl);
            string strDate = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<CooperativeRoom> listCooperativeRooms = JsonSerializer.Deserialize<List<CooperativeRoom>>(strDate, options);
            return listCooperativeRooms;
        }

        public async Task<CooperativeRoom> GetCooperativeRoom(string id)
        {
            HttpResponseMessage response = await client.GetAsync(CooperativeRoomAPiUrl + "/id?id=" + id);
            string strDate = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            CooperativeRoom room = JsonSerializer.Deserialize<CooperativeRoom>(strDate, options);
            return room;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddCooperativeRoomCooperative()
        {
            var idsess = HttpContext.Session.GetString("IdUser");
            if (idsess == null)
            {
                return RedirectToAction("Login", "Account");
            }
            await getNotify();

            return View();
        }

        public async Task<IActionResult> EditCooperativeRoom(string id)
        {
            var idsess = HttpContext.Session.GetString("IdUser");
            if (idsess == null)
            {
                return RedirectToAction("Login", "Account");
            }
            await getNotify();

            HttpResponseMessage response = await client.GetAsync(CooperativeRoomAPiUrl + "/id?id=" + id);
            string strDate = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            CooperativeRoom data = JsonSerializer.Deserialize<CooperativeRoom>(strDate, options);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCooperativeRoomCooperative([Bind("IdFcategory,CategoryName,Image,HarvestTime,Description,Status")] CooperativeRoom CooperativeRoom)
        {
            var idsess = HttpContext.Session.GetString("IdUser");
            if (idsess == null)
            {
                return RedirectToAction("Login", "Account");
            }
            await getNotify();

            if (ModelState.IsValid)
            {
                List<CooperativeRoom> listCooperativeRoomts = await GetCooperativeRooms();

                HttpResponseMessage response1 = await client.PostAsJsonAsync(CooperativeRoomAPiUrl, CooperativeRoom);
                response1.EnsureSuccessStatusCode();

                return RedirectToAction("CooperativeRoomCooperative");

            }

            return View("AddCooperativeRoomCooperative");
        }
        public async Task<List<Pond>> GetPonds(string idacc)
        {
            HttpResponseMessage response = await client.GetAsync(PondAPiUrl + "/idRoom?idRoom=" + idacc);
            string strDate = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<Pond> listPonds = JsonSerializer.Deserialize<List<Pond>>(strDate, options);

            return listPonds;
        }
        public async Task<int[]> getPond(int year = 0)
        {
            if (year == 0)
            {
                year = DateTime.Now.Year;
            }
            var idusr = HttpContext.Session.GetString("IdRoom");
            int[] result = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            List<Pond> list = await GetPonds(idusr);


            foreach (Pond p in list)
            {
                if (Convert.ToDateTime(p.StartDay).Year == year && Convert.ToDateTime(p.EndDay).Year > year)
                {
                    int start = Convert.ToDateTime(p.StartDay).Month;
                    int end = 12;


                    start--;
                    for (int i = start; i < end; i++)
                    {
                        result[i]++;
                    }
                }
                else if (Convert.ToDateTime(p.StartDay).Year == year && Convert.ToDateTime(p.EndDay).Year == year)
                {
                    int start = Convert.ToDateTime(p.StartDay).Month;
                    int end = Convert.ToDateTime(p.EndDay).Month;
                    start--;
                    for (int i = start; i < end; i++)
                    {
                        result[i]++;
                    }
                }
                else if (Convert.ToDateTime(p.StartDay).Year < year && Convert.ToDateTime(p.EndDay).Year == year)
                {
                    int start = 0;
                    int end = Convert.ToDateTime(p.EndDay).Month;


                    for (int i = start; i < end; i++)
                    {
                        result[i]++;
                    }
                }



            }
            result[12] = list.Count + 1;

            return result;
        }



        public async Task<IActionResult> CooperativeRoomCooperative(int year = 0)
        {
            if (year == 0)
            {
                year = DateTime.Now.Year;
            }
            await getNotify();

            var idusr = HttpContext.Session.GetString("IdRoom");
            var room = await GetCooperativeRoom(idusr);

            ViewBag.IdAcc = room.IdCoo;
            ViewBag.now = year;
            ViewBag.year = await getyear();
            return View();

        }



        public async Task<List<int>> getyear()
        {

            var idusr = HttpContext.Session.GetString("IdRoom");
            List<int> result = new List<int>();
            List<Pond> list = await GetPonds(idusr);

            if (list.Count > 0)
            {
                int y = 0;
                foreach (var item in list)
                {
                    if (item.StartDay != null)
                    {
                        if (y > Convert.ToDateTime(item.StartDay).Year || y == 0)
                        {
                            y = Convert.ToDateTime(item.StartDay).Year;
                        }
                    }
                }
                for (int i = y; i <= (DateTime.Now.Year + 1); i++)
                {
                    result.Add(i);
                }
            }

            return result;
        }
        public async Task<List<int>> getyearM()
        {


            var idusr = HttpContext.Session.GetString("IdRoom");
            List<int> result = new List<int>();
            List<Member> list = await GetMembers(1, idusr);

            if (list.Count > 0)
            {
                int y = 0;
                foreach (var item in list)
                {
                    if (y > Convert.ToDateTime(item.Date).Year || y == 0)
                    {
                        y = Convert.ToDateTime(item.Date).Year;
                    }
                }

                for (int i = y; i <= DateTime.Now.Year; i++)
                {
                    result.Add(i);
                }
            }
            return result;
        }



        public async Task<IActionResult> ChartMember(int year = 0)
        {
            if (year == 0)
            {
                year = DateTime.Now.Year;
            }
            await getNotify();

            var idusr = HttpContext.Session.GetString("IdRoom");
            var room = await GetCooperativeRoom(idusr);

            ViewBag.IdAcc = room.IdCoo;
            ViewBag.now = year;
            ViewBag.year = await getyearM();

            return View();

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
    }
}
