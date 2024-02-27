using Microsoft.AspNetCore.Mvc;
using _Nisab_Calculator.Models;

namespace _Nisab_Calculator.Controllers
{
    [Route("[controller]")]
    public class UserController: Controller
    {
        public readonly IRepository _userRepository;

        public UserController(IRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ActionResult GetAllUser()
        {
            var user = _userRepository.GetAll();
            if (user == null)
            {
                return View("bos data");
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult GetUser(int id)
        {
            var user = _userRepository.GetById(id);
            return View(user);
        }

        [HttpGet]
        [Route("{id}")]
        public User Details1(int id)
        {
            var user = _userRepository.GetById(id);
            return (user);
        }

        [HttpGet]
        [Route("username/{username}")]
        public Task<User> getByUsername(string username)
        {
            var user = _userRepository.GetByUsername(username);
            return (user);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("addAction")]
        public IActionResult Register([FromForm] User user)
        {
            _userRepository.Add(user);
            return RedirectToAction("CommentSuccess");
        }

        public ActionResult Edit(int id)
        {
            var user = _userRepository.GetById(id);
            return View(user);
        }

        public ActionResult Delete(int id)
        {
            var user = _userRepository.GetById(id);
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = _userRepository.GetById(id);
            _userRepository.Delete(user);
            return RedirectToAction("Index");
        }
        [Route("comment/")]
        [HttpPost]
        public AddCommentDto addComment([FromBody] AddCommentDto comment)
        {
            _userRepository.addComment(comment);

            return comment;
        }
        [Route("commentPage")]
        [HttpGet]
        public IActionResult commentPage()
        {

            return View("/Views/User/commentPage.cshtml");
        }


        [HttpPost]
        [Route("loginn")]
        public IActionResult Login([FromForm] User önyüzdenUser)
        {
            User user1 = getByUsername(önyüzdenUser.username).Result;
            if (önyüzdenUser.username == user1.username && önyüzdenUser.password == user1.password)
            {
                return RedirectToAction("LoginSuccess");
            }

            return View();
        }
        [HttpGet]
        [Route("loginaction")]
        public IActionResult Index([FromForm] User önyüzdenUser)
        {
            var user = Login(önyüzdenUser);
            return View("Index", user);
        }
        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Register()
        {
            return View("/Views/User/Register.cshtml");
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("addComment")]
        public IActionResult Add([FromForm] AddCommentDto addCommentDto)
        {
            addComment(addCommentDto);
            return RedirectToAction("CommentSuccess");
        }
        [Route("successComment")]
        public IActionResult CommentSuccess()
        {
            return View("/Views/User/CommentSuccess.cshtml");
        }
        [Route("LoginSuccess")]
        public IActionResult LoginSuccess()
        {
            return View("/Views/User/LoginSuccess.cshtml");
        }
        [Route("RegisterSuccess")]
        public IActionResult RegisterSuccess()
        {
            return View("/Views/User/RegisterSuccess.cshtml");
        }
    }
}
