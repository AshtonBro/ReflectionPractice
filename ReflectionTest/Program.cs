using System;

namespace ReflectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new a();
            //Print all values from a.

            var b = new b();
            //Copy all values from a to b.
            //Compare all b values to a.
            //Divide all b values by property number (b64 = value/64).

            var c = new c();
            //Copy all values from a to c, except if property has CopyFromB attribute.

            var d = new d();
            //Copy all values from c to d.

            var e = new e();
            //Copy all values from c to d. Arrays!!! Split value do it fits.

            var f = new f();
            //Copy all values from d to f. (convert values back). Some property values must be set from different property in same object, based on source attribute.
            //Print differences between f and a.

            var g = new g();
            //Copy all values from f to g. Some properties are skipped, put there values in array properties.

            var taskReflectionPresenter = new ReflectionPresenter();

            taskReflectionPresenter.GetValues(a);

            taskReflectionPresenter.CopyDivideValues(a, b);

            taskReflectionPresenter.CopyValuesWithAttrFilter(a, b, c);

            taskReflectionPresenter.CopyValues(c, d);
        }
    }
}
