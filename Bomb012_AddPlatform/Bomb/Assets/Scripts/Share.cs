using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace Assets.Scripts
{
    static class Share
    {  // use the flags to do not let each collider of bullets counts more than one time to decrese the health
        //for Sphere original bomb 
        public static Boolean check_01 = false;
        public static Boolean check_Sphere2 = false;
        public static Boolean check_Sphere3 = false;
        //If one of objects destroy the flag will be true then the second object will be destroy 
        public static Boolean destroy_enemy = false;
        public static Boolean destroy_player = false;
        // 
        public static Boolean destroy_flag1 = false;
        public static Boolean destroy_flag2 = false;
        public static Boolean destroy_flag3 = false;
        // Enemy list objects Destroy
       public static Boolean ListEnemyDestroy = false;
        //Player List objects Destroy
        public static Boolean ListPlayerDestroy = false;
        //Move button pressed
        public static bool moveButton = false;
        //Attack button pressed
        public static bool attackButton = false;
    }
}
