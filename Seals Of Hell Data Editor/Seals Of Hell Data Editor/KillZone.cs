using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seals_Of_Hell_Data_Editor
{
    class KillZone :Updater
    {
        public bool IsValid()
        {
            bool aValidity = true;
            aValidity = aValidity && IsInRoom();
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("KillZone Not In Room");
                return aValidity;
            }
            if(!string.IsNullOrEmpty(mConditionalObject))
            {
                aValidity = aValidity && DataHandler.IsConditionalPresent(mConditionalObject);
                if (!aValidity)
                {
                    DataHandler.SetErrorMessage("Conditional object not created");
                    return aValidity;
                }
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mName);
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("KillZone name not set");
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mStory);
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("KillZone story not set");
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mUpdateStory);
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("KillZone has no attack story");
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mEndStory);
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("KillZone has no death story");
                return aValidity;
            }
            aValidity = aValidity && mUpdatableObjects.Count >= 1;
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("There are no updatable objects in killzone");
                return aValidity;
            }
            aValidity = aValidity && DataHandler.AreUpdatablesInSameRoom(GetInRoom(), mUpdatableObjects);
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("Updatable objects are not in killzone room");
                return aValidity;
            }
            return aValidity;
        }
    }
}
