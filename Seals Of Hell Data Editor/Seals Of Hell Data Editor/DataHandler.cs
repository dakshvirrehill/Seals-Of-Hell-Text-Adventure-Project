using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seals_Of_Hell_Data_Editor
{
    class DataHandler
    {
        public string mName { get; set; }
        public string mStory { get; set; }
        public string mFirstRegion { get; set; }
        public Dictionary<string, Region> mRegionDetails { get; set; }
        public DataHandler()
        {
            mRegionDetails = new Dictionary<string, Region>();
        }

        public bool IsValid()
        {
            if(string.IsNullOrEmpty(mFirstRegion))
            {
                return false;
            }
            if (mRegionDetails.Count <= 0)
            {
                return false;
            }
            foreach (Region aRegion in mRegionDetails.Values)
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
