using System;
using Realms;

namespace FinalProject
{
    public class Users : RealmObject
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Age { get; set; }
    }
}