module com.example.lab1ambal {
    requires javafx.controls;
    requires javafx.fxml;



    opens com.example.lab1ambal to javafx.fxml;
    exports com.example.lab1ambal;
}