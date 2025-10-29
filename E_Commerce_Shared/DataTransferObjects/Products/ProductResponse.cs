using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Shared.DataTransferObjects.Products
{
    public record ProductResponse
    {
#nullable disable
     public  int id                    {get; set;}
     public   string Name              {get; set;}
     public    string Description      {get; set;}
     public   string PictureUrl        {get; set;}
     public   decimal Price            {get; set;}
     public   string PBrand            {get; set;}
     public   string Type              { get; set; }
   }
}
