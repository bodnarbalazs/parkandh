<?php
    $place=file_get_contents("php://input");
    echo json_encode($place);
?>