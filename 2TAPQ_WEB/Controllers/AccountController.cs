using _2TAPQ_WEB.Models;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text.Json;

namespace _2TAPQ_WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly HttpClient client = null;
        private string AccountAPiUrl = "";
        private string WardAPiUrl = "";
        private string DistrictAPiUrl = "";
        private string ProvinceAPiUrl = "";
        private string RoleAPiUrl = "";
        private string RoleStaffAPiUrl = "";
        private string CooperativeRoomAPiUrl = "";
        private string MemberAPiUrl = "";
        private string StoreHouseAPiUrl = "";
        private string ReceiptsPaymentAPiUrl = "";
        private string PondAPiUrl = "";

        const int farm = 2;

        notification notify = new notification();
        AccountGet acc = new AccountGet();
        public AccountController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            AccountAPiUrl = "https://localhost:7291/api/Account";
            WardAPiUrl = "https://localhost:7291/api/Ward";
            DistrictAPiUrl = "https://localhost:7291/api/District";
            ProvinceAPiUrl = "https://localhost:7291/api/Province";
            RoleAPiUrl = "https://localhost:7291/api/Role";
            RoleStaffAPiUrl = "https://localhost:7291/api/RoleStaff";
            CooperativeRoomAPiUrl = "https://localhost:7291/api/CooperativeRoom";
            MemberAPiUrl = "https://localhost:7291/api/Member";
            StoreHouseAPiUrl = "https://localhost:7291/api/StoreHouse";
            PondAPiUrl = "https://localhost:7291/api/Pond";
            ReceiptsPaymentAPiUrl = "https://localhost:7291/api/ReceiptsPayment";
        }


        /// <summary>
        /// Start get methor
        /// </summary>

        public async Task<List<Ward>> GetWards()
        {
            HttpResponseMessage response = await client.GetAsync(WardAPiUrl);
            string strDate = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<Ward> listWards = JsonSerializer.Deserialize<List<Ward>>(strDate, options);
            return listWards;
        }
        public async Task<List<District>> GetDistricts()
        {
            HttpResponseMessage response = await client.GetAsync(DistrictAPiUrl);
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
        public async Task<ReceiptsPayment> GetReceiptsPayment(string id)
        {
            HttpResponseMessage response = await client.GetAsync(ReceiptsPaymentAPiUrl + "/idacc?idacc=" + id);
            string strDate = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            ReceiptsPayment data = JsonSerializer.Deserialize<ReceiptsPayment>(strDate, options);
            return data;
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

        public async Task<List<Role>> GetRoles()
        {
            HttpResponseMessage response = await client.GetAsync(RoleAPiUrl);
            string strDate = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<Role> list = JsonSerializer.Deserialize<List<Role>>(strDate, options);
            return list;
        }

        public async Task<List<Ward>> GetWardByID(string id)
        {
            var result = await acc.GetWards(id);

            return result;
        }
        public async Task<List<District>> GetDistrictByID(string id)
        {
            var result = await acc.GetDistricts(id);

            return result;
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
        public async Task<CooperativeRoom> GetCooperativeRoomByAcc(string idacc)
        {
            HttpResponseMessage response = await client.GetAsync(CooperativeRoomAPiUrl + "/idacc?idacc=" + idacc);
            string strDate = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            CooperativeRoom c = JsonSerializer.Deserialize<CooperativeRoom>(strDate, options);
            return c;
        }
        public async Task<CooperativeRoom> GetCooperativeRoomByCode(string code)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(CooperativeRoomAPiUrl + "/code?code=" + code);
                string strDate = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                CooperativeRoom c = JsonSerializer.Deserialize<CooperativeRoom>(strDate, options);
                return c;
            }
            catch
            {
                return null;
            }

        }

        public async Task<RoleStaff> GetRoleStaffByID(string id)
        {
            HttpResponseMessage response = await client.GetAsync(RoleStaffAPiUrl + "/id?id=" + id);
            string strDate = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            RoleStaff Account = JsonSerializer.Deserialize<RoleStaff>(strDate, options);
            return Account;
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


        /// <summary>
        /// End get methor
        /// </summary>


        public async Task<IActionResult> Login(string? err)
        {
            HttpContext.Session.Remove("IdUser");
            HttpContext.Session.Remove("IdFarm");
            if (err != null)
            {
                ViewBag.error = err;
            }
            return View();
        }
        public async Task<IActionResult> ForgetPass(string Email)
        {
            ViewBag.Email = Email;
            return View();
        }
        public async Task<IActionResult> CheckMailForget(string? err)
        {

            if (err != null)
            {
                ViewBag.error = err;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckMailForget(string email, string OTP, string OTPV)
        {
            if (email != null)
            {
                List<Account> list = await acc.GetAccounts();
                Account farm = list.FirstOrDefault(e => e.Email.Equals(email));
                if (farm != null)
                {
                    if (OTP.Equals(""))
                    {
                        ViewBag.OTP = "Yêu cầu gữi mã OTP";
                        return View("CheckMailForget");
                    }
                    if (!OTP.Equals(OTPV))
                    {
                        ViewBag.OTP = "OTP sai vui lòng nhập lại";
                        return View("CheckMailForget");
                    }
                    return RedirectToAction("ForgetPass", new { Email = email });
                }
            }
            ViewBag.OTP = "Sắc nhận mã OTP thất bại";
            return View("CheckMailForget");

        }
        public async Task<IActionResult> CheckMail()
        {

       
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckMail(string email, string OTP, string OTPV)
        {

            if (OTP == null || OTP.Equals(""))
            {
                ViewBag.OTP = "Yêu cầu gữi mã OTP";
                return View("CheckMail");
            }
            if (!OTP.Equals(OTPV))
            {
                ViewBag.OTP = "OTP sai vui lòng nhập lại";
                return View("CheckMail");
            }


            return RedirectToAction("Register", new { Email = email });


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgetPass(string email, string password, string confirmpassword)
        {
            if (email != null)
            {
                List<Account> list = await acc.GetAccounts();
                Account farm = list.FirstOrDefault(e => e.Email.Equals(email));
                if (farm != null)
                {
                  
                    if (!password.Equals(confirmpassword))
                    {
                        ViewBag.Error = "Xác Nhân Mật Khẩu Không Giống!!";
                        return View("ForgetPass");
                    }

                    farm.Password = acc.MD5Password(password);
                    HttpResponseMessage response1 = await client.PutAsJsonAsync(AccountAPiUrl + "/id?id=" + farm.IdAcc, farm);
                    response1.EnsureSuccessStatusCode();
                    return RedirectToAction("Login");
                }
            }
            return View("ForgetPass");

        }

        public async Task<string> getOTP(string? Email)
        {
            string otp = "";
            try
            {
                var a = await acc.GetAccounts();
                
                if (Email != null)
                {
                    if (a.FirstOrDefault(b => b.Email.Equals(Email)) != null)
                    {

                        otp = getOTP();
                        var formadd = new MailAddress("lyhuynhtrongan@gmail.com");
                        var to = new MailAddress(Email);
                        const string frompass = "uzxohyrctuhxdcdt";
                        const string subject = "Send OTP From 2TAPQ!";
                        string boby = "hello ba gia ngheo kho co OTP: <h>" + otp + "</h>";

                        var smtp = new SmtpClient
                        {
                            Host = "smtp.gmail.com",
                            Port = 587,
                            EnableSsl = true,
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            UseDefaultCredentials = false,
                            Credentials = new NetworkCredential(formadd.Address, frompass),
                            Timeout = 200000
                        };

                        using (var message = new MailMessage(formadd, to)
                        {
                            Subject = subject,
                            Body = "<div style='font-family: Helvetica,Arial,sans-serif;min-width:1000px;overflow:auto;line-height:2'>" +
                              "<div style='margin:50px auto;width:70%;padding:20px 0'>" +
                              "<div style='border-bottom:1px solid #eee'>" +
                              "<a href='' style='font-size:1.4em;color: #00466a;text-decoration:none;font-weight:600'>2TAPQ</a>" +
                              "</div>" +
                              "<p style='font-size:1.1em'>Xin Chào,</p>" +
                              "<p>Trân thanh cảm ơn bạn đã sử dụng dịch vụ của 2TAPQ. Hãy sử dụng mã OTP này để tạo mật khẩu mới. </ p > " +
                              "<h2 style='background: #00466a;margin: 0 auto;width: max-content;padding: 0 10px;color: #fff;border-radius: 4px;'>" + otp + "</h2>" +
                              "<p style='font-size:0.9em;'>Regards,<br />2TAPQ</p>" +
                              "<hr style='border:none;border-top:1px solid #eee' />" +
                              "<div style='float:right;padding:8px 0;color:#aaa;font-size:0.8em;line-height:1;font-weight:300'>" +
                              "<p>+2TAPQ</p>" +
                              "<p>+FPT Univercity</p>" +
                              "<p>+Thành phố Cần Thơ</p>" +
                              "</div>" +
                              "</div>" +
                              "</div>",
                            IsBodyHtml = true
                        })
                        {
                            smtp.Send(message);
                        }
                        return otp;
                    }
                }
                return otp;
            }
            catch
            {
                return otp;
            }
        }
        public async Task<string> getOTPcheck(string? Email)
        {
            string otp = "";
            try
            {

                var a = await acc.GetAccounts();

                if (Email != null)
                {
                    if (a.FirstOrDefault(b => b.Email.Equals(Email)) == null)
                    {
                        otp = getOTP();
                        var formadd = new MailAddress("lyhuynhtrongan@gmail.com");
                        var to = new MailAddress(Email);
                        const string frompass = "uzxohyrctuhxdcdt";
                        const string subject = "Send OTP From 2TAPQ!";
                        string boby = "hello ba gia ngheo kho co OTP: <h>" + otp + "</h>";

                        var smtp = new SmtpClient
                        {
                            Host = "smtp.gmail.com",
                            Port = 587,
                            EnableSsl = true,
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            UseDefaultCredentials = false,
                            Credentials = new NetworkCredential(formadd.Address, frompass),
                            Timeout = 200000
                        };

                        using (var message = new MailMessage(formadd, to)
                        {
                            Subject = subject,
                            Body = "<div style='font-family: Helvetica,Arial,sans-serif;min-width:1000px;overflow:auto;line-height:2'>" +
                              "<div style='margin:50px auto;width:70%;padding:20px 0'>" +
                              "<div style='border-bottom:1px solid #eee'>" +
                              "<a href='' style='font-size:1.4em;color: #00466a;text-decoration:none;font-weight:600'>2TAPQ</a>" +
                              "</div>" +
                              "<p style='font-size:1.1em'>Xin Chào,</p>" +
                              "<p>Trân thanh cảm ơn bạn đã sử dụng dịch vụ của 2TAPQ. Hãy sử dụng mã OTP này để tạo mật khẩu mới. </ p > " +
                              "<h2 style='background: #00466a;margin: 0 auto;width: max-content;padding: 0 10px;color: #fff;border-radius: 4px;'>" + otp + "</h2>" +
                              "<p style='font-size:0.9em;'>Regards,<br />2TAPQ</p>" +
                              "<hr style='border:none;border-top:1px solid #eee' />" +
                              "<div style='float:right;padding:8px 0;color:#aaa;font-size:0.8em;line-height:1;font-weight:300'>" +
                              "<p>+2TAPQ</p>" +
                              "<p>+FPT Univercity</p>" +
                              "<p>+Thành phố Cần Thơ</p>" +
                              "</div>" +
                              "</div>" +
                              "</div>",
                            IsBodyHtml = true
                        })
                        {
                            smtp.Send(message);
                        }
                    }
                    return otp;
                
            }
                return otp;
            }
            catch
            {
                return otp;
            }
        }

        public static string getOTP()
        {
            string otp = "";
            Random r = new Random();

            for (int i = 0; i < 6; i++)
            {
                otp += r.Next(0, 6).ToString();
            }

            return otp;
        }

        public async Task<IActionResult> StaffFarm(string? sea, int pg = 1)
        {
            await getNotify();
            var idusr = HttpContext.Session.GetString("IdFarm");
            if (idusr == null)
            {
                return RedirectToAction("Login", "Account");
            }

            List<Account> list = await acc.getAllAccountStaffFarm(idusr);

            if (sea != null)
            {
                list = list.Where(a => a.Phone.Contains(sea)).ToList();
                ViewBag.Search = sea;
            }

            const int pageSize = 6;
            if (pg < 1)
                pg = 1;

            int recsCount = list.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = list.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SearchStaff(string search)
        {
            return RedirectToAction("StaffFarm", new { sea = search });
        }


        public async Task<IActionResult> Register(string? err, string Email)
        {

            ViewBag.Ward = await GetWards();
            ViewBag.District = await GetDistricts();
            ViewBag.Province = await GetProvinces();
            ViewBag.Email = Email;
            if (err != null)
            {
                ViewBag.error = err;
            }
            return View();
        }


        public async Task<IActionResult> CreateStaff(string? err)
        {
            await getNotify();

            var idusr = HttpContext.Session.GetString("IdFarm");
            var farm = await acc.GetAccountByID(idusr);
            var idsess = HttpContext.Session.GetString("IdUser");
            if (idsess == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Farm = farm;
            if (err != null)
            {
                ViewBag.error = err;
            }
            return View();
        }
        public async Task<IActionResult> EditStaff(string id)
        {
            await getNotify();

            var idusr = HttpContext.Session.GetString("IdFarm");
            if (idusr == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var farm = await acc.GetAccountByID(id);


            ViewBag.Farm = farm;

            return View(farm);
        }

        public RoleStaff GetStaff(string idRole, decimal salary)
        {
            var idusr = HttpContext.Session.GetString("IdFarm");

            var r = new RoleStaff
            {
                IdRoleStaff = "RS00000001",
                IdRole = idRole,
                IdAcc = idusr,
                Salary = salary,
                Status = 1
            };
            return r;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStaff([Bind("IdAcc,Username,Password,Fullname,Email,Phone,Birthday,Address,Role,IdRoleStaff,IdWard,DateJoin,Image,Status")] Account account, string salary, string idRole)
        {
            await getNotify();
            var idusr = HttpContext.Session.GetString("IdUser");
            if (idusr == null)
            {
                return RedirectToAction("Login", "Account");
            }
            if (ModelState.IsValid)
            {
                List<Account> listAccounts = await GetAccounts();
                DateTime? bd = account.Birthday;
                DateTime join = DateTime.Now;
                account.Birthday = bd;
                account.DateJoin = join;
                Account ac = null;
                try
                {
                    ac = listAccounts.FirstOrDefault(a => a.Email.Equals(account.Email) || a.Username.Equals(account.Fullname));
                }
                catch
                {

                }
                if (ac == null)
                {
                    decimal s = Convert.ToDecimal(salary);
                    var r = GetStaff(idRole, s);

                    string idstaff = await getidStaff();
                    account.IdRoleStaff = idstaff;

                    HttpResponseMessage response1 = await client.PostAsJsonAsync(RoleStaffAPiUrl, r);
                    response1.EnsureSuccessStatusCode();

                    response1 = await client.PostAsJsonAsync(AccountAPiUrl, account);
                    response1.EnsureSuccessStatusCode();

                    return RedirectToAction("StaffFarm", "Account");
                }
            }
      
            var farm = await acc.GetAccountByID(idusr);
            ViewBag.Farm = farm;
            return View("CreateStaff");

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditStaff([Bind("IdAcc,Username,Password,Fullname,Email,Phone,Birthday,Address,Role,IdRoleStaff,IdWard,DateJoin,Image,Status")] Account account, string salary, string idRole)
        {
            await getNotify();
            var idusr = HttpContext.Session.GetString("IdUser");
            if (idusr == null)
            {
                return RedirectToAction("Login", "Account");
            }
            if (ModelState.IsValid)
            {


                decimal s = Convert.ToDecimal(salary);

                Account ac = await acc.GetAccountByID(account.IdAcc);

                RoleStaff role = ac.IdRoleStaffNavigation;
                role.Salary = s;
                role.IdRole = idRole;

                HttpResponseMessage response1 = await client.PutAsJsonAsync(RoleStaffAPiUrl + "/id?id=" + account.IdRoleStaff, role);
                response1.EnsureSuccessStatusCode();

                response1 = await client.PutAsJsonAsync(AccountAPiUrl + "/id?id=" + account.IdAcc, account);
                response1.EnsureSuccessStatusCode();

                return RedirectToAction("StaffFarm", "Account");

            }

            return View("EditStaff");

        }
        public async Task<IActionResult> Profile()
        {
            var idacc = HttpContext.Session.GetString("IdFarm");
            await getNotify();


            var idusr = HttpContext.Session.GetString("IdUser");
            if (idusr == null)
            {
                return RedirectToAction("Login", "Account");
            }

            Member a = await acc.GetMemberByID(idacc);
            List<Pond> p = await GetPonds(idacc);
            ReceiptsPayment rp = await GetReceiptsPayment(idacc);
            var farm = await acc.GetAccountByID(idusr);

            ViewBag.Farm = farm;
            ViewBag.Pond = p.Count;
            ViewBag.ReceiptsPayment = rp.Total;
            if (a != null)
            {
                ViewBag.Member = a;
            }


            return View(farm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile([Bind("IdAcc,Username,Password,Fullname,Email,Phone,Birthday,Address,Role,IdRoleStaff,IdWard,DateJoin,Image,Status")] Account account)
        {
            await getNotify();
            if (ModelState.IsValid)
            {
                HttpResponseMessage response1 = await client.PutAsJsonAsync(AccountAPiUrl + "/id?id=" + account.IdAcc, account);
                response1.EnsureSuccessStatusCode();
                return RedirectToAction("Profile");
            }

            ViewBag.regis = 1;
            return View("EditProfile", account);
        }

        public async Task<IActionResult> JoinCooperative()
        {
            await getNotify();

            var idusr = HttpContext.Session.GetString("IdFarm");
            if (idusr == null)
            {
                return RedirectToAction("Login", "Account");
            }
            Member a = await acc.GetMemberByID(idusr);
            if (a != null)
            {
                return RedirectToAction("Coopertive", a);
            }
            var farm = await acc.GetAccountByID(idusr);

            ViewBag.Farm = farm;

            return View();
        }

        public async Task<IActionResult> Coopertive(Member a)
        {
            await getNotify();

            CooperativeRoom c = await GetCooperativeRoom(a.IdRoom);
            if (a != null)
            {
                ViewBag.Member = a;
            }
            return View(c);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> JoinCooperative(string Joincode)
        {
            await getNotify();
            var idusr = HttpContext.Session.GetString("IdFarm");
        
         
            CooperativeRoom c = await GetCooperativeRoomByCode(Joincode);
            if (c == null)
            {
                ViewBag.wrong = "Không thể tìm thấy hợp tác xã này!!";
                return View();
            }
            else
            {

                Member m = new Member
                {
                    IdMember = "M000000001",
                    IdRoom = c.IdRoom,
                    IdUser = idusr,
                    Date = DateTime.Now,
                    Status = 2
                };
                HttpResponseMessage response1 = await client.PostAsJsonAsync(MemberAPiUrl, m);
                response1.EnsureSuccessStatusCode();
            }

            ViewBag.wrong = "Đã gữi yêu cầu!";
            return View();
        }



        public async Task<IActionResult> ChangePassword()
        {
            await getNotify();

            var idusr = HttpContext.Session.GetString("IdFarm");
            if (idusr == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var farm = await acc.GetAccountByID(idusr);

            ViewBag.Farm = farm;

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(string Oldpassword, string Newpassword, string Confirmpassword)
        {
            await getNotify();
            var idusr = HttpContext.Session.GetString("IdUser");
            if (idusr == null)
            {
                return RedirectToAction("Login", "Account");
            }
            Account farm = await acc.GetAccountByID(idusr);

            if (!farm.Password.ToLower().Equals(acc.MD5Password(Oldpassword).ToLower()))
            {
                @ViewBag.Oldpassword = "Wrong Password !!!";
                return View("ChangePassword");
            }
            if (!Newpassword.Equals(Confirmpassword))
            {
                @ViewBag.Newpassword = "Confirm password not same!!!";
                return View("ChangePassword");
            }
            farm.Password = acc.MD5Password(Newpassword);
            HttpResponseMessage response1 = await client.PutAsJsonAsync(AccountAPiUrl + "/id?id=" + farm.IdAcc, farm);
            response1.EnsureSuccessStatusCode();
            return RedirectToAction("Profile"); 
        
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password)
        {
            string error = "";
            try
            {

                HttpResponseMessage response = await client.GetAsync(AccountAPiUrl + "/" + email + "/" + password);
                string strDate = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                Account account = JsonSerializer.Deserialize<Account>(strDate, options);

                if (account != null)
                {
                    HttpContext.Session.SetString("IdUser", account.IdAcc);
                    if (account.Role == 1)
                    {
                        return RedirectToAction("FarmerAdmin", "AccountAdmin");
                    }
                    else if (account.Role == 2)
                    {
                        if (account.IdRoleStaff != null)
                        {
                            HttpContext.Session.SetString("IdFarm", account.IdRoleStaffNavigation.IdAcc);
                            if(account.IdRoleStaffNavigation.IdRole == "RL00000002")
                            {
                                return RedirectToAction("StoreHouse", "StoreHouse");
                            }
                        }
                        else
                        {
                            HttpContext.Session.SetString("IdFarm", account.IdAcc);
                        }
                        return RedirectToAction("Pond", "Pond");
                    }
                    else if (account.Role == 3)
                    {
                        if (account.IdRoleStaff != null)
                        {
                            HttpContext.Session.SetString("IdCoop", account.IdRoleStaffNavigation.IdAcc);
                            var room = await GetCooperativeRoomByAcc(account.IdRoleStaffNavigation.IdAcc);
                            HttpContext.Session.SetString("IdRoom", room.IdRoom);
                        }
                        else
                        {
                            HttpContext.Session.SetString("IdCoop", account.IdAcc);
                            var room = await GetCooperativeRoomByAcc(account.IdAcc);
                            HttpContext.Session.SetString("IdRoom", room.IdRoom);
                        }
                        return RedirectToAction("MemberCooperative", "MemberCooperative");
                    }
                    else
                        return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.wrong = true;
                    return View();
                }
            }
            catch
            {
                ViewBag.wrong = true;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("IdAcc,Username,Password,Fullname,Email,Phone,Birthday,Address,Role,IdRoleStaff,IdWard,DateJoin,Image,Status")] Account account)
        {

            if (ModelState.IsValid)
            {
                List<Account> listAccounts = await GetAccounts();
                DateTime? bd = account.Birthday;
                DateTime join = DateTime.Now;
                account.Birthday = bd;
                account.DateJoin = join;
              
                if (listAccounts.FirstOrDefault(a => a.Email.Equals(account.Email) || a.Username.Equals(account.Username)) == null)
                {
                    HttpResponseMessage response1 = await client.PostAsJsonAsync(AccountAPiUrl, account);
                    response1.EnsureSuccessStatusCode();

                    HttpResponseMessage response = await client.GetAsync(AccountAPiUrl + "/" + account.Email + "/" + account.Password);
                    string strDate = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    };
                    account = JsonSerializer.Deserialize<Account>(strDate, options);

                    HttpContext.Session.SetString("IdUser", account.IdAcc);
                    HttpContext.Session.SetString("IdFarm", account.IdAcc);

                    StoreHouse sh = new StoreHouse
                    {
                        IdSHouse = "SH00000001",
                        IdUser = account.IdAcc,
                        Status = 1,
                    };

                    ReceiptsPayment rp = new ReceiptsPayment
                    {
                        IdInvoice = "RP00000001",
                        IdUser = account.IdAcc,
                        Total = 0,
                        AddedDate = DateTime.Now,
                        Status = 1,
                    };

                    response1 = await client.PostAsJsonAsync(StoreHouseAPiUrl, sh);
                    response1.EnsureSuccessStatusCode();
                    response1 = await client.PostAsJsonAsync(ReceiptsPaymentAPiUrl, rp);
                    response1.EnsureSuccessStatusCode();

                    notify.addnotifiFarm("Account", account.IdAcc, "A000000001");
                    await Task.Delay(100);

                    return RedirectToAction("Login");
                }
            }
            ViewBag.Ward = await GetWards();
            ViewBag.District = await GetDistricts();
            ViewBag.Province = await GetProvinces();
            ViewBag.Email = account.Email;
            return View("Register", account);
        }

        public async Task<IActionResult> DeleteAccount(string id)
        {
            HttpResponseMessage response1 = await client.DeleteAsync(
                     AccountAPiUrl + "/id?id=" + id);
            response1.EnsureSuccessStatusCode();
            return RedirectToAction("StaffFarm", "Account");
        }

        public async Task<IActionResult> getNotify()
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
            return null;
        }

        public async void Readed(string id)
        {
            await notify.readed(id);
        }

    }
}

