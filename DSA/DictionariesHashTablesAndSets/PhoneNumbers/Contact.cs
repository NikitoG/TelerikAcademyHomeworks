namespace PhoneNumbers
{
    public class Contact
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string NickName { get; set; }

        public string Town { get; set; }

        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} | {4} | {5}", this.FirstName, this.MiddleName, this.LastName, this.NickName, this.Town, this.PhoneNumber);
        }
    }
}
