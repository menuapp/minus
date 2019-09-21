import { NavigationBar } from './components/navigationBar';

declare var require: any

var React = require('react');
var ReactDOM = require('react-dom');



export class Hello extends React.Component {
    render() {
        return (
            <div>
                <NavigationBar />
                <h1>Welcome to minus</h1>
            </div>
        );
    }
}

ReactDOM.render(<Hello />, document.getElementById('root'));