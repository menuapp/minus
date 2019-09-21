import React from "react";
import Radium from "radium";

const popAnimation = Radium.keyframes({
  "50%": { transform: "scale(1.2)" }
});
const styles = {
  base: {
    fontFamily: "quicksand",
    fontSize: "16px",
    width: "100px",
    fontWeight: "500",
    background: "#6bada7",
    borderRadius: "4px",
    border: "0px",
    color: "white",
    cursor: "pointer",
    padding: "5px 15px 5px 15px",
    ":hover": {
      animation: "x 0.8s ease",
      animationName: popAnimation
    },
    ":focus": {
      outline: "none"
    },
    ":disabled": {
      background: "#ccc",
      color: "white",
      cursor: "not-allowed"
    }
  },
  block: {
    fontSize: "20px",
    color: "red"
  }
};

class Button extends React.Component {
  handleClick() {
    this.props.click() || (this.props.click()) 
  }
  
  render() {
    return (
      <button
        type={this.props.type}
        onClick={this.handleClick.bind(this)}
        disabled={this.props.disabled}
        style={[
          styles.base,
          this.props.block && styles.block,
          this.props.customStyle ? { background: this.props.customStyle } : ""
        ]}
      >
        {this.props.children}
      </button>
    );
  }
}
export default Radium(Button);
