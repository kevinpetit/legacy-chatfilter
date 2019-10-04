# Guild Wars Legacy: Chat Filter

This is a tool for Guild Wars 1 players. It will fetch a community-updated ChatFilter.ini file, hosted by Guild Wars Legacy.
By using this feature, you will see less gold-spammers in-game.

# How to install it?
Go to releases, grab the latest release. Drop the file in your Guild Wars installation folder.
I suggest creating a shortcut link for this tool, as it will launch Guild Wars automatically after it has downloaded the latest file.

# How does it work?
The program will load up https://www.guildwarslegacy.com/chatfilter.php (code is available in the repository).
This will generate the MD5-hash of the currently live ChatFilter.ini file (also in the repository).

If the local file does not match the hash of the remote file, or if it can't be found, it will download the latest version from Guild Wars Legacy.

Once that's done, the game will be launched - either by Gw.lnk (if it can be found), which allows you to pre-enter your credentials in the shortcut using the command line launcher options OR Gw.exe if Gw.lnk can't be found.

## Server side
There are 3 parts on the server side required to make this work:
1. Place the chatfilter.php file on the server.
2. Make sure that the ChatFilter.ini file is located at the same location.
3. Run a cronjob that will retrieve this file at a regular interval: */1 * * * * cd /srv/www/guildwarslegacy.com/public_html/; curl https://raw.githubusercontent.com/kevinpetit/legacy-chatfilter/master/ChatFilter.ini > ChatFilter.ini

Should you want to change this, you'll need to change the URL in the client as well.
