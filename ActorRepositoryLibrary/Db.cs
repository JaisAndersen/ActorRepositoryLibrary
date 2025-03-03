using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActorRepositoryLibrary
{
    public class Db
    {
        public static readonly string LocalConnectionString =
        "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActorLibrary;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";        
    }
}
