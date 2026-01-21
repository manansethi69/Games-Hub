# Games‑Hub

Games‑Hub is a collection of Unity‑based educational and action titles built across multiple client and course projects.  
This repository currently includes **Knights Divide**, **Safe Dating Game**, and **Mi'kmaw Kina'matnewey**, each with its own Unity project and documentation.[file:191]

---

## Repository Structure

- `KnightsDivide/` – 2D action‑RPG with dual protagonists, bosses, and progression systems.[file:191]  
- `SafeDatingGame/` (DPL Studios client project) – Serious game teaching safe dating practices, deployed for web and mobile via itch.io and Squarespace.  
- `mi_kmaw-kina_matnewey/` – Side‑scrolling educational game that teaches Mi’kmaq vocabulary through boss battles and word–image matching.[file:191]

Each subfolder contains its own Unity project, assets, and (when applicable) PDFs with final reports or presentations.

---

## Knights Divide

**Knights Divide** is a 2D action‑RPG built in Unity, featuring five handcrafted levels where players alternate between **Lancelot**, a melee knight with shields and counterattacks, and **Raevyn**, a highly mobile ranged hero with dashes and wall jumps.[file:191]

### Core Features

- Tight combat focused on perfect blocks, counters, dashes, wall jumps, and character‑specific skills.[file:191]  
- Five levels (two for each character plus a final choice level) with unique bosses, lighting setups, and dungeon or dark‑themed layouts.[file:191]  
- RPG‑style progression with ability points earned from enemies and spent on stats like health, attack speed, and cooldown reduction.[file:191]

### Design & Implementation

- Early prototypes used toxic water and moving platforms before scope was narrowed around core combat and encounter design.[file:191]  
- Codebase organized into sprites, tilemaps, prefabs, sounds, scripts, and scenes, with abstract skill classes and collider‑driven hit detection.[file:191]  
- Pixel‑art aesthetic with Unity 2D lighting and a mix of curated asset‑store content and custom art (including a bespoke final boss).[file:191]

> For full details, see `KnightsDivide/Final-Project-Document.pdf` and `KnightsDivide/Presentation.pdf`.[file:191][file:192]

---

## Safe Dating Game (DPL Studios)

A client project for **DPL Studios Inc.**: an educational game that teaches teenagers about safe dating through interactive scenarios set in a stylized city and café environment.

### Deployment & Platforms

- Game builds hosted on **itch.io**, with separate **desktop** and **mobile** versions so the client can switch between them in the itch.io dashboard.  
- Marketing / client‑facing website built in **Squarespace**, embedding the game from itch.io; Squarespace hosting is managed by the client while itch.io remains free.

### Gameplay Overview

- Two main modules plus a bonus section: an intro + bonus round (first module) and a café scenario (second module).  
- Players explore glowing buildings, progress to a bonus scene (café, park, mall), identify unsafe choices (e.g., park), then complete a final café conversation with their date leading to an end‑screen.

### UX, UI, and Feature Work

- Refactored UI to remove overlap and blurriness, added proper anchors so interfaces scale correctly across phone and desktop resolutions.  
- Implemented mobile‑friendly on‑screen controls matching the game’s visual style, including touch input for movement and interactions.  
- Animated all NPCs with idle and movement cycles, and documented animation workflows in Blender and Unity for future teams.  
- Introduced **“Sparrow”**, a 2D/3D guide character with animations, UI sprites, and sounds that reacts to correct and incorrect answers.  
- Added DPL‑dollar **text and icon feedback animations** for gaining or losing points, improving clarity of player progress.

---

## Mi'kmaw Kina'matnewey

**Mi'kmaw Kina'matnewey** is a 2D side‑scrolling educational game designed to support learning of Mi’kmaq vocabulary.[file:191]

### Description

- Built in Unity (C#) and targeted at mobile deployment, with gameplay reminiscent of classic Mario or Sonic‑style platformers.[file:191]  
- Players control a character who matches Mi’kmaq words provided by a boss to the correct images, gaining coins for correct answers and losing lives for mistakes.[file:191]  
- After three incorrect answers the player must restart, reinforcing vocabulary accuracy while maintaining challenge.[file:191]

### Visuals & Boss Encounters

- Horizontal scrolling levels with enemies, platforms, and interactive elements themed around Mi’kmaq cultural content.[file:191]  
- Boss battles require correctly matching words to images to defeat the boss, blending quiz mechanics with action gameplay.[file:191]
