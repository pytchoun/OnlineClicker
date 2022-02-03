<?php
require_once "$_SERVER[DOCUMENT_ROOT]/OnlineClicker/UserTokenManager.php";
$userTokenManager = new UserTokenManager();

/*$_POST["score"] = 1;
$_POST["clickLevel"] = 2;
$_POST["autoGathererLevel"] = 3;*/

if (isset($_POST["score"]) && isset($_POST["clickLevel"]) && isset($_POST["autoGathererLevel"])) {
    $score = $_POST["score"];
    $click_level = $_POST["clickLevel"];
    $auto_gatherer_level = $_POST["autoGathererLevel"];

    $token = $userTokenManager->generateUserToken($score, $click_level, $auto_gatherer_level);
    //$userTokenManager->groundSave($token, $tile_index, $is_free, $tree_gameobject);
    echo $token;
} else {
    echo "An error has occurred.";
}
