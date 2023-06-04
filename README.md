# HiddenGPT
 
### Secretly interact with OpenAI's API through copy pasting prompts

*  HiddenGPT is a simple C# app that monitors your clipboard and sends it to OpenAI's API when you click the selected hotkey. It then copies the response to your clipboard. This allows you to interact with OpenAI's API without having to leave your browser or editor.

* It is disguised as a simple tray icon with the Netflix logo. It is also completely open source, so you can be sure that it's not doing anything malicious.

## Overview
* [Screenshots](#screenshots)
* [Installation](#installation)
* [Usage](#usage)
* [Context Menu](#context-menu)
* [Settings](#settings)
* [How to setup a proxy server](#how-to-setup-a-proxy-server)

## Screenshots
|Settings|Tray Icon|
|---|---|
| ![Screenshot 1](https://media.discordapp.net/attachments/1081091376101457992/1114952733682847834/FRJ1wBu.png) | ![Screenshot 2](https://media.discordapp.net/attachments/1081091376101457992/1114952831363977246/VuBkSoP.png) |

## Installation
To install HiddenGPT, download the latest release from the [releases page](https://github.com/Zebratic/HiddenGPT/releases). You can then run the executable from anywhere on your computer.

### Run on startup?
1. Press `Win + R` to open the run dialog
2. Type `shell:startup` and press enter
3. Create a shortcut to the HiddenGPT executable in the folder that opened

## Usage
1. Copy a prompt to your clipboard
2. Press the hotkey (Default: `Ctrl + Shift + G`)
3. And that's it! The response will be copied to your clipboard!

## Context Menu
* `Clear Context`: Resets the remembered conversation context
* `Hide`: Permanently hides the tray icon (Need to restart the process to get it back)
* `Exit`: Exits the application

## Settings
* `API Key`: Your OpenAI API key. You can find it [here](https://platform.openai.com/account/api-keys)
* `Request Url`: The OpenAI url to send the request to. (Default: `https://api.openai.com/v1/chat/completions`)
* `Proxy Url`: The proxy url to send the request through. (Default: `https://estate.red/hiddengpt.php`)
* `Model`: The model to use. (Default: `gpt-3.5-turbo`) (You can find a list of models [here](https://platform.openai.com/docs/models))
* `System Msg`: The role that the AI should live into. (Default: `You are the most intelligent person in the world. You can answer any question, however you do not respond to a question you cant answer.`)
* `Max Tokens`: The maximum number of tokens to use. (Default: `100`)
* `Hotkey`: The hotkey to use to send the request. (Default: `Ctrl + Shift + G`)
* `Proxied Requests`: Whether or not to send requests through a proxy. (Default: `true`)
* `Remember Context`: Whether or not to remember the context of the conversation. (Default: `true`)
* `Auto Paste`: Whether or not to automatically paste the response. (Default: `true`)
* `Instant`: Whether or not to type the response instantly or letter by letter. (Default: `false`)

_(You can change any of the settings by double clicking the tray icon)_

## How to setup a proxy server
1. Download the [hiddengpt.php](https://github.com/Zebratic/HiddenGPT/blob/main/hiddengpt.php)
2. Upload it to a web server that runs PHP (I recommend [000webhost](https://www.000webhost.com/) or [Replit](https://replit.com/))
3. Change the `Proxy Url` setting to the url of that point to the file (e.g. `https://example.000webhost.com/hiddengpt.php`)