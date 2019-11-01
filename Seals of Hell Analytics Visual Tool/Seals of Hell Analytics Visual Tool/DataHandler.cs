using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seals_of_Hell_Analytics_Visual_Tool
{
    public struct ActionData
    {
        public int mActionId;
        public string mCommandName;
        public int mCount;
    }
    public struct PickableData
    {
        public int mPickableId;
        public string mPickableName;
        public int mPickCount;
        public int mDropCount;
    }
    public struct GameData
    {
        public int mGameId;
        public double mPlayTime;
        public int mInventoryCount;
    }
    class DataHandler
    {
        public List<ActionData> mActions { get; set; }
        public List<PickableData> mPickables { get; set; }
        public List<GameData> mGamePlayData { get; set; }
        public bool mInit { get; set; }

        public DataHandler()
        {
            mActions = new List<ActionData>();
            mPickables = new List<PickableData>();
            mGamePlayData = new List<GameData>();
            mInit = false;
        }
    }
}
