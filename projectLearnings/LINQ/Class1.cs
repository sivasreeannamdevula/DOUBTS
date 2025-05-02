using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class Class1
    {
       public void method1()
       {
            List<int> list2 = new List<int>();
            list2.AddRange(23, 35, 2, 56, 7);
            //IEnumerable data is loaded into clients memory and then operatioms are performed
            //it brings all the data into clients memory
            IEnumerable<int> res = from c in list2 where c > 30 select c;

            //IQueyable --on server-side itslef operations are performed on the data
            //filter chesina data only theeskostadhi
            IQueryable<int> res2 = list2.AsQueryable().Where(d => d > 39);
            foreach (var i in res2)
            {
                System.Console.WriteLine(i);
            }
        }

    }
}
