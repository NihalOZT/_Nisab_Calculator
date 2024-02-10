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
            var comments = user.comments;
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
        [Route("add")]
        public User Create([FromBody] User user)
        {
            
                _userRepository.Add(user);
            

            return user;
        }

        public ActionResult Edit(int id)
        {
            var user = _userRepository.GetById(id);
            return View(user);
        }

        //[HttpPost]
        //public ActionResult Edit(Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _productRepository.Update(product);
        //        return RedirectToAction("Index");
        //    }

        //    return View(product);
        //}

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
        [Route("comment/{userId}")]
        [HttpPost]
        public Comment addComment(int userId,[FromBody] Comment comment)
        {
            _userRepository.addComment(userId, comment);

            return comment;
        }

        [HttpPost]
        [Route("loginn")]
        public bool Login([FromForm] User önyüzdenUser)
        {
            User user1 = getByUsername(önyüzdenUser.username).Result;
            if (önyüzdenUser.username == user1.username && önyüzdenUser.password == user1.password)
            {
                return true;
            }

            return false;
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
        public IActionResult Index()
        {
            return View();
        }

    }
}
