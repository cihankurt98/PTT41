using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLC_CommunicationApp
{
    public class RollingBuffer
    {
        public Node Head { get; private set; }

        public Node Writer { get; private set; }
        public Node Reader { get; private set; }

        public RollingBuffer(int size)
        {
            if(size > 255 || size < 0)
            { throw new ArgumentOutOfRangeException("size"); }

            Head = new Node();
            Node current = Head;

            for(int i = 0; i < size; i++)
            {
                current.Next = new Node();
                current = current.Next;
            }
            current.Next = Head;

            Writer = Head;
            Reader = Head;
        }

        public string Read()
        {
            string message;

            if (Reader == Writer)
            {
                message = String.Empty;
                return message;
            }

            message = Reader.Message;
            Reader = Reader.Next;

            return message;
        }

        public void Write(string message)
        {
            if (Writer.Next == Reader)
            {
                Reader = Reader.Next;
            }
            Writer = Writer.Next;
            Writer.Message = message;
        }
    }
}
