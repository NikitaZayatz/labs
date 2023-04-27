package com.example.lab1ambal;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.chart.AreaChart;
import javafx.scene.chart.LineChart;
import javafx.scene.chart.NumberAxis;
import javafx.scene.chart.XYChart;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextArea;
import javafx.scene.control.TextField;
import javafx.scene.paint.Color;

import java.net.URL;
import java.util.ResourceBundle;

public class HelloController {

    @FXML
    private ResourceBundle resources;

    @FXML
    private URL location;

    @FXML
    private TextField Ct_second_TextField;

    @FXML
    private TextField Ct_second_TextField1;

    @FXML
    private TextField N_second_TextField;

    @FXML
    private TextField N_second_TextField1;

    @FXML
    private TextField a_second_TextField;

    @FXML
    private TextField a_second_TextField1;

    @FXML
    private TextArea answer1;

    @FXML
    private LineChart<?, ?> chart;

    @FXML
    private LineChart<?, ?> chart1;

    @FXML
    private TextArea first_answer;

    @FXML
    private Button first_result_buttun;

    @FXML
    private Button first_result_buttun1;

    @FXML
    private TextField from_Ca_second_TextField;

    @FXML
    private TextField from_Ca_second_TextField1;

    @FXML
    private TextField from_a_textField;

    @FXML
    private TextField from_a_textField1;

    @FXML
    private TextField n_textField;

    @FXML
    private TextField n_textField1;

    @FXML
    private LineChart<?, ?> second_chart;

    @FXML
    private LineChart<?, ?> second_chart1;

    @FXML
    private Button second_result_Button;

    @FXML
    private Button second_result_Button1;

    @FXML
    private TextArea second_result_TextArea;

    @FXML
    private TextArea second_result_TextArea1;

    @FXML
    private TextField second_step_textField;

    @FXML
    private TextField second_step_textField1;

    @FXML
    private TextField step_textField;

    @FXML
    private TextField step_textField1;

    @FXML
    private TextField to_CA_second_TextField;

    @FXML
    private TextField to_CA_second_TextField1;

    @FXML
    private TextField to_a_textField;

    @FXML
    private TextField to_a_textField1;

    @FXML
    void second_result_Button1(ActionEvent event) {

        second_chart1.getData().clear();
        float Ct1 = 0f;
        float Ct2 = 0f;
        float a = 0f;
        int n;
        float h;
        float Rc = 0f;
        float C = 0f;
        float Ca = Float.parseFloat(Ct_second_TextField1.getText());
        a = Float.parseFloat(a_second_TextField1.getText());
        h = Float.parseFloat(second_step_textField1.getText());
        Ct1 = Float.parseFloat(from_Ca_second_TextField1.getText());
        Ct2 = Float.parseFloat(to_CA_second_TextField1.getText());
        n = Integer.parseInt(N_second_TextField1.getText());
        XYChart.Series series11 = new XYChart.Series();
        String str5 = "";
        float Ct = Ct1;
        while (Ct <= Ct2)
        {
            C = Ca * Ct;
            Rc = 1 / (a + (1 - a) / n + C);
            str5 += "  Ct = " + Ct + "  R = " + Rc + "\n";
            series11.getData().add(new XYChart.Data(Ct, Rc));
            Ct += h;
        }

        second_result_TextArea1.setText(str5);
        second_chart1.getData().add(series11);
        System.out.println("all work");
        System.out.println(str5);

    }
    @FXML
    void first_result1(ActionEvent event) {
        chart1.getData().clear();
        float a_1 = 0f;
        float a_2 = 0f;
        float n;
        float h;
        float R = 0f;
        float a = 0f;
        h = Float.parseFloat(step_textField1.getText());
        a_1 = Float.parseFloat(from_a_textField1.getText());
        a_2 = Float.parseFloat(to_a_textField1.getText());
        n = Float.parseFloat(n_textField1.getText());
        XYChart.Series series3 = new XYChart.Series();
        /*final NumberAxis xAxis = new NumberAxis(1, 31, 1);
        final NumberAxis yAxis = new NumberAxis();
        chart =
                new AreaChart<Number,Number>(xAxis,yAxis);*/
        String str4 = "";
        while(a_1<=a_2)
        {
            R = 1/(n + (1 - n)/a_1);
            str4 += "  n = " + a_1 + "  R = " + R + "\n";
            series3.getData().add(new XYChart.Data(a_1,R));
            a_1 += h;
        }
        // chart1.getData().clear();
        chart1.getData().add(series3);
        chart1.setVisible(true);
        answer1.setText(str4);

    }
    @FXML
    void second_result_Button(ActionEvent event) {
        second_chart.getData().clear();
        float c_1 = 0f;
        float c_2 = 0f;
        float a = 0f;
        int n;
        float h;
        float Rc = 0f;
        float c = 0f;
        float Ct = Float.parseFloat(Ct_second_TextField.getText());
        a = Float.parseFloat(a_second_TextField.getText());

        h = Float.parseFloat(second_step_textField.getText());
        c_1 =Float.parseFloat(from_Ca_second_TextField.getText());
        c_2 =  Float.parseFloat(to_CA_second_TextField.getText());
        n = Integer.parseInt(N_second_TextField.getText());
        XYChart.Series series1 = new XYChart.Series();
        String str2 = "";
        while (c_1 <= c_2)
        {
            c = Ct*c_1;
            Rc = 1 / (a + (1 - a) / n + c);
            str2 += "  Ca = " + c_1 + "  R = " + Rc + "\n";
            series1.getData().add(new XYChart.Data(Rc, c_1));
            c_1 += h;
        }

        second_result_TextArea.setText(str2);
        second_chart.getData().add(series1);
        System.out.println("all work");
        System.out.println(str2);


























    }
    @FXML
    void first_result(ActionEvent event) {
        chart.getData().clear();
        float a_1 = 0f;
        float a_2 = 0f;
        int n;
        float h;
        float R = 0f;
        float a = 0f;
        h = Float.parseFloat(step_textField.getText());
        a_1 = Float.parseFloat(from_a_textField.getText());
        a_2 = Float.parseFloat(to_a_textField.getText());
        n = Integer.parseInt(n_textField.getText());
        XYChart.Series series = new XYChart.Series();
        /*final NumberAxis xAxis = new NumberAxis(1, 31, 1);
        final NumberAxis yAxis = new NumberAxis();
        chart =
                new AreaChart<Number,Number>(xAxis,yAxis);*/
        String str = "";
        while(a_1<a_2)
        {
            R = 1/(a_1 + (1 - a_1)/n);
            str += "  a = " + a_1 + "  R = " + R + "\n";
            series.getData().add(new XYChart.Data(a_1,R));
            a_1 += h;
        }
        chart.getData().clear();
        chart.getData().add(series);
        chart.setVisible(true);
        first_answer.setText(str);

    }
Color cl = Color.rgb(111,22,33);
    @FXML
    void initialize() {
        chart.setCreateSymbols(false);
        chart.setLegendVisible(false);
        chart.setLegendVisible(false);
        n_textField.setText("10");
        from_a_textField.setText("0");
        to_a_textField.setText("6");
        step_textField.setText("1");
        to_CA_second_TextField.setText("6");
        N_second_TextField.setText("10");
        from_Ca_second_TextField.setText("1");
        second_step_textField.setText("1");
        Ct_second_TextField.setText("4");
        a_second_TextField.setText("5");
    }



}