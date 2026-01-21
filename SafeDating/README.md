Current Project Status 
 

Except for a few minor details, this game is basically complete. Our game is currently operational. The client wanted to host the game on a website that users could visit and play the game on. So we had to do it in two steps: we hosted the game on itch.io and the website on Squarespace, which has the game embedded in it. Squarespace is a paid platform, which is the responsibility of the client, while itch.io is a free platform

To access the game: 

Itch.io: Safedatingapp by DPL Studios Inc. (itch.io) 

Squarespace: MobileGamePage — DPL Studios Inc. (squarespace.com) (Please Login Squarespace account to view the page. ) 

 The credentials for both and some more accounts are shared in the credential's sections of this document. 

 The client requested that the game be compatible with both mobile and computer devices. Therefore, we provided two versions of the game: one for mobile and one for desktop. Both versions were hosted on itch.io, allowing the client to switch between them on itch.io's Dashboard. 

 How to play the game? 
 

In this game the objective is to teach teenagers how to safely date. The game consists of two modules and a bonus module. The intro module and bonus module are considered one part of the game referred to as "first module" for the rest of the document. Once the user completes the first module then they enter café module referred to as "second module" for the rest of the document. To complete the intro module the user must interact with all the buildings shown glowing and then they are taken to bonus round. 

After interacting with these objects, the user can move to the bonus module in which there are three interactable objects which are café, park, mall. The user must find the object, which is not safe, which is park. Once the user interacts with the park and answers the question then they are asked to go to café to start the final café module. Inside café module, the player must walk to their date which is shining like these building objects. The player then is prompted with options to sit with the date or not sit.  After answering the questions with the date, the end game screen is displayed. 

![image](https://github.com/user-attachments/assets/02bb8120-47a3-4939-8887-c45e27cb4937)
![image](https://github.com/user-attachments/assets/c5eff1cc-ceb7-48a1-bb83-f7ccdcc5619f)
![image](https://github.com/user-attachments/assets/4717152d-8b93-4356-8d63-5e917ae5d0d3)
UI Display Refactoring &Touch Control UI for mobile
 

Our team has fixed the UI overlapping issue and UI display blurriness issue to improve the user experience. We have also added anchors to the UI canvas to ensure consistent display on screens of various sizes, making the game more mobile-friendly. We implemented the touch control UI changes to match our current UI style and made the touch control UI mobile-friendly. 

NPC Animation Changes: 
 

We animated all the NPCs in the game. Each NPC has a body movement animation, and some are programmed to move around the street, making the game more realistic. 

For the purpose of helping the future development team get familiar with the blender and Unity animation system more easily, we have created a series of step-by-step instructional documents to assist. 
Non-Human character new feature: 
 

We have created a guide character named "Sparrow" to help players learn safe dating tips. Sparrow introduces the game rules and background.  

 

We have designed both 2D and 3D versions of the Sparrow character, including animations, UI images, and sound design. These designs allow us to provide feedback to players - for example, when a player answers a question correctly, the Sparrow character will show a spinning animation and provide sound feedback, if player answers wrong, the Sparrow will show a small jumping animation and sound feedback.  
![image](https://github.com/user-attachments/assets/0a6c942e-bf24-4bda-bbe3-ae495538af23)

Text Animation feature: 
 

To provide a better user experience for feedback, we have implemented a text animation feature. When a player answers a question, they will either gain or lose points. An animation will appear around the DPL dollar sign UI in the top left to indicate the addition or deduction of points. 
![image](https://github.com/user-attachments/assets/19281657-dd97-45df-86cf-65e0d9b91457)


