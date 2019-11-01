using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace Seals_of_Hell_Analytics_Visual_Tool
{
    class DatabaseManager
    {
        static string mConnectionString;
        public static void SetConnectionString(string pConnectionString)
        {
            mConnectionString = pConnectionString;
        }

        public static bool SetData(DataHandler pDataHandler)
        {
            pDataHandler.mActions.Clear();
            pDataHandler.mGamePlayData.Clear();
            pDataHandler.mPickables.Clear();
            pDataHandler.mInit = false;
            DataTable aData = ReadData("SELECT * FROM ActionData;");
            if(aData == null)
            {
                return false;
            }
            foreach(DataRow aRow in aData.Rows)
            {
                ActionData aAData = new ActionData();
                if(!int.TryParse(aRow[0].ToString(), out aAData.mActionId))
                {
                    continue;
                }
                if(!int.TryParse(aRow[2].ToString(), out aAData.mCount))
                {
                    continue;
                }
                aAData.mCommandName = aRow[1].ToString();
                pDataHandler.mActions.Add(aAData);
            }
            pDataHandler.mActions.Sort((a1, a2) => a1.mCommandName.CompareTo(a2.mCommandName));
            aData = ReadData("SELECT * FROM PickableData;");
            if (aData == null)
            {
                return false;
            }
            foreach (DataRow aRow in aData.Rows)
            {
                PickableData aPData = new PickableData();
                if (!int.TryParse(aRow[0].ToString(), out aPData.mPickableId))
                {
                    continue;
                }
                if (!int.TryParse(aRow[2].ToString(), out aPData.mPickCount))
                {
                    continue;
                }
                if (!int.TryParse(aRow[3].ToString(), out aPData.mDropCount))
                {
                    continue;
                }
                aPData.mPickableName = aRow[1].ToString();
                pDataHandler.mPickables.Add(aPData);
            }
            pDataHandler.mPickables.Sort((p1, p2) => p1.mPickableName.CompareTo(p2.mPickableName));
            aData = ReadData("SELECT * FROM GameData;");
            if (aData == null)
            {
                return false;
            }
            foreach(DataRow aRow in aData.Rows)
            {
                GameData aGData = new GameData();
                if (!int.TryParse(aRow[0].ToString(), out aGData.mGameId))
                {
                    continue;
                }
                if (!double.TryParse(aRow[1].ToString(), out aGData.mPlayTime))
                {
                    continue;
                }
                if (!int.TryParse(aRow[2].ToString(), out aGData.mInventoryCount))
                {
                    continue;
                }
                pDataHandler.mGamePlayData.Add(aGData);
            }
            pDataHandler.mGamePlayData.Sort((g1, g2) => g1.mPlayTime.CompareTo(g2.mPlayTime));
            pDataHandler.mInit = true;
            return true;
        }

        static DataTable ReadData(string pCommand)
        {
            try
            {
                DataTable aTable = new DataTable();
                using (SQLiteConnection aConnection = new SQLiteConnection(mConnectionString))
                {
                    aConnection.Open();
                    SQLiteDataAdapter aAdapter = new SQLiteDataAdapter(pCommand, aConnection);
                    aAdapter.Fill(aTable);
                    aConnection.Close();
                }
                return aTable;
            }
            catch (Exception aE)
            {
                Console.WriteLine("Database Error: {0}\n{1}\n", aE.Message, aE.StackTrace);
                return null;
            }
        }

    }
}
