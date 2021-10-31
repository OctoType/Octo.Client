using System;
using System.Collections.Generic;
using OctoType.Files;

namespace OctoType.Charts {

    public class ChartManager : FileLoader {

        /// <summary>
        /// In memory chart can be interpreted to be structure as such:
        /// Chart: {
        ///     For each key: {
        ///         string key,
        ///         Queue notes
        ///     }
        /// }
        /// </summary>
        private Dictionary<string, Queue<float>> InMemoryChart;
        private string InMemoryName;

        /// <summary>
        /// Reads a chart into memory and selects it as the current chart
        /// </summary>
        public override void LoadFile(string name, string path) {
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
