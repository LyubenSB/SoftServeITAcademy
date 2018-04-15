using LMDB.ObjectModels.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ObjectModels.OperationalObjects
{
    public class Movie : IComparable<Movie>, IMotionPictureData
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return string.Format(@"
|| ID: {0}
|| Title: {1}
|| Year: {2}
|| Description: {3}
", this.Id, this.Title, this.ReleaseDate.ToString(), this.Description);
        }

        /// <summary>
        /// Implemented comparer for proper addition in the SortedSet collection.
        /// Objects are compared by "Title" property.
        /// </summary>
        /// <param name="other">movie to be compared</param>
        /// <returns>integer</returns>
        public int CompareTo(Movie other)
        {
            int result = this.Title.CompareTo(other.Title);

            return result;
        }

    }
}
