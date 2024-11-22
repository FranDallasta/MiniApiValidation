using Microsoft.Data.SqlClient;

public class AuthService
{
    public bool LoginUser(string username, string password)
    {
        if (!ValidationHelpers.IsValidInput(username) || !ValidationHelpers.IsValidInput(password))
        {
            return false;
        }

        string query = "SELECT COUNT(1) FROM Users WHERE Username = @Username AND Password = @Password";

        using (var connection = new SqlConnection("YourConnectionStringHere"))
        {
            using (var command = new Microsoft.Data.SqlClient.SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
    }

    public void TestSqlInjection()
    {
        string maliciousInput = "admin' OR '1'='1"; // SQL injection attempt
        bool result = LoginUser(maliciousInput, "anyPassword");

        Console.WriteLine(result ? "SQL Injection Test Failed" : "SQL Injection Test Passed");
    }

    public void TestXssInput()
    {
        string maliciousInput = "<script>alert('XSS');</script>"; // XSS attempt
        bool isValid = ValidationHelpers.IsValidInput(maliciousInput);

        Console.WriteLine(isValid ? "XSS Test Failed" : "XSS Test Passed");
    }


}
