using System;
using System.Linq;

namespace ReflectionTest
{
    public class ReflectionPresenter
    {
        private const string PRESS_ENTER = "Press ENTER to continue";

        public static void GetValues(a _a)
        {
            var aPropertyes = _a.GetType().GetProperties();
            
            foreach (var aProp in aPropertyes)
            {
                var value = aProp.GetValue(_a);

                Console.WriteLine($"Print property value: {value}");
            }

            Console.WriteLine("-------------End Task №1-------------");
            Console.WriteLine(PRESS_ENTER);
            Console.ReadLine();
        }

        public static void CopyDivideValues(a _a, b _b)
        {
            var aType = _a.GetType();
            var bPropertyes = _b.GetType().GetProperties();

            foreach (var bProp in bPropertyes)
            {
                var aPropExist = aType.GetProperty(aType.Name + bProp.Name.Substring(1));

                if (aPropExist != null)
                {
                    bProp.SetValue(_b, aPropExist.GetValue(_a));

                    Console.WriteLine($"Proportion value from {aPropExist.Name} successfully copied to {bProp.Name}.");
                }
                else
                {
                    Console.WriteLine($"{bProp.Name} is incorrect property!");
                }

            }

            Console.WriteLine("");
            Console.WriteLine("Next step is division");
            Console.WriteLine(PRESS_ENTER + " " + "to divide");
            Console.ReadLine();

            foreach (var bProp in bPropertyes)
            {
                var value = bProp.GetValue(_b);

                if (value != null)
                {
                    var division = bProp.Name.Substring(1);

                    var result = Convert.ToInt32(value) / Int32.Parse(division);

                    bProp.SetValue(_b, result);

                    Console.WriteLine($"{bProp.Name}: " +
                        $"Receive value - {result} = {division} / {value}, " +
                        $"Expect value - {bProp.GetValue(_b)}");
                }
                else
                {
                    Console.WriteLine($"{bProp.Name} is incorrect property!");
                }
            }

            Console.WriteLine("-------------End Task №2-------------");
            Console.WriteLine(PRESS_ENTER);
            Console.ReadLine();
        }

        public static void CopyValuesWithAttrFilter(a _a, b _b, c _c)
        {
            var aType = _a.GetType();
            var bType = _b.GetType();
            var cPropertyes = _c.GetType().GetProperties();

            foreach (var cProp in cPropertyes)
            {
                var aPropExist = aType.GetProperty(aType.Name + cProp.Name.Substring(1));

                if (aPropExist != null)
                {
                    var isHasAttribute = cProp.GetCustomAttributes(typeof(CopyFromB), false).Length > 0;

                    if (isHasAttribute)
                    {
                        var bPropExist = bType.GetProperty(bType.Name + cProp.Name.Substring(1));

                        if(bPropExist != null)
                        {
                            cProp.SetValue(_c, bPropExist.GetValue(_b));

                            Console.WriteLine($"Proportion value from {bPropExist.Name}" +
                            $" successfully copied to {cProp.Name} - because {cProp.Name} has attribute.");
                        }
                        else
                        {
                            Console.WriteLine($"{bPropExist.Name} is incorrect property!");
                        }
                    }
                    else
                    {
                        cProp.SetValue(_c, aPropExist.GetValue(_a));

                        Console.WriteLine($"Proportion value from {aPropExist.Name} " +
                            $"successfully copied to {cProp.Name}.");
                    }
                }
                else
                {
                    Console.WriteLine($"{cProp.Name} is incorrect property!");
                }
            }
           
            Console.WriteLine("-------------End Task №3-------------");
            Console.WriteLine(PRESS_ENTER);
            Console.ReadLine();
        }

        public static void CopyValues(c _c, d _d)
        {
            var dPropertyes = _d.GetType().GetProperties();
            var cType = _c.GetType();

            foreach (var dProp in dPropertyes)
            {
                var a_propExist = cType.GetProperty(cType.Name + dProp.Name.Substring(1));

                if (a_propExist != null)
                {
                    dProp.SetValue(_d, a_propExist.GetValue(_c));

                    Console.WriteLine($"Proportion value from {a_propExist.Name} successfully copied to {dProp.Name}.");
                }
                else
                {
                    Console.WriteLine($"{dProp.Name} is incorrect property!");
                }
            }

            Console.WriteLine("-------------End Task №4-------------");
            Console.WriteLine(PRESS_ENTER);
            Console.ReadLine();
        }
    }
}