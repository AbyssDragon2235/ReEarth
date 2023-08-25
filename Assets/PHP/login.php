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

    $namecheckquery = "SELECT username, salt, hash FROM User WHERE username='" . $username . "';";

    $namecheck = mysqli_query($con, $namecheckquery) or die("101: name check failed");

    if (mysqli_num_rows($namecheck) != 1)
    {
        echo "302: name already exists more than once or doesn't exist";
        exit();
    }

    $existinginfo = mysqli_fetch_assoc($namecheck);
    $salt = $existinginfo["salt"];
    $hash = $existinginfo["hash"];

    $loginghash = crypt($password, $salt);
    if ($hash != $loginhash)
    {
        echo "303: Password does not match the correct password";
        exit();
    }

    echo "0";
?>