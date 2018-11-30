using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorld.API.Engine.Interfaces
{
    /// <summary>
    /// Interface for mapping object T1 to new object T2.
    /// </summary>
    /// <typeparam name="T1">The source object type to map from.</typeparam>
    /// <typeparam name="T2">The destination object type to map to.</typeparam>
    public interface IGenericMapper<in T1, out T2>
    {
        /// <summary>
        /// Maps an object of type T1 to a new instance of type T2.
        /// </summary>
        /// <param name="item">The item to map from.</param>
        /// <returns>New instance of T2.</returns>
        T2 Map(T1 item);
    }
}