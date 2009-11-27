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
    [XmlRoot("metrics")]
    [Serializable]
    public class Metrics : IEquatable<Metrics>
    {
        [XmlElement("cycleTime")]
        public string CycleTime { get; set; }

        [XmlElement("efficiency")]
        public string Efficiency { get; set; }

        [XmlElement("leadTime")]
        public string LeadTime { get; set; }

        [XmlElement("waitTime")]
        public string WaitTime { get; set; }

        [XmlElement("workTime")]
        public string WorkTime { get; set; }

        #region IEquatable<Metrics> Members

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.
        ///                 </param>
        public bool Equals(Metrics other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.CycleTime, CycleTime) && Equals(other.Efficiency, Efficiency) &&
                   Equals(other.LeadTime, LeadTime) && Equals(other.WaitTime, WaitTime) &&
                   Equals(other.WorkTime, WorkTime);
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
            if (obj.GetType() != typeof (Metrics)) return false;
            return Equals((Metrics) obj);
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
                int result = (CycleTime != null ? CycleTime.GetHashCode() : 0);
                result = (result*397) ^ (Efficiency != null ? Efficiency.GetHashCode() : 0);
                result = (result*397) ^ (LeadTime != null ? LeadTime.GetHashCode() : 0);
                result = (result*397) ^ (WaitTime != null ? WaitTime.GetHashCode() : 0);
                result = (result*397) ^ (WorkTime != null ? WorkTime.GetHashCode() : 0);
                return result;
            }
        }

        public static bool operator ==(Metrics left, Metrics right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Metrics left, Metrics right)
        {
            return !Equals(left, right);
        }
    }
}