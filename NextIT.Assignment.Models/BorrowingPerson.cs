using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NextIT.Assignment.Models
{
    public class BorrowingPerson
    {
        [JsonPropertyName("FirstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("LastName")]
        public string LastName { get; set; }

        [JsonConverter(typeof(DateConverter))]
        [JsonPropertyName("From")]
        [DateAttribute]
        public DateTime From { get; set; }

        public override string ToString()
        {
            return $"First name: {FirstName}\n\rLast name: {LastName}\n\rFrom: {From:d.M.yyyy}\n";
        }
    }

    public class DateAttribute : RangeAttribute
    {
        public DateAttribute() : base(typeof(DateTime), 
            new DateTime(1900, 1,1).ToShortDateString(),
            DateTime.Now.AddDays(1).ToShortDateString())
        {

        }
    }
}