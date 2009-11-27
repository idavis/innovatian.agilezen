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
            _communicator = new ZenCommunicator("8dee94ab26324659991250b292db3601");
            IZenApi _zenApiChannel = _communicator.CreateAgileZenChannel();
            ProjectCollection projects = _zenApiChannel.GetProjects();
            Project project = _zenApiChannel.GetProject(projects.Items[0].Id.ToString());
            StoryCollection stories = _zenApiChannel.GetStories(projects.Items[0].Id.ToString());
        }
    }
}