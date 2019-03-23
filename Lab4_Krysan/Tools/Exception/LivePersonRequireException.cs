namespace Lab4_Krysan.Tools.Exception
{
    class LivePersonRequireException : System.Exception
    {
        public LivePersonRequireException()
        {
        }

        public LivePersonRequireException(string message)
            : base(message)
        {
        }

        public LivePersonRequireException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
