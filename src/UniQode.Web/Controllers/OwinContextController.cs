using System.Web;
using System.Web.Mvc;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace UniQode.Web.Controllers
{
    public abstract class OwinContextController : Controller
    {
        protected OwinContextController(IOwinContext owinContext = null, IAuthenticationManager authenticationManager = null)
        {
            _owinContext = owinContext;
            _authenticationManager = authenticationManager;
        }

        private readonly IOwinContext _owinContext;
        public IOwinContext OwinContext => _owinContext ?? HttpContext.GetOwinContext();

        private readonly IAuthenticationManager _authenticationManager;
        public IAuthenticationManager Authentication => _authenticationManager ?? OwinContext.Authentication;
    }
}