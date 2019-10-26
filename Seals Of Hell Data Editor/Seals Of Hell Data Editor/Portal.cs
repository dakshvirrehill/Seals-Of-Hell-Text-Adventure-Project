using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seals_Of_Hell_Data_Editor
{
    class Portal
    {
        public string mName { get; set; }
        public string mStory { get; set; }
        public bool mIsVisible { get; set; }
        public bool mIsInteractable { get; set; }
        public string mCurrentRegionName { get; set; }

        public Portal(string pRegionName)
        {
            mCurrentRegionName = pRegionName;
            mName = pRegionName + " Portal";
            mStory = pRegionName + " Portal";
        }

    }
}
