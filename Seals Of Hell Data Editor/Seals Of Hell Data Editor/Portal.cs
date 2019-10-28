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

        public string mActiveRegion { get; set; }
        public string mConnectedRegion { get; set; }

        public Portal(string pRegionName)
        {
            mCurrentRegionName = pRegionName;
            mName = pRegionName + " Portal";
            mStory = pRegionName + " Portal";
            mIsInteractable = true;
            mIsVisible = true;
        }

        public bool IsValid()
        {
            bool aValidity = true;
            aValidity = aValidity && !string.IsNullOrEmpty(mName);
            if(!aValidity)
            {
                DataHandler.SetErrorMessage("Portal has no name");
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mStory);
            if(!aValidity)
            {
                DataHandler.SetErrorMessage("Portal has no story");
                return aValidity;
            }
            aValidity = aValidity && DataHandler.IsRegionPresent(mCurrentRegionName);
            if(!aValidity)
            {
                DataHandler.SetErrorMessage("Region not present");
                return aValidity;
            }
            return aValidity;
        }

    }
}
