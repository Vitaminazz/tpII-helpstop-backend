using System;



namespace HelpApp.Domain.Validation
{
    internal class DomainExceptionValidation : Exception
    {
        public DomainExceptionValidation(string error) : base(error) { }
        public static void when(bool haserror, string error)
        {
            if (haserror)
            {
                throw new DomainExceptionValidation(error);
            }
        }
    }
}
