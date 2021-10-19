using System;
namespace OctoType.Utils {

    public static class StringUtils {

        public static string Normalize(string name) {
            return name.ToLower().Trim();
        }
    }
}
