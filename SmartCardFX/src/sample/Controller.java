package sample;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.Alert;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import smarcard.SmartCard;

import javax.smartcardio.CardTerminal;
import java.util.List;

public class Controller {
    @FXML
    private Button displayTerminalsButton;
    @FXML
    private Label availableTerminalsLabel;

    private SmartCard smartCard;


    public Controller() {
        this.smartCard = new SmartCard();
    }

    public void onDisplayTerminalsButtonClick(ActionEvent actionEvent) {
        try {
            smartCard.establishConnection();
            List<CardTerminal> cardTerminals = smartCard.getConnection().getCardTerminals();
            StringBuilder builder = new StringBuilder();
            builder.append("Available terminals: \n\n");
            for (CardTerminal terminal : cardTerminals) {
                builder.append(terminal + "\n");
            }
            this.availableTerminalsLabel.setText(builder.toString());

        } catch (Exception e) {
            this.availableTerminalsLabel.setText("No smart card readers connected");
        }
    }
}
