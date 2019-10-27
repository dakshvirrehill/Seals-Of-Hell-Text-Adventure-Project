using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seals_Of_Hell_Data_Editor
{
    class PickableItem
    {
        public enum Type
        {
            Weapon,
            Shield,
            Giveable,
            Wearable
        }

        public string mName { get; set; }
        public string mStory { get; set; }
        public bool mIsVisible { get; set; }
        public bool mIsInteractable { get; set; }
        public Type mType { get; set; }

        public PickableItem()
        {
            mConditionalOf = new List<string>();
        }

        string mInRoom;
        List<string> mConditionalOf;
        public void SetInRoom(string pRoom)
        {
            mInRoom = pRoom;
        }
        public string GetInRoom()
        {
            return mInRoom;
        }
        public bool IsInRoom()
        {
            return !string.IsNullOrEmpty(mInRoom);
        }

        public void AddConditionalOf(string pObjName)
        {
            if(!mConditionalOf.Contains(pObjName))
            {
                mConditionalOf.Add(pObjName);
            }
        }
        public void AddConditionalOf(List<string> pConditionalOf)
        {
            mConditionalOf.AddRange(pConditionalOf);
        }
        public List<string> GetConditionalOf()
        {
            return mConditionalOf;
        }
        public bool IsConditionalOf()
        {
            return mConditionalOf.Count > 0;
        }

        public bool IsValid()
        {
            bool aValidity = true;
            aValidity = aValidity && !string.IsNullOrEmpty(mName);
            if(!aValidity)
            {
                DataHandler.SetErrorMessage("Pickable has no name");
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mStory);
            if(!aValidity)
            {
                DataHandler.SetErrorMessage("Pickable has no story");
                return aValidity;
            }
            aValidity = aValidity && IsInRoom();
            if(!aValidity)
            {
                DataHandler.SetErrorMessage("Pickable has no room");
                return aValidity;
            }
            if(mType == Type.Weapon || mType == Type.Wearable)
            {
                aValidity = aValidity && IsConditionalOf();
                if(!aValidity)
                {
                    DataHandler.SetErrorMessage("Weapon or Wearable not a conditional");
                    return aValidity;
                }
                aValidity = aValidity && DataHandler.AreUpdatersPresent(mConditionalOf);
                if(!aValidity)
                {
                    DataHandler.SetErrorMessage("Pickable Updaters not present");
                    return aValidity;
                }
            }
            else if(mType == Type.Giveable)
            {
                aValidity = aValidity && mConditionalOf.Count == 1;
                if(!aValidity)
                {
                    DataHandler.SetErrorMessage("Giveable needs to be given to only 1 collector");
                    return aValidity;
                }
                aValidity = aValidity && DataHandler.AreUpdatersPresent(mConditionalOf);
                if(!aValidity)
                {
                    DataHandler.SetErrorMessage("Collector not present");
                    return aValidity;
                }
            }
            else
            {
                if(IsConditionalOf())
                {
                    aValidity = aValidity && DataHandler.AreUpdatersPresent(mConditionalOf);
                    if (!aValidity)
                    {
                        DataHandler.SetErrorMessage("Pickable Updaters not present");
                        return aValidity;
                    }
                }
            }
            return aValidity;
        }

    }
}
