using System;
using System.Collections.Generic;


namespace SysProg
{
    class Program
    {
        public static Random _random = new Random();
        static void Main(string[] args) {
            Room Room = new Room(1000, 1000);
            foreach (Enemy enemy in Room.enemies) {
                enemy.takeDamage(RandomNumber(1, 6));
            }
        }
        public static int RandomNumber(int min, int max) {
            return _random.Next(min, max);
        }
    }
    class Room
    {
        public List<Enemy> enemies = new List<Enemy>();
        private Tile[][] Tilemap;

        public Room(int width, int height) {
            for (int i = 0; i < Tilemap.Length; i++) {
                Tilemap[i] = new Tile[i];
            }
            Tilemap = new Tile[width + height][];
            for (int i = 0; i < Tilemap.Length; i++) {
                enemies.Add(new Enemy());
            }
        }
    }
    class Enemy
    {
        public float Health = 20;
        public void takeDamage(int damageAmount) {
            Health -= damageAmount;
            Console.WriteLine($"The enemy took {damageAmount} damage and has {Health} health left");
        }
    }

    class Tile
    {
    }
}