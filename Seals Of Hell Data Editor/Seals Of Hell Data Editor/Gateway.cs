using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seals_Of_Hell_Data_Editor
{
    class Gateway
    {
        public enum Direction
        {
            North,
            South,
            East,
            West,
            NorthEast,
            NorthWest,
            SouthEast,
            SouthWest
        }
        public enum Path
        {
            North_South,
            East_West,
            NorthEast_SouthWest,
            NorthWest_SouthEast
        }
        public bool mIsVisible { get; set; }
        public bool mIsInteractable { get; set; }
        public string mName { get; set; }
        public string mStory { get; set; }
        public Path mPath { get; set; }
        public string mRoom1 { get; set; }
        public string mRoom2 { get; set; }
    }
}
