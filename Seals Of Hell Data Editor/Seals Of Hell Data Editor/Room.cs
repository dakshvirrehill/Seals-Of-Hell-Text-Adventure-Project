using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seals_Of_Hell_Data_Editor
{
    class Room
    {
        public string mName;
        public string mStory;
        public string mRegion;
        public Room(string pName, string pRegion, string pStory = "")
        {
            mName = pName;
            mStory = pStory;
            mRegion = pRegion;
        }
    }
}
