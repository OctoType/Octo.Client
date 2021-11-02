using System;
namespace OctoType.Charts {

    internal class Note {

        internal string Key { get; private set; }
        internal float StartTime { get; private set; }
        internal float EndTime { get; private set; }
        internal bool IsLong { get; private set;  }

        //constructor for held note
        internal Note(string Key, float StartTime, float EndTime) {
            this.Key = Key;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            IsLong = true;
        }

        //constructor for single note
        internal Note(string Key, float StartTime) {
            this.Key = Key;
            this.StartTime = StartTime;
            IsLong = false;
        }
    }
}
