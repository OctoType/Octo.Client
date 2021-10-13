using System;
using System.IO;
using System.Collections.Generic;

namespace OctoType.Files {

	public abstract class FileLoader {

		private Dictionary<String, Object> data;

		public FileLoader() {
			data = new Dictionary<String, Object>();
        }

		public abstract void LoadFile(String name, String path);

		public void UnloadFile(String name, String path) {
			data.Remove(name);
        }

		public void UnloadAllFiles() {
			data.Clear();
        }
		public Object GetFile(String name) {
			return data[name];
        }
	}
}
