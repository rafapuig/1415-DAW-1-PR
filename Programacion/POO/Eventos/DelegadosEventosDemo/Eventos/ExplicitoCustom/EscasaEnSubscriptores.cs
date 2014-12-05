using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegadosEventosDemo.Eventos.ExplicitoCustom
{
    class ScarceEventSource
    {       

        //Un diccionario compartido por todas las instacias de la clase 
        //lleva el seguimiento de todos los controladores para cualquiera de los eventos
        private static readonly Dictionary<Tuple<ScarceEventSource, object>, EventHandler> _eventHandlers        
            = new Dictionary<Tuple<ScarceEventSource, object>, EventHandler>();

        // Objectos usados como claves para identidicar un evento particular en el diccionario.
        private static readonly object EventoUnoId = new object();
        private static readonly object EventoDosId = new object();

        public event EventHandler EventOne
        {
            add { AddEvent(EventoUnoId, value); }
            remove { RemoveEvent(EventoUnoId, value); }
        }

        public event EventHandler EventTwo
        {
            add { AddEvent(EventoDosId, value); }
            remove { RemoveEvent(EventoDosId, value); }
        }

        public void RaiseBoth()
        {
            RaiseEvent(EventoUnoId, EventArgs.Empty);
            RaiseEvent(EventoDosId, EventArgs.Empty);
        }

        private Tuple<ScarceEventSource, object> MakeKey(object eventId)
        {
            return Tuple.Create(this, eventId);
        }

        private void AddEvent(object eventId, EventHandler handler)
        {
            var key = MakeKey(eventId);
            EventHandler entry;
            _eventHandlers.TryGetValue(key, out entry);
            entry += handler;
            _eventHandlers[key] = entry;
        }

        private void RemoveEvent(object eventId, EventHandler handler)
        {
            var key = MakeKey(eventId);
            EventHandler entry = _eventHandlers[key];
            entry -= handler;
            if (entry == null)
            {
                _eventHandlers.Remove(key);
            }
            else
            {
                _eventHandlers[key] = entry;
            }
        }

        private void RaiseEvent(object eventId, EventArgs e)
        {
            var key = MakeKey(eventId);
            EventHandler handler;
            if (_eventHandlers.TryGetValue(key, out handler))
            {
                handler(this, e);
            }
        }
    }

}
