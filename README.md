# Card Contest Grid Generator

## Setup

1. Install the latest release.
2. Extract it to a folder, than within that folder do the following.
3. Create a folder called `Cards`.
4. Create a folder called `Grids`.
5. Create a text file in `Cards` called `Socials.txt`
6. Ensure `backgroundBase.png` exists and is exactly `4000x2500`.
7. Ensure `Grids-1.png` exists, what it is doesn't matter it should be overwritten after being loaded its just a fallback for failure.
8. Ensure `Config.txt` exists and that matches the below formatting; 
    ```
    ContestName = Inscryption TCG Contest - November Card Contest 2025
    HAlignment = Right
    Color = {255,200,0,255}
    Position = {3837,2131}
    FontURL = https://github.com/Chaosyr/KamWerksPortraitsAndOtherAssets/raw/refs/heads/main/heavyweight.ttf
    DisplayNameSize = 128
    SocialNameSize = 50
    ContestNameSize = 64
    ```

## How to Utilize

1. Within `Cards` add folders for each of your participants `Display Name`, note `$` will be replaced with a `/` by default.
2. Within that folder place the entry's 3 can be placed in maximum, they must be called `Entry_1.png`, `Entry_2.png`, `Entry_3.png`.
3. Ensure the cards are of a ratio off of `414x579`, this is to make the Bilinear affect and the resize not make the card funky, when adjusting the card's size go off the longer unit on the card and put that in the ratio via something like aseprite, than set the other unit from the updated ratio to the other unit in the card.
4. Within `Socials.txt` add each entry it must be in the form of `Display Name;Social(s)`.
5. If you want to change the `backgroundBase.png` feel free but note that the text color is `ffc800` so the background must be able to show it.
6. If 'Charity' in the config is enabled you will need to create a folder in the root called `Icons`, this contains six files the names and positions will be modifiable in a later update.
    1. Within `Icons` create or add `Fanscryption.png` this will be a `804x418` image and represents the second company name.
    2. Within `Icons` create or add `DMG.png` this will be a `804x418` image and represents the first company name.
    3. Within `Icons` create or add `4thAnniversaryLogo.png` this will be a `1012x559` image and represents the events name.
    4. Within `Icons` create or add `St-Judes-Name.png` this will be a `1012x559` image and represents the charitys name.
    5. Within `Icons` create or add `Inscryption 4 Year Anniversary Fundraiser-donate-qr-8c879829-e6be-4564-bb06-2ca0aec7aade (1).png` this will be a `500x500` image in which is a QR code for getting to the donation page.
    6. Within `Icons` create or add `StJudes.png` this will be a `598x384` image and represents the charitys logo.
7. Run the Executable.
8. Once it finishes the resulting Grids will be found in the `Grids` folder.

## How to Configure

1. Open the `Config.txt` file
2. Set the `ContestName` value after the ` = ` the spaces are required.
3. Set the `HAlignment` value after the ` = ` the spaces are required, and the inputs must be `Center`, `Left`, or `Right`.
4. Set the `Color` value after the ` = ` the spaces are required, the input should follow `{RED,GREEN,BLUE,ALPHA}` replace the word with a Integer value.
5. Set the `Position` value after the ` = ` the spaces are required, the input should follow `{X,Y}` replace the letter with a Integer in the bounds of `3840x2160`, note as with most code values start at `0` and end one unit before the end value.
6. Set the `FontURL` value after the ` = ` the spaces are required, the input must be a valid public link in which would refer to the downloadable file specifically a otf or ttf file, others may work but unsure to be safe stick to those.
7. Set the `XSize` value after the ` = ` the spaces are required, the input should be a integer.
8. If this is a setup for a charity simply add a entry called `Charity = ` and set the value to `true`, it can also be set false but it will always be defaulted to false.
9. Save the file.
10. Run the application, if it doesn't look how you like repeat from step 2.