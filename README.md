# BombSquad Windows Downloader

**[Download](https://github.com/PGgamer2/BombSquad-Win-Downloader/releases)**

This project started when I searched for a BombSquad download link for Windows.
I had to do some researches to find it from the [ballistica server](https://files.ballistica.net/bombsquad/builds/).

This program simply installs the latest version of BombSquad (or the BombSquad Server) from the official server.

### Important used libraries
- DotNetZip to extract the downloaded .zip files.
- Markdig to convert markdown to html (for the changelog file).
- ILMerge to *merge* the libraries into one executable.
- Windows Script Host Object Model to create shortcuts to the desktop.

You can use `nuget restore` to install the missing packages.