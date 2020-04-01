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
import Payment from './components/payment/payment';
import OrderStatus from './components/orderStatus/orderStatus';
import orderStates from './Extensions/orderStates';
import Confirm from './components/confirmation/confirmation';

export default class App extends React.Component {
  constructor(props) {
    super(props);

    this.productService = new ProductService();
    this.orderService = new OrderService();
    this.authenticationService = new AuthenticationService();
    this.updateCategoryItems = this.updateCategoryItems.bind(this);
    this.handleClick = this.handleClick.bind(this);
    this.dimBacklight = this.dimBacklight.bind(this);
    this.updateBasket = this.updateBasket.bind(this);
    this.getBasketStatus = this.getBasketStatus.bind(this);
    this.preparingOrder = this.preparingOrder.bind(this);

    this.state = {
      data: [],
      products: [],
      backlightDim: false,
      basket: null,
      basketQuantity: null,
      orderState: null,
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

  listenOrderStatus() {
    this.wSocket = new WebSocket("ws://192.168.1.174:5556/orderstatus?token=" + localStorage.getItem('token'));

    this.wSocket.onopen = (event) => {
      console.log("listening order status for update");
      // this.wSocketTimer = setInterval(() => {
      //   this.wSocket.send("keep alive...");
      // }, 5000);
    };

    this.wSocket.onmessage = (event) => {
      if (event.data == "order delivered") {
        this.delivered();
        this.wSocket.close();
        clearInterval(this.wSocketTimer);
      }

      console.log(event.data);
    }
  }

  preparingOrder() {
    this.setState({
      orderState: orderStates.PREPARING,
    });
    this.listenOrderStatus();
  }

  delivered() {
    this.setState({
      orderState: orderStates.DELIVERED,
    });
  }

  updateCategoryItems(index) {
    this.setState({ currentCategoryIndex: index });
  }

  updateBasket() {
    this.getBasketStatus();
  }

  async getBasketStatus() {
    let basketData = await this.orderService.getBasket();
    if (basketData) {
      let quantities = basketData.orderProducts.map(product => product.quantity);
      let sum = quantities.length > 0 && quantities.reduce(((sum, quantity) => sum += quantity));

      this.setState({
        basket: basketData,
        basketQuantity: sum,
        orderState: basketData.orderStatus
      });
    }
  }

  render() {
    return (
      <div className={"App" + (this.state.backlightDim ? " backlightDim" : "")} onClick={this.handleClick}>
        <NavigationBar basketQuantity={this.state.basketQuantity} clickOutsideNavbar={this.state.clickOutsideNavbar} dimBacklight={this.dimBacklight} />
        <Switch>
          <Route path="/payment">
            <Payment />
          </Route>
          <Route path="/confirmation">
            <Confirm basket={this.state.basket} preparingOrder={this.preparingOrder} />
          </Route>
          <Route path="/itemDetails/:id">
            <ItemDetails products={this.state.products || []} />
          </Route>
          <Route path="/basket">
            <Basket basket={this.state.basket} />
          </Route>
          <Route path="/register">
            <Register />
          </Route>
          <Route path="/signin">
            <SignIn />
          </Route>
          <Route path="/register"></Route>
          <Route path="/">
            <div className="page-container">
              <OrderStatus orderState={this.state.orderState} />
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
            </div>
          </Route>
        </Switch>
      </div>
    );
  }
}
