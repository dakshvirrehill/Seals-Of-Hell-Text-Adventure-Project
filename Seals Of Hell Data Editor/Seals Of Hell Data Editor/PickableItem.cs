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

        public string mName;
        public string mStory;
        public Type mType;
    }
}
