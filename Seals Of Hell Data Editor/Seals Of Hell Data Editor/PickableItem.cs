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
            return aValidity;
        }

    }
}
