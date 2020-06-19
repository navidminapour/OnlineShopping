using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core
{
    public interface IUnitOfWork
    {
        void Begin();
        void Commit();
        void Rollback();
    }
}
