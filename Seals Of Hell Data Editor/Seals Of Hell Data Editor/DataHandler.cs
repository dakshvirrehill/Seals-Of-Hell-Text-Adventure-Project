using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seals_Of_Hell_Data_Editor
{
    class DataHandler
    {
        public Dictionary<string, Region> mRegionList { get; set; }
        public List<string> mCommandVerbs { get; set; }
        public DataHandler()
        {
            mRegionList = new Dictionary<string, Region>();
            mCommandVerbs = new List<string>();
        }

        public bool IsValid()
        {
            if (mRegionList.Count <= 0)
            {
                return false;
            }
            if (mCommandVerbs.Count <= 0)
            {
                return false;
            }
            foreach (Region aRegion in mRegionList.Values)
            {
                if (aRegion.mRooms.Count <= 0)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
