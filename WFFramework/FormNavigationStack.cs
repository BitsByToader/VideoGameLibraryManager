using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFFramework
{
    /// <summary>
    /// Extends the basic container and provides stack navigation. What this means is that views remain in the container's hierarchy even though they're not actively shown. The views are displayed in a first in,
    /// last out manner, and are stored until they are all popped out of the stack. The first view in the stack, the root, will never be popped as the container server no purpose if it is empty.
    /// </summary>
    public class FormNavigationStack: FormViewContainer
    {
        private Stack<IView> _views = new Stack<IView>();
        private IView _root;

        /// <summary>
        /// Constructor for the container.
        /// </summary>
        public FormNavigationStack(): base() {}

        /// <summary>
        /// Sets the root of the stack and clears out any other views remaining.
        /// </summary>
        /// <param name="root">The new root view of the container.</param>
        public void SetRoot(IView root)
        {
            _root = root;
            _views.Clear();
            PushView(root);
        }

        /// <summary>
        /// Pushes a view onto the stack, displaying it at the same time. The view will be notifies it is now in the stack's hierarchy and it is about to be displayed. The old view is moved up the stack
        /// and is also notified properly.
        /// </summary>
        /// <param name="view">The new view in the stack.</param>
        public void PushView(IView view)
        {
            view.AddToParent(this);
            view.WillBeAddedToParent();

            _views.Push(view);
            ChangeView(_views.Peek());
        }

        /// <summary>
        /// Pops a view from the stack, removing it from the hierarchy and displaying the next view in the stack. The views are notified of their lifecycle changes.
        /// </summary>
        public void PopView()
        {
            if (_views.Count > 1) // do not pop the root
            {
                IView v = _views.Pop();

                ChangeView(_views.Peek());

                v.WillBeRemovedFromParent();
                v.removeFromParent();
            }
        }

        /// <summary>
        /// Pops all of the views from the stack, undoing the navigation sequence all the way back to the root view of the container. All of the views are notified in order of the lifecycle changes.
        /// </summary>
        public void PopToRoot()
        {
            _views.Peek().WillDisappear(); // current view will dissapear

            while (_views.Count > 1)
            {
                IView v = _views.Pop();
                v.WillBeRemovedFromParent(); // all views will be removed from the hierarchy
                v.removeFromParent();
            }

            _root.WillAppear(); // the root view will now appear
            ChangeView(_views.Peek());
        }
    }
}