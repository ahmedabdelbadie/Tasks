namespace Task.PersonAddress.DTO.DTOs;

public class PersonDTO
{
    public int PersonId { get; set; }
    public string Personname { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    public AddressDTO Address { get; set; }
}
