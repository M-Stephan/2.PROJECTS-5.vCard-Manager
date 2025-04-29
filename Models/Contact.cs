public class Contact
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public Contact(string contactName, string contactEmail, string contactPhone)
    {
        Name = contactName;
        Email = contactEmail;
        Phone = contactPhone;
    }

    public string ToVcf()
    {
        return $"\nBEGIN:VCARD\nFN:{Name}\nTEL:{Phone}\nEMAIL:{Email}\nEND:VCARD";
    }
}