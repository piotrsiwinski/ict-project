package smarcard;

import javax.smartcardio.*;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by Piotrek on 23.04.2017.
 */
public class SmartCard {
    private CardConnector connector;
    private List<CardTerminal> connectedCardTerminals;
    private CardChannel channel;

    public SmartCard() {
        connector = new CardConnector();
    }

    public void connect(int terminalId) throws CardException {
        CardTerminal selectedTerminal = getTerminalById(terminalId);
        if (!selectedTerminal.isCardPresent()) {
            throw new CardException("Student card is not present");
        }
        channel = connector.connectToCardTerminal(selectedTerminal);
    }

    public CardTerminal getTerminalById(int terminalId) throws CardException {
        connectedCardTerminals = getConnectedCardTerminals();
        if (terminalId < 0) {
            throw new IllegalArgumentException("Terminal id has to be greater than 0");
        }
        if (connectedCardTerminals.size() == 0) {
            throw new CardException("No available Smart Card Readers");
        }
        return connectedCardTerminals.get(terminalId);
    }

    public List<CardTerminal> getConnectedCardTerminals() {
        connectedCardTerminals = new SmartCardTerminalFactory().getConnectedCardTerminals();
        return connectedCardTerminals;
    }

    public List<String> getData() throws CardException {
        openEF0002File();
        return getRawData();
    }

    private void openEF0002File() throws CardException {
        ResponseAPDU selectMfResponse = channel.transmit(new CommandAPDU(CommandHelper.CMD_SELECT_MF()));
        if (!CommandHelper.checkResponse(selectMfResponse))
            throw new CardException("## Select MF error");

        ResponseAPDU selectDfResponse = channel.transmit(new CommandAPDU(CommandHelper.CMD_SELECT_DF()));
        if (!CommandHelper.checkResponse(selectDfResponse))
            throw new CardException("## Select DF error");

        ResponseAPDU selectEf0002Response = channel.transmit(new CommandAPDU(CommandHelper.CMD_SELECT_EF0002()));
        if (!CommandHelper.checkResponse(selectEf0002Response))
            throw new CardException("## Select EF0002 error");

    }

    private List<String> getRawData() throws CardException {
        List<String> data = new ArrayList<String>() {};
        StringBuilder builder = new StringBuilder();

        ResponseAPDU readDataResponse = channel.transmit(new CommandAPDU(CommandHelper.CMD_READ_DATA()));
        byte[] responseBytes = readDataResponse.getBytes();

        for (int i = 0; i < responseBytes.length - 2; i++) {
            int code = (int) responseBytes[i];
            if (code <= 0) {
                continue;
            }
            char c = (char) responseBytes[i];
            if ((code > 31) && (code < 256)) {
                builder.append(c);
            }
            if ((code == 0x0C || code == 0x13 || code == 0x18)) {
                data.add(builder.toString());
                builder.setLength(0);
            }
        }
        return data;
    }
}
