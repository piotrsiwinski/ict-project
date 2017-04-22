package smarcard;

import lombok.Data;

import javax.smartcardio.CardChannel;
import javax.smartcardio.CardException;
import javax.smartcardio.CardTerminal;
import java.util.List;

/**
 * Created by Piotrek on 23.04.2017.
 */
@Data
public class SmartCard {
    private CardConnector connector;
    private SmartCardTerminalFactory factory;
    private List<CardTerminal> connectedCardTerminals;
    private CardChannel channel;

    public SmartCard() {
        factory = new SmartCardTerminalFactory();
        connector = new CardConnector();
        connectedCardTerminals = factory.getConnectedCardTerminals();
    }

    public void connect(){
        this.connect(0);
    }

    public void connect(int terminalId){
        CardTerminal selectedTerminal = connectedCardTerminals.get(terminalId);
        try {
            channel = connector.connectToCardTerminal(selectedTerminal);
        } catch (CardException e) {
            //Cant connect to terminal (error while obtaining channel)
            e.printStackTrace();
        }
    }
}
