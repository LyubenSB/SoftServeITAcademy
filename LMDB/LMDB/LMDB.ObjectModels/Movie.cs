using LMDB.ObjectModels.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMDB.ObjectModels.Models
{
    /// <summary>
    /// Class representing a movie object.
    /// </summary>
    public class Movie : IComparable<Movie>
    {
        public Movie()
        {
            this.Genre = new HashSet<string>();
            this.Actors = new HashSet<string>();
        }

        public int MovieID { get; set; }
        public string Title { get; set; }
        public ICollection<string> Genre { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public ICollection<string> Actors { get; set; }
        public int Year { get; set; }
        public bool IsNew { get; set; }

        public override string ToString()
        {
            return string.Format(@"
|| Title: {0}{6}
|| Genre: {1}
|| Description: {2}
|| Director: {3}
|| Actors: {4}
|| Year: {5}", this.Title, string.Join(", ",this.Genre), this.Description, this.Director, string.Join(", ", this.Actors), this.Year, this.IsNew == true ? "(NEW)": "");
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
