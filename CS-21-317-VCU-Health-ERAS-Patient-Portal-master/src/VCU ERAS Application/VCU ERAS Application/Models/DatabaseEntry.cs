using System;
using System.Collections.Generic;
using System.Text;

namespace VCU_ERAS_Application.Models
{
    public class DatabaseEntry
    {
        public int id { get; set; }
        public int type { get; set; }//0 for surgery, 1 for contition, 2 for location
        public string surgeryname { get; set; }//0
        public string surgeryInfo { get; set; }//0
        public string condition { get; set; }//1
        public string dietinstructions { get; set; }//1
        public string postinstructions { get; set; }//1
        public string locationname { get; set; }//2
        public string address { get; set; }//2
        public string phonenumber { get; set; }//2
        public string dayofinformation { get; set; }//2
    }
}
