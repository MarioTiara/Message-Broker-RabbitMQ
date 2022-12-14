using System.Reflection.Metadata.Ecma335;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormulaAirLine.API.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string PassangerName { get; set; }="";
        public string PassportNumber { get; set; }="";
        public string From { get; set; }="";
        public string To { get; set; }="";
        public int status { get; set; }


    }
}