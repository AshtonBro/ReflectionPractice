using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace ReflectionTest
{
    public class ReflectionPresenter
    {
        private const string PRESS_ENTER = "Press ENTER to continue";

        private static IFormatProvider formatProvider;
        private static int index;

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
                    var hasAttribute = cProp.GetCustomAttribute<CopyFromB>();

                    if (hasAttribute != null)
                    {
                        var bPropExist = bType.GetProperty(bType.Name + cProp.Name.Substring(1));

                        if (bPropExist != null)
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
                var cPropExist = cType.GetProperty(cType.Name + dProp.Name.Substring(1));

                if (cPropExist != null)
                {
                    dProp.SetValue(_d, cPropExist.GetValue(_c));

                    Console.WriteLine($"Proportion value from {cPropExist.Name} successfully copied to {dProp.Name}.");
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

        //Copy all values from c to e. Arrays!!! Split value do it fits.
        public static void CopyValuesArrayProp(c _c, e _e)
        {
            var cType = _c.GetType();
            var eType = _e.GetType();
            var ePropertyes = _e.GetType().GetProperties();
            var cPropertyes = _c.GetType().GetProperties();

            foreach (var eProp in ePropertyes)
            {
                var cPropExist = cType.GetProperty(cType.Name + eProp.Name.Substring(1));

                if (cPropExist != null)
                {
                    if (typeof(IEnumerable).IsAssignableFrom(eProp.PropertyType))
                    {
                        Console.WriteLine(cPropExist.Name + " " + eProp.PropertyType.Name);

                        
                       //var listType = typeof(List<>).MakeGenericType(eProp.PropertyType);

                       //var instanceType = (IList)Activator.CreateInstance(listType);

                       var value = (int)cPropExist.GetValue(_c);

                        //var result = ((IConvertible)4).ToByte(formatProvider);

                        var instanceType = Array.CreateInstance(eProp.PropertyType, value.ToString().Length);

                        while (value > 0)
                        {
                            var num = value % 10;

                            var result = ((IConvertible)num).ToByte(formatProvider);

                            instanceType.SetValue(result, index++);

                            value = value / 10;
                        }

                        //instanceType.SetValue(result, 0);


                        eProp.SetValue(_e, instanceType);

                        // List<object> listS = instanceType.Cast<object>().ToList();

                        // listS.Add(value);

                        //var al = new ArrayList(listS);

                        // var instanceType = Array.CreateInstance(eProp.PropertyType.GetElementType(), 1);

                        // instanceType.SetValue(value, 0);

                        //var convertValue = Convert.ChangeType(listS[0], eProp.PropertyType);

                        //instanceType.Add(value);

                        //foreach (var item in currentEnum)
                        //{
                        //    if (item != default)
                        //    {
                        //        instance.Add((item);
                        //    }
                        //}

                        // eProp.SetValue(_e, instanceType);

                        Type tProp = eProp.PropertyType;


                        //eProp.SetValue(_e, Convert.ChangeType(value, tProp), null);

                    }
                    else
                    {
                        eProp.SetValue(_e, cPropExist.GetValue(_c));

                        Console.WriteLine($"Proportion value from {cPropExist.Name} successfully copied to {eProp.Name}.");
                    }
                }
                else
                {
                    Console.WriteLine($"{eProp.Name} is incorrect property!");
                }
            }

            Console.WriteLine("-------------End Task №5-------------");
            Console.WriteLine(PRESS_ENTER);
            Console.ReadLine();

        }
    }
}