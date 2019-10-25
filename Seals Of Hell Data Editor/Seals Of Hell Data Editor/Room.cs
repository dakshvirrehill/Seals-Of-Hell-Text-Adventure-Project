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
                return;
            if (mCollectors.ContainsKey(pOldCollectorName))
            {
                mCollectors.Remove(pOldCollectorName);
                if(mCollectors != null)
                {
                    foreach (Collector aCollector in mCollectors.Values)
                    {
                        if (aCollector.mUpdatableObjects.Contains(pOldCollectorName))
                        {
                            aCollector.mUpdatableObjects.Remove(pOldCollectorName);
                            aCollector.mUpdatableObjects.Add(pNewCollector.mName);
                        }
                    }
                }
                if(mEnemies != null)
                {
                    foreach (Enemy aEnemy in mEnemies.Values)
                    {
                        if (aEnemy.mUpdatableObjects.Contains(pOldCollectorName))
                        {
                            aEnemy.mUpdatableObjects.Remove(pOldCollectorName);
                            aEnemy.mUpdatableObjects.Add(pNewCollector.mName);
                        }
                    }
                }
                if(mKillZones != null)
                {
                    foreach (KillZone aKillZone in mKillZones.Values)
                    {
                        if (aKillZone.mUpdatableObjects.Contains(pOldCollectorName))
                        {
                            aKillZone.mUpdatableObjects.Remove(pOldCollectorName);
                            aKillZone.mUpdatableObjects.Add(pNewCollector.mName);
                        }
                    }
                }
                if(mTreasureCollector != null)
                {
                    if(mTreasureCollector.mUpdatableObjects.Contains(pOldCollectorName))
                    {
                        mTreasureCollector.mUpdatableObjects.Remove(pOldCollectorName);
                        mTreasureCollector.mUpdatableObjects.Add(pNewCollector.mName);
                    }
                }
                if(mOneInteractionItems != null)
                {
                    foreach(OneInteractionItem aItem in mOneInteractionItems.Values)
                    {
                        if(aItem.mUpdatableObjects.Contains(pOldCollectorName))
                        {
                            aItem.mUpdatableObjects.Remove(pOldCollectorName);
                            aItem.mUpdatableObjects.Add(pNewCollector.mName);
                        }
                    }
                }
            }
            mCollectors.Add(pNewCollector.mName, pNewCollector);
        }

    }
}
