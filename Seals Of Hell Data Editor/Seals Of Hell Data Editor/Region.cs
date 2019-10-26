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
        public string mEntryRoom { get; set; }
        public Dictionary<string, Room> mRooms { get; set; }
        public Region()
        {
            mName = "Default Name";
            mStory = "Default Story";
            mEntryRoom = "Default Entry Room";
            mRooms = new Dictionary<string, Room>();
            mRooms.Add(mEntryRoom, new Room());
            mRooms[mEntryRoom].mName = mEntryRoom;
        }
        public Region(string pEntryRoom)
        {
            mEntryRoom = pEntryRoom;
            mRooms = new Dictionary<string, Room>();
        }
    }
}
