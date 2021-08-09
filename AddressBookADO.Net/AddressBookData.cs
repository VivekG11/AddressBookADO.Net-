using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookADO.Net
{
    class AddressBookData
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public double Zip { get; set; }
        public double PhoneNumber { get; set; }
        public string email { get; set; }
        public string BookName { get; set; }
        public string type { get; set; }
        public int count { get; set; }
        public string number { get; set; }
    }
}
