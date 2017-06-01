package smarcard.Models;

import com.google.gson.annotations.SerializedName;
import lombok.AllArgsConstructor;
import lombok.Data;


@Data
@AllArgsConstructor
public class Event {
    @SerializedName("StudentId")
    private String studentId;

    @SerializedName("ClassId")
    private int subjectId;
}
