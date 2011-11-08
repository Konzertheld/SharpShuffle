using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpShuffle
{
    public enum PlayActions
    {
        AddAndPlayNow,
        AddAndPlayNext,
        Add,
        PlayNowUseView,
        PlayNowReplacePlaylist
    }

    public static class Config
    {
        private static Dictionary<ModifierKeys, PlayActions> PlayKeys;

        static Config()
        {
            PlayKeys = new Dictionary<ModifierKeys, PlayActions>();
            PlayKeys[ModifierKeys.None] = PlayActions.AddAndPlayNow;
            PlayKeys[ModifierKeys.Shift] = PlayActions.AddAndPlayNext;
            PlayKeys[ModifierKeys.Alt] = PlayActions.Add;
            PlayKeys[ModifierKeys.Control] = PlayActions.PlayNowUseView;
        }

        public static PlayActions GetPlayAction(ModifierKeys modifier)
        {
            return PlayKeys[modifier];
        }

        public static void SetPlayAction(ModifierKeys modifier, PlayActions action)
        {
            if (modifier != ModifierKeys.Windows)
                PlayKeys[modifier] = action;
        }
    }
}
