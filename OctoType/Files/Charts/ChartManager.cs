using System;
using System.Collections.Generic;
using OctoType.Files;

namespace OctoType.Charts {

    public class ChartManager : FileLoader {

        private string SelectedChart;
        private Dictionary<string, Queue<Note>> InMemoryNotes;

        /// <summary>
        /// Reads a chart into memory
        /// </summary>
        public override void LoadFile(string name, string path) {
            data[name] = new Chart(path);
        }

        public void SelectChart(string name) {
            Chart chart = (Chart) data[SelectedChart];
            InMemoryNotes = chart.Notes;
        }
        public Chart GetLoadedChart() {
            return (Chart) data[SelectedChart];
        }
    }
}
