<?php
include('config.php');

if(isset($_GET['password'])) {
    if($_GET['password'] == $password) {
        if(isset($_GET['action'])) {
            $action = $_GET['action'];
            if($action == "download") {
                if(isset($_GET['name'])) {
                    $file_name = $_GET['name'];            
                    $full_path = $file_directory . $file_name;
                    if(file_exists($full_path)) {
                        header('Content-Type: application/octet-stream');
                        header("Content-Transfer-Encoding: Binary"); 
                        header("Content-disposition: attachment; filename=\"" . $file_name . "\"");
                        flush();
                        readfile($full_path); 
                    }
                    else {
                        die();
                    }
                }
                
            }
            elseif ($action == "getfiles") {
                if ($handle = opendir($file_directory)) {
                    while (false !== ($entry = readdir($handle))) {
                        if ($entry != "." && $entry != "..") {
                            echo $entry . "|";
                        }
                    }
                    closedir($file_directory);
                }
            }
        }
    }
    else {
        die();
    }
}
?>