using System;
using System.Net;
using System.Net.Http;

namespace HaloInfiniteMobileApp.Exceptions
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Roslynator", "RCS1194:Implement exception constructors.", Justification = "<Pending>")]
    public class HttpRequestExceptionEx : HttpRequestException
    {
        public HttpStatusCode HttpCode { get; }

        public HttpRequestExceptionEx(HttpStatusCode code) : this(code, null, null)
        {
        }

        public HttpRequestExceptionEx(HttpStatusCode code, string message) : this(code, message, null)
        {
        }

        public HttpRequestExceptionEx(HttpStatusCode code, string message, Exception inner) : base(message, inner)
        {
            HttpCode = code;
        }
    }
}