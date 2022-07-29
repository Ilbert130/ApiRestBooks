using System.Reflection;
using System.Runtime.Serialization;

namespace ApiRestBooks.Utilities
{
    public class ResponseMessageEnum
    {
        public enum ResponseMessageEnumBook
        {
            [EnumMember(Value = "Success Process")]
            GetSuccess,
            [EnumMember(Value = "An Error Has Occurred When Obtaining The Data")]
            GetGenericError,
            [EnumMember(Value = "Data Not Found")]
            GetNotData,
            [EnumMember(Value = "The Register Already Exist")]
            GetDataExist,
            [EnumMember(Value = "The Data Sent Doesn't Content The Correct Format Or Is Null")]
            GetDataNull
        }

        public static String GetEnumMemberValue<T>(T value)
        where T : struct, IConvertible
        {
            return typeof(T)
                .GetTypeInfo()
                .DeclaredMembers
                .SingleOrDefault(x => x.Name == value.ToString())
                ?.GetCustomAttribute<EnumMemberAttribute>(false)
                ?.Value;
        }
    }
}
