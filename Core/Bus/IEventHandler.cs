using Core.Events;
using System.Threading.Tasks;

namespace Core.Bus
{
    public interface IEventHandler<in TEvent>: IEventHandler
        where TEvent : Event
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler
    {
    }
}