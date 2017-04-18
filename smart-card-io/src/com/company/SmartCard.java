package com.company;

import javax.smartcardio.*;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by Piotrek on 18.04.2017.
 */
public class SmartCard {
    private TerminalFactory terminalFactory;

    private Card card;
    private CardChannel cardChannel;
    private int[] result_len;
    private boolean[] result_is_string;
    public SmartCard()throws Exception{
        getConnectedTerminals();
        establishConnectionWithCard();
        readEFData();


    }

    private List<CardTerminal> getConnectedTerminals() throws Exception{
        terminalFactory = TerminalFactory.getDefault();
        List<CardTerminal> terminalList = new ArrayList<CardTerminal>();
        try{
            terminalList = terminalFactory.terminals().list();
        }catch (CardException e){

        }
        return terminalList;
    }

    private void establishConnectionWithCard()throws Exception{
        List<CardTerminal> terminals = getConnectedTerminals();
        CardTerminal cardTerminal = terminals.get(0);
        card = cardTerminal.connect("T=0");
        cardChannel = card.getBasicChannel();
    }

    /*private void readCardData() throws Exception{
        byte[] read_command = new byte[5];
        CommandAPDU commandAPDU;
        ResponseAPDU responseAPDU;

        //odczytanie danych
        for(int offset = 0; offset < 2; offset++){
            read_command[0] = (byte)0x00; // CLA
            read_command[1] = (byte)0xB0; // INS
            read_command[2] = (byte)(((offset) >> 8) & 0xFF); // P1
            read_command[3] = (byte)((offset) & 0xFF); // P2
            read_command[4] = (byte)0xFF; // Lc
            commandAPDU = new CommandAPDU(read_command);
            responseAPDU = cardChannel.transmit(commandAPDU);
            byte[] responseBytes = responseAPDU.getBytes();

            int lp = 0;
            int nr_stringu = 0;
            String[] result = new String[50];
            result_len = new int[50];
            result_is_string = new boolean[50];
            boolean hex_0x0C = false;
            boolean last_byte_control = false;
            int offset =0;
            for(int i=0; i < responseBytes.length - 2; i++){
                int code = (int) responseBytes[i];
                if(code == 0){
                    continue;
                }
                lp++;
                char c = (char) responseBytes[i];
                if(code > 31 && code < 256){
                    result[nr_stringu] += c;
                }
                if(hex_0x0C){
                    result_len[nr_stringu] = code;
                    hex_0x0C = false;
                }

                if (((code == (int)0x0C) || (code == (int)0x13) || (code == (int)0x18)) && (last_byte_control == false)) {
                    last_byte_control = true; // zeby nie traktowal dlugosci danych w rekordzie jako bajtu kontrolnego
                    nr_stringu++;

                    if (code == (int)0x0C) {
                        result_is_string[nr_stringu] = true;
                    } else {
                        result_is_string[nr_stringu] = false;
                    }
                    hex_0x0C = true;
                } else {
                    last_byte_control = false;
                }
            }
            offset += 64;
        }
    }*/

    private boolean readEFData() throws Exception {
        boolean success = true;
        byte[] read_comm;
        CommandAPDU apdu_comm3;
        ResponseAPDU response3;
        byte[] dane = new byte[256];
        int offset = 0;
        String res = "";
        int lp = 0;
        read_comm = new byte[5]; int i;
        String[] result = new String[50];  // parsuje rekordy do stringa

        result_len = new int[50];  // odcztuje dlugosci stringow
        result_is_string = new boolean[50];  // zapisuje, czy rekord to string (0x0C), czy int (0x13)
        int nr_stringu = 0;

        // odczytane 2x danych po 256 bajtow
        for (int offs = 0; offs<2; offs++) {
            read_comm[0] = (byte)0x00; // CLA
            read_comm[1] = (byte)0xB0; // INS
            read_comm[2] = (byte)(((offset) >> 8) & 0xFF); // P1
            read_comm[3] = (byte)((offset) & 0xFF); // P2
            read_comm[4] = (byte)0xFF; // Lc
            // wysylanie komendy czytania 256 bajtow...
            apdu_comm3 = new CommandAPDU(read_comm);
            response3 = cardChannel.transmit(apdu_comm3);
            byte[] tmp_dane = response3.getBytes();
            boolean last_byte_control = false, hex_0x0C = false;
            for (i=0; i<tmp_dane.length-2; i++) {
                int code = (int)tmp_dane[i];
                if (code > 0) {
                    lp++;
                    char c = (char)tmp_dane[i];
                    if ((code>31) && (code < 256)) {
                        if (hex_0x0C == false) {
                            result[nr_stringu] += c;
                        }
                    }
                    if (hex_0x0C == true) {
                        result_len[nr_stringu] = code;
                        hex_0x0C = false;
                    }
                    if (((code == (int)0x0C) || (code == (int)0x13) || (code == (int)0x18)) && (last_byte_control == false)) {
                        last_byte_control = true; // zeby nie traktowal dlugosci danych w rekordzie jako bajtu kontrolnego
                        nr_stringu++;

                        if (code == (int)0x0C) {
                            result_is_string[nr_stringu] = true;
                        } else {
                            result_is_string[nr_stringu] = false;
                        }
                        hex_0x0C = true;
                    } else {
                        last_byte_control = false;
                    }
                }
            }
            offset += 64;
        }
        //koniec dwukrotnego odczytu danych
        // formatowanie odczytanego strumienia bajtow
        int size, nr_danych=0;
        String[] dane_karty = new String[9];
        String form_data;

        for (i = 0; i<result.length; i++) {
            if (result[i] != null) {
                size = 4+result_len[i];
                if (size > result[i].length()) {
                    size = result[i].length();
                }
                form_data = result[i].substring(4,size);
                if ((i>0) && (nr_danych < 9)) {
                    if (i != 5) {
                        dane_karty[nr_danych] = form_data;
                        nr_danych++;
                    } else if ((i == 5) && (result_is_string[i] == true)) { // drugie imie
                        dane_karty[nr_danych-1] += " "+form_data;
                    } else {
                        dane_karty[nr_danych] = form_data;
                        nr_danych++;
                    }
                }
            }
        }
        // sformatowanie daty waznosci karty na RRRR-MM-DD
        dane_karty[7] = dane_karty[7].substring(0,4)+"-"+dane_karty[7].substring(4,6)+"-"+dane_karty[7].substring(6,8);
        return success;
    }
}
