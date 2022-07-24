# TextFilter

David Milne 24/07/2022

## Project Structure

 - TextFilter base project contains Program.cs.
 - Common project contains extensions, interfaces and constants.
 - Infrastructure project contains file reader class and default text resource.
 - Service project contains business logic.

## How to use
Download project and run locally. No other configuration should be required as long as visual studio is installed on the machine.

The prompt will ask you to enter a file path or just hit return to operate on the default text.

## Logging
I have added a simple logger to log warnings and errors to the console. 

## Things to think about for a production release
**RegEx**
I'm no expert in regex so I'm a bit uneasy about the expression I used to replace words. It has passed all my test cases but it would be good to explore further.

**Metrics/Reporting**
Any production app should probably collect these using something like Prometheus. However it felt out of scope for the time given.

**How to define a word?**
It doesn't take much imagination to think of text that would test or break the simple parameters I have used. i.e. hyphenated, or abbreviated or even strings like .netcore which is treated for all intents as a word.

**Clean up Punctuation**
I followed the instructions given however it would be nice to clean up "orphaned" punctuation marks afterwards.
> Written with [StackEdit](https://stackedit.io/).

