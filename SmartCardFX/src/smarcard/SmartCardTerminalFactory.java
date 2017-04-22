package smarcard;

import lombok.Data;

import javax.smartcardio.*;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by Piotrek on 20.04.2017.
 */
@Data
public class SmartCardTerminalFactory {
    private TerminalFactory factory;

    public SmartCardTerminalFactory() {
        try {
            init();
        } catch(CardException e){
            e.printStackTrace();
        }
    }

    private void init() throws CardException{
        factory = TerminalFactory.getDefault();
    }
    
    public List<CardTerminal> getConnectedCardTerminals(){
        try{
            return factory.terminals().list();
        }
        catch (CardException e){
            return new ArrayList<>();
        }
    }
}
