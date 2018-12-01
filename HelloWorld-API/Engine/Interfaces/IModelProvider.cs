using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HelloWorld.API.Engine.Models;

namespace HelloWorld.API.Engine.Interfaces
{
    /// <summary>
    /// Defines provider pattern interface for models.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IModelProvider<T>
    {
        bool Create(T item);
        IEnumerable<T> Read(IQueryParametersModel queryParametersModel);
        bool Update(T item);
        bool Delete(T item);
    }
}