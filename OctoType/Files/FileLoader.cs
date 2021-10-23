using System;
using System.IO;
using System.Collections.Generic;

namespace OctoType.Files {

	public abstract class FileLoader {

		protected Dictionary<String, Object> data;

		public FileLoader() {
			data = new Dictionary<String, Object>();
        }

		public abstract void LoadFile(String name, String path);

		public virtual void UnloadFile(String name, String path) {
			data.Remove(name);
        }

		public virtual void UnloadAllFiles() {
			data.Clear();
        }

		public Object GetFile(String name) {
			try {
				return data[name];
			} catch(KeyNotFoundException ex) {
				Console.WriteLine("ERR: GetFile line 26 " + name + " not found.");
				Console.WriteLine(ex.ToString());
				return null;
            }
        }
	}
}
