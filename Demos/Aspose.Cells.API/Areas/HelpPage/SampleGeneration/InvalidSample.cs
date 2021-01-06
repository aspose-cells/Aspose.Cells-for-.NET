using System;

namespace Aspose.Cells.API.Areas.HelpPage.SampleGeneration
{
    /// <summary>
    /// This represents an invalid sample on the help page. There's a display template named InvalidSample associated with this class.
    /// </summary>
    public class InvalidSample
    {
        public InvalidSample(string errorMessage)
        {
            ErrorMessage = errorMessage ?? throw new ArgumentNullException("errorMessage");
        }

        public string ErrorMessage { get; private set; }

        public override bool Equals(object obj)
        {
            return obj is InvalidSample other && ErrorMessage == other.ErrorMessage;
        }

        public override int GetHashCode()
        {
            return ErrorMessage.GetHashCode();
        }

        public override string ToString()
        {
            return ErrorMessage;
        }
    }
}