namespace Quiz
{
    public class QuestionPrompt
    {
        private string question;
        private string correctAnswer;

        public QuestionPrompt(string question, string answer)
        {
            this.question = question;
            this.correctAnswer = answer;
        }

        public bool Ask()
        {
            Console.WriteLine(question);
            string? userInput = Console.ReadLine()?.Trim().ToLower();

            if (userInput == correctAnswer.ToLower())
            {
                Console.WriteLine("Correct!");
                return true;
            }
            else
            {
                Console.WriteLine($"Incorrect. The correct answer was: {correctAnswer}");
                return false;
            }
        }
    }
}
