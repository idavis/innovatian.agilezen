#region License

// 
// Author: Ian Davis <ian@innovatian.com>
// Copyright (c) 2009, Innovatian Software, LLC
// 
// Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// See the file LICENSE.txt for details.
// 

#endregion

#region Using Directives

using System.ServiceModel;
using System.ServiceModel.Description;

#endregion

namespace Innovatian.AgileZen
{
    public class ZenCommunicator
    {
        private readonly ChannelFactory<IZenApi> _channelFactory;

        public ZenCommunicator(string apiKey)
            :this(apiKey, false)
        {
        }

        public ZenCommunicator(string apiKey, bool ssl)
        {
            ContractDescription constract;
            using (var channelFactory = new ChannelFactory<IZenApi>())
            {
                constract = channelFactory.Endpoint.Contract;
            }
            string uri = string.Format("http{0}://agilezen.com/api/v1", ssl ? "s" : string.Empty);
            var serviceEndpoint = new ServiceEndpoint(constract,
                                                      new WebHttpBinding(),
                                                      new EndpointAddress(uri));
            serviceEndpoint.Behaviors.Add(new WebHttpBehavior());
            serviceEndpoint.Behaviors.Add(new ZenEndpointBehavior(apiKey));
            _channelFactory = new ChannelFactory<IZenApi>(serviceEndpoint);
        }

        public IZenApi CreateAgileZenChannel()
        {
            return _channelFactory.CreateChannel();
        }
    }
}