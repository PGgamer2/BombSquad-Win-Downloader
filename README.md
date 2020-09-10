# BombSquad Windows Downloader
This project started when I searched for the first time a BombSquad download link for Windows.
I had to do some researches to find the official link from the [ballistica server](https://files.ballistica.net/bombsquad/builds/).

This program simply installs BombSquad (or the BombSquad Server) from the official download link.

### Important used libraries
- DotNetZip to extract the downloaded .zip files.
- Markdig to convert markdown to html (for the changelog file).
- ILMerge to *merge* the libraries into one executable.
- Windows Script Host Object Model to create shortcuts to the desktop.