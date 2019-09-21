import React, { Component } from "react";
import { connect } from "react-redux";
import ProductGrid from "./components/ProductGrid";
import CartTable from "./components/CartTable";
import { fetchProducts } from "./state/product/actions";
import { fetchCart, addToCart } from "./state/cart/actions";
import "./App.css";
import LoadingScreen from "react-loading-screen";
import FirebaseSocial from "./components/Social/FirebaseSocial";
import AboutUs from "./components/AboutUs";
import Rodal from "rodal";
import "./rodal.css";
import logo from "./images/logo.png";
import Stepper from "./Stepper";
import Paginations from "./components/stepper/Paginations";
import CardReactFormContainer from "card-react";
import "card-react/lib/card.css";
import { SectionsContainer, Section } from "react-fullpage";
import BahsisKutusu from './components/bahsiskutusu/BahsisKutusu';
import Modal from "react-responsive-modal";

export const StepperContext = React.createContext();

class StepperProvider extends Component {
  state = {
    stage: 1
  };
  render() {
    return (
      <StepperContext.Provider
        value={{
          stage: this.state.stage,
          handleClick: () =>
            this.setState({
              stage: this.state.stage + 1
            })
        }}
      >
        {this.props.children}
      </StepperContext.Provider>
    );
  }
}

class App extends Component {
  componentWillMount() {
    this.props.fetchProducts();
    this.props.fetchCart();
  }

  addToCart = product => {
    this.props.addToCart(product._id, 1);
  };

  constructor(props) {
    super(props);
    this.state = {
      total: 100,
      loading: true,
      count: 1,
      visible: false,
      open: false
    };
  }

  onOpenModal = () => {
    this.setState({ open: true });
  };

  onCloseModal = () => {
    this.setState({ open: false });
  };

  show() {
    this.setState({ visible: true });
  }

  hide() {
    this.setState({ visible: false });
  }

  componentDidMount() {
    setTimeout(() => this.setState({ loading: false }), 2700);
  }


  render() {
    const { isProductsLoading, products, cart } = this.props;

    const { loading } = this.state;

    const { open } = this.state;

    const styles = {
      fontFamily: "sans-serif",
      textAlign: "center"
    };

    const yiyeceklerBaslik = {
      fontSize: "35px",
      textAlign: "center",
      color: "lightblue",
      fontFamily: "fantasy",
      fontWeight: "bold",
      letterSpacing: "-1px",
      border: "7px dotted orange",
      borderRightColor: "red",
      borderLeftColor: "red",
      padding: "15px"
    };
    const iceceklerBaslik = {
      fontSize: "35px",
      textAlign: "center",
      color: "lightblue",
      fontFamily: "fantasy",
      fontWeight: "bold",
      letterSpacing: "-1px",
      border: "7px dotted orange",
      borderRightColor: "red",
      borderLeftColor: "red",
      padding: "15px"
    };
    const tatlilarBaslik = {
      fontSize: "35px",
      textAlign: "center",
      color: "lightblue",
      fontFamily: "fantasy",
      fontWeight: "bold",
      letterSpacing: "-1px",
      border: "7px dotted orange",
      borderRightColor: "red",
      borderLeftColor: "red",
      padding: "15px"
    };
    const odemeBaslik = {
      fontSize: "35px",
      textAlign: "center",
      color: "lightblue",
      fontFamily: "fantasy",
      fontWeight: "bold",
      letterSpacing: "-1px",
      border: "7px dotted orange",
      borderRightColor: "red",
      borderLeftColor: "red",
      padding: "15px"
    };
    // const params = {
    //   slidesPerView: 1,
    //   loop: false,
    //   pagination: {
    //     el: ".swiper-pagination",
    //     clickable: true,
    //     dynamicBullets: true
    //   },
    //   navigation: {
    //     nextEl: ".swiper-button-next",
    //     prevEl: ".swiper-button-prev"
    //   }
    // };

    if (isProductsLoading) {
      return <h2>Yükleniyor..</h2>;
    }

    let options = {
      sectionClassName: "section",
      anchors: ["anasayfa", "yiyecekler", "icecekler", "tatlilar", "odeme"],
      scrollBar: false,
      navigation: true,
      verticalAlign: false,
      sectionPaddingTop: "0",
      sectionPaddingBottom: "0",
      arrowNavigation: true,
      delay: 500,
      handleMouseWheel: true
    };

    return (
      <div>
        <div className="parentDiv">
          <button className="sepet-icon" onClick={this.show.bind(this)} />
          <Rodal visible={this.state.visible} onClose={this.hide.bind(this)}>
            <CartTable cart={cart} />
          </Rodal>
        </div>
        <div>
          <LoadingScreen
            loading={loading}
            bgColor="#34526f"
            spinnerColor="#9ee5f8"
            textColor="#dd9201"
            logoSrc={logo}
            text="ALTYUM PROJESINE HOŞGELDİN"
          />
        </div>

        <SectionsContainer {...options}>
          <Section className="slide0">
            <div className="rwd-table">
              <StepperProvider>
                <Stepper stage={1}>
                  {/* <Stepper.Progress>
                      <Stepper.Stage num={1} />
                      <Stepper.Stage num={2} />
                      <Stepper.Stage num={3} />
                    </Stepper.Progress> */}
                  <div
                    style={{
                      flex: 1,
                      display: "flex",
                      flexDirection: "column"
                    }}
                  >
                    {/* <Stepper.Header title="Hoşgeldiniz" /> */}
                    <Stepper.Progress>
                      <Stepper.Stage num={1} />
                      <Stepper.Stage num={2} />
                      <Stepper.Stage num={3} />
                    </Stepper.Progress>
                    <Stepper.Steps>
                      <Stepper.Step num={1} text={<AboutUs />} />
                      <Stepper.Step num={2} text={<FirebaseSocial />} />
                      <Stepper.Step num={3} text={<Paginations />} />
                    </Stepper.Steps>
                    {/* <Stepper.Footer title="Stepper Footer" /> */}
                  </div>
                </Stepper>
              </StepperProvider>
            </div>
          </Section>
          <Section className="slide1">
            <h1 style={yiyeceklerBaslik}>Yiyecekler</h1>
            <ProductGrid products={products} addToCart={this.addToCart} />
          </Section>
          <Section className="slide2">
            <h1 style={iceceklerBaslik}>İcecekler</h1>
            <ProductGrid products={products} addToCart={this.addToCart} />
          </Section>
          <Section className="slide3">
            <h1 style={tatlilarBaslik}>Tatlilar</h1>
            <ProductGrid products={products} addToCart={this.addToCart} />
          </Section>
          <Section className="slide4">
            <h1 style={odemeBaslik}>Odeme</h1>
            <CardReactFormContainer
              container="card-wrapper"
              formInputsNames={{
                number: "CCnumber",
                expiry: "CCexpiry",
                cvc: "CCcvc",
                name: "CCname"
              }}
              initialValues={{
                number: "",
                cvc: "",
                expiry: "",
                name: ""
              }}
              classes={{
                valid: "valid-input",
                invalid: "invalid-input"
              }}
              formatting={true}
            >
              <form className="odeme-form">
                <div id="card-wrapper" />
                <br />
                <div className="input-styles">
                  <input placeholder="TAM ADI" type="text" name="CCname" />
                  <br />
                  <br />
                  <input
                    placeholder="Kart Numarası"
                    type="text"
                    name="CCnumber"
                  />
                  <br />
                  <br />
                  <input placeholder="AY/YIL" type="text" name="CCexpiry" />
                  <br />
                  <br />
                  <input placeholder="CVC" type="text" name="CCcvc" />
                  <br />
                  <br />
                </div>
                <br />
                <button>Ödemeyi Tamamla</button> veya{" "}
                <button>Sonra Tamamla</button>
              </form>
              <div style={styles}>
                <button onClick={this.onOpenModal}>Tip Box</button>
                <Modal open={open} onClose={this.onCloseModal} center>
                  <h2>Her zaman bekleriz</h2>
                  <BahsisKutusu />
                </Modal>
              </div>
            </CardReactFormContainer>
          </Section>
        </SectionsContainer>
      </div>
    );
  }
}

const getProductById = (products, productId) =>
  products.find(p => p._id === productId);

const populateCartItems = (cart, products) => ({
  ...cart,
  items: cart.items.map(item => ({
    ...item,
    product: getProductById(products, item.productId)
  }))
});

const mapStateToProps = state => ({
  isProductsLoading: state.product.isLoading,
  products: state.product.products,
  cart: populateCartItems(state.cart.cart, state.product.products)
});

const mapDispatchToProps = {
  fetchProducts,
  fetchCart,
  addToCart
};

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(App);
