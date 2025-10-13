# Card Contest Grid Generator

## Setup

1. Install the latest release.
2. Extract it to a folder, than within that folder do the following.
3. Create a folder called `Cards`.
4. Create a folder called `Grids`.
5. Create a text file in `Cards` called `Socials.txt`
6. Ensure `backgroundBase.png` exists and is exactly `3840x2160`.
7. Ensure `Grids-1.png` exists, what it is doesn't matter it should be overwritten after being loaded its just a fallback for failure.

## How to Utilize.

1. Within `Cards` add folders for each of your participants `Display Name`, note `$` will be replaced with a `/` by default.
2. Within that folder place the entry's 3 can be placed in maximum, they must be called `Entry_1.png`, `Entry_2.png`, `Entry_3.png`.
3. Ensure the cards are of a ratio off of `414x579`, this is to make the Bilinear affect and the resize not make the card funky, when adjusting the card's size go off the longer unit on the card and put that in the ratio via something like aseprite, than set the other unit from the updated ratio to the other unit in the card.
4. Within `Socials.txt` add each entry it must be in the form of `Display Name;Social(s)`.
5. If you want to change the `backgroundBase.png` feel free but note that the text color is `ffc800` so the background must be able to show it. [I'll add a way to change the text in the lower right later on.]
6. Run the Executable.
7. Once it finishes the resulting Grids will be found in the `Grids` folder.