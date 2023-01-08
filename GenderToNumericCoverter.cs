using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryAPI
{
    public class GenderToNumericConverter : ValueConverter<string, int>
    {
        public GenderToNumericConverter() : base(input =>
        {
            if (input == "male")
            {
                return 1;
            }
            else if (input == "female")
            {
                return 0;
            }
            else
            {
                throw new Exception("Invalid input. Insert male or female");
            }
        }, output => output == 1 ? "male" : output == 0 ? "female" : throw new Exception("Invalid output. Insert 0 or 1"),
        mappingHints: null)
        {

        }
    }
}

