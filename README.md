# D&amp;D 5e Character/Game tracking application
This application was originally planned to supplement paper for keeping track of players and encounters in the campaign I am leading. I have expanded upon the original design and added various features as I went. I am currently at a place where I am satisfied with its current state and may not do any more significant changes.

The system gives a DM the ability to create eahc player character and add proficiencies, equipment, spells, and experience as they progress. This list is then serialized in to a bin file and can be loaded later.

There are a few tools added to the main form which allow a DM to roll dice, view all of the characters and their stats, and track combat as it happens.

Dice rolling is handled through a static class. At some point I was using extension methods but after reading some best practices blogs and considering the opinions out there, I decided to move them to a static class and not as extensions of int and string.

Equipment is a base class with a few child classes (Armor, Weapon).

LINQ is used to split up the lists and put only certain items in certain dropdowns. It is also used in the dynamically created character tracker window. Creating this page was a lot of work but the end result and the tricks I learned while doing it are very valuable.

This is by far the largest and most complicated C# project I've worked on so far. My other major project guiWords is large but most of that is SQL rather than C#. What I learned working on this I applied to guiWords later. I have begun a Unity project which is also using some parts of the design from this project (character, equipment, etc).
