using System;
namespace OctoType.Screens {
    public class TestScreen : IScreen{

        private bool isLoaded;

        bool IScreen.IsLoaded { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        void IScreen.Draw() {
            throw new NotImplementedException();
        }

        void IScreen.LoadContent() {
            throw new NotImplementedException();
        }

        void IScreen.OnExit() {
            throw new NotImplementedException();
        }

        void IScreen.OnSuspend() {
            throw new NotImplementedException();
        }

        void IScreen.UnloadContent() {
            throw new NotImplementedException();
        }

        void IScreen.Update() {
            throw new NotImplementedException();
        }
    }
}
