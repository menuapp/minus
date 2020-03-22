import React from 'react';
import './App.css';
import Slider from './components/slider/slider';
import ProductService from './Service/productService';
import SlidingPage from './components/slidingPage/slidingPage';
import NavigationBar from './components/navigationBar/navigationBar';
import CategoryBar from './components/categoryBar/categoryBar';
import { Route, Switch, Redirect } from 'react-router-dom';
import SignIn from './components/signIn/signIn';
import ItemDetails from './components/itemDetails/itemDetails';
import Register from './components/register/register';
import Basket from './components/basket/basket';
import AuthenticationService from './Service/authenticationService';
import OrderService from './Service/orderService';

export default class App extends React.Component {
  constructor(props) {
    super(props);

    this.productService = new ProductService();
    this.orderService = new OrderService();
    this.authenticationService = new AuthenticationService();
    this.sendMessage = this.sendMessage.bind(this);
    this.openConnection = this.openConnection.bind(this);
    this.updateCategoryItems = this.updateCategoryItems.bind(this);
    this.handleClick = this.handleClick.bind(this);
    this.dimBacklight = this.dimBacklight.bind(this);
    this.updateBasket = this.updateBasket.bind(this);
    this.getBasketStatus = this.getBasketStatus.bind(this);

    this.state = {
      data: [],
      products: [],
      backlightDim: false,
      basketQuantity: null,
      clickOutsideNavbar: true,
      restaurantName: 'agileaction',
      currentCategoryIndex: 0
    };
  }

  handleClick() {
    this.setState({ clickOutsideNavbar: true, backlightDim: false });
  }

  dimBacklight(state) {
    this.setState({ backlightDim: state, clickOutsideNavbar: false });
  }

  async componentDidMount() {
    this.getBasketStatus();

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

  updateBasket() {
    this.setState({ basketQuantity: this.state.basketQuantity + 1 });
  }

  async getBasketStatus() {
    let basket = await this.orderService.getBasket();
    if (basket) {
      let quantities = basket.orderProducts.map(product => product.quantity);
      let sum = quantities.length > 0 && quantities.reduce(((sum, quantity) => sum += quantity));

      this.setState({
        basket: basket,
        basketQuantity: sum
      });
    }

  }

  render() {
    return (
      <div className={"App" + (this.state.backlightDim ? " backlightDim" : "")} onClick={this.handleClick}>
        <NavigationBar basketQuantity={this.state.basketQuantity} clickOutsideNavbar={this.state.clickOutsideNavbar} dimBacklight={this.dimBacklight} />
        <Switch>
          <Route path="/itemDetails/:id">
            <ItemDetails products={this.state.products || []} />
          </Route>
          <Route path="/basket">
            <Basket />
          </Route>
          <Route path="/register">
            <Register />
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
            <SlidingPage updateBasket={this.updateBasket}
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
