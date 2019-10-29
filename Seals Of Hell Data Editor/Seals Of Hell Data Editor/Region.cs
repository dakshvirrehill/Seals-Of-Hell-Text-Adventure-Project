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
        public Region(bool pCreateEntryRoom)
        {
            if(pCreateEntryRoom)
            {
                mName = "Default Name";
                mStory = "Default Story";
                mEntryRoom = "Default Entry Room";
                mRooms = new Dictionary<string, Room>();
                mRooms.Add(mEntryRoom, new Room());
                mRooms[mEntryRoom].mName = mEntryRoom;
            }
        }
        public Region()
        {

        }
        public Region(string pEntryRoom)
        {
            mEntryRoom = pEntryRoom;
            mRooms = new Dictionary<string, Room>();
        }
        public bool IsRegionValid(bool pFirst = false)
        {
            bool aValidity = true;
            aValidity = aValidity && !string.IsNullOrEmpty(mName);
            if(!aValidity)
            {
                DataHandler.SetErrorMessage("Region has no name");
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mStory);
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("Region has no story");
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mEntryRoom);
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("Region has no entry room");
                return aValidity;
            }
            aValidity = aValidity && mRooms.ContainsKey(mEntryRoom);
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("Entry room not in rooms");
                return aValidity;
            }
            if(pFirst)
            {
                aValidity = aValidity && mRooms.Count == 1;
                if (!aValidity)
                {
                    DataHandler.SetErrorMessage("Only one room can be there in first region");
                    return aValidity;
                }
                aValidity = aValidity && mRooms[mEntryRoom].IsRoomValid(true, true);
                if (!aValidity)
                {
                    return aValidity;
                }
            }
            else
            {
                aValidity = aValidity && mRooms[mEntryRoom].IsRoomValid(true, false);
                if (!aValidity)
                {
                    return aValidity;
                }
                foreach(Room aRoom in mRooms.Values)
                {
                    if(aRoom.mName == mEntryRoom)
                    {
                        continue;
                    }
                    aValidity = aValidity && aRoom.IsRoomValid();
                    if (!aValidity)
                    {
                        return aValidity;
                    }
                }
            }
            return aValidity;
        }
    }
}
