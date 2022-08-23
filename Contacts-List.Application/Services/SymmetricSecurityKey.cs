namespace Contacts_List.Application.Services
{
    internal class SymmetricSecurityKey
    {
        private byte[] vs;

        public SymmetricSecurityKey(byte[] vs)
        {
            this.vs = vs;
        }
    }
}