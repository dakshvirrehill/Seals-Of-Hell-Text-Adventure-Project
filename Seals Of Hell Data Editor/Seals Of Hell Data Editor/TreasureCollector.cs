using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seals_Of_Hell_Data_Editor
{
    class TreasureCollector : Updater
    {
        public string mKey { get; set; }
        public List<string> mTreasures { get; set; }
        public TreasureCollector()
        {
            mName = "Treasure Collector";
            mStory = "Default Story";
            mUpdateStory = "Default Story";
            mEndStory = "Default Story";
            mTreasures = new List<string>();
        }

        public bool IsTCValid()
        {
            bool aValidity = true;
            aValidity = aValidity && !string.IsNullOrEmpty(mName);
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("Treasure Collector has no name");
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mStory);
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("Treasure Collector has no story");
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mUpdateStory);
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("Treasure Collector has no update story");
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mEndStory);
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("Treasure Collector has no end story");
                return aValidity;
            }
            aValidity = aValidity && string.IsNullOrEmpty(mConditionalObject);
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("Treasure Collector can't have conditional object");
                return aValidity;
            }
            aValidity = aValidity && mTreasures.Count >= 1;
            if(!aValidity)
            {
                DataHandler.SetErrorMessage("Treasure Collector has no treasure");
                return aValidity;
            }
            if(mUpdatableObjects.Count > 0)
            {
                aValidity = aValidity && DataHandler.AreUpdatablesInSameRoom(GetInRoom(), mUpdatableObjects);
                if (!aValidity)
                {
                    DataHandler.SetErrorMessage("Updatable objects are not in treasure collector room");
                    return aValidity;
                }
            }
            return aValidity;
        }

    }
}
