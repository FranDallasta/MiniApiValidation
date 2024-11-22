public static class ValidationHelpers
{
    public static bool IsValidInput(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return false;
        }

        return input.All(char.IsLetterOrDigit);
    }
}
