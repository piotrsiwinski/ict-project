﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace SmartCardReader.WebUI.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Teacher_ID { get; set; }
        public string Teacher_Name { get; set; }
        public string Teacher_Surname { get; set; }
        public string Subject_Name { get; set; }

     

    }

}