<h1 align="center">edhutil</h1>

---

# Contents
- 1 - [Introduction](#1-introduction)
- 2 - [Script Setup](#2-script-setup)
- 3 - [Future Features](#3-future-features)

---

# 1. Introduction

**edhutil** is a collection of tools that will aid players with various tasks related to playing and discussing Elder Dragon Highlander (EDH).

The software stack includes 3 parts; a Postgres database, an ASP.NET API, and a Discord bot.

---

# 2. Script Setup

The project hasn't been configured to use docker compose yet, so running the bash scripts in the scripts folder sets up the project.
They should be run from the root of the repository in order of prerequisites, database, API, then Discord.
The config templates in Edhutil and DiscordBot should be filled out after running the prerequisites script and before the others.
Make sure to remove the `.template` from the config file names.

---

# 3. Future Features

This is a loose list of planned features.

- Lookup command that takes in a card and printing and responds with an image of that card.
- Deck tracking per player.
- Score tracking per deck and pilot pair.

**Note:** This section doesn't really belong in the README, remove this when more functionality has been added.
