using System;
using System.Collections.Generic;
using System.Text;

namespace Scaffolding.Common.Helpers
{
    public interface IBuilder<T>
    {
        T Build();
    }

    public interface IBuilderEx<T>
    {
        T Build(IServiceProvider sp);
    }
}
