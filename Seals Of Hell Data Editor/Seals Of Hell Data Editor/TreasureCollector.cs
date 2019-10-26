using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seals_Of_Hell_Data_Editor
{
    class TreasureCollector : Updater
    {
        public List<string> mTreasures { get; set; }
        public TreasureCollector()
        {
            mTreasures = new List<string>();
        }
    }
}
