package smarcard;

import lombok.AllArgsConstructor;
import lombok.Data;

import javax.smartcardio.Card;
import javax.smartcardio.CardTerminal;
import java.util.List;

/**
 * Created by Piotrek on 20.04.2017.
 */
@Data
@AllArgsConstructor
public class SmartCardConnection {
    private List<CardTerminal> cardTerminals;
    private CardTerminal selectedCardTerminal;
    private Card card;
}
