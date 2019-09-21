import React from "react";
import ReactDOM from "react-dom";
import { Provider } from "react-redux";
import App from "./App";
import configureStore from "./state/store";
import * as serviceWorker from "./serviceWorker";
import "../node_modules/bootstrap/dist/css/bootstrap.css";
import { StyleRoot } from "radium";

  
const store = configureStore({});

ReactDOM.render(
    <StyleRoot>
      <Provider store={store}>
        <App />
      </Provider>
    </StyleRoot>,
  document.getElementById("root")
);

serviceWorker.unregister();
