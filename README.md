## Introduction
This solution shows how to create a modal/popup in Blazor that can be dragged and dropped without having to use a third party Blazor library. I am using a bootstrap modal and client side javascript to drag and drop the modal.

I developed this modal as part of my Quotodoro application, which can be found on https://quotodoro.com
The first version of Quotodoro used React, bootstrap and React-DnD for drag and drop functionality. React-DnD was difficult to implement. I couldn't use it for the modals/popup. Once I re-platformed to Blazor it became a lot easier to add the drag and drop functionality as I wanted it.

I already had a good base when I re-platformed the code from React to Blazor Server. The components used bootstrap, which I could re-use. It was easy to convert the React components to Blazor and there was no need to use a third-party Blazor library. 

It was surprisingly easy to add drag and drop functionality to my Blazor components, compared to the work that I had to do for the React components to become draggable.

Before I dive deep into the details, I have to mention that this solution started as a Blazor Server project. I suspect that the code will react differently when used in a Blazor WebAssembly project. To keep the example code simple and accessible, I have used a standard Blazor project and made as few changes as possible to demonstrate how a Modal can be made draggable. However, in the App.razor.cs I explicity use the InteractiverServerRenderMode. This is more or less the same as what was called Blazor Server in the past.


## Problem
Blazor doesn't have a built-in component for a modal/popup. Using bootstrap makes it possible to easily create a modal/pop, but the modal cannot be dragged and dropped. 
For first time users of a bootstrap modal: the modal is not only the visible popup. It also includes a layer/div the overlaps the entire web page.

Developing the draggable modal for Blazor Server I had to overcome a few problems:

- Blazor Server works on the server. I had to make sure that it wouldn't call the clientside javascript continuously during a movement of the mouse.
- Dragging should only be activated while clicking the title bar of the modal, otherwise it wouldn't be possible to select text in the editboxes without the modal being dragged
- The code should be added to a Blazor layout. The Blazor layour will be the base of more specific modals. Look at ModalLayout.cs and ProjectModal.cs


## Architecture
wwwroot/css
Css classes needed to give the modal the desired UI, for example the transparent drop shadow

wwwroot/javascript
Bootstrap and jquery javascripts and the main script draggable.js

Components/Modals
The modal layout and the project modal that uses it

## Solution
The most important code is:

File: wwwroot/javascript/draggable.js
This is the client side javascript that calculates and sets the new position of the Modal. I have used vanilla javascript to make sure that it will always work. 

File: Components/Modals/ModalLayout.razor and ModalLayout.razor.cs
This is the layout used to drag the Modals. It stored the start position when dragging starts and it calls the javascript to recalculate the new position when dragging stops.

## How it works
For a better understanding of using layouts I refer to the Blazor documentation. 
In short, on line 19 in the ModalLayout.razor @ChildContent is replaced with the ProjectModal.
Everything within the ModalLayout tags in the ProjectModal.razor is used as @ChildContent

Looking at the code, you can see that the title and the dragging is handled in the ModalLayout. 
- Javascript ondragover and ondragstart is being handled.
- bootstrap classes starting with modal-
- @ondragstart and @ondragend being handled
- Several draggables being filled

It was a bit of trial and error to find the right values for all the attributes. The ondragover and ondragstart are needed to make it possible to activate dragging only when the title is clicked. You can play with the values a bit to discover for yourself. The most important part is in DragStart and DragEnd methods

When a Blazor component is draggable, it can be freely moved around. However it doesn't keep its position when dragging stops. 

Once the dragging ends the DragEnd function is called, which calls the client side javascript. It calculates the new position of the component and uses this to set the new position of the component. Without this last step the component would stay at its original position.

## Remark
During dragging the modal is half transparent. I think this is done by bootstrap. I haven't spend time on changing this, because it found it useful.
I have left the functionality to toggle the help in the modal/popup as well.

Ed Schimmel

Byte217
https://byte217.com