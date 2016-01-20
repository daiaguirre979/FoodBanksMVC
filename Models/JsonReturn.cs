using System;
using System.Collections.Generic;
using FoodBanksMVC.Contracts;

namespace FoodBanksMVC.Models
{
    /// <summary>Request return type.</summary>
    public class JsonReturn : IJsonReturn
    {
        /// <summary>Unique request identifer.</summary>
        public int RequestId { get; set; }

        /// <summary>Request results.</summary>
        public object Result { get; set; }

        /// <summary>Http status code.</summary>
        public string Status { get; set; }

        /// <summary>Error information.</summary>
        public Error Error { get; set; }

        /// <summary>Associated links for reference to result (self) or paging links.</summary>
        public List<Link> Links { get; set; }

        public JsonReturn()
        {
            Links = new List<Link>();
        }

        public JsonReturn( int id, object res, string stat, Error err )
        {
            Links = new List<Link>();
            RequestId = id;
            Result = res;
            Status = stat;
            Error = err;
        }
    }

    /// <summary>Error information.</summary>
    public class Error
    {
        /// <summary></summary>
        public string Message { get; set; }

        /// <summary></summary>
        public int Code { get; set; }

        /// <summary></summary>
        public string MoreInfo { get; set; }
    }

    public class Link
    {
        /// <summary>Link relationship.</summary>
        /// <remarks>Values = self, previous, next</remarks>
        public string Rel { get; set; }

        /// <summary>Url.</summary>
        public string Href { get; set; }
    }
}