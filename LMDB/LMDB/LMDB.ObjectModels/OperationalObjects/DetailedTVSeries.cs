using LMDB.ObjectModels.Contracts;
using LMDB.ObjectModels.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ObjectModels.OperationalObjects
{
    public class DetailedTVSeries : IComparable<DetailedTVSeries>, IMotionPictureData
    {
        public DetailedTVSeries()
        {
            this.Genres = new List<Genre>();
            this.Networks = new List<Networks>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<Genre> Genres { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int NumberOfSeasons { get; set; }

        public int NumberOfEpisodes { get; set; }

        public string Overview { get; set; }

        public string Rating { get; set; }

        public string Status { get; set; }

        public ICollection<Networks> Networks { get; set; }

        public override string ToString()
        {
            return string.Format(@"
|| ID: {0}
|| Title: {1}
|| Genres: {2}
|| Release Date: {3}
|| Rating: {4}
|| Networks Aired On: {5}
|| Number Of Episodes: {6}
|| Number Of Seasons: {7}
|| Status: {8}
|| Overview: {9}", this.Id, this.Title, string.Join(", ", this.Genres), this.ReleaseDate.Date.ToShortDateString(), this.Rating,string.Join(", ",this.Networks), this.NumberOfEpisodes, this.NumberOfSeasons,this.Status, this.Overview);
        }



        /// <summary>
        /// Implemented comparer for proper addition in the SortedSet collection.
        /// Objects are compared by "Title" property.
        /// </summary>
        /// <param name="other">movie to be compared</param>
        /// <returns>integer</returns>
        public int CompareTo(DetailedTVSeries other)
        {
            int result = this.Title.CompareTo(other.Title);

            return result;
        }
    }
}
