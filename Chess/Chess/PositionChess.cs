﻿using Chess.Board;

namespace Chess
{
    class PositionChess
    {
        public char Column { get; set; }
        public int Line { get; set; }

        public PositionChess(char column, int line)
        {
            Column = column;
            Line = line;
        }

        public Position ToPosition() {
            return new Position(8 - Line, Column - 'a');
        }

        public override string ToString() {
            return "" + Column + Line;
        }
    }
}
