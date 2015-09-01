using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwoTrails.BusinessObjects;

namespace TwoTrails.Utilities
{
    public enum TtPointCommandType
    {
        SingleEdit,
        MultiEdit,
        Delete,
        Add
    }

    public abstract class TtPointCommand
    {
        public abstract TtPointCommandType CommandType { get; protected set; }
        public abstract void Execute(IDictionary<string, TtPoint> points);
        public abstract void UnExecute(IDictionary<string, TtPoint> points);
    } 
}
