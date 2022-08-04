using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopManagement.Application.Contracts
{
    public class SendMethod
    {
        public int Id { get;private set; }
        public string Transmission { get; private set; }
        public string Description { get; private set; }

        private SendMethod(int id, string transmission,string description)
        {
            Id = id;
            Transmission = transmission;
            Description = description;
        }

        public static List<SendMethod> GetList()
        {
            return new List<SendMethod>
            {
                new SendMethod(3,"پیک موتوری", "هزینه ارسال:30000 تومان")
                ,new SendMethod(4,"پست پیشتاز","هزینه ارسال: 15 هزار تومان")

            };
        }

        public static SendMethod GetBy(int id)
        {
            return GetList().FirstOrDefault(x => x.Id == id);
        }
    }
}
