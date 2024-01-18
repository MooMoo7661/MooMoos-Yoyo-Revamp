using Terraria.Localization;

namespace CombinationsMod.Content.Keybindings
{
    public class KeybindInputs
    {
        /// <summary>
        /// Takes in a keybind, and returns it as it would be proper. Example: "Mouse2" returns "Right Click"
        /// </summary>
        /// <param name="key">Internal name of the keybind. Example: "LeftShift", or "Mouse3"</param>
        /// <returns></returns>
        public static string GetKeybindDisplayName(string key)
        {
            if (LanguageManager.Instance.ActiveCulture.Name != "en-US") // hardcoded language check cuz I do not feel like using more localization for this.
            {
                return key;
            }

            string result = key switch
            {
                "Mouse1" => "Left Click",
                "Mouse2" => "Right Click",
                "Mouse3" => "Middle Click",
                "LeftShift" => "Left Shift",
                "LeftControl" => "Left Control",
                "LeftAlt" => "Left Alt",
                "CapsLock" => "Caps Lock",
                "RightAlt" => "Right Alt",
                "RightShift" => "Right Shift",
                "RightControl" => "Right Control",

                "OemPlus" => "+",
                "OemPipe" => "\\",
                "OemTilde" => "`",
                "OemPeriod" => ".",
                "OemQuotes" => "\"",
                "OemSemicolon" => ";",
                "OemComma" => ",",
                "OemOpenBrackets" => "[",
                "OemCloseBrackets" => "]",
                "OemMinus" => "-",
                "OemQuestion" => "?",

                "PageDown" => "Page Down",
                "PageUp" => "Page Up",

                "NumLock" => "Num Lock",
                "NumPad0" => "Num Pad 0",
                "NumPad1" => "Num Pad 1",
                "NumPad2" => "Num Pad 2",
                "NumPad3" => "Num Pad 3",
                "NumPad4" => "Num Pad 4",
                "NumPad5" => "Num Pad 5",
                "NumPad6" => "Num Pad 6",
                "NumPad7" => "Num Pad 7",
                "NumPad8" => "Num Pad 8",
                "NumPad9" => "Num Pad 9",

                "Add" => "+",
                "Subtract" => "-",
                "Multiply" => "*",
                "Divide" => "/",

                "D1" => "1",
                "D2" => "2",
                "D3" => "3",
                "D4" => "4",
                "D5" => "5",
                "D6" => "6",
                "D7" => "7",
                "D8" => "8",
                "D9" => "9",
                "D0" => "0",
                _ => key
            };

            return result;
        }
    }
}
