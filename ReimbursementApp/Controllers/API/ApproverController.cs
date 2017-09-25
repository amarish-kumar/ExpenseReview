using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReimbursementApp.Data.Contracts;

namespace ReimbursementApp.Controllers.API
{
    [Route("api/[controller]")]
    public class ApproverController :Controller
    {
        private IExpenseReviewUOW UOW;

        public ApproverController(IExpenseReviewUOW uow)
        {
            UOW = uow;
        }

        [HttpGet("")]
        public IQueryable Get()
        {
            var model = UOW.Approvers.GetAll().OrderByDescending(emp => emp.Id);
            return model;
        }
    }
}
