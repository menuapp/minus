import React from 'react';
import './App.css';
import Slider from './components/slider/slider';
import ProductService from './Service/productService';
import SlidingPage from './components/slidingPage/slidingPage';

export default class App extends React.Component {
  constructor(props) {
    super(props);
    this.state = { data: [], restaurantName: "agileaction" };

    this.productService = new ProductService();
    this.sendMessage = this.sendMessage.bind(this);
    this.openConnection = this.openConnection.bind(this);
  }

  async componentDidMount() {
    let json = await this.productService.getAll(this.state.restaurantName);
    this.setState({ data: json });
  }

  openConnection() {
    this.socket = new WebSocket("ws://localhost/webservice/api/basket/get");

    this.socket.onopen = () => {
      console.log("Connected...");
      console.log("hello");
    }

    this.socket.onmessage = (event) => {
      console.log(JSON.parse(event.data));
    };
  }

  sendMessage() {
    this.socket.send("hello");
  }

  render() {
    return (
      <div className="App">

        {this.state.data.map((cards) => {
          return (<div className="page container-fluid">
            <SlidingPage cards={cards.products} />
          </div>
          );
        })}

      </div>
    );
  }
}
