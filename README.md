# legacy-chatfilter

# How does it work?
The program will load up https://www.guildwarslegacy.com/chatfilter.php (code is available in the repository).
This will generate the MD5-hash of the currently live ChatFilter.ini file (also in the repository).

If the local file does not match the hash of the remote file, or if it can't be found, it will download the latest version from Guild Wars Legacy.

Once that's done, the game will be launched - either by Gw.lnk (if it can be found), which allows you to pre-enter your credentials in the shortcut using the command line launcher options OR Gw.exe if Gw.lnk can't be found.
