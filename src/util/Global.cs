using System;

namespace DarkPad.Util {
    public static class Global {
        public const string github = "https://github.com/frankleypatricio/DarkPad";
        public const int minWidth = 564;
        public const int minHeight = 380;

        public static string WorkingDirectory {
            get => Environment.CurrentDirectory;
        }
    }
}
