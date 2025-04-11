using Spectre.Console;

class MainMenuController : MenuControllerBase
{
    protected override Task OnStart()
    {
        Console.Clear();
        
        AnsiConsole.Write(
            new FigletText("Contacts Project")
                .Centered()
                .Color(Color.Orange1)
        );

        return Task.CompletedTask;
    }
    protected override async Task<bool> HandleUserInput()
    {
        MenuEnums.Main userInput = DisplayMenu.MainMenu();
        switch (userInput)
        {
            case MenuEnums.Main.MANAGECONTACTS:
                ContactController contactController = new();
                await contactController.StartAsync();
                break;
            case MenuEnums.Main.MANAGECATEGORY:
                CategoryController categoryController = new();
                await categoryController.StartAsync();
                break;
            case MenuEnums.Main.SENDEMAIL:
                SendEmailMenuController sendEmailMenuController = new();
                await sendEmailMenuController.StartAsync();
                break;
            case MenuEnums.Main.EXIT:
                return true;
        }
        return false;
    }
}