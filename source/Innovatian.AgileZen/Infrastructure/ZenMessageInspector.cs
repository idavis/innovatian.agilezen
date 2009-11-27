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
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

#endregion

namespace Innovatian.AgileZen
{
    internal class ZenMessageInspector : IClientMessageInspector
    {
        private readonly string _apiKey;

        public ZenMessageInspector(string apiKey)
        {
            _apiKey = apiKey;
        }

        private static HttpRequestMessageProperty GetHttpRequestProp(Message request)
        {
            if (!request.Properties.ContainsKey(HttpRequestMessageProperty.Name))
            {
                request.Properties.Add(HttpRequestMessageProperty.Name, new HttpRequestMessageProperty());
            }

            return request.Properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
        }

        #region Implementation of IClientMessageInspector

        /// <summary>
        /// Enables inspection or modification of a message before a request message is sent to a service.
        /// </summary>
        /// <returns>
        /// The object that is returned as the <paramref name="correlationState "/>argument of the <see cref="M:System.ServiceModel.Dispatcher.IClientMessageInspector.AfterReceiveReply(System.ServiceModel.Channels.Message@,System.Object)"/> method. This is null if no correlation state is used.The best practice is to make this a <see cref="T:System.Guid"/> to ensure that no two <paramref name="correlationState"/> objects are the same.
        /// </returns>
        /// <param name="request">The message to be sent to the service.</param><param name="channel">The WCF client object channel.</param>
        object IClientMessageInspector.BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            HttpRequestMessageProperty httpRequest = GetHttpRequestProp(request);
            if (httpRequest != null)
            {
                httpRequest.Headers.Add("X-Zen-ApiKey", _apiKey);
            }
            return null;
        }

        /// <summary>
        /// Enables inspection or modification of a message after a reply message is received but prior to passing it back to the client application.
        /// </summary>
        /// <param name="reply">The message to be transformed into types and handed back to the client application.</param><param name="correlationState">Correlation state data.</param>
        void IClientMessageInspector.AfterReceiveReply(ref Message reply, object correlationState)
        {
        }

        #endregion
    }
}