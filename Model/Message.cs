using Google.Protobuf.WellKnownTypes;

namespace DataSourceSimulator
{
    public class Message
    {
        private object userID;
        private object messageID;
        private object ackMessageID;
        private object messagetpe;
        string payload;
        Timestamp sendTime;


        public Message(object userID, object messageID, object ackMessageID, object messagetpe)
        {
            this.UserID = userID;
            this.MessageID = messageID;
            this.AckMessageID = ackMessageID;
            this.Messagetype = messagetpe;
        }

        public object UserID { get => userID; set => userID = value; }
        public object MessageID { get => messageID; set => messageID = value; }
        public object AckMessageID { get => ackMessageID; set => ackMessageID = value; }
        public object Messagetype { get => messagetpe; set => messagetpe = value; }
        public string Payload { get => payload; set => payload = value; }
        public Timestamp SendTime { get => sendTime; set => sendTime = value; }
    }
}