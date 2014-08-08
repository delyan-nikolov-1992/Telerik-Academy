namespace VersionAttribute
{
    using System;
    using System.Reflection;

    [Version(1, 2)]
    public class Test
    {
        [Version(10, 11)]
        static void Main()
        {
            MemberInfo member = typeof(Test);
            Console.WriteLine("Information for class: {0}", member.Name);

            foreach (Attribute attr in member.GetCustomAttributes())
            {
                PrintVersionAttributeInfo(attr);
            }

            MethodInfo[] methods = typeof(Test).GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public 
                                                                                    | BindingFlags.Static);
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine("Method name: {0}", method.Name);

                foreach (Attribute attr in method.GetCustomAttributes())
                {
                    PrintVersionAttributeInfo(attr);
                }
            }
        }

        [Version(10, 12)]
        private static void PrintVersionAttributeInfo(Attribute attr)
        {
            if (attr is VersionAttribute)
            {
                VersionAttribute version = (VersionAttribute)attr;
                Console.WriteLine("          Version: {0}", version.GetVersion);
            }
        }
    }
}