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
using System.Xml.Serialization;

#endregion

namespace Innovatian.AgileZen
{
    [XmlRoot("story")]
    [Serializable]
    public class Story : IEquatable<Story>
    {
        [XmlElement("blocked")]
        public bool Blocked { get; set; }

        [XmlElement("color")]
        public string Color { get; set; }

        [XmlElement("creator")]
        public User Creator { get; set; }

        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("owner")]
        public User Owner { get; set; }

        [XmlElement("phase")]
        public Phase Phase { get; set; }

        [XmlElement("phaseIndex")]
        public int PhaseIndex { get; set; }

        [XmlElement("ready")]
        public bool Ready { get; set; }

        [XmlElement("size")]
        public string Size { get; set; }

        [XmlElement("text")]
        public string Text { get; set; }

        #region IEquatable<Story> Members

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.
        ///                 </param>
        public bool Equals(Story other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Blocked.Equals(Blocked) && Equals(other.Color, Color) && Equals(other.Creator, Creator) &&
                   other.Id == Id && Equals(other.Owner, Owner) && Equals(other.Phase, Phase) &&
                   other.PhaseIndex == PhaseIndex && other.Ready.Equals(Ready) && Equals(other.Size, Size) &&
                   Equals(other.Text, Text);
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
            if (obj.GetType() != typeof (Story)) return false;
            return Equals((Story) obj);
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
                int result = Blocked.GetHashCode();
                result = (result*397) ^ (Color != null ? Color.GetHashCode() : 0);
                result = (result*397) ^ (Creator != null ? Creator.GetHashCode() : 0);
                result = (result*397) ^ Id;
                result = (result*397) ^ (Owner != null ? Owner.GetHashCode() : 0);
                result = (result*397) ^ (Phase != null ? Phase.GetHashCode() : 0);
                result = (result*397) ^ PhaseIndex;
                result = (result*397) ^ Ready.GetHashCode();
                result = (result*397) ^ (Size != null ? Size.GetHashCode() : 0);
                result = (result*397) ^ (Text != null ? Text.GetHashCode() : 0);
                return result;
            }
        }

        public static bool operator ==(Story left, Story right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Story left, Story right)
        {
            return !Equals(left, right);
        }
    }
}