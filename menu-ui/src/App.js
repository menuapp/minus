import React from 'react';
import './App.css';
import Slider from './components/slider/slider';
import ProductService from './Service/productService';
import SlidingPage from './components/slidingPage/slidingPage';
import NavigationBar from './components/navigationBar/navigationBar';
import CategoryBar from './components/categoryBar/categoryBar';
import { Route, Switch } from 'react-router-dom';
import SignIn from './components/signIn/signIn';
import ItemDetails from './components/itemDetails/itemDetails';

export default class App extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      data: [],
      restaurantName: 'agileaction',
      currentCategoryIndex: 0
    };

    this.productService = new ProductService();
    this.sendMessage = this.sendMessage.bind(this);
    this.openConnection = this.openConnection.bind(this);
    this.updateCategoryItems = this.updateCategoryItems.bind(this);
  }

  async componentDidMount() {
    let json = await this.productService.getAll(this.state.restaurantName);
    this.setState({ data: json });
  }

  openConnection() {
    this.socket = new WebSocket('ws://localhost/webservice/connect');

    this.socket.onopen = () => {
      console.log('Connected...');
      console.log('hello');
    };

    this.socket.onmessage = event => {
      console.log(JSON.parse(event.data));
      // console.log("order came...");
    };
  }

  sendMessage() {
    this.socket.send('hello');
  }

  updateCategoryItems(index) {
    this.setState({ currentCategoryIndex: index });
  }

  render() {
    return (
      <div className="App">
        <Switch>
          <Route path="/itemDetails/:id">
            <ItemDetails data={this.state.data} />
          </Route>
          <Route path="/signin">
            <SignIn />
          </Route>
          <Route path="/register"></Route>
          <Route path="/">
            <NavigationBar />
            <CategoryBar
              updateCategoryItems={this.updateCategoryItems}
              categoryName={this.state.data.map(category => category.name)}
            />
            <Switch>
              <Route>
                {this.state.data.map((cards, index) => {
                  if (index === this.state.currentCategoryIndex) {
                    return (
                      <div
                        key={index}
                        data-key={index}
                        className="page container-fluid"
                      >
                        <SlidingPage cards={cards.products} />
                      </div>
                    );
                  }
                })}
              </Route>
            </Switch>
          </Route>
        </Switch>
      </div>
    );
  }
}
