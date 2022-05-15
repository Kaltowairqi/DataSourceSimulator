namespace DataSourceSimulator
{
    public class CommunicationManager
    {
        public CommunicationManager(PacketManager packetManager)
        {
            PacketManager = packetManager;
        }

        public PacketManager PacketManager { get; }
    }
}