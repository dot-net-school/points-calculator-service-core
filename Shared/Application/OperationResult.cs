namespace Shared.Application;

public static class OperationResult
{
    public static bool IsSucceeded { get; private set; }
    public static string Message { get; private set; }

    static OperationResult()
    {
        IsSucceeded = false;
        Message = string.Empty;
    }

    public static string Succeeded(string message = "mission accomplished.")
    {
        IsSucceeded = true;
        Message = message;
        return message;
    }

    public static string Failed(string message)
    {
        IsSucceeded = false;
        Message = message;
        return message;
    }
}


