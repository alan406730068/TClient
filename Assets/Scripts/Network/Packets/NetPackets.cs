using LiteNetLib.Utils;

namespace Network.Packets
{
    public enum PacketType : byte
    {
        #region Client to Server
        C2S_Invalid = 0,
        C2S_AuthRequest = 1,
        #endregion

        #region Server to Client
        S2C_OnAuth = 100,
        #endregion
    }

    public interface INetPacket : INetSerializable
    {
        PacketType Type { get; }
    }
}
