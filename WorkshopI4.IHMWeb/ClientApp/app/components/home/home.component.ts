import { Component, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['../app/app.component.css']
})
export class HomeComponent implements OnInit {
    public terminal: Terminal = new Terminal;
    public terminals: Terminal[] = [];
    public hubConnection: HubConnection;

    ngOnInit(): void {
        let builder = new HubConnectionBuilder();

        // as per setup in the startup.cs
        this.hubConnection = builder.withUrl('/hubs/terminal').build();

        // message coming from the server
        this.hubConnection.on("Send", (message) => {
            this.terminals.push(message);
        });

        // starting the connection
        this.hubConnection.start();
    }
}
export class Terminal {
    id: string
    statut: string
}