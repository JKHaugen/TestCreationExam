using NUnit.Framework;
using TestCreationExam.TestCases.Common;

namespace TestCreationExam.TestCases
{
    class StudentRegistrationForm : BaseTestLocal
    {
        [Test]
        [Category("Student Registration Form")]
        public void StudentRegistrationFormCase()
        {
            // Steps to automate:
            // 1. Navigate to https://demoqa.com/automation-practice-form
            // 2. Fill in first name with a random string [a-zA-Z] of length 6
            // 3. Fill in last name with a random string [a-zA-Z] of length 8
            // 4. Fill in email, "<generated first name>.<generated last name>@example.com"
            // 5. Randomly assign a gender from the three options
            // 6. Fill in mobile using <3 random digits> + 555 + <4 random digits>
            // 7. Fill in date of birth with a random day/month in 2000
            // 8. Select one of the three hobbies at random
            // 9. Set the current address to, "<4 random digits> Main St"
            // 10. Set the state to "NCR"
            // 11. Set the city to "Delhi"
            // 12. Click Submit
            // 13. Using NUnit asserts, assert each of the form submission results against what was entered
            //
            // NOTE:
            // - Use the provided WebDriver methods in BasePageLocal
            // - Document all methods using XML documentation, https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/

        }
    }
}