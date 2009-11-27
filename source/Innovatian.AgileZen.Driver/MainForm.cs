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

using System.Windows.Forms;

#endregion

namespace Innovatian.AgileZen.Driver
{
    public partial class MainForm : Form
    {
        private readonly ZenCommunicator _communicator;

        public MainForm()
        {
            InitializeComponent();
            _communicator = new ZenCommunicator("<<YOUR-API-KEY>>");
            IZenApi _zenApiChannel = _communicator.CreateAgileZenChannel();
            ProjectCollection projects = _zenApiChannel.GetProjects();
            Project firstProject = projects.Items[0];
            string projectId = firstProject.Id.ToString();
            Project project = _zenApiChannel.GetProject(projectId);
            StoryCollection stories = _zenApiChannel.GetStories(projectId);
        }
    }
}