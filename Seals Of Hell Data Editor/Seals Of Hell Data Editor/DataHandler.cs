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
            mName = "Default Game";
            mStory = "Default Story";
            mFirstRegion = "Default First Region";
            mRegionDetails = new Dictionary<string, Region>();
            mRegionDetails.Add(mFirstRegion, new Region());
            mRegionDetails[mFirstRegion].mName = mFirstRegion;
        }

    }
}
