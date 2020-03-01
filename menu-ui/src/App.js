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
      products: [],
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

    let products = [];
    json.forEach(category => {
      products.push(...category.products);
    });
    this.setState({ data: json, products: products });
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
        <NavigationBar />
        <Switch>
          <Route path="/itemDetails/:id">
            <ItemDetails products={this.state.products || []} />
          </Route>
          <Route path="/signin">
            <SignIn />
          </Route>
          <Route path="/register"></Route>
          <Route path="/">
            <CategoryBar
              updateCategoryItems={this.updateCategoryItems}
              categoryName={this.state.data.map(category => category.name)}
            />
            <SlidingPage
              category={
                (this.state.data[this.state.currentCategoryIndex] || {})
                  .products || []
              }
            />
          </Route>
        </Switch>
      </div>
    );
  }
}
