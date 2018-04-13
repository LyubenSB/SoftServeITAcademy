using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ObjectModels.OperationalObjects
{
    public class NonDetailMovie : IComparable<NonDetailMovie>
    {
        public NonDetailMovie()
        {

        }

        public int MovieID { get; set; }
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return string.Format(@"
|| Title: {0}
|| Year: {2}
|| Description: {1}
}", this.Title, this.Description, this.ReleaseDate);
        }

        /// <summary>
        /// Implemented comparer for proper addition in the SortedSet collection.
        /// Objects are compared by "Title" property.
        /// </summary>
        /// <param name="other">movie to be compared</param>
        /// <returns>integer</returns>
        public int CompareTo(NonDetailMovie other)
        {
            int result = this.Title.CompareTo(other.Title);

            return result;
        }

    }
}
