/************************************************************************************
*                                                                                   *
*  File:        ICustomIterator.cs                                                  *
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

namespace Helpers
{
    /// <summary>
    /// Interface that provides a way of creating an iterator for a custom collection of objects.
    /// </summary>
    public interface ICustomIterator
    {
        /// <summary>
        /// Checks if there is a next item in the collction or not.
        /// </summary>
        /// <returns>boolean value.</returns>
        bool HasNext();

        /// <summary>
        /// Gets the next item in the collection.
        /// </summary>
        /// <returns>desired item</returns>
        object Next();
    }
}
