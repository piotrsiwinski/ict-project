package sample;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.Alert;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import smarcard.CardConnector;
import smarcard.Models.Student;
import smarcard.SmartCard;
import smarcard.SmartCardTerminalFactory;

import javax.smartcardio.CardTerminal;
import java.util.List;

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
                builder.append(terminal).append("\n\n");
            }

//            if(c.getConnectedCardTerminals().size() ==0){
//                this.availableTerminalsLabel.setText("No smart card readers connected");
//            }
            SmartCard card = new SmartCard();
            card.connect(0);

            Student studentData = card.getData();
            builder.append(studentData.toString()).append("\n");

            this.availableTerminalsLabel.setText(builder.toString());

            Alert alert = new Alert(Alert.AlertType.INFORMATION);
            alert.setTitle("Student data");
            alert.setHeaderText("");
            alert.setContentText(studentData.toString());
            alert.showAndWait();
        } catch (Exception e) {
            this.availableTerminalsLabel.setText("");
            e.printStackTrace();
            Alert alert = new Alert(Alert.AlertType.ERROR);
            alert.setTitle("Error occured");
            alert.setHeaderText("Oops, error occured");
            alert.setContentText(e.getMessage());
            alert.showAndWait();
        }
    }
}
