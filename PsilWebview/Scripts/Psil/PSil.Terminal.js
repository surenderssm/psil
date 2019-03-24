if (typeof (PSil) == 'undefined')
    PSil = {};

// Manage the Psil Terminal
PSil.Terminal = function () {

    var processPsil = function (command, term) {
        term.push(function (command, term) {
            if (command == 'help') {
                term.echo(psilHelpCommands);
            } else if (command == 'ping') {
                term.echo('pong');
            } else {
                //  term.echo('unknown command ' + command);
                var successCallBack = function (data) {
                    data = JSON.parse(data);
                    term.echo(String(data.result));
                };

                var errorCallback = function () {
                    term.echo("Oops ! Something wrong with our System");
                };
                term.echo(PSil.Evaluate(command, successCallBack, errorCallback));
            }
        }, {
            prompt: 'psil> ',
            name: 'psil'
        });
    };
    var psilHelpCommands = "Try commands like following \n (+ 1 2) or ( bind x 12) ( + x 1) or ( * 5 6) ";

    var terminalHelp = "sample commands are help,js,start,psil,terminal \n Type start to get Psil terminal And See the Magic \n" + psilHelpCommands;


    var initTerminalFeature = function (command, term) {
        if (command == 'terminal') {
            //TODO: Surender : TO add commands to make terminal more interactive like color change and other things
        } else if (command == "help")
        {
            term.echo(terminalHelp)
        }
        else if (String(command).toLowerCase() == 'start' || String(command).toLowerCase() == 'psil') {
            processPsil(command, term);
        } else if (command == "js") {
            // Javascript Interpreter just for the fun to avoid Console 
            term.push(function (command, term) {
                var result = window.eval(command);
                if (result != undefined) {
                    term.echo(String(result));
                }
            }, {
                name: 'js',
                prompt: 'js> '
            });
        }
    };
    var welcomeMessage = "Welcome To Psil Interpreter Terminal ! Use help to see available commands or check out PSIL commands \n";
    return {
        InitTerminal: function () {
            $('#psilInter').terminal(initTerminalFeature, {
                greetings: welcomeMessage,
                prompt: '**type start to get started**> ',
                name: 'psil',
                onBlur: function () {
                    // prevent loosing focus
                    return false;
                }
            });
        }
    }
}();

$(document).ready(function () {
    //Initialize the Terminal
    PSil.Terminal.InitTerminal();
});

