using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seals_Of_Hell_Data_Editor
{
    class Region
    {
        public string mName { get; set; }
        public string mStory { get; set; }
        public Dictionary<string, Room> mRooms { get; set; }
        public Region(string pNewRegion,string pNewStory = "")
        {
            mName = pNewRegion;
            mStory = pNewStory;
            mRooms = new Dictionary<string, Room>();
        }
    }
}
