using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChoresApplication.Models
{
    public class ChoresModel
    {
        public int ID { get; set; }

        public string ChoreName { get; set; }
        public string ChoreDescription { get; set; }
    }
}