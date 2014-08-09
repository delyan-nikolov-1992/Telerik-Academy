<?php
	$server = 'localhost';
	$username = 'root';
	$database = 'dda_game';
    $connection = mysqli_connect($server, $username, "", $database);

    if (mysqli_connect_errno()) {
      echo "Failed to connect to MySQL: " . mysqli_connect_error();
    }

    $questionId = $_POST['questionId'];
    $result = array();
    $answers = array();
    $counter = 0;
    $query = "SELECT q_text FROM questions WHERE id=".$questionId;
    $databaseResult = mysqli_query($connection, $query);
    $result['question'] = mysqli_fetch_array($databaseResult)['q_text'];
	
    $query = "SELECT a_text, is_correct FROM answers WHERE q_id=".$questionId;
    $databaseResult = mysqli_query($connection, $query);
	
    while ($currentRow = mysqli_fetch_array($databaseResult)) {
        array_push($answers, $currentRow['a_text']);

        if ($currentRow['is_correct'] == '1') {
            $result['correct'] = $counter;
        }

        $counter++;
    }

    $result['answers'] = $answers;
	
	$query = "SELECT text FROM information WHERE q_id=".$questionId;
    $databaseResult = mysqli_query($connection, $query);
    $result['information'] = mysqli_fetch_array($databaseResult)['text'];

    echo json_encode($result);

    mysqli_close($connection);
?>