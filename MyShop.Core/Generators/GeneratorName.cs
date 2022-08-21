using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Generators
{
    public class GeneratorName
    {
        public static string GenrateUniqeCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
