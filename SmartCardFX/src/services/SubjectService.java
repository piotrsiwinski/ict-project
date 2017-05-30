package services;

import com.google.gson.Gson;
import smarcard.Models.Event;

import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.Scanner;

/**
 * Created by Piotrek on 18.05.2017.
 */
public class SubjectService {
    private String URL = "http://localhost:5001/api/";

    public URL CreateURL(String url) {
        URL result = null;
        try {
            result = new URL(url);
        } catch (MalformedURLException e) {
            e.printStackTrace();
        }

        return result;
    }

    public String getSubjects() {
        try {
            String result = getResponseFromHttpUrl(this.CreateURL(this.URL + "Class"));
            return result;

        } catch (IOException e) {
            e.printStackTrace();
        }
        return "";
    }

    public int addEventToStudent(Event event) throws Exception {
        Gson gson = new Gson();
        String json = gson.toJson(event);

        //TODO: Insert right url
        URL url = new URL(this.URL + "Events");
        HttpURLConnection connection = (HttpURLConnection) url.openConnection();

        connection.setDoOutput(true);
        connection.setInstanceFollowRedirects(false);
        connection.setRequestMethod("POST");
        connection.setRequestProperty("Content-Type", "application/json");
        connection.setRequestProperty("charset", "utf-8");
        connection.setRequestProperty("Content-Length", Integer.toString(json.length()));
        connection.setUseCaches(false);
        connection.getOutputStream().write(json.getBytes());

        OutputStreamWriter wr = new OutputStreamWriter(connection.getOutputStream());
        wr.write(json.toString());
        wr.flush();
        wr.close();

        int res = connection.getResponseCode();

        connection.disconnect();
        return res;

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
