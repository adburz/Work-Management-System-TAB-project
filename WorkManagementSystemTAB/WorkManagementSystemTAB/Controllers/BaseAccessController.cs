using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Controllers
{
    public class BaseAccessController : ControllerBase
    {
        protected bool IsLoggedIn()
        {
            if (User.FindFirstValue(Strings.AccessLevel) == null)
                return false;

            return true;
        }

        protected bool IsManagerOrAbove()
        {
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
            var accessLvl = this.User.FindFirstValue(Strings.AccessLevel);

            if (accessLvl == AccessLevelEnum.Manager.ToString())
                return true;

            return false;
        }

        protected bool IsAdmin()
        {
            var accessLvl = this.User.FindFirstValue(Strings.AccessLevel);

            if (accessLvl == AccessLevelEnum.Admin.ToString())
                return true;

            return false;
        }

        protected string LoggedUserEmail => this.User.FindFirstValue("email");
    }
}
