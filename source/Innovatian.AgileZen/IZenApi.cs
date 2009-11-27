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
using System.ServiceModel.Web;

#endregion

namespace Innovatian.AgileZen
{
    [ServiceContract(Namespace = "http://innovatian.com/AgileZen")]
    [XmlSerializerFormat]
    public interface IZenApi
    {
        [OperationContract(Name = "projects")]
        [WebGet(
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "/projects")]
        ProjectCollection GetProjects();

        [OperationContract(Name = "getProject")]
        [WebGet(
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "/project/{projectId}")]
        Project GetProject(string projectId);

        [OperationContract(Name = "postProject")]
        [WebInvoke(Method = "POST",
            UriTemplate = "/projects")]
        void PostProject(Project project);

        [OperationContract(Name = "putProject")]
        [WebInvoke(Method = "PUT",
            UriTemplate = "/project/{projectId}")]
        void PutProject(string projectId);

        [OperationContract(Name = "deleteProject")]
        [WebInvoke(Method = "DELETE",
            UriTemplate = "/project/{projectId}")]
        void DeleteProject(string projectId);

        [OperationContract(Name = "getStories")]
        [WebGet(
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "/project/{projectId}/stories")]
        StoryCollection GetStories(string projectId);

        [OperationContract(Name = "getStory")]
        [WebGet(
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "/project/{projectId}/story/{storyId}")]
        Story GetStory(string projectId, string storyId);

        [OperationContract(Name = "postStories")]
        [WebInvoke(Method = "POST",
            UriTemplate = "/project/{projectId}/stories")]
        void PostStory(string projectId, Story story);

        [OperationContract(Name = "putStory")]
        [WebInvoke(Method = "PUT",
            UriTemplate = "/project/{projectId}/story/{storyId}")]
        void PutStory(string projectId, string storyId);

        [OperationContract(Name = "deleteStory")]
        [WebInvoke(Method = "DELETE",
            UriTemplate = "/project/{projectId}/story/{storyId}")]
        void DeleteStory(string projectId, string storyId);
    }
}