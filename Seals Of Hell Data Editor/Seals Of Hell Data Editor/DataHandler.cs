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
        Dictionary<string, Room> mRooms;
        List<string> mAssignedRooms;
        Dictionary<PickableItem.Type, Dictionary<string,PickableItem>> mPickableItems;
        List<string> mAssignedGiveables;
        Dictionary<string, Collector> mCollectors;
        List<string> mAssignedCollectors;
        Dictionary<string, Enemy> mEnemies;
        List<string> mAssignedEnemies;
        Dictionary<string, KillZone> mKillZones;
        List<string> mAssignedKillZones;
        Dictionary<string, OneInteractionItem> mOIItems;
        List<string> mAssignedOIItems;
        void InitializeImpPrivMembers()
        {
            mRooms = new Dictionary<string, Room>();
            mAssignedRooms = new List<string>();
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
            mEnemies = new Dictionary<string, Enemy>();
            mAssignedEnemies = new List<string>();
            mKillZones = new Dictionary<string, KillZone>();
            mAssignedKillZones = new List<string>();
            mOIItems = new Dictionary<string, OneInteractionItem>();
            mAssignedOIItems = new List<string>();
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
        #region Room
        public List<string> GetRoomNames()
        {
            return new List<string>(mRooms.Keys);
        }
        public Room GetRoomObject(string pRoomName)
        {
            if (mRooms.ContainsKey(pRoomName))
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
            if (!mRooms.ContainsKey(pRoom.mName))
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
        #region Pickable Item
        public bool IsPickableItemPresent(string pName)
        {
            return mPickableItems[PickableItem.Type.Giveable].ContainsKey(pName) || mPickableItems[PickableItem.Type.Weapon].ContainsKey(pName)
                || mPickableItems[PickableItem.Type.Shield].ContainsKey(pName) || mPickableItems[PickableItem.Type.Wearable].ContainsKey(pName);
        }
        public List<string> GetPickableItemNames(PickableItem.Type pType)
        {
            return new List<string>(mPickableItems[pType].Keys);
        }
        public List<string> GetPickableItemNames()
        {
            List<string> aPickableItems = new List<string>();
            aPickableItems.AddRange(mPickableItems[PickableItem.Type.Giveable].Keys);
            aPickableItems.AddRange(mPickableItems[PickableItem.Type.Shield].Keys);
            aPickableItems.AddRange(mPickableItems[PickableItem.Type.Weapon].Keys);
            aPickableItems.AddRange(mPickableItems[PickableItem.Type.Weapon].Keys);
            return aPickableItems;
        }
        public PickableItem GetPickableItem(PickableItem.Type pType, string pName)
        {
            if(mPickableItems[pType].ContainsKey(pName))
            {
                return mPickableItems[pType][pName];
            }
            return null;
        }
        public PickableItem GetPickableItem(string pName)
        {
            if(mPickableItems[PickableItem.Type.Giveable].ContainsKey(pName))
            {
                return mPickableItems[PickableItem.Type.Giveable][pName];
            }
            else if(mPickableItems[PickableItem.Type.Shield].ContainsKey(pName))
            {
                return mPickableItems[PickableItem.Type.Shield][pName];
            }
            else if(mPickableItems[PickableItem.Type.Weapon].ContainsKey(pName))
            {
                return mPickableItems[PickableItem.Type.Weapon][pName];
            }
            else if(mPickableItems[PickableItem.Type.Wearable].ContainsKey(pName))
            {
                return mPickableItems[PickableItem.Type.Wearable][pName];
            }
            else
            {
                return null;
            }
        }
        public void DeletePickableItem(PickableItem.Type pType, string pName)
        {
            if(mPickableItems[pType].ContainsKey(pName))
            {
                mPickableItems[pType].Remove(pName);
            }
        }
        public void UpdatePickableName(List<string> pConditionalOf, string pNewName)
        {
            foreach(string aObjName in pConditionalOf)
            {
                
                if(mCollectors.ContainsKey(aObjName))
                {
                    mCollectors[aObjName].mConditionalObject = pNewName;
                }
                else if(mEnemies.ContainsKey(aObjName))
                {
                    mEnemies[aObjName].mConditionalObject = pNewName;
                }
                else if(mKillZones.ContainsKey(aObjName))
                {
                    mKillZones[aObjName].mConditionalObject = pNewName;
                }
                else if(mOIItems.ContainsKey(aObjName))
                {
                    mOIItems[aObjName].mConditionalObject = pNewName;
                }
                else if (mRegionDetails[mFirstRegion].mRooms[mRegionDetails[mFirstRegion].mEntryRoom].mTreasureCollector.mName == aObjName)
                {
                    mRegionDetails[mFirstRegion].mRooms[mRegionDetails[mFirstRegion].mEntryRoom].mTreasureCollector.mConditionalObject = pNewName;
                }
            }
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
        #region Enemy
        public List<string> GetEnemyNames()
        {
            return new List<string>(mEnemies.Keys);
        }
        public Enemy GetEnemyObject(string pEnemyName)
        {
            if (mEnemies.ContainsKey(pEnemyName))
            {
                return mEnemies[pEnemyName];
            }
            return null;
        }
        public bool IsEnemyAssigned(string pEnemyName)
        {
            return mAssignedEnemies.Contains(pEnemyName);
        }
        public void AddEnemy(Enemy pEnemy)
        {
            if (!mEnemies.ContainsKey(pEnemy.mName))
            {
                mEnemies.Add(pEnemy.mName, pEnemy);
            }
        }
        public bool IsEnemyPresent(string pEnemyName)
        {
            return mEnemies.ContainsKey(pEnemyName);
        }
        public void DeleteEnemy(string pEnemyName)
        {
            if (mEnemies.ContainsKey(pEnemyName))
            {
                mEnemies.Remove(pEnemyName);
            }
        }
        #endregion
        #region Kill Zone
        public List<string> GetKillZoneNames()
        {
            return new List<string>(mKillZones.Keys);
        }
        public KillZone GetKillZoneObject(string pKillZoneName)
        {
            if (mKillZones.ContainsKey(pKillZoneName))
            {
                return mKillZones[pKillZoneName];
            }
            return null;
        }
        public bool IsKillZoneAssigned(string pKillZoneName)
        {
            return mAssignedKillZones.Contains(pKillZoneName);
        }
        public void AddKillZone(KillZone pKillZone)
        {
            if (!mKillZones.ContainsKey(pKillZone.mName))
            {
                mKillZones.Add(pKillZone.mName, pKillZone);
            }
        }
        public bool IsKillZonePresent(string pKillZoneName)
        {
            return mKillZones.ContainsKey(pKillZoneName);
        }
        public void DeleteKillZone(string pKillZoneName)
        {
            if (mKillZones.ContainsKey(pKillZoneName))
            {
                mKillZones.Remove(pKillZoneName);
            }
        }
        #endregion
        #region One Interaction Items
        public List<string> GetOIItemNames()
        {
            return new List<string>(mOIItems.Keys);
        }
        public OneInteractionItem GetOIItemObject(string pOIItemName)
        {
            if (mOIItems.ContainsKey(pOIItemName))
            {
                return mOIItems[pOIItemName];
            }
            return null;
        }
        public bool IsOIItemAssigned(string pOIItemName)
        {
            return mAssignedOIItems.Contains(pOIItemName);
        }
        public void AddOIItem(OneInteractionItem pOIItem)
        {
            if (!mOIItems.ContainsKey(pOIItem.mName))
            {
                mOIItems.Add(pOIItem.mName, pOIItem);
            }
        }
        public bool IsOIItemPresent(string pOIItemName)
        {
            return mOIItems.ContainsKey(pOIItemName);
        }
        public void DeleteOIItem(string pOIItemName)
        {
            if (mOIItems.ContainsKey(pOIItemName))
            {
                mOIItems.Remove(pOIItemName);
            }
        }
        #endregion
    }
}
