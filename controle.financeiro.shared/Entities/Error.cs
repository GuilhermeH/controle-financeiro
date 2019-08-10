namespace controle.financeiro.shared.Entities
{
    public class Error
    {
        public Error(string property, string message)
        {
            Property = property;
            Message = message;
        }

        public string Property { get; private set; }
        public string Message { get; private set; }
    }
}