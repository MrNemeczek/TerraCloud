namespace TerraCloud.Application.Exceptions
{
    public sealed class ApplicationException : Exception
    {
        public ApplicationException() : base($"Application error")
        {
        }
    }
}
