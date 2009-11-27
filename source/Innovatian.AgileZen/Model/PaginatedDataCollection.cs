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
    [Serializable]
    public abstract class PaginatedDataCollection : IEquatable<PaginatedDataCollection>
    {
        [XmlElement("page")]
        public int Page { get; set; }

        [XmlElement("pageSize")]
        public int PageSize { get; set; }

        [XmlElement("totalItems")]
        public int TotalItems { get; set; }

        [XmlElement("totalPages")]
        public int TotalPages { get; set; }

        #region IEquatable<PaginatedDataCollection> Members

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.
        ///                 </param>
        public bool Equals(PaginatedDataCollection other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Page == Page && other.PageSize == PageSize && other.TotalItems == TotalItems &&
                   other.TotalPages == TotalPages;
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
            if (obj.GetType() != typeof (PaginatedDataCollection)) return false;
            return Equals((PaginatedDataCollection) obj);
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
                int result = Page;
                result = (result*397) ^ PageSize;
                result = (result*397) ^ TotalItems;
                result = (result*397) ^ TotalPages;
                return result;
            }
        }

        public static bool operator ==(PaginatedDataCollection left, PaginatedDataCollection right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PaginatedDataCollection left, PaginatedDataCollection right)
        {
            return !Equals(left, right);
        }
    }
}