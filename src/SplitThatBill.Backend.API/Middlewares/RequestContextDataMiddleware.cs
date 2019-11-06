﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SplitThatBill.Backend.Core.Entities;
using SplitThatBill.Backend.Core.Interfaces;

namespace SplitThatBill.Backend.API.Middlewares
{
    public class RequestContextDataMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestContextDataMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IContextData svc)
        {
            svc.CurrentUser = new Person(1, "lhar", "gil");
            await _next(httpContext);
        }
    }
}
