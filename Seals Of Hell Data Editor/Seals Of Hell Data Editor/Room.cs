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
        public bool mHasCollectors { get; set; }
        public bool mHasEnemies { get; set; }
        public bool mHasKillzones { get; set; }
        public bool mHasOneInteractionItems { get; set; }
        public bool mHasPickableItems { get; set; }
        public bool mHasPortals { get; set; }
        public TreasureCollector mTreasureCollector { get; set; }
        public Dictionary<string, Gateway> mGateways { get; set; }
        public Dictionary<string, Collector> mCollector { get; set; }
        public Dictionary<string, Enemy> mEnemy { get; set; }
        public Dictionary<string, KillZone> mKillZone { get; set; }
        public Dictionary<string, OneInteractionItem> mOneInteractionItem { get; set; }
        public Dictionary<string, PickableItem> mPickableItem { get; set; }
        public Dictionary<string, Portal> mPortal { get; set; }
        public Room()
        {
            mName = "Default Name";
            mStory = "Default Story";
        }

    }
}
