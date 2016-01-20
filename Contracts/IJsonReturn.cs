using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FoodBanksMVC.Models;

namespace FoodBanksMVC.Contracts
{
    public interface IJsonReturn
    {
        int RequestId { get; set; }
        object Result { get; set; }
        string Status { get; set; }
        Error Error { get; set; }
        List<Link> Links { get; set; }

        //void JsonReturn();
        //void JsonReturn(int id, object res, string stat, Error err );
    }

    public interface IError
    {
        string Message { get; set; }
        int Code { get; set; }
        string MoreInfo { get; set; }
    }

    public interface ILink
    {
        string Rel { get; set; }
        string Href { get; set; }
    }
}
