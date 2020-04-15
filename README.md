# VsToggly

A simple clientside mod that allows to toggle mousebuttons to avoid hurting your finger by having to hold the button for hours.

## Installation
Drop it into your Mods folder. It does not need to be installed on the server to work.

## Usage
Simply press the hotkey named "Toggly Toggly Mouse". This activates the mode and the next mousebutton that you press will be hold down until you press any button on the mouse again. This might be a bit crude and can lead to bad controls if you use it in an item menu etc. but it works for me.


## Config
These are the configuration values:

<code>AbortKeycodes</code>: Keycodes of keys that terminate the mode. At the moment this is just Escape, otherwise the menu does not work that well.

<code>DeactivateWhenMouseClick</code>: If the mode deactivates as soon as you press the mouse a second time. (true|false)

<code>ValidMouseButtons</code>: Which EnumMouseButton-codes the mod considers as valid targets to toggle. At the moment this is left and right.
