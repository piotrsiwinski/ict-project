package sample.MainWindow;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Alert;
import javafx.scene.control.Button;
import javafx.scene.control.ComboBox;
import javafx.scene.control.Label;
import services.SubjectService;
import smarcard.CardConnector;
import smarcard.Models.Event;
import smarcard.Models.Student;
import smarcard.Models.Subject;
import smarcard.SmartCard;

import javax.smartcardio.CardTerminal;
import java.net.URL;
import java.util.Arrays;
import java.util.List;
import java.util.ResourceBundle;
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
    private Subject[] subjects;
    private SubjectService subjectService = new SubjectService();
    private Student studentData;

    @Override
    public void initialize(URL location, ResourceBundle resources) {
        this.initialize();
    }

    private void initialize() {
        if (this.subjectComboBox != null) {
            this.subjectComboBox.setItems(this.items);
        }
    }

    public void onDisplayTerminalsButtonClick(ActionEvent actionEvent) {
        this.getStudentData();
    }

    public void onRefreshClick(ActionEvent actionEvent) {
        this.getAvailableEvents();
    }

    public void onSendButton(ActionEvent actionEvent) {
        this.sendEvent();
    }

    private void getStudentData() {
        try {
            StringBuilder builder = new StringBuilder();
            builder.append("Available terminals: \n\n");

            SmartCard c = new SmartCard();
            for (CardTerminal terminal : c.getConnectedCardTerminals()) {
                builder.append(terminal).append("\n\n");
            }

            SmartCard card = new SmartCard();
            card.connect(0);

            studentData = card.getData();
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

    private void getAvailableEvents() {
        String result = subjectService.getSubjects();
        try {
//            Gson gson = new Gson();
            Gson gson = new GsonBuilder().setDateFormat("yyyy-MM-dd").create();
            this.subjects = gson.fromJson(result, Subject[].class);
            List<String> arr = Arrays.stream(subjects).map(x -> x.describeSubject()).collect(Collectors.toList());


            this.items = FXCollections.observableArrayList(arr.toArray(new String[0]));
            this.subjectComboBox.setItems(items);
        } catch (Exception e) {
            Alert alert = new Alert(Alert.AlertType.ERROR);
            alert.setTitle("Error occured");
            alert.setHeaderText("No events available");
            alert.setContentText(e.getMessage());
            alert.showAndWait();
        }


    }

    private void sendEvent() {
        try {
            int selectedIndex = this.subjectComboBox.getSelectionModel().getSelectedIndex();
            Subject selectedSubject = subjects[selectedIndex];
//            Event event = new Event("112233", selectedSubject.getId());
            Event event = new Event(this.studentData.getIndexNumber(), selectedSubject.getId());

            int response = this.subjectService.addEventToStudent(event);
            if (200 <= response && response < 300) {
                Alert alert = new Alert(Alert.AlertType.INFORMATION);
                alert.setTitle("Success");
                alert.setHeaderText("Success");
                alert.setContentText("Successfully added you to event");
                alert.showAndWait();
            } else {
                throw new Exception("Server responded with code: " + response);
            }

        } catch (NullPointerException e) {
            Alert alert = new Alert(Alert.AlertType.ERROR);
            alert.setTitle("Error occured");
            alert.setHeaderText("Oops, error occured");
            alert.setContentText("Please select event or refresh");
            alert.showAndWait();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
