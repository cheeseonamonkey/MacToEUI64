using System;

public static class ByteConverter
{
    //takes a binary string, int, or byte and converts to hex
    public static string ByteToHex(string binaryString)
    {
        sbyte sbite = Convert.ToSByte(binaryString, 2);
        return ByteToHex(sbite);
    }
    public static string ByteToHex(sbyte sbite)
    {
        return ByteToHex((byte)sbite);
    }
    public static string ByteToHex(byte bite)
    {
        string hex = bite.ToString("X");
        return hex;
    }

    //takes hex as a string or int and converts to a binary string
    public static byte HexToByte(string hex)
    {
        byte bite = (byte)Convert.ToSByte(hex, 16);

        return bite;
    }
    public static byte HexToByte(int hex)
    {
        return HexToByte(hex.ToString());
    }
}