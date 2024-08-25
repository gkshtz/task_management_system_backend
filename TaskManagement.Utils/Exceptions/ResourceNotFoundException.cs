using TaskManagement.Utils.Enums;

namespace TaskManagement.Utils.Exceptions
{
    public class ResourceNotFoundException : CustomException
    {
        public ResourceNotFoundException(): base(404)
        {
            Name  = ErrorNames.RESOURCE_NOT_FOUND_ERROR.ToString();
        }
        public ResourceNotFoundException(string message): base(message, 404)
        {
            Name = ErrorNames.RESOURCE_NOT_FOUND_ERROR.ToString();
        }
    }
}
