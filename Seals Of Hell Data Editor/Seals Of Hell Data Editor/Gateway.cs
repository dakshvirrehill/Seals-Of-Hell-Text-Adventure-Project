using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seals_Of_Hell_Data_Editor
{
    class Gateway
    {
        public enum Direction
        {
            North,
            South,
            East,
            West,
            NorthEast,
            NorthWest,
            SouthEast,
            SouthWest
        }
        public enum Path
        {
            North_South,
            East_West,
            NorthEast_SouthWest,
            NorthWest_SouthEast
        }
        public bool mIsVisible { get; set; }
        public bool mIsInteractable { get; set; }
        public string mName { get; set; }
        public string mStory { get; set; }
        public Path mPath { get; set; }
        public string mRoom1 { get; set; }
        public string mRoom2 { get; set; }

        public Direction GetRoom1Direction()
        {
            switch(mPath)
            {
                case Path.East_West: return Direction.East;
                case Path.North_South: return Direction.North;
                case Path.NorthWest_SouthEast:return Direction.NorthWest;
                case Path.NorthEast_SouthWest:return Direction.NorthEast;
            }
            return Direction.North;
        }
        public Direction GetRoom2Direction()
        {
            switch (mPath)
            {
                case Path.East_West: return Direction.West;
                case Path.North_South: return Direction.South;
                case Path.NorthWest_SouthEast: return Direction.SouthEast;
                case Path.NorthEast_SouthWest: return Direction.SouthWest;
            }
            return Direction.South;
        }

        public bool IsValid()
        {
            bool aValidity = true;
            aValidity = aValidity && !string.IsNullOrEmpty(mName);
            if(!aValidity)
            {
                DataHandler.SetErrorMessage("Gateway has no name");
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mStory);
            if(!aValidity)
            {
                DataHandler.SetErrorMessage("Gateway has no story");
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mRoom1);
            if(!aValidity)
            {
                DataHandler.SetErrorMessage("Gateway has no room 1");
                return aValidity;
            }
            aValidity = aValidity && !string.IsNullOrEmpty(mRoom2);
            if (!aValidity)
            {
                DataHandler.SetErrorMessage("Gateway has no room 2");
                return aValidity;
            }
            aValidity = aValidity && DataHandler.IsGatewayValid(mName);
            if(!aValidity)
            {
                DataHandler.SetErrorMessage("Gateway path not valid");
                return aValidity;
            }
            return aValidity;
        }

    }
}
