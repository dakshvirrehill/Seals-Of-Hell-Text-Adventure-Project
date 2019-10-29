using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seals_Of_Hell_Data_Editor
{
    class OneInteractionItem : Updater
    {
        public enum Type
        {
            Moveable,
            Playable,
            Eatable,
            Riddle
        }

        public Type mType;

        public bool IsValid()
        {
            bool aValidity = true;
            aValidity = aValidity && IsInRoom();
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("One Interaction Item Not In Room");
                return aValidity;
            }
            aValidity = aValidity && string.IsNullOrEmpty(mConditionalObject);
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("One Interaction Item has conditional object");
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mName);
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("One Interaction Item name not set");
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mStory);
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("One Interaction Item story not set");
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mUpdateStory);
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("One Interaction Item has no update story");
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mEndStory);
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("One Interaction Item has no end story");
                return aValidity;
            }
            if(mType == Type.Moveable || mType == Type.Riddle)
            {
                aValidity = aValidity && mUpdatableObjects.Count >= 1;
                if (!aValidity)
                {
                    DataHandler.SetErrorMessage("There are no updatable objects in movable or playable Item");
                    return aValidity;
                }
                aValidity = aValidity && DataHandler.AreUpdatablesInSameRoom(GetInRoom(), mUpdatableObjects);
                if (!aValidity)
                {
                    DataHandler.SetErrorMessage("Updatable objects are not in movable or playable room");
                    return aValidity;
                }
            }
            else if(mType == Type.Playable)
            {
                if(mUpdatableObjects.Count > 0)
                {
                    aValidity = aValidity && DataHandler.AreUpdatablesInSameRoom(GetInRoom(), mUpdatableObjects);
                    if (!aValidity)
                    {
                        DataHandler.SetErrorMessage("Updatable objects are not in movable or playable room");
                        return aValidity;
                    }
                }
            }
            else
            {
                aValidity = aValidity && mUpdatableObjects.Count <= 0;
                if (!aValidity)
                {
                    DataHandler.SetErrorMessage("There are updatable objects in riddle or eatable");
                    return aValidity;
                }
            }
            return aValidity;
        }

    }
}
