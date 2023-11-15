
using System.Reflection;

using Abstraction;

namespace DynamicDllLoading {

    public class Program {
        public static void Main(string[] argsv) {

            IDLLInterface callable = GetDllClass<IDLLInterface>();
            string greeting = callable.GreetingsFromDll();
            Console.WriteLine(greeting);
        }

        public static T GetDllClass<T>() {
            string base_path = @$"{Directory.GetCurrentDirectory()}\DynDll";

            foreach (string path in Directory.GetFiles(base_path)) {
                if (!path.EndsWith(".dll")) continue;

                Assembly dll = Assembly.LoadFile(path);
                Type[] types = dll.GetExportedTypes();

                foreach (Type type in types) {
                    if (type.IsInterface) continue;
                    Type t = typeof(T);

                    Type? has_interface = type.GetInterface(t.Name);

                    if (has_interface == null) continue;

                    T callable = (T)type.GetConstructors().First().Invoke(null);
                    return callable;
                }

            }
            throw new Exception("Not instance of interface");
        }

    }

}
