package smarcard;

import lombok.Data;

import javax.smartcardio.*;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by Piotrek on 20.04.2017.
 */
@Data
public class SmartCard {
    private List<CardTerminal> cardTerminals = new ArrayList<CardTerminal>();

    public void connect() throws Exception{
        // show the list of available terminals
        TerminalFactory factory = TerminalFactory.getDefault();
        cardTerminals = factory.terminals().list();
        System.out.println("Terminals: " + cardTerminals);
        // get the first terminal
        CardTerminal terminal = cardTerminals.get(0);
        // establish a connection with the card
        Card card = terminal.connect("T=0");
        System.out.println("card: " + card);
        //CardChannel channel = card.getBasicChannel();
        //ResponseAPDU responseAPDU = channel.transmit(new CommandAPDU(new byte[]{}));
//        System.out.println("response: " + toString(responseAPDU.getBytes()));
        // disconnect
        card.disconnect(false);
    }
}
