package smarcard.Models;

import lombok.Data;
import com.google.gson.annotations.SerializedName;

/**
 * Created by Piotrek on 18.05.2017.
 */
@Data
public class Subject {
    @SerializedName("Id")
    public int Id;

    @SerializedName("Teacher_ID")
    public String teacherId;

    @SerializedName("Teacher_Name")
    public String teacherName;

    @SerializedName("Teacher_Surname")
    public String teacherSuername;

    @SerializedName("Subject_Name")
    public String subjectName;


}
