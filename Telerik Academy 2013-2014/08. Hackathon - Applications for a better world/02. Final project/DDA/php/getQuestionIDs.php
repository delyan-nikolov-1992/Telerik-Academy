<?php
    $connection = mysqli_connect("localhost", "root", "", "dda_game");

    if (mysqli_connect_errno()) {
      echo "Failed to connect to MySQL: " . mysqli_connect_error();
    }

    $questionType = $_POST['questionType'];

    $query = "SELECT id FROM questions WHERE t_id=".$questionType;

    $databaseResult = mysqli_query($connection, $query);
    $result = array();

    while($row = mysqli_fetch_array($databaseResult)) {
        array_push($result, $row['id']);
    }

    mysqli_close($connection);

    echo json_encode($result);
?>