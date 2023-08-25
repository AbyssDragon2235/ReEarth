<?php

    $con = new mysqli('db5014103255.hosting-data.io', 'dbu5428831', 'LegendsNeverDie2235', 'dbs11761050');

    //check connection happening
    if(mysqli_connect_errno())
    {
        echo "201: connection failed"; //error code #1 = connection failed
        exit();
    }

    $username = $_POST["name"];
    $password = $_POST["password"];

    //check if name exists
    $namecheckquery = "SELECT username FROM User WHERE username='" . $username . "';";

    $namecheck = mysqli_query($con, $namecheckquery) or die("101: name check failed");

    if (mysqli_num_rows($namecheck) > 0)
    {
        echo "301: name already exists";
        exit();
    }

    //add user to table
    $salt = "\$5\$rounds=5000\$" . "steamedhams" . $username . "\$";
    $hash = crypt($password, $salt);

    $insertuserquery = "INSERT INTO User (username, hash, salt) VALUES ('" . $username . "', '" . $hash . "', '" . $salt . "');";
    mysqli_query($con, $insertuserquery) or die("102: insert player query failed");

    echo("0");


?>