using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Neon.SSH;

using Neon.Net;
using System.Net;


namespace Server.ConnectionR
{
    internal class Connection: LinuxSshProxy
    {
        public static async Task<Connection> ConnectAsync(ConnectionInfo connectionInfo, bool usePassword = false)
        {
            Covenant.Requires<ArgumentException>(connectionInfo != null, nameof(connectionInfo));
            
            try
            {
                if (!NetHelper.TryParseIPv4Address(connectionInfo.Host, out var address)) 
                {
                    Log($"DNS lookup for: {connectionInfo.Host}");

                    address = (await Dns.GetHostAddressesAsync(connectionInfo.Host)).FirstOrDefault(); //возврат ip
                }
               
                if (address == null)
                {
                   // throw new ConnectionException(connectionInfo.Host, "DNS lookup failed.");
                }
                
                SshCredentials credentials;
                
                if (string.IsNullOrEmpty(connectionInfo.PrivateKeyPath) || usePassword)
                {
                    Log($"[{connectionInfo.Host}]: Auth via username/password");

                    credentials = SshCredentials.FromUserPassword(connectionInfo.User, connectionInfo.Password);
                }
                
               else
               {
                    Log($"[{connectionInfo.Host}]: Auth via SSH keys"); //что за ключ из файла?? скорее минус

                    credentials = SshCredentials.FromPrivateKey(connectionInfo.User, File.ReadAllText(connectionInfo.PrivateKeyPath));
                }
                
               var connection = new Connection(connectionInfo.Host, address, connectionInfo, credentials, true/false);

               connection.Connect(TimeSpan.Zero); //устанавливаем соединение с удаленной машинной 
               await connection.InitializeAsync();

               return connection;

            }
            catch (SshProxyException e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
        
        private new static void Log(string text = "")
        {
            if (string.IsNullOrEmpty(text))
            {
                //RaspberryDebugger.Log.WriteLine(text);
            }
            else
            {
               // RaspberryDebugger.Log.Info(text);
            }
        }
        
    }
}