Github is available here (for those who decompiled the mod) => https://github.com/MooMoo7661/MooMoos-Yoyo-Revamp
Unlisted video about the inner workings of the mod => https://www.youtube.com/watch?v=dQw4w9WgXcQ

This mod is fully localized in English, Spanish, Russian, and French.
Japanese and Polish will be arriving either with the release of the 1.4.5 version, or sometime soon before / after it.
Any localization errors should be reported to the discord. If possible, please specify what the text should be changed to and why.

Quick Summary of what the mod does:
Fully reworks yoyo bags
Adds special effects for vanilla yoyos
Provides easy ways of creating items that can be used with this mod's systems
Adds many new yoyos + accessories
Crossmod support for TMLAchievements


-= For Modders =-

* How do I add support for my items to be equipped in this mod's accessory slots?

There are 2 ways. The first is making the item inherit one of the various classes in ItemLoader.cs
This file contains multiple "Mod_" classes (example: ModYoyo, ModDrill, etc).
These items will automatically be able to be placed in the respective accessory slot.
If you don't want to make an item inherit something other than ModItem for whatever reason, then refer to the option below.

The second way is by adding the item to the correct bool set in ItemSets.cs
You should do this by default anyways.

Check out AccessorySlots.cs (Content/UI) to see how other slots allow specific items to be put in.
They all have some sort of bool set requirement, or check if the Item.ModItem is Mod_

* How can I add custom yoyo string textures/colors, or localized abilities?
This mod uses MooMooLib, (MooMoo's Yoyo String Lib) to do this.
Inside of the mod, there is 2 dictionaries.
For the texture dictionary, simply give it a texture and an ItemID to key the texture with.
For the color dictionary, give it a Color and an int. I suggest using an int that is not near 0 to avoid mod conflicts.
Keep in mind this mod adds about 10 more colors past the vanilla max which is (I believe) ~27.
You can also use negative numbers, except -1 which just makes the string invisible.

For localized abilities, it's pretty much the same thing. Give it a localized text (or just a set string if you're lazy), and an ItemID to key the text with.
The displaying of the ability is handled by the mod in TooltipModifiers.cs (Content/GlobalClasses).

Some important files to note:
ItemLoader (Content/Utility)
ItemSets (Content/Utility)
DictionaryEntries (Content/Utility)
CombinationsModClass
