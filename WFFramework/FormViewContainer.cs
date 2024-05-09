using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFFramework
{
    public class FormViewContainer : TableLayoutPanel, IViewContainer
    {
        private IView _currentView = null;

        public FormViewContainer(): base()
        {
            ColumnCount = 1;
            RowCount = 1;
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (Controls.Count == 1)
            {
                Controls[0].Size = Size;
            }
        }

        public void ChangeView(IView view)
        {
            Form wrappedForm = (Form) view; // will throw if view is not derived from Form
            wrappedForm.TopLevel = false;
            wrappedForm.FormBorderStyle = FormBorderStyle.None;

            if (Controls.Count == 1 && _currentView != null) // We already have a view in the container
            {
                _currentView.WillDisappear();
                Form curr = Controls[0] as Form; // we only accept Forms so this shouldn't fail, can also use currentView cast as Form which should also not fail
                curr.Hide(); // not necessary (from limited testing), but intuition says this should be done
            }

            view.WillAppear();
            _currentView = view;

            Controls.Clear(); // remove old form
            Controls.Add(wrappedForm); // add new form
            wrappedForm.Size = Size;
            wrappedForm.Show();
            Refresh();
        }

        public IView GetCurrentView()
        {
            return _currentView;
        }
    }
}
