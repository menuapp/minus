"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
require("./navigationBar.css");
var React = require("react");
var ReactDOM = require("react-dom");
var NavigationBar = /** @class */ (function (_super) {
    __extends(NavigationBar, _super);
    function NavigationBar(props) {
        return _super.call(this, props) || this;
    }
    NavigationBar.prototype.render = function () {
        return (React.createElement("nav", null,
            React.createElement("li", null, "Menus"),
            React.createElement("li", null, "Restaurants"),
            React.createElement("li", null, "Products"),
            React.createElement("li", null, "Contact")));
    };
    return NavigationBar;
}(React.Component));
exports.NavigationBar = NavigationBar;
//# sourceMappingURL=navigationBar.js.map