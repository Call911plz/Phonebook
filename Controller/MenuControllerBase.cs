
using Spectre.Console;

class MenuControllerBase
{

    public async Task StartAsync()
    {
        bool exit = false;

        await OnReady();

        while (exit != true)
        {
            await OnStart();

            exit = await HandleUserInput();

            if (exit != true)
            {
                AnsiConsole.MarkupLine("[bold grey]Press Enter to continue[/]");
                Console.Read();
            }
        }
    }

    protected virtual Task<bool> HandleUserInput() { return Task.FromResult(false); }

    // Work class may do once on ready
    protected virtual Task OnReady() { return Task.CompletedTask; }
    
    // Work class may do at the start of each loop
    protected virtual Task OnStart() 
    {
        Console.Clear();
        return Task.CompletedTask; 
    }
}