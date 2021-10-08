using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.DataStructure
{
	public class Category : IComparable
	{
		#region Constractions
		public Category(string v, MessageType incoming, MessageTopic subscribe)
		{
			message = v;
			messageType = incoming;
			messageTopic = subscribe;
		}
		#endregion
		#region Property
		public string message { get; set; }
		public MessageType messageType { get; set; }
		public MessageTopic messageTopic { get; set; }
		#endregion
		#region Operators
		public static bool operator >(Category a, Category b)
        {
            return a.CompareTo(b) == 1;
        }
        public static bool operator <(Category a, Category b)
        {
            return a.CompareTo(b) == -1;
        }

        public static bool operator >=(Category a, Category b)
        {
            return (a.CompareTo(b) == 1 || a.CompareTo(b) == 0);
        }

        public static bool operator <=(Category a, Category b)
        {
            return (a.CompareTo(b) == -1 || a.CompareTo(b) == 0);
        }

        public static bool operator ==(Category a, Category b)
        {
            return a.CompareTo(b) == 0;
        }

        public static bool operator !=(Category a, Category b)
        {
            return a.CompareTo(b) != 0;
        }
		#endregion
		#region Methods
		public int CompareTo(object obj)
		{
            try
            {
                Category c = obj as Category;
                // Сначала сравниваем по Message
                if (String.Compare(message, c.message) < 0)
                {
                    return -1;
                }
                else
                {
                    if (String.Compare(message, c.message) == 0)
                    {
                        // Потом сравниваем по типу сообщения
                        if (messageType < c.messageType)
                        {
                            return -1;
                        }
                        else
                        {
                            if (messageType == c.messageType)
                            {
                                // В конце сравниваем по теме сообщения
                                if (messageTopic < c.messageTopic)
                                {
                                    return -1;
                                }
                                else
                                {
                                    if (messageTopic == c.messageTopic)
                                    {
                                        return 0;
                                    }
                                    else
                                    {
                                        return 1;
                                    }
                                }
                            }
                            else
                            {
                                return 1;
                            }
                        }
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            catch (NullReferenceException)
            {
                return -1;
            }
        }
        public override string ToString()
        {
            return String.Format("{0}.{1}.{2}", message, messageType, messageTopic);
        }
        public override bool Equals(object obj)
        {
            try
            {
                Category c = obj as Category;
                return (this == c);
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }
        #endregion

    }
}
