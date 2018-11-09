using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShelfBusinessLogic
{
    public interface IBookResolver<in TSource, in TDestination, TDestMemebr>
    {
        TDestMemebr Resolve(TSource source, TDestination destination, TDestMemebr destMemebr, IDataProvider context);
    }
}
