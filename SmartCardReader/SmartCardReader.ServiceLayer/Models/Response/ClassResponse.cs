using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SmartCardReader.DataAccessLayer.Models;

namespace SmartCardReader.ServiceLayer.Models.Response
{
//    class CustomDateTimeConverter : IsoDateTimeConverter
//    {
//        public CustomDateTimeConverter()
//        {
//            base.DateTimeFormat = "yyyy-MM-dd HH:mm";
//        }
//    }
    
    public class ClassResponse
    {
        public int Id { get; set; }
//        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime StartDateTime { get; set; }
        public string CourseName { get; set; }
        public List<string> Lecturers { get; set; }
        
    }
}