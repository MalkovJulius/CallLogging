namespace CallLogging.Dtos
{
    public class PhoneNumberDto : BaseDto
    {
        public string PhoneNumber { get; set; }

        public int OwnerId { get; set; }
        public string NameOwner { get; set; }
        public string SurnameOwner { get; set; }
    }
}
