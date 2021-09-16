using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Controllers
{
    public class BaseAccessController : ControllerBase
    {
        protected string LoggedUserEmail => this.User.FindFirstValue(Strings.Email);

        protected bool IsLoggedIn()
        {
            //return true;
            if (User.FindFirstValue(Strings.AccessLevel) == null)
                return false;

            return true;
        }

        protected bool IsWorkerOrAbove()
        {
            if (!IsLoggedIn())
                return false;

            var accessLvl = this.User.FindFirstValue(Strings.AccessLevel);

            if (accessLvl != AccessLevelEnum.Undefined.ToString())
            {
                return true;
            }

            return false;
        }

        protected bool IsManagerOrAbove()
        {
            //return true;
            if (!IsLoggedIn())
                return false;

            if (IsWorker())
                return false;

            return true;
        }

        protected bool IsWorker()
        {
            var accessLvl = this.User.FindFirstValue(Strings.AccessLevel);

            if (accessLvl == AccessLevelEnum.Worker.ToString())
                return true;

            return false;

        }

        protected bool IsManager()
        {
            //return true;
            var accessLvl = this.User.FindFirstValue(Strings.AccessLevel);

            if (accessLvl == AccessLevelEnum.Manager.ToString())
                return true;

            return false;
        }

        protected bool IsAdmin()
        {
            //return true;
            var accessLvl = this.User.FindFirstValue(Strings.AccessLevel);

            if (accessLvl == AccessLevelEnum.Admin.ToString())
                return true;

            return false;
        }
    }
}
