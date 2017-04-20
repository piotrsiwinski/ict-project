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
public class SmartCard {

    private SmartCardConnector smartCardConnector;
    private SmartCardConnection connection;

    public SmartCard() {
        this.smartCardConnector = new SmartCardConnector();
    }

    public void establishConnection() throws CardException{
        connection = new SmartCardConnector().connect();
    }

}
