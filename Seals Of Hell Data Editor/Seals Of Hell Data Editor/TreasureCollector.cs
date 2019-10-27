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
            mTreasures = new List<string>();
        }

        public bool IsTCValid()
        {
            bool aValidity = true;
            aValidity = aValidity && !string.IsNullOrEmpty(mName);
            if (!aValidity)
            {
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mStory);
            if (!aValidity)
            {
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mUpdateStory);
            if (!aValidity)
            {
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mEndStory);
            if (!aValidity)
            {
                return aValidity;
            }
            aValidity = aValidity && string.IsNullOrEmpty(mConditionalObject);
            if (!aValidity)
            {
                return aValidity;
            }
            aValidity = aValidity && mTreasures.Count >= 1;
            if(!aValidity)
            {
                return aValidity;
            }
            return aValidity;
        }

    }
}
