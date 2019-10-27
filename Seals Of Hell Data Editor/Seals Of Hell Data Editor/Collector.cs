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
                DataHandler.SetErrorMessage("Collector Not In Room");
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mConditionalObject);
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("Collector has no conditional object");
                return aValidity;
            }
            aValidity = aValidity && DataHandler.IsConditionalPresent(mConditionalObject);
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("Conditional object not created");
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mName);
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("Collector name not set");
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mStory);
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("Collector story not set");
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mUpdateStory);
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("Collector has no update story");
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mEndStory);
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("Collector has no end story");
                return aValidity;
            }
            aValidity = aValidity && mUpdatableObjects.Count >= 1;
            if(!aValidity)
            {
                DataHandler.SetErrorMessage("There are no updatable objects in collector");
                return aValidity;
            }
            aValidity = aValidity && DataHandler.AreUpdatablesInSameRoom(GetInRoom(), mUpdatableObjects);
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("Updatable objects are not in collector room");
                return aValidity;
            }
            return aValidity;
        }
    }
}
