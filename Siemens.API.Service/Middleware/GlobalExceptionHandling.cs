using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Net;
using System.Text;

namespace Siemens.API.Service.Middleware
{
    public class GlobalExceptionHandling
    {
        private readonly RequestDelegate _requestDelegate;

        public GlobalExceptionHandling(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        //Delegate Invoke
        public async Task Invoke(HttpContext context)
        {
            try
            {
                //Runs the request
                await _requestDelegate(context);
            }

            catch (Exception exception)
            {
                var response = context.Response;

                if (exception is DivideByZeroException)
                {
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
                else if (exception is SqlTypeException)
                {
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                }

                else if (exception is NullReferenceException)
                {
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                }

                else if (exception is KeyNotFoundException)
                {
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                }

                else
                {
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                }
                var result = JsonSerializer.Serialize(new { message = exception.Message });

                await response.WriteAsync(result);


            }

        }
    }
}
