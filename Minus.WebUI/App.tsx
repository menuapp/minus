declare var require: any

var React = require('react');
var ReactDOM = require('react-dom');

export class Hello extends React.Component {
    render() {
        return (
            
            <h2><h1>Welcome to webUI</h1>werwe</h2>
        );
    }
}

ReactDOM.render(<Hello />, document.getElementById('root'));