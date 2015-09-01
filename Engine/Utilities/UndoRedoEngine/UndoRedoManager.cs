using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwoTrails.BusinessObjects;

namespace TwoTrails.Utilities
{
    public enum UndoRedoResult
    {
        Single,
        Multi,
        Delete,
        None
    }

    public delegate void UndoRedoUpdateEvent();

    public class TtPointUndoRedoManager
    {
        public event UndoRedoUpdateEvent UndoRedoUpdate;

        private Stack<TtPointCommand> _Undocommands = new Stack<TtPointCommand>();
        private Stack<TtPointCommand> _Redocommands = new Stack<TtPointCommand>();

        public bool CanUndo { get { return _Undocommands.Count > 1; } }
        public bool CanRedo { get { return _Redocommands.Count > 0; } }


        public UndoRedoResult Redo(int levels, IDictionary<string, TtPoint> points)
        {
            if (_Redocommands.Count < 1)
                return UndoRedoResult.None;

            bool wasMulti = false;

            for (int i = 1; i <= levels; i++)
            {
                if (_Redocommands.Count != 0)
                {
                    TtPointCommand command = _Redocommands.Pop();
                    command.Execute(points);
                    _Undocommands.Push(command);

                    if (command.CommandType != TtPointCommandType.SingleEdit)
                        wasMulti = true;
                }
            }

            if (UndoRedoUpdate != null)
                UndoRedoUpdate();

            if (wasMulti)
                return UndoRedoResult.Multi;
            else
                return UndoRedoResult.Single;
        }

        public UndoRedoResult Undo(int levels, IDictionary<string, TtPoint> points)
        {
            if (_Undocommands.Count < 1)
                return UndoRedoResult.None;

            bool wasMulti = false;
            bool hasDelete = false;

            for (int i = 1; i <= levels; i++)
            {
                if (_Undocommands.Count != 0)
                {
                    TtPointCommand command = _Undocommands.Pop();
                    command.UnExecute(points);
                    _Redocommands.Push(command);

                    if (command.CommandType != TtPointCommandType.SingleEdit)
                        wasMulti = true;
                    if (command.CommandType == TtPointCommandType.Delete ||
                        command.CommandType == TtPointCommandType.Add)
                        hasDelete = true;
                }
            }

            if (UndoRedoUpdate != null)
                UndoRedoUpdate();

            if (hasDelete)
                return UndoRedoResult.Delete;
            if (wasMulti)
                return UndoRedoResult.Multi;
            else
                return UndoRedoResult.Single;
        }


        public void EditPoint(TtPoint point, IDictionary<string, TtPoint> points)
        {
            TtPointCommand cmd = new EditPointCommand(point);

            _Undocommands.Push(cmd);
            _Redocommands.Clear();

            cmd.Execute(points);

            if (UndoRedoUpdate != null)
                UndoRedoUpdate();
        }

        public void EditPoints(List<TtPoint> newPoints, IDictionary<string, TtPoint> points)
        {
            TtPointCommand cmd = new MultiEditPointCommand(newPoints);

            _Undocommands.Push(cmd);
            _Redocommands.Clear();

            cmd.Execute(points);

            if (UndoRedoUpdate != null)
                UndoRedoUpdate();
        }

        public void DeletePoint(TtPoint point, IDictionary<string, TtPoint> points)
        {
            TtPointCommand cmd = new DeletePointCommand(point);

            _Undocommands.Push(cmd);
            _Redocommands.Clear();

            cmd.Execute(points);

            if (UndoRedoUpdate != null)
                UndoRedoUpdate();
        }

        public void DeletePoints(List<TtPoint> delPoints, IDictionary<string, TtPoint> points)
        {
            TtPointCommand cmd = new MultiDeletePointCommand(delPoints);

            _Undocommands.Push(cmd);
            _Redocommands.Clear();

            cmd.Execute(points);

            if (UndoRedoUpdate != null)
                UndoRedoUpdate();
        }

        public void AddPoints(List<TtPoint> addPoints, IDictionary<string, TtPoint> points)
        {
            TtPointCommand cmd = new MultiAddPointCommand(addPoints);

            _Undocommands.Push(cmd);
            _Redocommands.Clear();

            cmd.Execute(points);

            if (UndoRedoUpdate != null)
                UndoRedoUpdate();
        }

        public void ClearHistory()
        {
            _Undocommands.Clear();
            _Redocommands.Clear();

            if (UndoRedoUpdate != null)
                UndoRedoUpdate();
        }
    }
}
