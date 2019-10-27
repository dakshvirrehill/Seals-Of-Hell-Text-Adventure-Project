using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seals_Of_Hell_Data_Editor
{
    class Collector : Updater
    {
        public bool IsValid()
        {
            bool aValidity = true;
            aValidity = aValidity && IsInRoom();
            if(!aValidity)
            {
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mConditionalObject);
            if (!aValidity)
            {
                return aValidity;
            }
            aValidity = aValidity && DataHandler.IsConditionalPresent(mConditionalObject);
            if (!aValidity)
            {
                return aValidity;
            }
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
            aValidity = aValidity && mUpdatableObjects.Count >= 1;
            if(!aValidity)
            {
                return aValidity;
            }
            aValidity = aValidity && DataHandler.AreUpdatablesInSameRoom(GetInRoom(), mUpdatableObjects);
            if (!aValidity)
            {
                return aValidity;
            }
            return aValidity;
        }
    }
}
