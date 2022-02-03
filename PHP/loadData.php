<?php
require_once "$_SERVER[DOCUMENT_ROOT]/OnlineClicker/UserTokenManager.php";
$userTokenManager = new UserTokenManager();

//$_POST["userSaveToken"] = "KK2Mrm";

if (!empty($_POST["userSaveToken"])) {
    $user_save_token = $_POST["userSaveToken"];

    $user_save_data = $userTokenManager->getUserSaveData($user_save_token);
    if (empty($user_save_data)) {
        echo "Invalide code.";
    } else {
        echo $user_save_data["user_score"];
        echo " ";
        echo $user_save_data["user_click_level"];
        echo " ";
        echo $user_save_data["user_auto_gatherer_level"];
    }   
} else {
    echo "An error has occurred.";
}
