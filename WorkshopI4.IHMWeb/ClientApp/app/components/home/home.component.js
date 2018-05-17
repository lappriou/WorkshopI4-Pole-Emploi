"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var signalr_1 = require("@aspnet/signalr");
var HomeComponent = /** @class */ (function () {
    function HomeComponent() {
        this.terminal = new Terminal;
        this.terminals = [];
    }
    HomeComponent.prototype.ngOnInit = function () {
        var _this = this;
        var builder = new signalr_1.HubConnectionBuilder();
        // as per setup in the startup.cs
        this.hubConnection = builder.withUrl('/hubs/terminal').build();
        // message coming from the server
        this.hubConnection.on("Send", function (message) {
            _this.terminals.push(message);
        });
        // starting the connection
        this.hubConnection.start();
    };
    HomeComponent = __decorate([
        core_1.Component({
            selector: 'home',
            templateUrl: './home.component.html',
            styleUrls: ['../app/app.component.css']
        })
    ], HomeComponent);
    return HomeComponent;
}());
exports.HomeComponent = HomeComponent;
var Terminal = /** @class */ (function () {
    function Terminal() {
    }
    return Terminal;
}());
exports.Terminal = Terminal;
//# sourceMappingURL=home.component.js.map