using FontAwesome.Sharp;
using System;

namespace Corretora
{
    class Emoji
    {
        static private IconChar[] emojis = new IconChar[] { IconChar.Smile, IconChar.SmileBeam, IconChar.SmileWink, IconChar.Laugh, IconChar.LaughSquint, IconChar.LaughWink, IconChar.Grin, IconChar.GrinAlt, IconChar.GrinBeam, IconChar.GrinBeamSweat, IconChar.GrinHearts, IconChar.GrinSquint, IconChar.GrinSquintTears, IconChar.GrinStars, IconChar.GrinTears, IconChar.GrinTongue, IconChar.GrinTongueSquint, IconChar.GrinTongueWink, IconChar.GrinWink };

        static public IconChar emoji()
        {
            Random random = new Random();
            int x = random.Next(0, 18);
            return emojis[x];
        }
    }
}
