using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFFramework
{
    public interface IViewCollection
    {
        /// <summary>
        /// A collection uses this method to compute the total number of views in the collection.
        /// </summary>
        /// <returns>Number of views which will be displayed.</returns>
        int Count();
        
        /// <summary>
        /// Instructs the collection view that the dataset has changed and needs to redraw its contents.
        /// </summary>
        void RefreshViews();

        /// <summary>
        /// Provides refreshed data to the collection view, than redraws its contents.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        void RefreshViews<T>(List<T> data);

        /// <summary>
        /// Accessor for the collection to retrieve a view at the specified index.
        /// </summary>
        /// <param name="index">Index of the view in the collection.</param>
        /// <returns>The view at the desired index.</returns>
        IView ViewAt(int index);

        /// <summary>
        /// A callback-style method which will be called when an element of the collection has been clicked by the user. Implementing classes can use this
        /// to trigger certain actions when the element was selected.
        /// </summary>
        /// <param name="index">The index of the element that was clicked.</param>
        void ClickedViewAt(int index);
    }
}