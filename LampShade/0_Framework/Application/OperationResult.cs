using System;
using System.Collections.Generic;
using System.Text;

namespace _0_Framework.Application
{
    public class OperationResult
    {
        public bool IsSucceced { get; set; }

        public string Message { get; set; }

        public OperationResult()
        {
            IsSucceced = false;

        }

        public OperationResult Succeced(string message = "عملیات با موفقیت انجام شد")
        {
            IsSucceced = true;
            Message = message;
            return this;
        }
        public OperationResult Failed(string message)
        {
            IsSucceced = false;
            Message = message;
            return this;
        }
    }
}
