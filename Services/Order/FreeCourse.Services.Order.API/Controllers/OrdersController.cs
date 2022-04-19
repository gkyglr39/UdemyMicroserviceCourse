using FreeCourse.Services.Order.Application.Commands;
using FreeCourse.Services.Order.Application.Dtos;
using FreeCourse.Services.Order.Application.Queries;
using FreeCourse.Shared.ControllerBases;
using FreeCourse.Shared.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeCourse.Services.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : CustomBaseController
    {
        private readonly IMediator _mediator;
        private readonly ISharedIdentityService _sharedIdenityService;

        public OrdersController(IMediator mediator, ISharedIdentityService sharedIdenityService)
        {
            _mediator = mediator;
            _sharedIdenityService = sharedIdenityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var response = await _mediator.Send(new GetOrdersByUserIdQuery() { UserId =_sharedIdenityService.GetUserId });
            return CreateActionResultInstance(response);                     
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrder(CreateOrderCommand createOrderCommand)
        {
            var response =await _mediator.Send(createOrderCommand);
            return CreateActionResultInstance(response);
        }

             


    }
}
