using System.Web.Mvc;

namespace SignalR.Chat.Controllers
{
    public class ChatController : Controller
    {
        //
        // GET: /Chat/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Loginuser(Models.Client chatter)
        {
           return View("ChatWindow", chatter);
        }

    }
}
