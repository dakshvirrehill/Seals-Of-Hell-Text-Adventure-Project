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

        public Room()
        {
            mName = "Default Name";
            mStory = "Default Story";
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

        }
        void EditUpdatableNames(string pOldName, string pNewName)
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
    }
}
