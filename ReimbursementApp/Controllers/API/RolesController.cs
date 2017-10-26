using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ReimbursementApp.Data.Contracts;

namespace ReimbursementApp.Controllers.API
{
    [Authorize]
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class RolesController : Controller
    {
        private IExpenseReviewUOW UOW;

        public RolesController(IExpenseReviewUOW uow)
        {
            UOW = uow;
        }

        [HttpGet("")]
        public IQueryable Get()
        {
            var model = UOW.Roles.GetAll().OrderBy(role => role.RoleId);
            return model;
        }
    }
}
