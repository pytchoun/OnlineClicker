<?php
require_once "$_SERVER[DOCUMENT_ROOT]/OnlineClicker/DatabaseManager.php";

class UserTokenManager extends DatabaseManager
{
    public function generateRandomString($length = 6) {
      $characters = '0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ';
      $charactersLength = strlen($characters);
      $randomString = '';
      for ($i = 0; $i < $length; $i++) {
          $randomString .= $characters[rand(0, $charactersLength - 1)];
      }
      return $randomString;
  }

    // Generate a user token
    public function generateUserToken($user_score, $user_click_level, $user_auto_gatherer_level)
    {
      // Generate token
      //$length = 3;
      //$token = bin2hex(random_bytes($length));
      $token =  $this->generateRandomString(6);
  
      $query = $this->getDb()->prepare('INSERT INTO user_save (user_score, user_click_level, user_auto_gatherer_level, user_save_token) VALUES (:user_score, :user_click_level, :user_auto_gatherer_level, :user_save_token)');
      $query->bindParam(':user_score', $user_score);
      $query->bindParam(':user_click_level', $user_click_level);
      $query->bindParam(':user_auto_gatherer_level', $user_auto_gatherer_level);
      $query->bindParam(':user_save_token', $token);
      $query->execute();
  
      return $token;
    }

    // Get user save data
    public function getUserSaveData($user_save_token)
    {
      $query = $this->getDb()->prepare('SELECT * FROM user_save WHERE user_save_token=:user_save_token');
      $query->bindParam(':user_save_token', $user_save_token);
      $query->execute();
      $user_data = $query->fetch();

      return $user_data;
    }

    // Generate a user token
    public function groundSave($user_save_token, $tile_index, $is_free, $tree_gameobject = null)
    {  
      $query = $this->getDb()->prepare('INSERT INTO ground_save (user_save_token, tile_index, is_free, tree_gameobject) VALUES (:user_save_token, :tile_index, :is_free, :tree_gameobject)');
      $query->bindParam(':user_save_token', $user_save_token);
      $query->bindParam(':tile_index', $tile_index);
      $query->bindParam(':is_free', $is_free);
      $query->bindParam(':tree_gameobject', $tree_gameobject);
      $query->execute();
    }

     // Get ground save data
     public function getGroundSaveData($user_save_token)
     {
       $query = $this->getDb()->prepare('SELECT * FROM ground_save WHERE user_save_token=:user_save_token');
       $query->bindParam(':user_save_token', $user_save_token);
       $query->execute();
       $ground_data = $query->fetchAll();
 
       return $ground_data;
     }
}
