using InfraccionesPedagogicas.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraccionesPedagogicas.Application.Response
{
    public class Response<T>
    {
        public Response()
        {

        }
        public Response(T data)
        {
            Data = data;
            Status = ResponseStatus.Success;
        }
        public Response(T data,ResponseStatus status,string errorMessage)
        {
            Data = data;
            this.Status = Status;
            this.ErrorMessage = errorMessage;
        }

        public T Data { get; set; }
        public ResponseStatus Status { get; set; }
        public string ErrorMessage { get; set; }
    }
}
