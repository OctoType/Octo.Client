using System;

using OctoType.Files;

namespace OctoType.Charts {

    public class ChartManager : FileLoader {

        private string InMemoryName;

        /// <summary>
        /// Reads a chart into memory and selects it as the current chart
        /// </summary>
        public override void LoadFile(string name, string path) {
            // parse the .oty chart file into memory
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the background path for the currently selected chart
        /// </summary>
        public string GetBackgroundPath() {
            return null;
        }
    }
}
