using Bier.ServicesAPI.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bier.ServicesAPI
{
    public class UserRepository : BaseRepository
    {
        public UserRepository() : base("Users")
        {
        }
    }
}
