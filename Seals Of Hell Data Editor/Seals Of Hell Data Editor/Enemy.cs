using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seals_Of_Hell_Data_Editor
{
    class Enemy : Updater
    {
        public int mLife;
        public string mBlockStory;

        public bool IsValid()
        {
            bool aValidity = true;
            aValidity = aValidity && IsInRoom();
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("Enemy Not In Room");
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mConditionalObject);
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("Enemy has no killable weapon");
                return aValidity;
            }
            aValidity = aValidity && DataHandler.IsConditionalPresent(mConditionalObject);
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("Enemy killable weapon not created");
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mName);
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("Enemy name not set");
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mStory);
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("Enemy story not set");
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mUpdateStory);
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("Enemy has no attack story");
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mEndStory);
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("Enemy has no death story");
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mBlockStory);
            if(!aValidity)
            {
                DataHandler.SetErrorMessage("Enemy has no block story");
                return aValidity;
            }
            aValidity = aValidity && mLife >= 1 && mLife <= 3;
            if(!aValidity)
            {
                DataHandler.SetErrorMessage("Life should be between 1 and 3");
                return aValidity;
            }
            aValidity = aValidity && DataHandler.AreUpdatablesInSameRoom(GetInRoom(), mUpdatableObjects);
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("Updatable objects are not in enemy room");
                return aValidity;
            }
            return aValidity;
        }

    }
}
