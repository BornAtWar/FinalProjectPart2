using System.Text.RegularExpressions;

namespace FinalProject
//Author: Demetrius Richards
//Purpose: Final Project
//Course: COMP-003A-L01
{
    class PatientIntakeForm
    {

        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to our New Patient Intake Form\nPlease fill out the upcoming instructions");
            try
            {
                ///<summary>
                ///Here we will collect the users input for thier First name and all the other things
                ///</summary>
                string firstName = InputStringWithValidation("Enter your First Name (Alphabets only): ", @"^[a-zA-Z]+$");
                string lastName = InputStringWithValidation("Enter your Last Name (Alphabets only): ", @"^[a-zA-Z]+$");
                int birthYear = InputIntWithValidation("Enter your Birth Year (1900-2024): ", 1900, 2024);
                string gender = InputStringWithValidation("Enter your Gender (M/F/O); ", @"^[MFOmfo]$", true);

                ///<summary>
                ///here will be the questionnaire
                ///</summary>
                List<string> questions = GenerateQuestions();
                List<string> responses = new List<string>();

                ///<summary>
                ///Collect the responses with loops
                ///</summary>
                Console.WriteLine("\nPlease answer the upcoming questions:");
                foreach (var question in questions)
                {
                    string response = CollectResponse(question);
                    responses.Add(response);
                }
                ///<summary>
                ///here we calculate age and convert gender to full desctription
                ///</summary> 
                int age = CalculateAge(birthYear);
                string fullGender = ConvertGender(gender);

                ///<summary>
                ///here we display profile summary and questionnaire responses
                ///</summary>
                DisplayProfileSummary(firstName, lastName, age, fullGender);
                DisplayResponses(questions, responses);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }
        /// <summary>
        /// here are the input methods with validation
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="pattern"></param>
        /// <param name="toUpperCase"></param>
        /// <returns></returns>
        private static string InputStringWithValidation(string prompt, string pattern, bool toUpperCase = false)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, pattern))
                {
                    return toUpperCase ? input.ToUpper() : input;
                }
                Console.WriteLine("Invalid input. Try again");

            }
        }

        private static int InputIntWithValidation(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int input) && input >= min && input <= max)
                {
                    return input;
                }
                Console.WriteLine($"Invalid input. Enter a value between {min} and {max}");


            }
        }

        /// <summary>
        /// here we have something that will  make questions for our questionnaire
        /// </summary>
        /// <returns></returns>
        private static List<string> GenerateQuestions()
        {
            return new List<string>
            {
                "Are you experiencing any symptoms as of right now?",
                "Have you had any surgeries in the past year?",
                "Have you been diagnosed with any chronic illnesses?",
                "Are you currently taking any type of medication?",
                "Do you have any type of allergies?",
                "Have you been hospitalized in the past year?",
                "Do you drink alcohol?",
                "Do you smoke?",
                "How often do you excercise?",
                "Does your family have a history for any major illnesses?",
            };
        }

        /// <summary>
        /// here we will collect a response with validation to make sure it is not empty
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        private static string CollectResponse(string question)
        {
            Console.WriteLine(question); string response; do
            {
                response = Console.ReadLine();
                if (string.IsNullOrEmpty(response))
                {
                    Console.WriteLine("Response cannot be null or empty. Please retry your response.");
                }
            } while (string.IsNullOrEmpty(response));
            return response;
        }

        /// <summary>
        /// calculating age
        /// </summary>
        /// <param name="birthYear"></param>
        /// <returns></returns>
        private static int CalculateAge(int birthYear)
        {
            return DateTime.Now.Year - birthYear;
        }

        /// <summary>
        /// converting gender input to the full description
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        private static string ConvertGender(string gender)
        {
            switch (gender.ToUpper())
            {
                case "M": return "Male";
                case "F": return "Female";
                case "O": return "Other not listed";
                default: return "Unknown";
            }
        }

        /// <summary>
        /// Display the users profile summary
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="age"></param>
        /// <param name="gender"></param>
        private static void DisplayProfileSummary(string firstName, string lastName, int age, string gender)
        {
            Console.WriteLine("\nProfile Summary:");
            Console.WriteLine($"Full Name: {firstName} {lastName}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Gender: {gender}");


        }
        /// <summary>
        /// We will display the questions and responses to those questions
        /// </summary>
        /// <param name="questions"></param>
        /// <param name="responses"></param>
        private static void DisplayResponses(List<string> questions, List<string> responses)
        {
            Console.WriteLine("\nQuestionnaire Responses:");
            for (int i = 0; i < questions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {questions[i]}");
                Console.WriteLine($"Response: {responses[i]}\n");

            }
        }



    }
}
