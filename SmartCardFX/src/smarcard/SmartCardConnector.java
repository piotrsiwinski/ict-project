package smarcard;

import lombok.Data;

import javax.smartcardio.*;
import java.util.List;

/**
 * Created by Piotrek on 20.04.2017.
 */
@Data
public class SmartCardConnector {
    private TerminalFactory factory;
    private List<CardTerminal> cardTerminals;

    public SmartCardConnection connect() throws CardException{
        // show the list of available terminals
        factory = TerminalFactory.getDefault();
        cardTerminals = factory.terminals().list();
        CardTerminal terminal = cardTerminals.get(0);
        Card card = terminal.connect("T=0");

//        CardChannel channel = card.getBasicChannel();
//        ResponseAPDU r = channel.transmit(new CommandAPDU(c1));

        return new SmartCardConnection(cardTerminals, terminal, card);
    }
}
