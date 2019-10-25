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
        public Dictionary<string, Collector> mCollectors { get; set; }
        public Dictionary<string, Enemy> mEnemies { get; set; }
        public Dictionary<string, KillZone> mKillZones { get; set; }
        public Dictionary<string, OneInteractionItem> mOneInteractionItems { get; set; }
        public Dictionary<string, PickableItem> mPickableItems { get; set; }
        public Dictionary<string, Portal> mPortals { get; set; }
        public Room()
        {
            mName = "Default Name";
            mStory = "Default Story";
        }

    }
}
