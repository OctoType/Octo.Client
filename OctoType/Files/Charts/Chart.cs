using System;
using System.Collections.Generic;

namespace OctoType.Charts {

    public class Chart {

        /// <summary>
        /// In memory chart can be interpreted to be structure as such:
        /// Chart: {
        ///     For each key: {
        ///         string key,
        ///         Queue notes
        ///     }
        /// }
        /// </summary>
        public Dictionary<string, Queue<Note>> Notes { get; private set; }
        public string AudioFile { get; private set; }
        public float SongPreviewTime { get; private set; }
        public string BackgroundFile { get; private set; }
        public string Title { get; private set; }
        public string Artist { get; private set; }
        public string Source { get; private set; }
        public List<string> Tags { get; private set; }
        public string Creator { get; private set; }
        public string Difficulty { get; private set; }
        public float Bpm { get; private set; }
        public float Offset { get; private set; }

        public Chart(string path) {
            //read in the data from path
        }
    }
}
