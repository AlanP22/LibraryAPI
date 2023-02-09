using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryAPI
{
    // This is custom value converter that changes male and female to boolean values and the other way 
    public class GenderToNumericCoverter : ValueConverter<string, bool>
    {

        public GenderToNumericCoverter() : base(input => input == "male", output => output ? "male" : "female", mappingHints: null)
        {
        }
    }
}

