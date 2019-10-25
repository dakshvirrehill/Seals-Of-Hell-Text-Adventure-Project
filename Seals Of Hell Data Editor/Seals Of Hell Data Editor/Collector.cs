using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seals_Of_Hell_Data_Editor
{
    class Collector : Updater
    {
        public string mName { get; set; }
        public string mStory { get; set; }
        public PickableItem mCollectionObject { get; set; }
        public string mUpdateStory { get; set; }
        public string mEndStory { get; set; }
        public bool mIsVisible { get; set; }
        public bool mIsInteractable { get; set; }
        public List<string> mUpdatables { get; set; }
        string mInRoom;
        public Collector()
        {
            mUpdatables = new List<string>();
        }

        public void SetInRoom(string pRoom)
        {
            mInRoom = pRoom;
        }
        
        public string GetInRoom()
        {
            return mInRoom;
        }

        public bool IsInRoom()
        {
            return !string.IsNullOrEmpty(mInRoom);
        }

    }
}
