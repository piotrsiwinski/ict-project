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
    }

    public void connect() throws CardException{
        this.connect(0);
    }

    public  CardTerminal getTerminalById(int terminalId) throws CardException{
        connectedCardTerminals = getConnectedCardTerminals();
        if(terminalId < 0){
            throw new IllegalArgumentException("Terminal id has to be greater than 0");
        }
        if(connectedCardTerminals.size() == 0){
            throw new CardException("No available Smart Card Readers");
        }
        return connectedCardTerminals.get(terminalId);
    }

    public List<CardTerminal> getConnectedCardTerminals(){
        connectedCardTerminals = factory.getConnectedCardTerminals();
        return connectedCardTerminals;
    }

    public void connect(int terminalId) throws CardException{
        CardTerminal selectedTerminal = getTerminalById(terminalId);
        if(!selectedTerminal.isCardPresent()){
            throw new CardException("Student card is not present");
        }
        try {
            channel = connector.connectToCardTerminal(selectedTerminal);
        } catch (CardException e) {
            throw new CardException("###Error in connecting to terminal, during obtaining CardChannel");
        }
    }
}
