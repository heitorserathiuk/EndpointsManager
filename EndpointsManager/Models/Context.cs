using System.Collections.Generic;

namespace EndpointsManager.Models
{
    public class Context
    {
        public List<Endpoint> endpoints { get; }

        public Context()
        {
            if (endpoints == null)
            {
                endpoints = new List<Endpoint>();
            }
        }
    }
}
