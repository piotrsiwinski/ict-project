package sample.MainWindow;

import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.google.gson.Gson;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Alert;
import javafx.scene.control.Button;
import javafx.scene.control.ComboBox;
import javafx.scene.control.Label;

import jdk.nashorn.internal.parser.JSONParser;
import services.SubjectService;
import smarcard.CardConnector;
import smarcard.Models.Student;
import smarcard.Models.Subject;
import smarcard.Models.SubjectsList;
import smarcard.SmartCard;

import javax.smartcardio.CardTerminal;
import java.io.FileReader;
import java.io.IOException;
import java.net.URL;
import java.util.*;
import java.util.stream.Collector;
import java.util.stream.Collectors;


/**
 * Created by Piotrek on 27.04.2017.
 */
public class MainWindowController implements Initializable {
    @FXML
    private Button displayTerminalsButton;
    @FXML
    private Label availableTerminalsLabel;
    @FXML
    private ComboBox subjectComboBox;

    private ObservableList<String> items = FXCollections.observableArrayList();

    private CardConnector smartCard;

    private void initialize() {
        if (this.subjectComboBox != null) {
            this.subjectComboBox.setItems(this.items);
        }
    }

    public void getAvailableEvents(){
        SubjectService subjectService = new SubjectService();
        String result = subjectService.getSubjects();

        Gson gson = new Gson();
        Subject[] subjects = gson.fromJson(result, Subject[].class);
        List<String> arr = Arrays.stream(subjects).map(x -> x.getSubjectName()).collect(Collectors.toList());

        this.items = FXCollections.observableArrayList(arr.toArray(new String[0]));
        this.subjectComboBox.setItems(items);

    }

    public void onDisplayTerminalsButtonClick(ActionEvent actionEvent) {
        try {
            StringBuilder builder = new StringBuilder();
            builder.append("Available terminals: \n\n");

            SmartCard c = new SmartCard();
            for (CardTerminal terminal : c.getConnectedCardTerminals()) {
                builder.append(terminal).append("\n\n");
            }

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
            e.printStackTrace();
            this.availableTerminalsLabel.setText("");
            //e.printStackTrace();
            Alert alert = new Alert(Alert.AlertType.ERROR);
            alert.setTitle("Error occured");
            alert.setHeaderText("Oops, error occured");
            alert.setContentText(e.getMessage());
            alert.showAndWait();
        }
    }

    @Override
    public void initialize(URL location, ResourceBundle resources) {
        this.initialize();
    }

    public void onRefreshClick(ActionEvent actionEvent) {
        this.getAvailableEvents();
    }
}
