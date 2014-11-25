using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardDemo
{
    static class AsciiModels
    {
        private static string[] _MilleniumFalcon = new string[] {
                @"              c==o                      ",
                @"            _/____\_                    ",
                @"     _.,--'"" ||^ || ""`z._               ",
                @"    /_/^ ___\||  || _/o\ ""`-._          ",
                @"  _/  ]. L_| || .||  \_/_  . _`--._     ",
                @" /_~7  _ . "" ||. || /] \ ]. (_)  . ""`--.",
                @"|__7~.(_)_ []|+--+|/____T_____________L|",
                @"|__|  _^(_) /^   __\____ _   _|         ",
                @"|__| (_){_) J ]K{__ L___ _   _]         ",
                @"|__| . _(_) \v     /__________|________ ",
                @"l__l_ (_). []|+-+-<\^   L  . _   - ---L|",
                @" \__\    __. ||^l  \Y] /_]  (_) .  _,--'",
                @"   \~_]  L_| || .\ .\\/~.    _,--'""     ",
                @"    \_\ . __/||  |\  \`-+-<'""           ",
                @"      ""`---._|J__L|X o~~|[\\            ",
                @"             \____/ \___|[//            ",
                @"              `--'   `--+-'             "};


        public static string[] MilleniumFalcon { get { return _MilleniumFalcon; } }


        private static string[] _EnemyShip = new string[] {
                @" /  _  \ ",
                @"|-=(_)=-|", 
                @" \     / "};

        public static string[] EnemyShip { get { return _EnemyShip; } }


        private static string[] _Car = new string[] {
                @"      ____        ",      
                @" ____//_]|________",      
                @"(o _ |  -|   _  o|",      
                @" `(_)-------(_)--'"};

        public static string[] Car { get { return _Car; } }


        private static string[] _Helicopter = new string[] {
                @"  ___________",
                @"     _,Z__   ",
                @"X====)59\_\  ",     
                @"     \___ _) ",
                @"    --`--`--'"};

        public static string[] Helicopter { get { return _Helicopter; } }


        private static string[] _Plane = new string[] {
                @"           ,-.   ",
                @" _,.      /  /   ",
                @"; \____,-==-._  )",
                @"//_    `----' {+>",
                @"`  `'--/  /-'`(  ",
                @"      /  /       ",
                @"      `='        "};

        public static string[] Plane { get { return _Plane; } }


    }


}
