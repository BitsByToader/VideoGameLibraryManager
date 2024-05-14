/************************************************************************************
*                                                                                   *
*  File:        ICollectionViewer.cs                                                * 
*  Copyright:   (c) 2024, Cristina Andrei Marian                                    *
*  E-mail:      andrei-marian.cristina@student.tuiasi.ro                            *
*  Description:                                                                     *
*                                                                                   *
*                                                                                   *
*  This code and information is provided "as is" without warranty of                *
*  any kind, either expressed or implied, including but not limited                 *
*  to the implied warranties of merchantability or fitness for a                    *
*  particular purpose. You are free to use this source code in your                 *
*  applications as long as the original copyright notice is included.               *
*                                                                                   *
************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helpers
{
    /// <summary>
    /// Interface that provides general functionality of a collection viewer. Can be extended for any type of collection 
    /// of objects.
    /// </summary>
    public interface ICollectionViewer
    {
        /// <summary>
        /// method used for getting the iterator asociated for the collection of objects.
        /// </summary>
        /// <returns> a custom iterator</returns>
        ICustomIterator GetIterator();

        /// <summary>
        /// method to add an item in the collection.
        /// </summary>
        /// <param name="item">item to be added in a collection, when used a cast to the type of the object in the collection is needed.</param>
        void AddItem(object item);

        /// <summary>
        /// method to add an entire iterable in the collection.
        /// </summary>
        /// <param name="items"></param>
        void AddItems(IEnumerable<object> items);

        /// <summary>
        /// Delete all the items in the collection. 
        /// </summary>
        void ClearItems();  
    }
}
