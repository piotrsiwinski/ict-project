package services;

import java.io.IOException;
import java.util.Scanner;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.Scanner;

/**
 * Created by Piotrek on 18.05.2017.
 */
public class SubjectService {
    private String URL = "http://localhost:18975/api/";
    public URL CreateURL(String url){
        URL result = null;
        try {
            result = new URL(url);
        } catch (MalformedURLException e) {
            e.printStackTrace();
        }

        return result;
    }

    public String getSubjects(){
        try {
            String result = getResponseFromHttpUrl(this.CreateURL(this.URL + "Subjects"));
            return result;

        } catch (IOException e) {
            e.printStackTrace();
        }
        return "";
    }


    private String getResponseFromHttpUrl(URL url) throws IOException {
        HttpURLConnection urlConnection = (HttpURLConnection) url.openConnection();
        try {
            InputStream in = urlConnection.getInputStream();

            Scanner scanner = new Scanner(in);
            scanner.useDelimiter("\\A");

            boolean hasInput = scanner.hasNext();
            if (hasInput) {
                return scanner.next();
            } else {
                return null;
            }
        } finally {
            urlConnection.disconnect();
        }
    }
}
