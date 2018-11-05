using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Json_n_Xml
{
    [Serializable]
    public class Person
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string PhoneNumber { get; set; }
        public int YearOfBirth { get; set; }
    }
}