using System;
namespace OctoType.Screens {
    public interface IScreen {
        /// <summary>
        /// Whether this <see cref="IScreen"/> can be resumed.
        /// </summary>
        bool ValidForResume { get; set; }

        /// <summary>
        /// Whether this <see cref="IScreen"/> can be pushed.
        /// </summary>
        bool ValidForPush { get; set; }

        /// <summary>
        /// Invoked when this <see cref="IScreen"/> is entering from a parent <see cref="IScreen"/>.
        /// </summary>
        /// <param name="last">The <see cref="IScreen"/> which has suspended.</param>
        void OnEntering(IScreen last);

        /// <summary>
        /// Invoked when this <see cref="IScreen"/> is exiting to a parent <see cref="IScreen"/>.
        /// </summary>
        /// <param name="next">The <see cref="IScreen"/> that will be resumed next.</param>
        /// <returns>True to cancel the exit process.</returns>
        bool OnExiting(IScreen next);

        /// <summary>
        /// Invoked when this <see cref="IScreen"/> is entered from a child <see cref="IScreen"/>.
        /// </summary>
        /// <param name="last">The next Screen.</param>
        void OnResuming(IScreen last);

        /// <summary>
        /// Invoked when this <see cref="IScreen"/> is exited to a child <see cref="IScreen"/>.
        /// </summary>
        /// <param name="next">The new Screen</param>
        void OnSuspending(IScreen next);
    }
}