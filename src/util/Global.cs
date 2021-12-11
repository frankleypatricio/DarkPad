using System;

namespace DarkPad.Util {
    public static class Global {
        public static string WorkingDirectory{
            get => Environment.CurrentDirectory;
        }
    }
}
