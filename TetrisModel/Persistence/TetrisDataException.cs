﻿namespace TetrisModel.Persistence;

public class TetrisDataException : Exception
{
    public TetrisDataException(){}
    public TetrisDataException(string message) : base(message){}
}