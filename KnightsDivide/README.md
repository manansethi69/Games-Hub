# Knights Divide

Knights Divide is a 2D action‑RPG built in Unity, featuring five handcrafted levels where players alternate between two distinct heroes: **Lancelot**, a melee knight with shields and counterattacks, and **Raevyn**, a highly mobile ranged fighter with dashes and wall jumps.[file:191]

---

## Game Overview

- Navigate maze‑like dungeons and caverns, defeat enemies, and face a unique boss at the end of each level.[file:191]  
- Alternate between Lancelot and Raevyn every level, culminating in a final boss encounter at the highest level.[file:191]  
- Progression emphasizes tight combat, character skills, and level layouts tuned to each hero’s playstyle.[file:191]

If you want to see the full report and build artifacts, check the `Final-Project-Document.pdf` and `Presentation.pdf` in this repository.[file:191][file:192]

---

## Core Mechanics

- **Distinct characters**  
  - Lancelot: melee‑focused, can block, perform perfect blocks, and counterattack.[file:191]  
  - Raevyn: ranged‑focused, can dash, perform perfect dashes, and wall jump; cannot block.[file:191]

- **Skills & progression**  
  - Each completed level grants a unique skill that can be used in later stages.[file:191]  
  - Level‑up system awards ability points for defeating enemies, which can be spent on stats such as health, attack speed, and cooldown reduction in a dedicated stats menu.[file:191]

- **Level structure**  
  - 5 levels total: 2 for Lancelot, 2 for Raevyn, and a final level where the player chooses a character.[file:191]  
  - Dungeon and dark‑themed variants, with lighting used to guide players and create atmosphere.[file:191]

---

## SnapShots

<img width="730" height="371" alt="Screenshot 2024-12-01 145123" src="https://github.com/user-attachments/assets/640f6860-b0a9-4639-8bee-c956ec52e3a8" />
<img width="509" height="567" alt="image" src="https://github.com/user-attachments/assets/7c44f06b-b4b3-4426-935d-7202d8aa432b" />
<img width="873" height="270" alt="image" src="https://github.com/user-attachments/assets/b1f55581-f7e4-4460-8533-a30bfdfae6b4" />
<img width="895" height="725" alt="image" src="https://github.com/user-attachments/assets/1842a058-2a11-4318-9e65-57e4b502f2cd" />

---

## Design & Implementation

- **Level and combat design**  
  - Early prototypes experimented with toxic water, moving platforms, and other traversal elements before the scope was narrowed to focus on core combat.[file:191]  
  - Later levels were developed in parallel, each pairing enemies and bosses with the current character’s abilities.[file:191]

- **Code structure**  
  - Organized into sprites, tilemaps, prefabs, sounds, scripts, and scenes within Unity.[file:191]  
  - Abstract skill scripts define a common interface; character‑specific and boss scripts inherit and implement unique behaviors.[file:191]  
  - Combat relies on 2D colliders, animation events, and health scripts to synchronize hits with visual feedback.[file:191]

- **Art & audio**  
  - Pixel‑art aesthetic with distinct silhouettes and animations for each character and enemy.[file:191]  
  - Dungeon tiles, props, and environmental pieces are composed to create cohesive layouts; lighting is crucial in later, darker levels.[file:191]  
  - Most assets come from free Unity Asset Store packs and online libraries, while the final boss was custom‑designed by the team.[file:191]

---

## Testing, Challenges, and Bugs

- **Testing**  
  - Continuous playtesting of maps to ensure navigation, enemy behavior, and collisions worked as intended for both characters.[file:191]  
  - Issues such as inconsistent audio triggers for Raevyn and animation conflicts during merges were identified and iteratively fixed.[file:191]

- **Technical challenges**  
  - Coordinating multi‑person development led to frequent merge conflicts, mitigated through structured branching and reviews in Plastic SCM.[file:191]  
  - Asset bloat and performance problems were addressed by compressing large assets and pruning unused resources.[file:191]

- **Known issues**  
  - A persistent compiler error tied to moving platforms occasionally blocked builds despite successful editor runs.[file:191]  
  - A few minor visual bugs remain but do not significantly impact gameplay.[file:191]

---

## Future Work

Planned or potential improvements include:[file:191]

- Additional biomes (e.g., fiery caverns, icy ruins, mystical forests) with new hazards and enemy types.  
- Expanded narrative through backstory, dialogue, collectibles, and cutscenes.  
- Accessibility and polish features such as difficulty options, a more robust tutorial, and localization.  

Despite scope reductions around story and visual progression, the final game delivers responsive combat, diverse enemies, and level designs that emphasize the strengths of each character.[file:191]
