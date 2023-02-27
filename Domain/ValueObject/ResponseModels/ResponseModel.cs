using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObject.ResponseModels
{
    public class ResponseModel<T>
    {
        public int? StatusCode { get; set; }
        public bool? Success { get; set; }
        public string? Message { get; set; }
        public Exception? Exception { get; set; }
        public T? Model { get; set; }
        public ResponseModel(T model)
        {
            Success = true;
            Model = model;
        }
        public ResponseModel(int statusCode, T model)
        {
            StatusCode = statusCode;
            Success = true;
            Model = model;
        }
        public ResponseModel(int statusCode, Exception exception)
        {
            StatusCode = statusCode;
            Success = false;
            Exception = exception;
            Message = "Error: " + exception.Message;
        }
    }
    public class ResponseModel
    {
        public int? StatusCode { get; set; }
        public bool? Success { get; set; } 
        public string? Message { get; set; }
        public Exception? Exception { get; set; }
        public ResponseModel(int statusCode, Exception exception)
        {
            StatusCode = statusCode;
            Success = false;
            Exception = exception;
            Message = "Error: " + exception.Message;
        }
        public ResponseModel(int statusCode, string message)
        {
            StatusCode = statusCode;
            Success = true;
            Message = message;
        }
        public ResponseModel(string message)
        {
            Success = true;
            Message = message;
        }

    }
}
