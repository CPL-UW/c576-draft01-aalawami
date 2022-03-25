using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MonSpawn {

    public string Name { get; set; }
    public int Health { get; set; }
    
    public MonSpawn(string name, int health)
    {
        this.Name = name;
        this.Health = health;
        
    }

    public MonSpawn(string name)
    {
        this.Name = name;
        this.Health = Random.Range(0, 12);
        
    }


    public int GetHealth()
    {
        return this.Health;
    }


}  
    

