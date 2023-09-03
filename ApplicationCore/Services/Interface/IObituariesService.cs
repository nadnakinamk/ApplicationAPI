using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Model;
namespace ApplicationCore.Services.Interface
{
   public interface IObituariesService
    {
        string Add(Obituaries obj);
        List<Obituaries> ObituarieGetdetails();
        List<Obituaries> ObituarieView(int ObituaryID);
    }
}



