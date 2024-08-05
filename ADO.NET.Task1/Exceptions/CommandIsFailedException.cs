namespace ADO.NET.Task1.Exceptions;

public class CommandIsFailedException : Exception
{
    public CommandIsFailedException(string message = "Command is failed") :  base(message)
    {
        
    }
}
