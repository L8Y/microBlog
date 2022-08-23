using mb_lib;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using mb_lib.Interface;

namespace microblog.Controllers
{
    public class HomeController : Controller
    {
        private readonly Ipost _PostServices;
        private readonly Icomments _CommentsServices;
        private readonly Iregister _RegisterServices;
        public HomeController(Ipost PostServices, Icomments CommentsServices, Iregister RegisterServices)
        {
            _PostServices = PostServices;
            _CommentsServices = CommentsServices;
            _RegisterServices = RegisterServices;   
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Register r)
        {
            int isUserCreated = _RegisterServices.add_user(r);
            if (ModelState.IsValid)
            {
                if (isUserCreated > 0)
                {
                    ViewData["Message"] = "User created successfully";
                }
                else
                {
                    ViewData["Message"] = "User not created, fill it again";
                }
                return View();
            }
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            bool isUserValid = _RegisterServices.login(email, password);

            if (isUserValid)
            {
                int userId = Convert.ToInt32(_RegisterServices.getUserId(email));
                HttpContext.Session.SetInt32("login_userId", userId);
                HttpContext.Session.SetString("login_email", email);
                return RedirectToAction("home");
            }
            else
            {
                ViewData["Message"] = "Invalid user";
            }
            return View();
        }
        [HttpGet]
        public ActionResult Home()
        {
            if (HttpContext.Session.GetString("login_email") == null)
            {
                return RedirectToAction("Login");
            }
            ViewBag.test = HttpContext.Session.GetInt32("login_userId");
            var displayPost = _PostServices.getPost();
            ViewBag.displayPost = displayPost;
            return View();
        }
        [HttpPost]
        public ActionResult Home(string post, string category)
        {
            DateTime date = DateTime.UtcNow;
            int PostOwnerId = (int)HttpContext.Session.GetInt32("login_userId");
            int isPostCreated = _PostServices.createPost(post, category, PostOwnerId, date);
            ViewBag.test = isPostCreated;
            var displayPost = _PostServices.getPost();
            ViewBag.displayPost = displayPost;
            return View();
        }
        [HttpGet]
        public ActionResult Comments(long PostId)
        {
            ViewBag.postId = PostId;
            var getPostById = _PostServices.getPostById(PostId);
            ViewBag.getPostById = getPostById;
            return View();
        }
        [HttpPost]
        public ActionResult Comments(long PostId, string comments)
        {
            ViewBag.postsId = PostId;
            var getPostById = _PostServices.getPostById(PostId);
            ViewBag.getPostById = getPostById;
            long CommentOwnerId = (long)HttpContext.Session.GetInt32("login_userId");
            bool isCommentCreated = _CommentsServices.addComments(CommentOwnerId, PostId, comments);
            if (isCommentCreated)
            {
                ViewBag.Message = "Added successfully";

            }
            else
            {
                ViewBag.Message = "Not successfull";
            }
            return View();
        }
        [HttpGet]
        public ActionResult delete()
        {
            var a = _PostServices.deletePostById(50);
            return View();
        }


    }
}