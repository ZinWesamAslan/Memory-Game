# Memory Game  
Windows Forms Application | C#

---

## About the Game  
A visual memory testing game. A grid of 25 squares is displayed. The system lights up a certain number of squares (configurable) in a distinct color (non‑black) for a specific duration. After the lights turn off, you must click the squares that were lit, in the correct order. Each correct attempt increases your score.

---

## Key Features  

- Interactive Grid: 25 squares (5×5) – the number of lit squares per round is adjustable in settings.  
- Configurable Timers:  
  - Overall game duration.  
  - How long each square stays lit.  
- Score Storage: Final player scores are saved after each session (basic storage, ready for future display).  
- Customizable Interface:  
  - Choose a profile picture.  
  - Change the game’s secondary color.  
- Dynamic Main Menu: Hover over any decorative square in the main menu – it smoothly switches between black and the secondary color.

---

## How to Play  

1. From the main menu, click Start to begin a new round.  
2. A set number of squares (as defined in Settings) will light up in the secondary color for a short time.  
3. After they turn off, click on the squares you remember being lit.  
4. If you select the correct squares, your Score increases and a new round begins (with a new pattern or same count, depending on logic).  
5. The game ends when the total game timer runs out or after a defined number of mistakes (according to your implementation).  
6. At the end, the final score is saved in a basic storage system.

---

## Main Menu Buttons  

| Button       | Function                                                                 |
|--------------|--------------------------------------------------------------------------|
| Start    | Starts a new game with the current settings.                             |
| Score    | (Placeholder for score history – to be fully implemented later.)         |
| Settings | Opens the settings window to modify:                                     |
|              | - Profile picture                                                        |
|              | - secondary color                                             |
|              | - Number of squares to light up per round                                |
|              | - Total game time                                                        |
|              | - Duration each square stays lit                                         |
| Exit     | Closes the application.                                                  |

---

## Technical Details  

- Language: C#  
- Framework: Windows Forms  
- Storage: Simple file‑based or in‑memory storage (basic implementation; can be extended to display high scores).  
- Main Menu Hover Effect: Several decorative squares in the main menu change color between black and the selected secondary color when the mouse hovers over them.

---

## Developer Notes  

- The code is designed to be expandable: adding new lighting patterns or a high‑score display is straightforward.  
- The current basic storage does not yet display the saved scores, but it is ready to be connected to a database or a list view.  
- All settings are stored during the current session; persistent settings can be added if needed.

---

Test your memory and have fun!
