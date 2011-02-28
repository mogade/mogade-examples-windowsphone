# Not Complete #

Work on this example has just begun. It is not complete.

# What's Working #

 * Setting up the mogade library
 * Submitting a score
 * Logging application starts
 * Logging error

# Where to Start #
The `Code\MogadeHelper.cs` file contains all our our mogade-specific configuration. This is where you'll provide your own key/secret and other information.
The `Leaderboards` enum and the `_leaderboardLookup` are just there to make it so you don't have to copy that leaderboard id throughout your code.

You'll want to look at the source code of `Pages\App.xaml.cs` which holds the intance of our mogade object. 
The instance is initialized in the `Application_Launching` and `Application_Activated` of the same class.

Pages that need to access the mogade client can inherit from `Pages\BasePage` - which really just exposes the property defined in `App`. The nice thing about
this approach is that it keeps the not-so-nice casting and tight coupling somewhat hidden from view. Now, to make your pages inherit from this type rather than
their default `PhoneApplicationPage`, you'll want to change both their `xaml.cs` file and the `xaml` file. Check out the `GameOver.xaml` for an example.

# In your Own Project #
The assemblies that this example uses (in the root `References` folder) might not be the most up to date. You should grab the latest from the [GitHub](https://github.com/mogade/mogade-windowsphone) page.

You'll also want to change the `MogadeProvider` to use your `gamekey` and `secret`. Finally, you'll want to change the leaderboard id used in `GameOver.xaml.cs` with your leaderboard id.

# One Last Thing #

The secret and key distributed with this example is a **real** game residing on testing.mogade.com. This is a test environment and it isn't necessarily reliable. 