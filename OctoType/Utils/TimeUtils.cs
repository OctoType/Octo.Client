using System;
namespace OctoType.Utils {
    
    public static class TimeUtils {

        private static float timer;
        public static float Timer {
            get {
                return timer;
            }
            set {
                timer = value;
            }
        }
    }
}
