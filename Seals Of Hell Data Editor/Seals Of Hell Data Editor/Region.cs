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
            mRooms = new Dictionary<string, Room>();
        }

        public void AddDefaultRoom()
        {
            mEntryRoom = mName + "_Default";
            mRooms.Add(mEntryRoom, new Room());
            mRooms[mEntryRoom].mName = "Default";
            mRooms[mEntryRoom].mRegion = mName;
            mRooms[mEntryRoom].mStory = "This is default entry room story";
        }
    }
}
