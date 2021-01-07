<form action="" method="post" enctype="multipart/form-data">
    <input type="file" name="file">
    <button type="submit">UPLOAD</button>
</form>

<?php

if(!empty($_FILES['file'])) {
    move_uploaded_file($_FILES['file']['tmp_name'], "/var/www/html/upload/" . $_FILES['file']['name']);
    
}

?>