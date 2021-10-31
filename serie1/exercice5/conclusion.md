## String est immuable

"String objects are immutable: they cannot be changed after they have been created. All of the String methods and C# operators that appear to modify a string actually return the results in a new string object."

source : [lien](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/#:~:text=String%20objects%20are%20immutable%3A%20they,in%20a%20new%20string%20object.)

Aussi, il est préférable d'utiliser un StringBuilder de manière générale si l'on souhaite changer la string : 

"If the String methods do not provide the functionality that you must have to modify individual characters in a string, you can use a StringBuilder object to modify the individual chars "in-place", and then create a new string to store the results by using the StringBuilder methods."

