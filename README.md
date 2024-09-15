## Introduction

This solution shows how to create a draggable modal/popup in Blazor without having to use a third party Blazor library. I am using a bootstrap modal and client side javascript to move the modal.

I developed this modal as part of Quotodoro, which can be found on https://quotodoro.com
To keep the code simple and accessible, I have used a standard project and made as few changes as possible to demonstrate how a Modal can be made draggable.


## Problem
Developing the draggable modal for Blazor Server I had to overcome a few problems:

- Blazor Server works on the server. I had to make sure that it would call the client continuously during a movement of the mouse.- 
- Dragging should only be activated while clicking the title of the modal, otherwise it wouldn't be possible to click an editbox without the modal being dragged
- The modal should be a layout, that could be used as a base for a specific modal. Look at ModalLayout.cs and ProjectModal.cs


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
This is the client side javascript that calculates and sets the new position of the Modal

File: Components/Modals/ModalLayout.razor and ModalLayout.razor.cs
This is the layout used to drag the Modals. It stored the start position when dragging start and it calls the javascript to recalculate the new position.

## How it works

For a better understanding of using layouts I refer to the Blazor documentation. 
In short, on line 19 in the ModalLayout.razor @ChildContent is replaced with the ProjectModal.
Everything within the ModalLayout tags in the ProjectModal.razor is used as @ChildContet

Looking at the code, you can see that the title and the dragging is handled in the ModalLayout. 
Javascript ondragover and ondragstart is being handled.
bootstrap classes starting with modal-
@ondragstart and @ondragend being handled
Several draggables being filled

I wrote this code a few years ago. It was a bit of trial and error. I don't know exactly how it works anymore. The ondragover and ondragstart are needed to make it possible to activate dragging only when the title is clicked. Yoiu can play with the values a bit to discover for yourself. The most important part is in DragStart and DragEnd.

When a component is draggable, it can be freely moved around. Once the dragging ends the DragEnd function is called, which calls the client side javascript, calculates the new position of the component and set the position of the component. Without this last step the component would stay at its original position.

## Remark
During dragging the modal is half transparent. I think this is caused by bootstrap and I haven't spend time on changing this.
I have left the fucntionality to toggle the help in the modal as well.

Ed Schimmel
Byte217