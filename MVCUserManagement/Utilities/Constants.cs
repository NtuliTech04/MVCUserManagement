namespace UserManagement.Utilities
{
    public class RegexExpression
    {
        //Title case text format that also accepts numerics.
        public const string TitleNumericCase = "[A-Z0-9][A-Za-z0-9]*(\\s[A-Z0-9][A-Za-z0-9]*)*$";

        //Sentence case text format
        public const string SentenceCase = "[A-Z][a-zA-Z0-9',. -:;?\"]*(\\s[a-zA-Z0-9',. -:;?\"]+)*$";

        //Proper case text format
        public const string ProperCase = "[A-Z][a-z]*(\\s[A-Z][a-z]*)*$";

        //Email address text format
        public const string EmailRegex = @"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,4})+$";

        //Password text format
        public const string PasswordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,20}$";

        //Supported image regex
        public const string ImageRegex = @"(?i:^.*\.(jpg|png|jpeg)$)";

    }

    public class MediaConstants
    {
        //Max size for images
        public const int ImageMaxBytes = 2097152;    //2097152 Bytes - 2 MegaBytes
        public const int ImageMaxMegaBytes = ImageMaxBytes / ToMegabytes;

        //Value to convert bytes to megabytes
        public const int ToMegabytes = 1048576;
    }

}