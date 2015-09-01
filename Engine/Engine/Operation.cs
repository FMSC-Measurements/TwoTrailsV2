using System;
using System.Collections.Generic;
using System.Text;
using TwoTrails.BusinessObjects;

namespace TwoTrails.Engine
{
    public enum OpType
    {
        GPS,
        Traverse,
        WayPoint,
        Quondam,
        SideShot,
        Walk,
        Take5
    }

    public enum UomDistance
    {
        FeetTenths,
        FeetInches,
        Meters,
        Chains,
        Yards
    }

    public enum UomSlope
    {
        Percent,
        Degrees
    }

    public enum UomElevation
    {
        Meters,
        Feet
    }

    public enum Datum
    {
        NAD83,
        WGS84,
        ITRF,
        NAD27,
        Local
    }

    public enum DeclinationType
    {
        MagDec,
        DeedRot
    }

    /// <summary>
    /// TODO: Can this be replaced by using the Elevation enum?
    /// </summary>
    public enum MapProjections
    {
        Meters,
        Feet
    }
}
