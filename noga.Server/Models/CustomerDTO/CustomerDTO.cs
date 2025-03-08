namespace NOGA.Server.Models.CustomerDTO
{
    public class CustomerDTO
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string CustomerNumber { get; set; }
            public List<AddressDTO> Addresses { get; set; }
            public List<ContactDTO> Contacts { get; set; }

    }
}
