import React, { Component } from 'react';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import Home from './components/home/Home';
import ShoppingListForm from './components/shopping-list-form/ShoppingListForm';
import ShoppingList from './components/shopping-list/ShoppingList';
import Content from './components/content/Content';

class App extends Component {

  constructor(props) {
    super(props);
    this.state = {
      input: "",
      itemData: "",
      todos: []
    };
  }

  // set home page input
  setInput = (e) => {
    const newVal = e.target.value;
    this.setState({
      input: newVal,
    });
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

  // delete item
  deleteItem = (id) => {
    const currentValue = [...this.state.todos];
    const newVal = currentValue.filter(item => item.id !== id);
    this.setState({ todos: newVal })
  }

  render() {
    return (
      <div className="container">
        <Router>
          <Switch>
            <Route exact path="/">
              <Home 
                input={this.state.input}
                setInput={this.setInput}
              />
            </Route>
            <Route path="/shopping-list" component={ShoppingListForm}>
              <Content 
                input={this.state.input} 
              />
              <ShoppingListForm
                itemData={this.state.itemData} 
                handleCreate={this.handleCreate}
                dataChange={this.dataChange}
                handleDelete={this.handleDelete}
              />
              <ShoppingList 
                todos={this.state.todos} 
                deleteItem={this.deleteItem} 
                editItem={this.editItem} 
              />
            </Route>
          </Switch>
        </Router>
      </div>
    );
  }
}

export default App;
