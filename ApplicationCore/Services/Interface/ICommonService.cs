using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Model;
namespace ApplicationCore.Services.Interface
{
   public interface ICommonService
    {
        List<States> SearchState(string State);
        List<Districts> SearchDistrict(int StateID, string District);
        List<Cities> SearchCity(int StateID, string DistrictID, string City);
    }
}
