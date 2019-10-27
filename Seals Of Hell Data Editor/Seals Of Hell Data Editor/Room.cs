using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seals_Of_Hell_Data_Editor
{
    class Room
    {
        public string mName { get; set; }
        public string mStory { get; set; }
        public TreasureCollector mTreasureCollector { get; set; }
        public Dictionary<string, Collector> mCollectors { get; set; }
        public Dictionary<string, Enemy> mEnemies { get; set; }
        public Dictionary<string,KillZone> mKillZones { get; set; }
        public Dictionary<string,OneInteractionItem> mOneInteractionItems { get; set; }
        public Dictionary<string, PickableItem> mPickableItems { get; set; }
        public Dictionary<string, Portal> mPortals { get; set; }
        public Dictionary<string, Gateway> mGateways { get; set; }

        string mRegion;
        Dictionary<Gateway.Direction, bool> mIsBlocked;

        public Room()
        {
            mName = "Default Name";
            mStory = "Default Story";
            mTreasureCollector = null;
            mCollectors = new Dictionary<string, Collector>();
            mEnemies = new Dictionary<string, Enemy>();
            mKillZones = new Dictionary<string, KillZone>();
            mOneInteractionItems = new Dictionary<string, OneInteractionItem>();
            mPickableItems = new Dictionary<string, PickableItem>();
            mPortals = new Dictionary<string, Portal>();
            mGateways = new Dictionary<string, Gateway>();
            mIsBlocked = new Dictionary<Gateway.Direction, bool>()
            {
                {Gateway.Direction.North,false },
                {Gateway.Direction.South,false },
                {Gateway.Direction.East,false },
                {Gateway.Direction.West,false },
                {Gateway.Direction.NorthEast,false },
                {Gateway.Direction.NorthWest,false },
                {Gateway.Direction.SouthEast,false },
                {Gateway.Direction.SouthWest,false }
            };
        }
        #region Helpers
        public List<string> GetAllInteractableNames(string pExcept = "")
        {
            List<string> aInteractables = new List<string>();
            aInteractables.AddRange(mCollectors.Keys);
            aInteractables.AddRange(mEnemies.Keys);
            aInteractables.AddRange(mKillZones.Keys);
            aInteractables.AddRange(mOneInteractionItems.Keys);
            aInteractables.AddRange(mPickableItems.Keys);
            aInteractables.AddRange(mPortals.Keys);
            aInteractables.AddRange(mGateways.Keys);
            if(mTreasureCollector != null)
            {
                aInteractables.Add(mTreasureCollector.mName);
            }
            if(!string.IsNullOrEmpty(pExcept))
            {
                aInteractables.Remove(pExcept);
            }
            return aInteractables;
        }
        public void RemoveOldCollectorAndAddNew(string pOldCollectorName, Collector pNewCollector)
        {
            if (mCollectors == null)
            {
                return;
            }
            if (mCollectors.ContainsKey(pOldCollectorName))
            {
                mCollectors.Remove(pOldCollectorName);
                EditUpdatableNames(pOldCollectorName, pNewCollector.mName);
            }
            mCollectors.Add(pNewCollector.mName, pNewCollector);
        }
        public void RemoveOldEnemyAndAddNew(string pOldEnemyName, Enemy pNewEnemy)
        {
            if(mEnemies == null)
            {
                return;
            }
            if(mEnemies.ContainsKey(pOldEnemyName))
            {
                mEnemies.Remove(pOldEnemyName);
                EditUpdatableNames(pOldEnemyName, pNewEnemy.mName);
            }
            mEnemies.Add(pNewEnemy.mName, pNewEnemy);
        }
        public void RemoveOldKillZoneAndAddNew(string pOldKillZoneName, KillZone pNewKillZone)
        {
            if (mKillZones == null)
            {
                return;
            }
            if (mKillZones.ContainsKey(pOldKillZoneName))
            {
                mKillZones.Remove(pOldKillZoneName);
                EditUpdatableNames(pOldKillZoneName, pNewKillZone.mName);
            }
            mKillZones.Add(pNewKillZone.mName, pNewKillZone);
        }
        public void RemoveOldOIItemAndAddNew(string pOldOIItemName, OneInteractionItem pNewOIItem)
        {
            if (mOneInteractionItems == null)
            {
                return;
            }
            if (mOneInteractionItems.ContainsKey(pOldOIItemName))
            {
                mOneInteractionItems.Remove(pOldOIItemName);
                EditUpdatableNames(pOldOIItemName, pNewOIItem.mName);
            }
            mOneInteractionItems.Add(pNewOIItem.mName, pNewOIItem);
        }
        public void RemoveOldPickableAndAddNew(string pOldPickableName, PickableItem pNewPickableItem)
        {
            if (mPickableItems == null)
            {
                return;
            }
            if (mPickableItems.ContainsKey(pOldPickableName))
            {
                mPickableItems.Remove(pOldPickableName);
                EditUpdatableNames(pOldPickableName, pNewPickableItem.mName);
            }
            mPickableItems.Add(pNewPickableItem.mName, pNewPickableItem);
        }
        public void RemoveOldGatewayAndAddNew(string pOldGatewayName, Gateway pNewGateway)
        {
            if (mGateways == null)
            {
                return;
            }
            if (mGateways.ContainsKey(pOldGatewayName))
            {
                mGateways.Remove(pOldGatewayName);
                EditUpdatableNames(pOldGatewayName, pNewGateway.mName);
            }
            mGateways.Add(pNewGateway.mName, pNewGateway);
        }
        public void EditUpdatableNames(string pOldName, string pNewName)
        {
            if (mCollectors != null)
            {
                foreach (Collector aCollector in mCollectors.Values)
                {
                    aCollector.ChangeUpdatableObjectName(pOldName, pNewName);
                }
            }
            if (mEnemies != null)
            {
                foreach (Enemy aEnemy in mEnemies.Values)
                {
                    aEnemy.ChangeUpdatableObjectName(pOldName, pNewName);
                }
            }
            if (mKillZones != null)
            {
                foreach (KillZone aKillZone in mKillZones.Values)
                {
                    aKillZone.ChangeUpdatableObjectName(pOldName, pNewName);
                }
            }
            if (mTreasureCollector != null)
            {
                mTreasureCollector.ChangeUpdatableObjectName(pOldName, pNewName);
            }
            if (mOneInteractionItems != null)
            {
                foreach (OneInteractionItem aItem in mOneInteractionItems.Values)
                {
                    aItem.ChangeUpdatableObjectName(pOldName, pNewName);
                }
            }
        }

        public void SetInRegion(string pRegion)
        {
            mRegion = pRegion;
        }
        public string GetInRegion()
        {
            return mRegion;
        }
        public bool IsInRegion()
        {
            return !string.IsNullOrEmpty(mRegion);
        }

        public bool IsBlocked(Gateway.Direction pDirection)
        {
            return mIsBlocked[pDirection];
        }
        public void ToggleDirectionBlock(Gateway.Direction pDirection, bool pBlock)
        {
            mIsBlocked[pDirection] = pBlock;
        }
        public bool AreObjectsInRoom(List<string> pObjNames)
        {
            foreach(string aObj in pObjNames)
            {
                if(!(mCollectors.ContainsKey(aObj) || mEnemies.ContainsKey(aObj) || mKillZones.ContainsKey(aObj) || mOneInteractionItems.ContainsKey(aObj)
                    || mPickableItems.ContainsKey(aObj) || mPortals.ContainsKey(aObj) || mGateways.ContainsKey(aObj)))
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
        public bool IsRoomValid(bool pIsEntry = false, bool pIsFirst = false)
        {
            bool aValidity = true;
            aValidity = aValidity && !string.IsNullOrEmpty(mName);
            if(!aValidity)
            {
                DataHandler.SetErrorMessage("Room has no name");
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mStory);
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("Room has no story");
                return aValidity;
            }
            if(pIsFirst && pIsEntry)
            {
                aValidity = aValidity && mGateways.Count == 0;
                if (!aValidity)
                {
                    DataHandler.SetErrorMessage("First Room can't have gateways");
                    return aValidity;
                }
                aValidity = aValidity && mPortals.Count > 0;
                if (!aValidity)
                {
                    DataHandler.SetErrorMessage("First Room should have all region portals");
                    return aValidity;
                }
                aValidity = aValidity && mTreasureCollector.IsTCValid();
                if (!aValidity)
                {
                    return aValidity;
                }
            }
            else
            {
                aValidity = aValidity && mTreasureCollector == null;
                if(!aValidity)
                {
                    DataHandler.SetErrorMessage("Only first room should have treasure collector");
                    return aValidity;
                }
                if (pIsEntry)
                {
                    aValidity = aValidity && mPortals.Count == 1;
                    if (!aValidity)
                    {
                        DataHandler.SetErrorMessage("Entry Room of Region should have portal");
                        return aValidity;
                    }
                }
                foreach(Collector aCollector in mCollectors.Values)
                {
                    aValidity = aValidity && aCollector.IsValid();
                    if(!aValidity)
                    {
                        return aValidity;
                    }
                }
                foreach (Enemy aEnemy in mEnemies.Values)
                {
                    aValidity = aValidity && aEnemy.IsValid();
                    if (!aValidity)
                    {
                        return aValidity;
                    }
                }
                foreach (KillZone aKillZone in mKillZones.Values)
                {
                    aValidity = aValidity && aKillZone.IsValid();
                    if (!aValidity)
                    {
                        return aValidity;
                    }
                }
                foreach (OneInteractionItem aOIItem in mOneInteractionItems.Values)
                {
                    aValidity = aValidity && aOIItem.IsValid();
                    if (!aValidity)
                    {
                        return aValidity;
                    }
                }
                foreach (PickableItem aItem in mPickableItems.Values)
                {
                    aValidity = aValidity && aItem.IsValid();
                    if (!aValidity)
                    {
                        return aValidity;
                    }
                }
                foreach (Portal aPortal in mPortals.Values)
                {
                    aValidity = aValidity && aPortal.IsValid();
                    if (!aValidity)
                    {
                        return aValidity;
                    }
                }
                foreach (Gateway aGateway in mGateways.Values)
                {
                    aValidity = aValidity && aGateway.IsValid();
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
