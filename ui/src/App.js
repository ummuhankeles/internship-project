import React, { Component } from 'react';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import Home from './components/home/Home';
import ShoppingListForm from './components/shopping-list-form/ShoppingListForm';

class App extends Component {

  constructor(props) {
    super(props);
    this.state = {
      itemData: "",
      todos: [],
    };
  }

  // add item
  handleCreate = () => {
    const currentValue = this.state.itemData;
    if(this.state.itemData !== "") {
    const itemData = {
      id: Math.random(),
      content: currentValue,
    }
    this.setState(
      {
        todos: [...this.state.todos, itemData]
      }
      );
    } else {
      alert("Please, enter input !")
    }
  }

  // delete state and textarea box
  handleDelete = () => {
    if(this.state.itemData === "") {
      alert("Input box already empty !");
    }
    this.setState({
      itemData: "",
    });
  }

  // set item change
  dataChange = (e) => {
    const newVal = e.target.value;
    this.setState({
      itemData: newVal,
    });
  }

  render() {
    return (
      <div className="container">
        <Router>
          <Switch>
            <Route exact path="/">
              <Home/>
            </Route>
            <Route path="/shopping-list" component={ShoppingListForm}>
              <ShoppingListForm 
                itemData={this.state.itemData} 
                handleCreate={this.handleCreate}
                dataChange={this.dataChange}
                handleDelete={this.handleDelete}
              />
            </Route>
          </Switch>
        </Router>
      </div>
    );
  }
}

export default App;
