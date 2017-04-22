package sample;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.Alert;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import smarcard.CardConnector;
import smarcard.SmartCard;
import smarcard.SmartCardTerminalFactory;

import javax.smartcardio.CardTerminal;

public class Controller {
    @FXML
    private Button displayTerminalsButton;
    @FXML
    private Label availableTerminalsLabel;

    private CardConnector smartCard;


    public Controller() {
        this.smartCard = new CardConnector();
    }

    public void onDisplayTerminalsButtonClick(ActionEvent actionEvent) {
        try {
            StringBuilder builder = new StringBuilder();
            builder.append("Available terminals: \n\n");

            SmartCard c = new SmartCard();
            for (CardTerminal terminal : c.getConnectedCardTerminals()) {
                builder.append(terminal + "\n");
            }
            this.availableTerminalsLabel.setText(builder.toString());
            if(c.getConnectedCardTerminals().size() ==0){
                this.availableTerminalsLabel.setText("No smart card readers connected");
            }
            new SmartCard().connect(0);

            Alert alert = new Alert(Alert.AlertType.INFORMATION);
            alert.setTitle("Ok");
            alert.setHeaderText("Passed");
            alert.setContentText("Ok");
            alert.showAndWait();

        } catch (Exception e) {
            e.printStackTrace();
            Alert alert = new Alert(Alert.AlertType.ERROR);
            alert.setTitle("Error occured");
            alert.setHeaderText("Oops, error occured");
            alert.setContentText(e.getMessage());
            alert.showAndWait();
        }
    }
}
