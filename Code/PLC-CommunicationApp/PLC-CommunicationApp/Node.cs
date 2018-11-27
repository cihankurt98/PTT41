using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PLC_CommunicationApp
{

    public class Node
    {
        private string message;
        public string Message { get => String.Copy(message); set { message = value ?? throw new ArgumentNullException("Message"); } }
        
        public Node Next { get; set; } 

        public Node()
        {
            Message = String.Empty;
            Next = null;
        }
    }
}
