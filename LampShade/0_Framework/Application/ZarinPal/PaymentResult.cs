using System;
using System.Collections.Generic;
using System.Text;

namespace _0_Framework.Application.ZarinPal
{
    public class PaymentResult
    {
        public bool IsSuccessful{ get; set; }
        public string Message { get; set; }
        public string IssueTrackingNo { get; set; }
        public double PayAmount { get; set; }

        public PaymentResult Succeeded(string message,string issueTrackingNo,double payAmount)
        {
            PayAmount = payAmount;
            IsSuccessful = true;
            Message = message;
            IssueTrackingNo = issueTrackingNo;
            return this;

        }
        public PaymentResult Failed(string message)
        {
            IsSuccessful = false;
            Message = message;
            return this;

        }
    }
}
