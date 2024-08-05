﻿namespace ADO.NET.Task1.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message = "Not Found") : base(message)
    {
        
    }
}
