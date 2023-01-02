using _2TAPQ_WEB.Models;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace _2TAPQ_WEB.Controllers
{
    public class PondController : Controller
    {
        private readonly HttpClient client = null;
        private string PondAPiUrl = "";
        private string PondDiaryAPIUrl = "";
        private string FishCategoryAPiUrl = "";
        private string CooperativeRoomAPiUrl = "";

        notification notify = new notification();
        VietNamChar vnc = new VietNamChar();
        AccountGet acc = new AccountGet();
        public PondController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            PondAPiUrl = "https://localhost:7291/api/Pond";
            FishCategoryAPiUrl = "https://localhost:7291/api/FishCategory";
            PondDiaryAPIUrl = "https://localhost:7291/api/PondDiary";
            CooperativeRoomAPiUrl = "https://localhost:7291/api/CooperativeRoom";
        }
        public async Task<List<FishCategory>> GetFishCategorys()
        {
            HttpResponseMessage response = await client.GetAsync(FishCategoryAPiUrl);
            string strDate = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<FishCategory> listFishCategorys = JsonSerializer.Deserialize<List<FishCategory>>(strDate, options);
            return listFishCategorys;
        }

        public async Task<List<Pond>> GetPonds(string idacc, int st = 1)
        {
            HttpResponseMessage response = await client.GetAsync(PondAPiUrl + "/idacc?idacc=" + idacc);
            string strDate = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<Pond> listPonds = JsonSerializer.Deserialize<List<Pond>>(strDate, options);
            listPonds = listPonds.Where(a => a.Status == st).ToList();
            return listPonds;
        }
        public async Task<List<Pond>> GetlistPond()
        {
            HttpResponseMessage response = await client.GetAsync(PondAPiUrl);
            string strDate = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<Pond> listPonds = JsonSerializer.Deserialize<List<Pond>>(strDate, options);

            return listPonds;
        }

        public async Task<Pond> GetPondbyid(string id)
        {
            HttpResponseMessage response = await client.GetAsync(PondAPiUrl + "/id?id=" + id);
            string strDate = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            Pond Ponds = JsonSerializer.Deserialize<Pond>(strDate, options);

            return Ponds;
        }

        public async Task<List<PondDiary>> GetlistPondDiary(string idPond)
        {
            HttpResponseMessage response = await client.GetAsync(PondDiaryAPIUrl + "/idPond?idPond=" + idPond);
            string strDate = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<PondDiary> listPonds = JsonSerializer.Deserialize<List<PondDiary>>(strDate, options);

            return listPonds;
        }

        /// <summary>
        /// End get methor
        /// </summary>


        public async Task<IActionResult> EditPondDialy(string idDialy)
        {
            var idsess = HttpContext.Session.GetString("IdUser");
            if (idsess == null)
            {
                return RedirectToAction("Login", "Account");
            }
            await getNotify();

            HttpResponseMessage response = await client.GetAsync(PondDiaryAPIUrl + "/id?id=" + idDialy);
            string strDate = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            PondDiary data = JsonSerializer.Deserialize<PondDiary>(strDate, options);

            ViewBag.idPond = data.IdPond;
            return View(data);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPondDialy([Bind("IdDiary,IdPond,Sanility,Ph,Temperature,WaterLevel,FishStatus,Date")] PondDiary pond)
        {
            var idsess = HttpContext.Session.GetString("IdUser");
            if (idsess == null)
            {
                return RedirectToAction("Login", "Account");
            }
            await getNotify();

            var idacc = HttpContext.Session.GetString("IdFarm");
            if (ModelState.IsValid)
            {
                bool check = await checkFish(pond, pond.IdPond);

                if (!check)
                {
                    pond.FishStatus = "Warning";
                    Member a = await acc.GetMemberByID(idacc);
                    if (a != null)
                    {
                        notify.addnotifiFarm("Fish", idacc, a.IdRoomNavigation.IdCoo, pond.IdPond);
                    }
                    else
                    {
                        notify.addnotifiFarm("Fish", idacc, null, pond.IdPond);
                    }

                }
                HttpResponseMessage response1 = await client.PutAsJsonAsync(PondDiaryAPIUrl + "/id?id=" + pond.IdDiary, pond);
                response1.EnsureSuccessStatusCode();

                return RedirectToAction("Pond", "Pond");
            }

            ViewBag.idPond = pond.IdPond;
            return View("EditPondDialy");
        }
        public static bool CompareDateTimes(DateTime firstDate, DateTime secondDate)
        {
            return firstDate.Day == secondDate.Day && firstDate.Month == secondDate.Month && firstDate.Year == secondDate.Year;
        }

        public async Task<IActionResult> ReportDialy(string idPond)
        {
            var idsess = HttpContext.Session.GetString("IdUser");
            if (idsess == null)
            {
                return RedirectToAction("Login", "Account");
            }
            await getNotify();


            var list = await GetlistPondDiary(idPond);
            DateTime now = DateTime.Now;
            PondDiary dialy = null;
            foreach (var a in list)
            {

                if (CompareDateTimes(Convert.ToDateTime(a.Date), now))
                {
                    dialy = a;
                    break;
                }
            }
            if (dialy != null)
            {
                return RedirectToAction("EditPondDialy", new { idDialy = dialy.IdDiary });
            }


            ViewBag.idPond = idPond;
            return View();
        }



        public async Task<IActionResult> HistoryDaily(string idPond, int pg = 1)
        {
            var idsess = HttpContext.Session.GetString("IdUser");
            if (idsess == null)
            {
                return RedirectToAction("Login", "Account");
            }
            await getNotify();


            ViewBag.idPond = idPond;
            var list = await GetlistPondDiary(idPond);

            const int pageSize = 8;
            if (pg < 1)
                pg = 1;
            int recsCount = list.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = list.Skip(recSkip).Take(pager.PageSize).ToList();

            return View(data);
        }
        public async Task<IActionResult> Detail(string idPond)
        {
            var idsess = HttpContext.Session.GetString("IdUser");
            if (idsess == null)
            {
                return RedirectToAction("Login", "Account");
            }
            await getNotify();


            Pond p = await GetPondbyid(idPond);
            ViewBag.idPond = p;
            return View();
        }

        public async Task<bool> checkFish(PondDiary diary, string idpond)
        {
            Pond p = await GetPondbyid(idpond);
            bool check = true;
            if (p.IdFcategoryNavigation != null)
            {
                if (p.IdFcategoryNavigation.Temperature != null && (p.IdFcategoryNavigation.Temperature <= (diary.Temperature - 5) || p.IdFcategoryNavigation.Temperature >= (diary.Temperature + 5)))
                {
                    return false;
                }
                if (p.IdFcategoryNavigation.Ph != null && (p.IdFcategoryNavigation.Ph <= (diary.Ph - 1) || p.IdFcategoryNavigation.Ph >= (diary.Ph + 1)))
                {
                    return false;
                }
                if (p.IdFcategoryNavigation.Sanility != null && (p.IdFcategoryNavigation.Sanility <= (diary.Sanility - 1) || p.IdFcategoryNavigation.Sanility >= (diary.Temperature + 1)))
                {
                    return false;
                }
                if (p.IdFcategoryNavigation.WaterLevel != null && (p.IdFcategoryNavigation.WaterLevel <= (diary.WaterLevel - 1) || p.IdFcategoryNavigation.WaterLevel >= (diary.WaterLevel + 1)))
                {
                    return false;
                }
            }


            return check;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReportDialy([Bind("IdDiary,IdPond,Sanility,Ph,Temperature,WaterLevel,FishStatus,Date")] PondDiary pond)
        {
            var idsess = HttpContext.Session.GetString("IdUser");
            if (idsess == null)
            {
                return RedirectToAction("Login", "Account");
            }
            await getNotify();

            var idacc = HttpContext.Session.GetString("IdFarm");

            if (ModelState.IsValid)
            {
                DateTime join = DateTime.Now;

                pond.Date = join;

                bool check = await checkFish(pond, pond.IdPond);
                if (!check)
                {
                    pond.FishStatus = "Warning";
                    Member a = await acc.GetMemberByID(idacc);
                    if (a != null)
                    {
                        notify.addnotifiFarm("Fish", idacc, a.IdRoomNavigation.IdCoo, pond.IdPond);
                    }
                    else
                    {
                        notify.addnotifiFarm("Fish", idacc, null, pond.IdPond);
                    }

                }
                HttpResponseMessage response1 = await client.PostAsJsonAsync(PondDiaryAPIUrl, pond);
                response1.EnsureSuccessStatusCode();

                return RedirectToAction("Pond", "Pond");
            }

            ViewBag.idPond = pond.IdPond;
            return View("AddPondDialy");
        }

        public async Task<int[]> getPond()
        {
            int[] result = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            List<Pond> list = await GetlistPond();
            foreach (Pond p in list)
            {
                int start = Convert.ToDateTime(p.StartDay).Month;
                int end = Convert.ToDateTime(p.EndDay).Month;
                if (end < start)
                {
                    end = 12;
                }
                start--;
                for (int i = start; i < end; i++)
                {
                    result[i]++;
                }

            }
            result[12] = list.Count + 1;

            return result;
        }

        public async Task<IActionResult> AddPond()
        {
            var idsess = HttpContext.Session.GetString("IdUser");
            if (idsess == null)
            {
                return RedirectToAction("Login", "Account");
            }
            await getNotify();

            var idacc = HttpContext.Session.GetString("IdFarm");
            ViewBag.Idacc = idacc;
            ViewBag.FishCategory = await GetFishCategorys();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPond([Bind("IdPond,IdAcc,IdFcategory,Name,PondArea,Image,Session,QuantityOfFingerlings,QuanlityOfEnd,StartDay,EndDay,Status")] Pond pond)
        {
            var idsess = HttpContext.Session.GetString("IdUser");
            if (idsess == null)
            {
                return RedirectToAction("Login", "Account");
            }
            await getNotify();

            var idacc = HttpContext.Session.GetString("IdFarm");
            if (ModelState.IsValid)
            {
                List<Pond> listPondts = await GetPonds(pond.IdAcc);
                List<FishCategory> fishCategory = await GetFishCategorys();

                DateTime join = DateTime.Now;
                FishCategory f = fishCategory.FirstOrDefault(f => f.IdFcategory.Equals(pond.IdFcategory));
                if (listPondts.FirstOrDefault(a => a.Name.Equals(pond.Name)) == null)
                {
                    pond.EndDay = join.AddDays(f.HarvestTime);
                    pond.StartDay = join;

                    HttpResponseMessage response1 = await client.PostAsJsonAsync(PondAPiUrl, pond);
                    response1.EnsureSuccessStatusCode();


                    Member a = await acc.GetMemberByID(pond.IdAcc);
                    if (a != null)
                    {
                        notify.addnotifiFarm("Pond", pond.IdAcc, a.IdRoomNavigation.IdCoo);
                    }
                    else
                    {
                        notify.addnotifiFarm("Pond", pond.IdAcc);
                    }
                    await Task.Delay(100);
                    return RedirectToAction("Pond", "Pond");
                }
            }
            ViewBag.Idacc = idacc;
            ViewBag.FishCategory = await GetFishCategorys();
            return View("AddPond");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Harvest([Bind("IdPond,IdAcc,IdFcategory,Name,PondArea,Image,Session,QuantityOfFingerlings,QuanlityOfEnd,StartDay,EndDay,Status")] Pond pond)
        {
            var idsess = HttpContext.Session.GetString("IdUser");
            if (idsess == null)
            {
                return RedirectToAction("Login", "Account");
            }
            await getNotify();


            var idacc = HttpContext.Session.GetString("IdFarm");
            if (ModelState.IsValid)
            {
                pond.EndDay = DateTime.Now;
                HttpResponseMessage response1 = await client.PutAsJsonAsync(PondAPiUrl + "/id?id=" + pond.IdPond, pond);
                response1.EnsureSuccessStatusCode();

                Member a = await acc.GetMemberByID(pond.IdAcc);
                if (a != null)
                {
                    notify.addnotifiFarm("Harvest", pond.IdAcc, a.IdRoomNavigation.IdCoo, pond.IdPond);
                }
                else
                {
                    notify.addnotifiFarm("Harvest", pond.IdAcc, null, pond.IdPond);
                }
                await Task.Delay(100);
                return RedirectToAction("Pond", "Pond");

            }
            ViewBag.Idacc = idacc;
            ViewBag.FishCategory = await GetFishCategorys();
            return View("AddPond");
        }

        public async Task<IActionResult> Harvest(string id)
        {
            var idsess = HttpContext.Session.GetString("IdUser");
            if (idsess == null)
            {
                return RedirectToAction("Login", "Account");
            }
            await getNotify();


            Pond p = await GetPondbyid(id);
            var idacc = HttpContext.Session.GetString("IdFarm");
            ViewBag.Idacc = idacc;
            ViewBag.FishCategory = await GetFishCategorys();
            return View(p);
        }

        public async Task<IActionResult> HistoryPond(string? sea, string? sort, int pg = 1)
        {
            var idsess = HttpContext.Session.GetString("IdUser");
            if (idsess == null)
            {
                return RedirectToAction("Login", "Account");
            }
            await getNotify();

            var idusr = HttpContext.Session.GetString("IdFarm");
            List<Pond> listponds = await GetPonds(idusr, 2);
            ViewBag.idacc = idusr;

            if (sea != null)
            {
                listponds = listponds.Where(a => vnc.LocDau(a.Name).ToLower().Contains(vnc.LocDau(sea).ToLower())).ToList();
                ViewBag.Search = sea;
            }
            if (sort != null)
            {
                if (sort.Equals("giam"))
                {
                    listponds = listponds.OrderByDescending(s => s.IdPond).ToList();
                }
                if (sort.Equals("tang"))
                {
                    listponds = listponds.OrderBy(s => s.IdPond).ToList();
                }
                ViewBag.Sort = sort;
            }

            const int pagesize = 6;
            if (pg < 1)
                pg = 1;
            int recscount = listponds.Count();
            var pager = new Pager(recscount, pg, pagesize);
            int recskip = (pg - 1) * pagesize;
            var data = listponds.Skip(recskip).Take(pager.PageSize).ToList();

            ViewBag.pager = pager;
            return View(data);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SearchHistoryPond(string search)
        {
            return RedirectToAction("HistoryPond", new { sea = search });
        }



        public async Task<IActionResult> Pond(string? sea, string? sort, int pg = 1)
        {
            var idsess = HttpContext.Session.GetString("IdUser");
            if (idsess == null)
            {
                return RedirectToAction("Login", "Account");
            }
            await getNotify();


            var idusr = HttpContext.Session.GetString("IdFarm");
            List<Pond> listponds = await GetPonds(idusr);
            ViewBag.idacc = idusr;

          
            if (sea != null)
            {
                listponds = listponds.Where(a => vnc.LocDau(a.Name).ToLower().Contains(vnc.LocDau(sea).ToLower())).ToList();
                ViewBag.Search = sea;
            }
            if (sort != null)
            {
                if (sort.Equals("giam"))
                {
                    listponds = listponds.OrderByDescending(s => s.IdPond).ToList();
                }
                if (sort.Equals("tang"))
                {
                    listponds = listponds.OrderBy(s => s.IdPond).ToList();
                }
                ViewBag.Sort = sort;
            }

            const int pagesize = 6;
            if (pg < 1)
                pg = 1;
            int recscount = listponds.Count();
            var pager = new Pager(recscount, pg, pagesize);
            int recskip = (pg - 1) * pagesize;
            var data = listponds.Skip(recskip).Take(pager.PageSize).ToList();

            ViewBag.pager = pager;
            return View(data);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SearchPond(string search)
        {
            return RedirectToAction("Pond", new { sea = search });
        }


        public async Task<IActionResult> Detailpond(string idPond)
        {
            var idsess = HttpContext.Session.GetString("IdUser");
            if (idsess == null)
            {
                return RedirectToAction("Login", "Account");
            }

            await getNotify();
            Pond p = await GetPondbyid(idPond);
            return View(p);
        }

        public async Task<IActionResult> DeletePond(string id)
        {
            HttpResponseMessage response1 = await client.DeleteAsync(
                     PondAPiUrl + "/id?id=" + id);
            response1.EnsureSuccessStatusCode();
            return RedirectToAction("Pond", "Pond");
        }

        public async Task<string> getNotify()
        {
            var id = HttpContext.Session.GetString("IdFarm");
            var idusr = HttpContext.Session.GetString("IdUser");
            List<Notify> not = await notify.GetNotifyfarm(id);
            var newnot = not.Where(a => a.Status == 2).Count();
            not = not.OrderByDescending(s => s.IdNotify).ToList();
            ViewBag.notifiAll = not;
            ViewBag.notifi = not.Take(4).ToList();
            ViewBag.notifiNum = newnot;
            Account a = await acc.GetAccountByID(idusr);
            ViewBag.User = a;
            return "";
        }

        public async void readed()
        {
            var idusr = HttpContext.Session.GetString("IdFarm");
            List<Notify> not = await notify.GetNotifyfarm(idusr);
            var newnot = not.Where(a => a.Status == 2).ToList();
            if (newnot.Count > 0)
            {
                await notify.readed(newnot);
            }
        }
    }
}
