<?php
abstract class DatabaseManager
{
  private $db;

  public function __construct()
  {
    $host = 'localhost';
    $name = 'onlineclicker';
    $user = 'root';
    $password = '';
    try {
      $this->db = new PDO('mysql:host=' . $host . ';dbname=' . $name . ';charset=utf8', $user, $password);
      $this->db->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    } catch (PDOException $e) {
      die('Connection error: ' . $e->getMessage());
    }
  }

  public function getDb()
  {
    return $this->db;
  }
}
