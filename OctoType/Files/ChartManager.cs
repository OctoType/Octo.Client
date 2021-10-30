using System;
using System.Collections.Generic;
using OctoType.Files;

namespace OctoType.Charts {

    public class ChartManager : FileLoader {

        private Dictionary<string, float> InMemoryChart;

        public override void LoadFile(string name, string path) {
            throw new NotImplementedException();
        }

        public string GetBackgroundPath() {
            return null;
        }
    }
}
