using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OkurtProject.Client.DTO;
using OkurtProject.Utils.Helpers;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace OkurtProject.Client.API.Middleware
{
    public class ApiResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (IsSwagger(httpContext))
            {
                await this._next(httpContext);
            }
            else
            {
                var originalBodyStream = httpContext.Response.Body;

                using (var responseBody = new MemoryStream())
                {
                    httpContext.Response.Body = responseBody;

                    try
                    {
                        await _next(httpContext);
                        if (httpContext.Response.StatusCode == (int)HttpStatusCode.OK)
                        {
                            var body = await FormatResponse(httpContext.Response);
                            await HandleSuccessAsync(httpContext, body);
                        }
                        else
                        {
                            await HandleNotSuccessAsync(httpContext, httpContext.Response.StatusCode);
                        }
                    }
                    catch (Exception ex)
                    {
                        await HandleExceptionAsync(httpContext, ex);
                    }
                    finally
                    {
                        responseBody.Seek(0, SeekOrigin.Begin);
                        await responseBody.CopyToAsync(originalBodyStream);
                    }
                }
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            string jsonString = string.Empty;

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = exception.Message;

            if (exception.GetType().Name != "ApiException")
            {
                message = "İşlem sırasında bir hata oluştu.";
            }

            var apiResponse = new ApiResponseDTO() { Success = false, Result = null, Error = message, StatusCode = context.Response.StatusCode };

            jsonString = JsonConvert.SerializeObject(apiResponse);

            return context.Response.WriteAsync(jsonString);
        }

        private static Task HandleSuccessAsync(HttpContext context, object body)
        {
            string jsonString, bodyText = string.Empty;

            if (!body.ToString().ValidateJSON())
                bodyText = JsonConvert.SerializeObject(body);
            else
                bodyText = body.ToString();

            dynamic bodyContent = JsonConvert.DeserializeObject<dynamic>(bodyText);

            var apiResponse = new ApiResponseDTO() { Success = true, Result = bodyContent, Error = null, StatusCode = context.Response.StatusCode };

            jsonString = JsonConvert.SerializeObject(apiResponse);

            return context.Response.WriteAsync(jsonString);
        }

        private static Task HandleNotSuccessAsync(HttpContext context, int code)
        {
            string message = string.Empty;

            if (code == (int)HttpStatusCode.NotFound)
            {
                message = "Belirtilen URL mevcut değil, lütfen gözden geçirin.";
            }
            else if (code == (int)HttpStatusCode.NoContent)
            {
                message = "Belirtilen URL'de içerik yok.";
            }
            else
            {
                message = "Telebiniz işlenemiyor.";
            }

            string jsonString, bodyText = string.Empty;

            dynamic bodyContent = JsonConvert.DeserializeObject<dynamic>(bodyText);

            var apiResponse = new ApiResponseDTO() { Success = false, Result = null, Error = message, StatusCode = code };

            jsonString = JsonConvert.SerializeObject(apiResponse);

            return context.Response.WriteAsync(jsonString);
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var plainBodyText = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            return plainBodyText;
        }

        private bool IsSwagger(HttpContext context)
        {
            return context.Request.Path.StartsWithSegments("/swagger");
        }
    }
}

