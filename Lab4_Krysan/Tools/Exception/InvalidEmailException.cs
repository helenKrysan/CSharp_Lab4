namespace Lab4_Krysan.Tools.Exception
{
    public class InvalidEmailException : System.Exception
    {
        public InvalidEmailException()
        {
        }

        public InvalidEmailException(string message)
            : base(message)
        {
        }

        public InvalidEmailException(string message, System.Exception inner)
            : base(message, inner)
        {
        }

    }
}
