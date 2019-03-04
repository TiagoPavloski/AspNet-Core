using Eventos.IO.Domain.Core.Events;
using Eventos.IO.Domain.Eventos.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Domain.Eventos.EventHandlers
{
    public class EventoEventHandler :
        IHandler<EventoRegistradoEvent>,
        IHandler<EventoAtualizadoEvent>,
        IHandler<EventoExcluidoEvent>
    {
        public void Handle(EventoRegistradoEvent message)
        {
            //Enviar email
        }

        public void Handle(EventoAtualizadoEvent message)
        {
            //Enviar email
        }

        public void Handle(EventoExcluidoEvent message)
        {
            //Enviar email
        }
    }
}
