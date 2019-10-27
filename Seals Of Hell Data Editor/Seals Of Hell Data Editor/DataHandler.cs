﻿using System;
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
        string mErrorMessage = "";
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
            mRegionDetails[mFirstRegion].mRooms[mRegionDetails[mFirstRegion].mEntryRoom].mTreasureCollector.SetInRoom(mRegionDetails[mFirstRegion].mEntryRoom);
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
        public string GetObjectType(string pName)
        {
            if(mCollectors.ContainsKey(pName))
            {
                return "Collector";
            }
            if(mEnemies.ContainsKey(pName))
            {
                return "Enemy";
            }
            if(mGateways.ContainsKey(pName))
            {
                return "Gateway";
            }
            if(mKillZones.ContainsKey(pName))
            {
                return "KillZone";
            }
            if(mOIItems.ContainsKey(pName))
            {
                return "OneInteractionItem";
            }
            if(mPickableItems[PickableItem.Type.Giveable].ContainsKey(pName) ||
                mPickableItems[PickableItem.Type.Shield].ContainsKey(pName) ||
                mPickableItems[PickableItem.Type.Weapon].ContainsKey(pName) ||
                mPickableItems[PickableItem.Type.Wearable].ContainsKey(pName))
            {
                return "PickableItem";
            }
            foreach(Portal aPortal in mPortals.Values)
            {
                if(aPortal.mName == pName)
                {
                    return "Portal";
                }
            }
            return null;
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
                SetErrorMessage("Game Name not set");
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mStory);
            if (!aValidity)
            {
                SetErrorMessage("Game Story not set");
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mFirstRegion);
            if (!aValidity)
            {
                SetErrorMessage("First Region not set");
                return aValidity;
            }
            aValidity = aValidity && mRegionDetails.ContainsKey(mFirstRegion);
            if (!aValidity)
            {
                SetErrorMessage("First Region not in All regions");
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
                SetErrorMessage("First room doesn't have all portals");
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
            aValidity = aValidity && mPickableItems[PickableItem.Type.Shield].Count >= 1;
            if(!aValidity)
            {
                SetErrorMessage("Game Has No Shield Object");
                return aValidity;
            }
            mErrorMessage = "";
            return aValidity;
        }
        Dictionary<string,string> GetUpdatableObjectsWithType(List<string> pUpdatableObjects,string pRoomKey,string pRegionKey)
        {
            Dictionary<string, string> aUpdtObjWType = new Dictionary<string, string>();
            foreach (string aObjName in pUpdatableObjects)
            {
                string aType = GetObjectType(aObjName);
                if (aType != null)
                {
                    if(aType.Equals("Gateway"))
                    {
                        aUpdtObjWType.Add(pRegionKey + "_" + aObjName, aType);
                    }
                    else if(aType.Equals("Portal"))
                    {
                        aUpdtObjWType.Add(aObjName, aType);
                    }
                    else
                    {
                        aUpdtObjWType.Add(pRoomKey + "_" + aObjName, aType);
                    }
                }
            }
            return aUpdtObjWType;
        }
        public string ConvertDataToJSON()
        {
            try
            {
                string aJSON = "";
                DataHandler mGameDetails = new DataHandler();
                mGameDetails.mName = mName;
                mGameDetails.mStory = mStory;
                mGameDetails.mFirstRegion = mFirstRegion;
                mGameDetails.mRegionDetails = new Dictionary<string, Region>();
                Dictionary<string, Portal> aPortals = new Dictionary<string, Portal>();
                Dictionary<string, Gateway> aGateway = new Dictionary<string, Gateway>();
                foreach(Region aCurrentRegion in mRegionDetails.Values)
                {
                    mGameDetails.mRegionDetails.Add(aCurrentRegion.mName, new Region());
                    Region aJSONRegion = mGameDetails.mRegionDetails[aCurrentRegion.mName];
                    aJSONRegion.mName = aCurrentRegion.mName;
                    aJSONRegion.mStory = aCurrentRegion.mStory;
                    aJSONRegion.mEntryRoom = aCurrentRegion.mName + "_" + aCurrentRegion.mEntryRoom;
                    aJSONRegion.mRooms = new Dictionary<string, Room>();
                    foreach(Room aCurrentRoom in aCurrentRegion.mRooms.Values)
                    {
                        string aRoomKey = aCurrentRegion.mName + "_" + aCurrentRoom.mName;
                        aJSONRegion.mRooms.Add(aRoomKey, new Room());
                        Room aJSONRoom = aJSONRegion.mRooms[aRoomKey];
                        aJSONRoom.mName = aCurrentRoom.mName;
                        aJSONRoom.mStory = aCurrentRoom.mStory;
                        if(aRoomKey == aJSONRegion.mEntryRoom && aJSONRegion.mName == mGameDetails.mFirstRegion)
                        {
                            aJSONRoom.mTreasureCollector = new TreasureCollector();
                            aJSONRoom.mTreasureCollector.mKey = aRoomKey + "_" + aCurrentRoom.mTreasureCollector.mName;
                            aJSONRoom.mTreasureCollector.mName = aCurrentRoom.mTreasureCollector.mName;
                            aJSONRoom.mTreasureCollector.mStory = aCurrentRoom.mTreasureCollector.mStory;
                            aJSONRoom.mTreasureCollector.mIsVisible = aCurrentRoom.mTreasureCollector.mIsVisible;
                            aJSONRoom.mTreasureCollector.mIsInteractable = aCurrentRoom.mTreasureCollector.mIsInteractable;
                            aJSONRoom.mTreasureCollector.mUpdateStory = aCurrentRoom.mTreasureCollector.mUpdateStory;
                            aJSONRoom.mTreasureCollector.mEndStory = aCurrentRoom.mTreasureCollector.mEndStory;
                            aJSONRoom.mTreasureCollector.mConditionalObject = null;
                            aJSONRoom.mTreasureCollector.mUpdatableObjects = null;
                            if(aCurrentRoom.mTreasureCollector.mUpdatableObjects.Count > 0)
                            {
                                aJSONRoom.mTreasureCollector.mUpdatableObjectsWithType = GetUpdatableObjectsWithType(aCurrentRoom.mTreasureCollector.mUpdatableObjects, aRoomKey, mGameDetails.mFirstRegion);
                            }
                            aJSONRoom.mTreasureCollector.mTreasures = new List<string>();
                            foreach(string aObjName in aCurrentRoom.mTreasureCollector.mTreasures)
                            {
                                PickableItem aItem = GetPickableItem(aObjName);
                                if(aItem != null)
                                {
                                    Room aRoom = GetRoomObject(aItem.GetInRoom());
                                    if(aRoom != null)
                                    {
                                        aJSONRoom.mTreasureCollector.mTreasures.Add(aRoom.GetInRegion() + "_" + aRoom.mName + "_" + aObjName);
                                    }
                                }
                            }
                            aJSONRoom.mPortals = new Dictionary<string, Portal>();
                            foreach (Portal aCurrentPortal in aCurrentRoom.mPortals.Values)
                            {
                                string aPortalKey = aCurrentPortal.mName;
                                aJSONRoom.mPortals.Add(aPortalKey, new Portal(aCurrentPortal.mCurrentRegionName));
                                aJSONRoom.mPortals[aPortalKey].mName = aCurrentPortal.mName;
                                aJSONRoom.mPortals[aPortalKey].mStory = aCurrentPortal.mStory;
                                aJSONRoom.mPortals[aPortalKey].mCurrentRegionName = null;
                                aJSONRoom.mPortals[aPortalKey].mActiveRegion = mGameDetails.mFirstRegion;
                                aJSONRoom.mPortals[aPortalKey].mConnectedRegion = aCurrentPortal.mCurrentRegionName;
                            }
                            aPortals = aJSONRoom.mPortals;
                            aJSONRoom.mGateways = null;
                        }
                        else
                        {
                            aJSONRoom.mTreasureCollector = null;
                            if (aCurrentRoom.mPortals.Count > 0)
                            {
                                aJSONRoom.mPortals = new Dictionary<string, Portal>();
                                foreach (string aCurrentPortal in aCurrentRoom.mPortals.Keys)
                                {
                                    aJSONRoom.mPortals.Add(aCurrentPortal, aPortals[aCurrentPortal]);
                                }
                            }
                            else
                            {
                                aJSONRoom.mPortals = null;
                            }
                            aJSONRoom.mGateways = new Dictionary<string, Gateway>();
                            foreach(Gateway aCurrentGateway in aCurrentRoom.mGateways.Values)
                            {
                                string aGatewayKey = aJSONRegion.mName + "_" + aCurrentGateway.mName;
                                if(!aGateway.ContainsKey(aGatewayKey))
                                {
                                    aGateway.Add(aGatewayKey, new Gateway());
                                    aGateway[aGatewayKey].mName = aCurrentGateway.mName;
                                    aGateway[aGatewayKey].mStory = aCurrentGateway.mStory;
                                    aGateway[aGatewayKey].mIsInteractable = aCurrentGateway.mIsInteractable;
                                    aGateway[aGatewayKey].mIsVisible = aCurrentGateway.mIsVisible;
                                    aGateway[aGatewayKey].mPath = aCurrentGateway.mPath;
                                    aGateway[aGatewayKey].mRoom1 = aCurrentGateway.mRoom1;
                                    aGateway[aGatewayKey].mRoom2 = aCurrentGateway.mRoom2;
                                }
                                aJSONRoom.mGateways.Add(aGatewayKey, aGateway[aGatewayKey]);
                            }
                        }
                        aJSONRoom.mCollectors = null;
                        aJSONRoom.mEnemies = null;
                        aJSONRoom.mKillZones = null;
                        aJSONRoom.mOneInteractionItems = null;
                        aJSONRoom.mPickableItems = null;
                        if(aCurrentRoom.mCollectors.Count > 0)
                        {
                            aJSONRoom.mCollectors = new Dictionary<string, Collector>();
                            foreach (Collector aCurrentCollector in aCurrentRoom.mCollectors.Values)
                            {
                                PickableItem aItem = GetPickableItem(PickableItem.Type.Giveable,aCurrentCollector.mConditionalObject);
                                if (aItem != null)
                                {
                                    Room aRoom = GetRoomObject(aItem.GetInRoom());
                                    if (aRoom != null)
                                    {
                                        string aCollectorKey = aRoomKey + "_" + aCurrentCollector.mName;
                                        aJSONRoom.mCollectors.Add(aCollectorKey, new Collector());
                                        aJSONRoom.mCollectors[aCollectorKey].mName = aCurrentCollector.mName;
                                        aJSONRoom.mCollectors[aCollectorKey].mStory = aCurrentCollector.mStory;
                                        aJSONRoom.mCollectors[aCollectorKey].mUpdateStory = aCurrentCollector.mUpdateStory;
                                        aJSONRoom.mCollectors[aCollectorKey].mEndStory = aCurrentCollector.mEndStory;
                                        aJSONRoom.mCollectors[aCollectorKey].mIsInteractable = aCurrentCollector.mIsInteractable;
                                        aJSONRoom.mCollectors[aCollectorKey].mIsVisible = aCurrentCollector.mIsVisible;
                                        aJSONRoom.mCollectors[aCollectorKey].mConditionalObject = aRoom.GetInRegion() + "_" + aRoom.mName + "_" + aCurrentCollector.mConditionalObject;
                                        aJSONRoom.mCollectors[aCollectorKey].mUpdatableObjectsWithType = GetUpdatableObjectsWithType(aCurrentCollector.mUpdatableObjects, aRoomKey, aJSONRegion.mName);
                                    }
                                }
                            }
                        }
                        if(aCurrentRoom.mEnemies.Count > 0)
                        {
                            aJSONRoom.mEnemies = new Dictionary<string, Enemy>();
                            foreach (Enemy aCurentEnemy in aCurrentRoom.mEnemies.Values)
                            {
                                PickableItem aItem = GetPickableItem(PickableItem.Type.Weapon, aCurentEnemy.mConditionalObject);
                                if (aItem != null)
                                {
                                    Room aRoom = GetRoomObject(aItem.GetInRoom());
                                    if (aRoom != null)
                                    {
                                        string aEnemyKey = aRoomKey + "_" + aCurentEnemy.mName;
                                        aJSONRoom.mEnemies.Add(aEnemyKey, new Enemy());
                                        aJSONRoom.mEnemies[aEnemyKey].mName = aCurentEnemy.mName;
                                        aJSONRoom.mEnemies[aEnemyKey].mStory = aCurentEnemy.mStory;
                                        aJSONRoom.mEnemies[aEnemyKey].mBlockStory = aCurentEnemy.mBlockStory;
                                        aJSONRoom.mEnemies[aEnemyKey].mLife = aCurentEnemy.mLife;
                                        aJSONRoom.mEnemies[aEnemyKey].mUpdateStory = aCurentEnemy.mUpdateStory;
                                        aJSONRoom.mEnemies[aEnemyKey].mEndStory = aCurentEnemy.mEndStory;
                                        aJSONRoom.mEnemies[aEnemyKey].mIsInteractable = aCurentEnemy.mIsInteractable;
                                        aJSONRoom.mEnemies[aEnemyKey].mIsVisible = aCurentEnemy.mIsVisible;
                                        aJSONRoom.mEnemies[aEnemyKey].mConditionalObject = aRoom.GetInRegion() + "_" + aRoom.mName + "_" + aCurentEnemy.mConditionalObject;
                                        aJSONRoom.mEnemies[aEnemyKey].mUpdatableObjectsWithType = GetUpdatableObjectsWithType(aCurentEnemy.mUpdatableObjects, aRoomKey, aJSONRegion.mName);
                                    }
                                }
                            }
                        }
                        if(aCurrentRoom.mKillZones.Count > 0)
                        {
                            aJSONRoom.mKillZones = new Dictionary<string, KillZone>();
                            foreach (KillZone aCurrentKillZone in aCurrentRoom.mKillZones.Values)
                            {
                                string aKillZoneKey = aRoomKey + "_" + aCurrentKillZone.mName;
                                aJSONRoom.mKillZones.Add(aKillZoneKey, new KillZone());
                                aJSONRoom.mKillZones[aKillZoneKey].mName = aCurrentKillZone.mName;
                                aJSONRoom.mKillZones[aKillZoneKey].mStory = aCurrentKillZone.mStory;
                                aJSONRoom.mKillZones[aKillZoneKey].mUpdateStory = aCurrentKillZone.mUpdateStory;
                                aJSONRoom.mKillZones[aKillZoneKey].mEndStory = aCurrentKillZone.mEndStory;
                                aJSONRoom.mKillZones[aKillZoneKey].mIsInteractable = aCurrentKillZone.mIsInteractable;
                                aJSONRoom.mKillZones[aKillZoneKey].mIsVisible = aCurrentKillZone.mIsVisible;
                                aJSONRoom.mKillZones[aKillZoneKey].mUpdatableObjectsWithType = GetUpdatableObjectsWithType(aCurrentKillZone.mUpdatableObjects, aRoomKey, aJSONRegion.mName);
                                if(string.IsNullOrEmpty(aCurrentKillZone.mConditionalObject))
                                {
                                    aJSONRoom.mKillZones[aKillZoneKey].mConditionalObject = null;
                                }
                                else
                                {
                                    PickableItem aItem = GetPickableItem(aCurrentKillZone.mConditionalObject);
                                    if (aItem != null)
                                    {
                                        Room aRoom = GetRoomObject(aItem.GetInRoom());
                                        if (aRoom != null)
                                        {
                                            aJSONRoom.mKillZones[aKillZoneKey].mConditionalObject = aRoom.GetInRegion() + "_" + aRoom.mName + "_" + aCurrentKillZone.mConditionalObject;
                                        }
                                    }
                                }
                            }
                        }
                        if(aCurrentRoom.mOneInteractionItems.Count > 0)
                        {
                            aJSONRoom.mOneInteractionItems = new Dictionary<string, OneInteractionItem>();
                            foreach (OneInteractionItem aCurrentOII in aCurrentRoom.mOneInteractionItems.Values)
                            {
                                string aOIIKey = aRoomKey + "_" + aCurrentOII.mName;
                                aJSONRoom.mOneInteractionItems.Add(aOIIKey, new OneInteractionItem());
                                aJSONRoom.mOneInteractionItems[aOIIKey].mName = aCurrentOII.mName;
                                aJSONRoom.mOneInteractionItems[aOIIKey].mStory = aCurrentOII.mStory;
                                aJSONRoom.mOneInteractionItems[aOIIKey].mType = aCurrentOII.mType;
                                aJSONRoom.mOneInteractionItems[aOIIKey].mUpdateStory = aCurrentOII.mUpdateStory;
                                aJSONRoom.mOneInteractionItems[aOIIKey].mEndStory = aCurrentOII.mEndStory;
                                aJSONRoom.mOneInteractionItems[aOIIKey].mIsInteractable = aCurrentOII.mIsInteractable;
                                aJSONRoom.mOneInteractionItems[aOIIKey].mIsVisible = aCurrentOII.mIsVisible;
                                aJSONRoom.mOneInteractionItems[aOIIKey].mConditionalObject = null;
                                if(aCurrentOII.mType == OneInteractionItem.Type.Moveable || aCurrentOII.mType == OneInteractionItem.Type.Playable)
                                {
                                    aJSONRoom.mOneInteractionItems[aOIIKey].mUpdatableObjectsWithType = GetUpdatableObjectsWithType(aCurrentOII.mUpdatableObjects, aRoomKey, aJSONRegion.mName);
                                }
                                else
                                {
                                    aJSONRoom.mOneInteractionItems[aOIIKey].mUpdatableObjectsWithType = new Dictionary<string, string>();
                                }
                            }
                        }
                        if(aCurrentRoom.mPickableItems.Count > 0)
                        {
                            aJSONRoom.mPickableItems = new Dictionary<string, PickableItem>();
                            foreach(PickableItem aItem in aCurrentRoom.mPickableItems.Values)
                            {
                                string aItemKey = aRoomKey + "_" + aItem.mName;
                                aJSONRoom.mPickableItems.Add(aItemKey, aItem);
                            }
                        }
                        aJSONRegion.mRooms[aRoomKey] = aJSONRoom;
                    }
                    mGameDetails.mRegionDetails[aCurrentRegion.mName] = aJSONRegion;
                }
                aJSON = JsonConvert.SerializeObject(mGameDetails, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
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
        public static bool IsRegionPresent(string pRegionName)
        {
            return mInstance.mRegionDetails.ContainsKey(pRegionName);
        }

        public static bool AreUpdatersPresent(List<string> pUpdaters)
        {
            foreach(string aUpd in pUpdaters)
            {
                if(!(mInstance.mCollectors.ContainsKey(aUpd) || mInstance.mEnemies.ContainsKey(aUpd) || mInstance.mKillZones.ContainsKey(aUpd)))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsGatewayValid(string pGateway)
        {
            if(mInstance.mGateways.ContainsKey(pGateway))
            {
                Gateway aG = mInstance.mGateways[pGateway];
                Room aR = mInstance.mRooms[aG.mRoom1];
                if(!aR.IsBlocked(aG.GetRoom1Direction()) && !aR.mGateways.ContainsKey(pGateway))
                {
                    return false;
                }
                aR = mInstance.mRooms[aG.mRoom2];
                if(!aR.IsBlocked(aG.GetRoom2Direction()) && !aR.mGateways.ContainsKey(pGateway))
                {
                    return false;
                }
                return true;
            }
            return false;
        }
        public static bool AreUpdatablesInSameRoom(string pRoomName, List<string> pUpdatables)
        {
            return mInstance.GetRoomObject(pRoomName).AreObjectsInRoom(pUpdatables);
        }

        public static void SetErrorMessage(string pMessage)
        {
            mInstance.mErrorMessage = pMessage;
        }

        public string GetErrorMessage()
        {
            return mErrorMessage;
        }

    }
}
