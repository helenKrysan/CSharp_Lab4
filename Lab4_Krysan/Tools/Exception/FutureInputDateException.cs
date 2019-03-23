namespace Lab4_Krysan.Tools.Exception
{
    class FutureInputDateException : System.Exception
    {
        public FutureInputDateException()
        {
        }

        public FutureInputDateException(string message)
            : base(message)
        {
        }

        public FutureInputDateException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
