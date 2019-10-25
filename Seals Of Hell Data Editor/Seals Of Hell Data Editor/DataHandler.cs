using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seals_Of_Hell_Data_Editor
{
    class DataHandler
    {
        public string mName { get; set; }
        public string mStory { get; set; }
        public string mFirstRegion { get; set; }
        public Dictionary<string, Region> mRegionDetails { get; set; }

        #region Private Members
        Dictionary<PickableItem.Type, Dictionary<string,PickableItem>> mPickableItems;
        List<string> mAssignedGiveables;
        Dictionary<string, Collector> mCollectors;
        List<string> mAssignedCollectors;
        Dictionary<string, Room> mRooms;
        List<string> mAssignedRooms;
        void InitializeImpPrivMembers()
        {
            mPickableItems = new Dictionary<PickableItem.Type, Dictionary<string, PickableItem>>
            {
                { PickableItem.Type.Weapon, new Dictionary<string,PickableItem>() },
                { PickableItem.Type.Shield, new Dictionary<string,PickableItem>() },
                { PickableItem.Type.Giveable, new Dictionary<string,PickableItem>() },
                { PickableItem.Type.Wearable, new Dictionary<string,PickableItem>() }
            };
            mAssignedGiveables = new List<string>();
            mCollectors = new Dictionary<string, Collector>();
            mAssignedCollectors = new List<string>();
            mRooms = new Dictionary<string, Room>();
            mAssignedRooms = new List<string>();
        }

        #endregion

        public DataHandler()
        {
            mName = "Default Game";
            mStory = "Default Story";
            mFirstRegion = "Default First Region";
            mRegionDetails = new Dictionary<string, Region>
            {
                { mFirstRegion, new Region() }
            };
            mRegionDetails[mFirstRegion].mName = mFirstRegion;

            InitializeImpPrivMembers();
        }
        
        #region Pickable Items
        public List<string> GetPickableItemNames(PickableItem.Type pType)
        {
            return new List<string>(mPickableItems[pType].Keys);
        }
        public PickableItem GetPickableItem(PickableItem.Type pType, string pName)
        {
            if(mPickableItems[pType].ContainsKey(pName))
            {
                return mPickableItems[pType][pName];
            }
            return null;
        }
        #region Giveable Pickable Item
        public void AssignGivable(string pGiveableName)
        {
            if(!mAssignedGiveables.Contains(pGiveableName))
            {
                mAssignedGiveables.Add(pGiveableName);
            }
        }
        public void UnAssignGivable(string pGiveableName)
        {
            if(mAssignedGiveables.Contains(pGiveableName))
            {
                mAssignedGiveables.Remove(pGiveableName);
            }
        }
        public bool IsGivableAssigned(string pGiveableName)
        {
            return mAssignedGiveables.Contains(pGiveableName);
        }
        #endregion
        #endregion
        #region Collector
        public List<string> GetCollectorNames()
        {
            return new List<string>(mCollectors.Keys);
        }
        public Collector GetCollectorObject(string pCollectorName)
        {
            if(mCollectors.ContainsKey(pCollectorName))
            {
                return mCollectors[pCollectorName];
            }
            return null;
        }
        public bool IsCollectorAssigned(string pCollectorName)
        {
            return mAssignedCollectors.Contains(pCollectorName);
        }
        public void AddCollector(Collector pCollector)
        {
            if(!mCollectors.ContainsKey(pCollector.mName))
            {
                mCollectors.Add(pCollector.mName, pCollector);
            }
        }
        public bool IsCollectorPresent(string pCollectorName)
        {
            return mCollectors.ContainsKey(pCollectorName);
        }
        public void DeleteCollector(string pCollectorName)
        {
            if(mCollectors.ContainsKey(pCollectorName))
            {
                mCollectors.Remove(pCollectorName);
            }
        }
        #endregion
        #region Room
        public List<string> GetRoomNames()
        {
            return new List<string>(mRooms.Keys);
        }
        public Room GetRoomObject(string pRoomName)
        {
            if(mRooms.ContainsKey(pRoomName))
            {
                return mRooms[pRoomName];
            }
            return null;
        }
        public bool IsRoomAssigned(string pRoomName)
        {
            return mAssignedRooms.Contains(pRoomName);
        }
        public void AddRoom(Room pRoom)
        {
            if(!mRooms.ContainsKey(pRoom.mName))
            {
                mRooms.Add(pRoom.mName, pRoom);
            }
        }
        public bool IsRoomPresent(string pRoomName)
        {
            return mRooms.ContainsKey(pRoomName);
        }
        public void DeleteRoom(string pRoomName)
        {
            mRooms.Remove(pRoomName);
        }
        #endregion
    }
}
