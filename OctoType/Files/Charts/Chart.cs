using System;
using System.Collections.Generic;

namespace OctoType.Charts {

    internal class Chart {

        /// <summary>
        /// In memory chart can be interpreted to be structure as such:
        /// Chart: {
        ///     For each key: {
        ///         string key,
        ///         Queue notes
        ///     }
        /// }
        /// </summary>
        internal Dictionary<string, Queue<Note>> Notes { get; private set; }
        internal string AudioFile { get; private set; }
        internal float SongPreviewTime { get; private set; }
        internal string BackgroundFile { get; private set; }
        internal string Title { get; private set; }
        internal string Artist { get; private set; }
        internal string Source { get; private set; }
        internal List<string> Tags { get; private set; }
        internal string Creator { get; private set; }
        internal string Difficulty { get; private set; }
        internal float Bpm { get; private set; }
        internal float Offset { get; private set; }

        internal Chart(string path) {

        }

    }
}
