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

#endregion

namespace Innovatian.AgileZen
{
    public class ZenCommunicator
    {
        private readonly ChannelFactory<IZenApi> _channelFactory;

        public ZenCommunicator(string apiKey)
        {
            var end = new EndpointAddress("http://agilezen.com/api/v1");
            _channelFactory = new ChannelFactory<IZenApi>("AgileZenREST", end);
            _channelFactory.Endpoint.Behaviors.Add(new ZenEndpointBehavior(apiKey));
        }

        public IZenApi CreateAgileZenChannel()
        {
            return _channelFactory.CreateChannel();
        }
    }
}