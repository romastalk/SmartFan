using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThridTry
{
    public class RandomCount
    {
        public List<double> GenerateRandom()
        {
            var list = new List<double>();
            Random random = new Random();
            list.Add(random.Next(100));//t
            list.Add(random.Next(100));//dav
            list.Add(random.Next(100));//vl
            return list;
        }
    }
}
