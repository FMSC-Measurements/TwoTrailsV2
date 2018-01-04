using System;
using System.Collections.Generic;
using System.Text;

namespace TwoTrails.Engine
{
    public class MapValues
    {

        private static bool isSetup = false;
        public static void setup()
        {
            if (!isSetup)
            {
                //mapBackground = String.Empty;
                //mapHasBackground = false;
                //mapBackgroundCoords = new System.Drawing.Point(0, 0);
                //mapBackgroundCoordsFile = String.Empty;

                mapUnadjNav = false;
                mapAdjBound = true;

                mapPoints = true;
                mapLines = true;
                mapLegend = false;

                mapPolyLabels = Values.EmptyGuid;
                mapPolyT5 = Values.EmptyGuid;

                mapDetailsUTM = true;

                isSetup = true;
                mapSkip = 0;

                closeBounds = true;
            }
        }

        #region DisplayOptions

        public static bool mapPoints
        {
            set;
            get;
        }

        public static bool mapLines
        {
            set;
            get;
        }

        //public static bool mapLabels
        //{
        //    set;
        //    get;
        //}

        public static bool mapGrid
        {
            set;
            get;
        }

        public static bool mapLegend
        {
            set;
            get;
        }

        //public static string mapBackground
        //{
        //    set;
        //    get;
        //}

        //public static string mapBackgroundCoordsFile
        //{
        //    set;
        //    get;
        //}

        //public static bool mapHasBackground
        //{
        //    set;
        //    get;
        //}

        //public static System.Drawing.Point mapBackgroundCoords
        //{
        //    set;
        //    get;
        //}

        public static bool mapAxis
        {
            set;
            get;
        }

        public static int mapSkip
        {
            get;
            set;
        }

        public static string mapPolyLabels
        {
            get;
            set;
        }

        public static string mapPolyT5 { get; set; }
        #endregion

        #region ElementOptions

        public static bool mapAdjNav
        {
            set;
            get;
        }

        public static bool mapAdjBound
        {
            set;
            get;
        }

        public static bool mapAdjMisc
        {
            set;
            get;
        }

        public static bool mapUnadjNav
        {
            set;
            get;
        }

        public static bool mapUnadjBound
        {
            set;
            get;
        }

        public static bool mapUnadjMisc
        {
            set;
            get;
        }

        public static bool mapUnadjWaypoints
        {
            set;
            get;
        }

        public static bool mapMyPos
        {
            set;
            get;
        }

        public static bool mapFollowPos
        {
            set;
            get;
        }

        #endregion


        #region DrawOptions
        public static bool mapMoveInvert
        {
            set;
            get;
        }

        public static bool mapDetails
        {
            get;
            set;
        }

        public static bool mapDetailsUTM
        {
            set;
            get;
        }

        public static bool closeBounds { get; set; }
        #endregion

    }
}
