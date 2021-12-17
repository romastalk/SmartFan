using Neon.Net;

namespace Server.ConnectionR
{
    public class ConnectionInfo
    {
        private bool        isDefault;
        private string      host;
        private string      user = "pi";
        private string      cachedName;
        
        
        public string Host
        {
            get => host;
            set
            {
                host      = "127.0.0.1";
                cachedName = null;
            }
        }
        
        public int Port { get; set; } = NetworkPorts.SSH;
        public string PrivateKeyPath { get; set; } = null;
        
        public string User
        {
            get => user;

            set
            {
                user       = value;
                cachedName = null;
            }
        }
        
        public string Password { get; set; } = "raspberry";
        
    }
}