using Abstraction;

namespace DynamicDll {
    public class DllClass : IDLLInterface {

        public DllClass() {}

        public string GreetingsFromDll() {
            return "Hello from dll";
        }

    }
}