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

using System;
using System.Collections.Generic;
using System.Xml.Serialization;

#endregion

namespace Innovatian.AgileZen
{
    [XmlRoot("project")]
    [Serializable]
    public class Project : IEquatable<Project>
    {
        [XmlElement("createTime")]
        public string CreateTime { get; set; }

        [XmlElement("description")]
        public string Desctiption { get; set; }

        [XmlElement("id")]
        public int Id { get; set; }

        [XmlArray("members")]
        [XmlArrayItem("user")]
        public List<User> Members { get; set; }

        [XmlElement("metrics")]
        public Metrics Metrics { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("owner")]
        public User Owner { get; set; }

        [XmlArray("phases")]
        [XmlArrayItem("phase")]
        public List<Phase> Phases { get; set; }

        #region IEquatable<Project> Members

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.
        ///                 </param>
        public bool Equals(Project other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.CreateTime, CreateTime) && Equals(other.Desctiption, Desctiption) && other.Id == Id &&
                   Equals(other.Members, Members) && Equals(other.Metrics, Metrics) && Equals(other.Name, Name) &&
                   Equals(other.Owner, Owner) && Equals(other.Phases, Phases);
        }

        #endregion

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>. 
        ///                 </param><exception cref="T:System.NullReferenceException">The <paramref name="obj"/> parameter is null.
        ///                 </exception><filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Project)) return false;
            return Equals((Project) obj);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            unchecked
            {
                int result = (CreateTime != null ? CreateTime.GetHashCode() : 0);
                result = (result*397) ^ (Desctiption != null ? Desctiption.GetHashCode() : 0);
                result = (result*397) ^ Id;
                result = (result*397) ^ (Members != null ? Members.GetHashCode() : 0);
                result = (result*397) ^ (Metrics != null ? Metrics.GetHashCode() : 0);
                result = (result*397) ^ (Name != null ? Name.GetHashCode() : 0);
                result = (result*397) ^ (Owner != null ? Owner.GetHashCode() : 0);
                result = (result*397) ^ (Phases != null ? Phases.GetHashCode() : 0);
                return result;
            }
        }

        public static bool operator ==(Project left, Project right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Project left, Project right)
        {
            return !Equals(left, right);
        }
    }
}