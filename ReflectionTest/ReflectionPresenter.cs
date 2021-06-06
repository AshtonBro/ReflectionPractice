using System;

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
            var bPropertyes = _b.GetType().GetProperties();

            var aType = _a.GetType();

            foreach (var bProp in bPropertyes)
            {
                var a_propExist = aType.GetProperty(aType.Name + bProp.Name.Substring(1));

                if (a_propExist != null)
                {
                    bProp.SetValue(_b, a_propExist.GetValue(_a));

                    Console.WriteLine($"Proportion value from {a_propExist.Name} successfully copied to {bProp.Name}.");
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
                    var isHasAttribute = cProp.GetCustomAttributes(typeof(Attribute), false).Length > 0;

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

        public static void CopyValues(c _a, d _b)
        {
            var propertyes_a = _a.GetType().GetProperties();
            var propertyes_b = _b.GetType().GetProperties();

            var index = -1;

            var firstChar = propertyes_b[0].Name[0];

            foreach (var property_a in propertyes_a)
            {
                index++;

                if (index <= propertyes_a.Length - 1 & index <= propertyes_b.Length - 1)
                {
                    if (!propertyes_b[index].Name.Contains($"{firstChar}"))
                    {
                        index++;
                    }

                    propertyes_b[index].SetValue(_b, property_a.GetValue(_a));

                    if (property_a.GetValue(_a).Equals(propertyes_b[index].GetValue(_b)))
                    {
                        Console.WriteLine($"Values between {property_a.Name} and {propertyes_b[index].Name} Equals is TRUE.");

                    }
                    else
                    {
                        Console.WriteLine($"Values between {property_a.Name} and {propertyes_b[index].Name} Equals is FALSE.");
                    }
                }
            }

            Console.WriteLine("-------------End Task №4-------------");
            Console.WriteLine(PRESS_ENTER);
            Console.ReadLine();
        }
    }
}