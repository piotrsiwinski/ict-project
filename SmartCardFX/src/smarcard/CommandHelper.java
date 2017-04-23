package smarcard;

import javax.smartcardio.ResponseAPDU;

/**
 * Created by Piotrek on 23.04.2017.
 */
public class CommandHelper {

    // Komenda APDU wybierajaca wezel glowny MF
    public static byte[] CMD_SELECT_MF()
    {
        return new byte[]{
                (byte) 0x00, // CLA
                (byte) 0xA4, // INS
                (byte) 0x00, // P1
                (byte) 0x0C, // P2
                (byte) 0x02, // Lc
                (byte) 0x3F, // FID 1 (high)
                (byte) 0x00}; // FID 2 (low)
    }

    // Komenda APDU wybierajaca katalog DF (po nazwie)
    public static byte[] CMD_SELECT_DF(){
        return new byte[]{
                (byte) 0x00, // CLA
                (byte) 0xA4, // INS
                (byte) 0x04, // P1
                (byte) 0x00, // P2
                (byte) 0x07, // Lc
                (byte) 0xD6, // AID 1 (high)
                (byte) 0x16, // AID 2
                (byte) 0x00, // AID 3
                (byte) 0x00, // AID 4
                (byte) 0x30, // AID 5 (low)
                (byte) 0x01, // PIX 1 (high)
                (byte) 0x01}; // PIX 2 (low)
    }

    // Komenda APDU wybierajaca plik EF o FID 0x0002 z katalogu DF
    public static byte[] CMD_SELECT_EF0002(){
        return new byte[] {
                (byte) 0x00, // CLA
                (byte) 0xA4, // INS
                (byte) 0x00, // P1
                (byte) 0x0C, // P2
                (byte) 0x02, // Lc
                (byte) 0x00, // FID 1 (high)
                (byte) 0x02}; // FID 2 (low)
    }

    public static byte[] CMD_READ_DATA(){
        return new byte[]{
        (byte) 0x00, // CLA
        (byte) 0xB0, // INS
        (byte) 0x00, // P1
        (byte) 0x00, // P2
        (byte) 0xFF // Lc
        };
    }

    public static boolean checkResponse(ResponseAPDU responseAPDU){
        byte[] response = responseAPDU.getBytes();
        if (response[response.length - 2] == (byte) 0x90 && response[response.length - 1] == (byte) 0x00) {
            return true;
        }
        return false;
    }

}
