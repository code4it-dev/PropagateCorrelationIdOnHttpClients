﻿namespace PropagateCorrelationIdOnHttpClients
{
    public class HeaderPropagationOptions
    {
        public IList<string> HeaderNames { get; set; } = new List<string>();
    }
}