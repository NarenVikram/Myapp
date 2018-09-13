using System;
using Realms;
namespace FinalProject
{
    public class products:RealmObject
    {
            public string Name { get; set; }
            //[PrimaryKey]
           // public String productID { get; set; } = Guid.NewGuid().ToString();
            public string Desc { get; set; }
            public string Quantity{ get; set; }
            public string Category { get; set; }
           
    }
}
