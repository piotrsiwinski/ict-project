package smarcard.Models;

import com.google.gson.annotations.SerializedName;
import lombok.Data;

import java.sql.Date;
import java.util.List;

/**
 * Created by Piotrek on 18.05.2017.
 */
@Data
public class Subject {
    @SerializedName("Id")
    public int id;

    @SerializedName("StartDateTime")
    public Date startDateTime;

    @SerializedName("CourseName")
    public String courseName;

    @SerializedName("Lecturers")
    List<String> lecturers;

    public String describeSubject() {
        StringBuilder builder = new StringBuilder();
        for(String l : lecturers){
            builder.append(l);
            builder.append(" ");
        }
        return courseName + " | " + builder.toString() + " | " + startDateTime.toString();
    }
}
