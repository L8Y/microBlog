using mb_lib;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using mb_lib.Interface;

namespace microblog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPost _postServices;
        private readonly IComments _commentsServices;
        private readonly IRegister _registerServices;
        public HomeController(IPost PostServices, IComments CommentsServices, IRegister RegisterServices)
        {
            _postServices = PostServices;
            _commentsServices = CommentsServices;
            _registerServices = RegisterServices;   
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Register r)
        {
            int isUserCreated = _registerServices.AddUser(r);
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
            bool isUserValid = _registerServices.Login(email, password);

            if (isUserValid)
            {
                int userId = Convert.ToInt32(_registerServices.GetUserId(email));
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
            var displayPost = _postServices.GetPost();
            ViewBag.displayPost = displayPost;
            return View();
        }
        [HttpPost]
        public ActionResult Home(string post, string category)
        {
            DateTime date = DateTime.UtcNow;
            int PostOwnerId = (int)HttpContext.Session.GetInt32("login_userId");
            int isPostCreated = _postServices.CreatePost(post, category, PostOwnerId, date);
            ViewBag.test = isPostCreated;
            var displayPost = _postServices.GetPost();
            ViewBag.displayPost = displayPost;
            return View();
        }
        [HttpGet]
        public ActionResult Comments(long PostId)
        {
            ViewBag.postId = PostId;
            var getPostById = _postServices.GetPostById(PostId);
            ViewBag.getPostById = getPostById;
            return View();
        }
        [HttpPost]
        public ActionResult Comments(long PostId, string comments)
        {
            ViewBag.postsId = PostId;
            var getPostById = _postServices.GetPostById(PostId);
            ViewBag.getPostById = getPostById;
            long CommentOwnerId = (long)HttpContext.Session.GetInt32("login_userId");
            bool isCommentCreated = _commentsServices.AddComments(CommentOwnerId, PostId, comments);
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
            var a = _postServices.DeletePostById(50);
            return View();
        }


    }
}