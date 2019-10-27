using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Seals_Of_Hell_Data_Editor
{
    public enum ObjectType
    {
        Region,
        Room,
        TreasureCollector,
        Collector,
        Enemy,
        Gateway,
        KillZone,
        OneInteractionItem,
        PickableItem,
        Portal
    }
    class DataHandler
    {
        public string mName { get; set; }
        public string mStory { get; set; }
        public string mFirstRegion { get; set; }
        public Dictionary<string, Region> mRegionDetails { get; set; }

        #region Private Members
        static DataHandler mInstance; //for validity checks
        Dictionary<string, Room> mRooms;
        List<string> mAssignedRooms;
        Dictionary<PickableItem.Type, Dictionary<string,PickableItem>> mPickableItems;
        List<string> mAssignedPickables;
        List<string> mAssignedGiveables;
        Dictionary<string, Collector> mCollectors;
        List<string> mAssignedCollectors;
        Dictionary<string, Enemy> mEnemies;
        List<string> mAssignedEnemies;
        Dictionary<string, KillZone> mKillZones;
        List<string> mAssignedKillZones;
        Dictionary<string, OneInteractionItem> mOIItems;
        List<string> mAssignedOIItems;
        Dictionary<string, Portal> mPortals;
        Dictionary<string, Gateway> mGateways;
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
            mAssignedPickables = new List<string>();
            mAssignedGiveables = new List<string>();
            mCollectors = new Dictionary<string, Collector>();
            mAssignedCollectors = new List<string>();
            mEnemies = new Dictionary<string, Enemy>();
            mAssignedEnemies = new List<string>();
            mKillZones = new Dictionary<string, KillZone>();
            mAssignedKillZones = new List<string>();
            mOIItems = new Dictionary<string, OneInteractionItem>();
            mAssignedOIItems = new List<string>();
            mPortals = new Dictionary<string, Portal>();
            mGateways = new Dictionary<string, Gateway>();
            if(mInstance == null)
            {
                mInstance = this;
            }
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
            mRegionDetails[mFirstRegion].mRooms[mRegionDetails[mFirstRegion].mEntryRoom].mTreasureCollector = new TreasureCollector();
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
        public void UnAssignRoom(string pRoomName)
        {
            if(mAssignedRooms.Contains(pRoomName))
            {
                mAssignedRooms.Remove(pRoomName);
            }
        }
        public void AssignRoom(string pRoomName)
        {
            if(!mAssignedRooms.Contains(pRoomName))
            {
                mAssignedRooms.Add(pRoomName);
            }
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
            Room aRoom = mRooms[pRoomName];
            if(aRoom  != null)
            {
                mRooms.Remove(pRoomName);
                List<string> aObjs = new List<string>(aRoom.mCollectors.Keys);
                UnAssignListOfObjects(ObjectType.Collector, aObjs);
                aObjs = new List<string>(aRoom.mEnemies.Keys);
                UnAssignListOfObjects(ObjectType.Enemy, aObjs);
                aObjs = new List<string>(aRoom.mKillZones.Keys);
                UnAssignListOfObjects(ObjectType.KillZone, aObjs);
                aObjs = new List<string>(aRoom.mOneInteractionItems.Keys);
                UnAssignListOfObjects(ObjectType.OneInteractionItem, aObjs);
                aObjs = new List<string>(aRoom.mPickableItems.Keys);
                UnAssignListOfObjects(ObjectType.PickableItem, aObjs);
            }
            
        }
        #endregion
        #region Interactables
        public bool IsObjectAssigned(ObjectType pType, string pName)
        {
            switch (pType)
            {
                case ObjectType.Collector:
                    return mAssignedCollectors.Contains(pName);
                case ObjectType.Enemy:
                    return mAssignedEnemies.Contains(pName);
                case ObjectType.KillZone:
                    return mAssignedKillZones.Contains(pName);
                case ObjectType.OneInteractionItem:
                    return mAssignedOIItems.Contains(pName);
                case ObjectType.PickableItem:
                    return mAssignedPickables.Contains(pName);
            }
            return false;
        }
        public void UnAssignObject(ObjectType pType, string pName)
        {
            switch (pType)
            {
                case ObjectType.Collector:
                    if (mAssignedCollectors.Contains(pName))
                    {
                        mCollectors[pName].SetInRoom("");
                        mAssignedCollectors.Remove(pName);
                    }
                    break;
                case ObjectType.Enemy:
                    if (mAssignedEnemies.Contains(pName))
                    {
                        mEnemies[pName].SetInRoom("");
                        mAssignedEnemies.Remove(pName);
                    }
                    break;
                case ObjectType.KillZone:
                    if (mAssignedKillZones.Contains(pName))
                    {
                        mKillZones[pName].SetInRoom("");
                        mAssignedKillZones.Remove(pName);
                    }
                    break;
                case ObjectType.OneInteractionItem:
                    if (mAssignedOIItems.Contains(pName))
                    {
                        mOIItems[pName].SetInRoom("");
                        mAssignedOIItems.Remove(pName);
                    }
                    break;
                case ObjectType.PickableItem:
                    if (mAssignedPickables.Contains(pName))
                    {
                        GetPickableItem(pName).SetInRoom("");
                        mAssignedPickables.Remove(pName);
                    }
                    break;
            }
        }
        public void UnAssignListOfObjects(ObjectType pType, List<string> pNames)
        {
            foreach(string aName in pNames)
            {
                UnAssignObject(pType, aName);
            }
        }
        public void AssignObject(ObjectType pType, string pName)
        {
            switch (pType)
            {
                case ObjectType.Collector:
                    if (!mAssignedCollectors.Contains(pName))
                    {
                        mAssignedCollectors.Add(pName);
                    }
                    break;
                case ObjectType.Enemy:
                    if (!mAssignedEnemies.Contains(pName))
                    {
                        mAssignedEnemies.Add(pName);
                    }
                    break;
                case ObjectType.KillZone:
                    if (!mAssignedKillZones.Contains(pName))
                    {
                        mAssignedKillZones.Add(pName);
                    }
                    break;
                case ObjectType.OneInteractionItem:
                    if (!mAssignedOIItems.Contains(pName))
                    {
                        mAssignedOIItems.Add(pName);
                    }
                    break;
                case ObjectType.PickableItem:
                    if (!mAssignedPickables.Contains(pName))
                    {
                        mAssignedPickables.Add(pName);
                    }
                    break;
            }
        }
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
            aPickableItems.AddRange(mPickableItems[PickableItem.Type.Wearable].Keys);
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
        public void AddPickable(PickableItem pItem)
        {
            if(!mPickableItems[pItem.mType].ContainsKey(pItem.mName))
            {
                mPickableItems[pItem.mType].Add(pItem.mName, pItem);
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
        #endregion
        #region Region
        public void AddPortal(Portal pRegionPortal)
        {
            if(!mPortals.ContainsKey(pRegionPortal.mName))
            {
                mPortals.Add(pRegionPortal.mName, pRegionPortal);
            }
        }
        public void DeletePortal(string pRegionName)
        {
            if(mPortals.ContainsKey(pRegionName))
            {
                mPortals.Remove(pRegionName);
            }
        }
        public Portal GetRegionPortal(string pRegionName)
        {
            if(mPortals.ContainsKey(pRegionName))
            {
                return mPortals[pRegionName];
            }
            return null;
        }
        public Gateway GetGatewayObject(string pGatewayName)
        {
            if(mGateways.ContainsKey(pGatewayName))
            {
                return mGateways[pGatewayName];
            }
            return null;
        }
        public void DeleteGateway(string pGatewayName)
        {
            if(mGateways.ContainsKey(pGatewayName))
            {
                mGateways.Remove(pGatewayName);
            }
        }
        public void AddGateway(Gateway pGateway)
        {
            if(!mGateways.ContainsKey(pGateway.mName))
            {
                mGateways.Add(pGateway.mName,pGateway);
            }
        }
        public bool IsGatewayPresent(string pGatewayName)
        {
            return mGateways.ContainsKey(pGatewayName);
        }
        #endregion
        public bool IsDataValid()
        {
            bool aValidity = true;
            aValidity = aValidity && !string.IsNullOrEmpty(mName);
            if(!aValidity)
            {
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mStory);
            if (!aValidity)
            {
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mFirstRegion);
            if (!aValidity)
            {
                return aValidity;
            }
            aValidity = aValidity && mRegionDetails.ContainsKey(mFirstRegion);
            if (!aValidity)
            {
                return aValidity;
            }
            aValidity = aValidity && mRegionDetails[mFirstRegion].IsRegionValid(true);
            if (!aValidity)
            {
                return aValidity;
            }
            aValidity = aValidity && mRegionDetails[mFirstRegion].mRooms[mRegionDetails[mFirstRegion].mEntryRoom].mPortals.Count == (mRegionDetails.Count-1);
            if (!aValidity)
            {
                return aValidity;
            }
            foreach (Region aRegion in mRegionDetails.Values)
            {
                if(aRegion.mName == mFirstRegion)
                {
                    continue;
                }
                aValidity = aValidity && aRegion.IsRegionValid();
                if (!aValidity)
                {
                    return aValidity;
                }
            }
            return aValidity;
        }
        public string ConvertDataToJSON()
        {
            try
            {
                string aJSON = "";
                return aJSON;
            }
            catch(Exception aE)
            {
                Console.WriteLine(aE.StackTrace);
                return null;
            }
        }

        public void ConvertFromJSON(string pJSON)
        {

        }

        public static bool IsConditionalPresent(string pConditional)
        {
            return mInstance.IsPickableItemPresent(pConditional);
        }

        public static bool AreUpdatablesInSameRoom(string pRoomName, List<string> pUpdatables)
        {
            return mInstance.GetRoomObject(pRoomName).AreObjectsInRoom(pUpdatables);
        }

    }
}
