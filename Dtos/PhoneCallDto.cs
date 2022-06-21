namespace CallLogging.Dtos
{
    public class PhoneCallDto : BaseDto
    {
        public DateTime? DateStart { get; set; }        
        public DateTime? DateEnd { get; set; }
        public int CallLength { get; set; }

        //TODO: do two dto instead following rows
        public int? CallerId { get; set; }
        public string? NameCaller { get; set; }
        public string? SurnameCaller { get; set; }
        public int? PhoneNumberCallerId { get; set; }
        public string? PhoneNumberCaller { get; set; }

        public int? RecipientId { get; set; }
        public string? NameRecipient { get; set; }
        public string? SurnameRecipient { get; set; }
        public int? PhoneNumberRecipientId { get; set; }
        public string? PhoneNumberRecipient { get; set; }
    }
}
