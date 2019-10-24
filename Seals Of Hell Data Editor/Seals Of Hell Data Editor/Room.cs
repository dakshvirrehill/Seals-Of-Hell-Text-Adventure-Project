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
        public string mRegion { get; set; }
        public bool mHasCollectors { get; set; }
        public bool mHasEnemies { get; set; }
        public bool mHasKillzones { get; set; }
        public bool mHasOneInteractionItems { get; set; }
        public bool mHasPickableItems { get; set; }
        public bool mHasPortals { get; set; }
        public Dictionary<string, Gateway> mGateways;
        public Dictionary<string, Collector> mCollector;
        public Dictionary<string, Enemy> mEnemy;
        public Dictionary<string, KillZone> mKillZone;
        public Dictionary<string, OneInteractionItem> mOneInteractionItem;
        public Dictionary<string, PickableItem> mPickableItem;
        public Dictionary<string, Portal> mPortal;
        public Room()
        {
            
        }
    }
}
