using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class BaseEvent : INotification
    {
        
    }

    public interface INotification
    {
    }
}