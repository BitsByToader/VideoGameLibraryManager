using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFFramework
{
    public class FormNavigationStack: FormViewContainer
    {
        private Stack<IView> _views = new Stack<IView>();
        private IView _root;

        public FormNavigationStack(): base() {}

        public void SetRoot(IView root)
        {
            _root = root;
            _views.Clear();
            PushView(root);
        }

        public void PushView(IView view)
        {
            view.AddToParent(this);
            view.WillBeAddedToParent();

            _views.Push(view);
            ChangeView(_views.Peek());
        }

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

        public void PopToRoot()
        {
            while (_views.Count > 1)
            {
                IView v = _views.Pop();
                v.WillBeRemovedFromParent();
                v.removeFromParent();
            }

            ChangeView(_views.Peek());
        }
    }
}