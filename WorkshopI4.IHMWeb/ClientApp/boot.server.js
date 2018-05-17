"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
require("reflect-metadata");
require("zone.js");
require("rxjs/add/operator/first");
var common_1 = require("@angular/common");
var core_1 = require("@angular/core");
var platform_server_1 = require("@angular/platform-server");
var aspnet_prerendering_1 = require("aspnet-prerendering");
var app_server_module_1 = require("./app/app.server.module");
core_1.enableProdMode();
exports.default = aspnet_prerendering_1.createServerRenderer(function (params) {
    var providers = [
        { provide: platform_server_1.INITIAL_CONFIG, useValue: { document: '<app></app>', url: params.url } },
        { provide: common_1.APP_BASE_HREF, useValue: params.baseUrl },
        { provide: 'BASE_URL', useValue: params.origin + params.baseUrl },
    ];
    return platform_server_1.platformDynamicServer(providers).bootstrapModule(app_server_module_1.AppModule).then(function (moduleRef) {
        var appRef = moduleRef.injector.get(core_1.ApplicationRef);
        var state = moduleRef.injector.get(platform_server_1.PlatformState);
        var zone = moduleRef.injector.get(core_1.NgZone);
        return new Promise(function (resolve, reject) {
            zone.onError.subscribe(function (errorInfo) { return reject(errorInfo); });
            appRef.isStable.first(function (isStable) { return isStable; }).subscribe(function () {
                // Because 'onStable' fires before 'onError', we have to delay slightly before
                // completing the request in case there's an error to report
                setImmediate(function () {
                    resolve({
                        html: state.renderToString()
                    });
                    moduleRef.destroy();
                });
            });
        });
    });
});
//# sourceMappingURL=boot.server.js.map