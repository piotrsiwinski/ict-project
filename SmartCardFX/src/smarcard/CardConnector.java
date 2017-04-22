package smarcard;

import lombok.Data;
import lombok.NoArgsConstructor;

import javax.smartcardio.*;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by Piotrek on 20.04.2017.
 */
@Data
@NoArgsConstructor
public class CardConnector {

    public CardChannel connectToCardTerminal(CardTerminal terminal) throws CardException{
        return this.connectToCardTerminal(terminal, "T=0");
    }
    public CardChannel connectToCardTerminal(CardTerminal terminal, String protocol)throws CardException{
        Card card = terminal.connect(protocol);
        return card.getBasicChannel();
    }

}
