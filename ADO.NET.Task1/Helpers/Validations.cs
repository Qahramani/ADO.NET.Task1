namespace ADO.NET.Task1.Helpers;

public static class Validations
{
    public static bool IsEmailCorrect(string email)
    {
        if (email.Length < 8)
        {
            Colored.WriteLine("Email length should be >= 8", ConsoleColor.DarkRed);
            return false;
        }
        bool IsDigit = false;
        bool IsLetter = false;
        int counter = 0;
        foreach (char c in email)
        {
            if (char.IsDigit(c))
                IsDigit = true;
            else if(char.IsLetter(c))
                IsLetter = true;
            else if (c is '@')
                counter++;
            

        }
        if (counter != 1)
        {
            Colored.WriteLine("Email should contain 1 @ ", ConsoleColor.DarkRed);
            return false;
        }
        if (!IsLetter || !IsDigit)
        {
            Colored.WriteLine("Email should contain (at least 1 letter, 1 digit and only 1 @) ", ConsoleColor.DarkRed);
            return false;

        }
        return true;
    }
}
