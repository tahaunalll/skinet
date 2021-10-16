using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ApiResponse
    {

        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetdDefaultMessageForStatusCode(statusCode);
        }



        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetdDefaultMessageForStatusCode(int statusCode)
        {
            return StatusCode switch
            {
                400 => "A bad request, you have made",
                401 =>"Authorized, you are not",
                404 =>"Resource found, it was not",
                500 =>"Errors are the path to the dark side. Errors lead to anger. Anger leads to hate. Hate leads to career change",
                _ =>null
            };
        }
    }
}