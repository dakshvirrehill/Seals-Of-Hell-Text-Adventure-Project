﻿using System;
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
    }
}
