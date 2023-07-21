using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day10Assessment12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter a piece of text
            Console.WriteLine("Enter a piece of text:");
            string inputText = Console.ReadLine();


            int wordCount = CountWords(inputText);


            List<string> emailAddresses = FindEmailAddresses(inputText);


            List<string> mobileNumbers = ExtractMobileNumbers(inputText);


            Console.WriteLine("Word Count: " + wordCount);


            if (emailAddresses.Count > 0)
            {
                Console.WriteLine("Email Addresses:");
                foreach (string email in emailAddresses)
                {
                    Console.WriteLine(email);
                }
            }
            else
            {
                Console.WriteLine("No email addresses found.");
            }

            // Display Mobile Numbers (if any)
            if (mobileNumbers.Count > 0)
            {
                Console.WriteLine("Mobile Numbers:");
                foreach (string mobileNumber in mobileNumbers)
                {
                    Console.WriteLine(mobileNumber);
                }
            }
            else
            {
                Console.WriteLine("No mobile numbers found.");
            }

            // Step 4: Perform Custom Regex Search
            Console.WriteLine("Enter a custom regular expression:");
            string customRegex = Console.ReadLine();
            List<string> customResults = PerformCustomRegexSearch(inputText, customRegex);

            // Display Custom Regex Results 
            if (customResults.Count > 0)
            {
                Console.WriteLine("Custom Regex Results:");
                foreach (string result in customResults)
                {
                    Console.WriteLine(result);
                }
            }
            else
            {
                Console.WriteLine("No matches found for the custom regular expression.");
            }

            Console.ReadKey();
        }

        // Step 1: to count the words
        static int CountWords(string text)
        {
            // Define the regular expression pattern to match words (sequences of characters)
            string pattern = @"\b\w+\b";

            //I Use Regex.Matches to find all matches of the pattern in the input text
            MatchCollection matches = Regex.Matches(text, pattern);

            // Its Return the count of matches, which corresponds to the word count
            return matches.Count;
        }

        // Step 2: Find Email Addresses
        static List<string> FindEmailAddresses(string text)
        {
            // Define the regular expression pattern to match email addresses
            string pattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";

            // Use Regex.Matches to find all matches of the pattern in the input text
            MatchCollection matches = Regex.Matches(text, pattern);

            // It Create a list to store the matched email addresses
            List<string> emailAddresses = new List<string>();

            // Iterate through each match and add the value (email address) to the list
            foreach (Match match in matches)
            {
                emailAddresses.Add(match.Value);
            }

            // Return the list of email addresses
            return emailAddresses;
        }

        // Step 3: Extract Mobile Numbers
        static List<string> ExtractMobileNumbers(string text)
        {
            // Define the regular expression pattern to match mobile numbers (10 digits)
            string pattern = @"\b\d{10}\b";

            // Use Regex.Matches to find all matches of the pattern in the input text
            MatchCollection matches = Regex.Matches(text, pattern);

            // Create a list to store the matched mobile numbers
            List<string> mobileNumbers = new List<string>();

            // Iterate through each match and add the value (mobile number) to the list
            foreach (Match match in matches)
            {
                mobileNumbers.Add(match.Value);
            }

            // Return the list of mobile numbers
            return mobileNumbers;
        }

        // Step 4: Perform Custom Regex Search
        static List<string> PerformCustomRegexSearch(string text, string customRegex)
        {
            // Use the customRegex provided by the user to create the regular expression pattern
            // The customRegex should be a valid regular expression
            //Its assumes the user provides a valid regular expression.
            // It does not handle invalid regular expressions .
            string pattern = customRegex;

            //Through Use Regex.Matches to find all matches of the custom pattern in the input text
            MatchCollection matches = Regex.Matches(text, pattern);

            // This Create a list to store the custom regex search results
            List<string> results = new List<string>();

            //It  Iterate through each match and add the value (matched text) to the list
            foreach (Match match in matches)
            {
                results.Add(match.Value);
            }

            // Return the list of custom regex search results
            return results;

        }

    }

}